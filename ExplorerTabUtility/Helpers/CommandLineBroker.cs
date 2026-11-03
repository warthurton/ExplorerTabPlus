using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExplorerTabUtility.Helpers;

/// <summary>
/// Forwards command-line locations from secondary launches to the tray instance.
/// </summary>
internal sealed class CommandLineBroker : IDisposable
{
    private const int ConnectTimeoutMs = 400;
    private const int SendAttempts = 5;
    private readonly CancellationTokenSource _shutdown = new();
    private readonly Func<string, Task> _locationHandler;
    private Task? _listenerTask;

    private static string PipeName => $"{Constants.AppName}.CommandLine.{Environment.UserName}";

    public CommandLineBroker(Func<string, Task> locationHandler)
    {
        _locationHandler = locationHandler ?? throw new ArgumentNullException(nameof(locationHandler));
    }

    public void Start()
    {
        _listenerTask ??= ListenAsync();
    }

    public static bool TrySend(IReadOnlyList<string> locations)
    {
        if (locations == null || locations.Count == 0)
            return false;

        for (var attempt = 0; attempt < SendAttempts; attempt++)
        {
            try
            {
                using var client = new NamedPipeClientStream(".", PipeName, PipeDirection.Out, PipeOptions.Asynchronous);
                client.Connect(ConnectTimeoutMs);

                using var writer = new StreamWriter(client, new UTF8Encoding(false), 256, leaveOpen: false)
                {
                    AutoFlush = true
                };

                foreach (var location in locations)
                {
                    if (!string.IsNullOrWhiteSpace(location))
                        writer.WriteLine(location);
                }

                return true;
            }
            catch (TimeoutException)
            {
                Thread.Sleep(100);
            }
            catch (IOException)
            {
                Thread.Sleep(100);
            }
        }

        return false;
    }

    private async Task ListenAsync()
    {
        while (!_shutdown.IsCancellationRequested)
        {
            try
            {
                using var server = new NamedPipeServerStream(
                    PipeName,
                    PipeDirection.In,
                    1,
                    PipeTransmissionMode.Byte,
                    PipeOptions.Asynchronous);

                await server.WaitForConnectionAsync(_shutdown.Token).ConfigureAwait(false);
                using var reader = new StreamReader(server, new UTF8Encoding(false), detectEncodingFromByteOrderMarks: false, bufferSize: 256);

                while (!_shutdown.IsCancellationRequested)
                {
                    var location = await reader.ReadLineAsync().ConfigureAwait(false);
                    if (location == null)
                        break;

                    if (!string.IsNullOrWhiteSpace(location))
                        _ = DispatchAsync(location);
                }
            }
            catch (OperationCanceledException) when (_shutdown.IsCancellationRequested)
            {
                break;
            }
            catch (IOException) when (!_shutdown.IsCancellationRequested)
            {
                await Task.Delay(100, _shutdown.Token).ConfigureAwait(false);
            }
        }
    }

    private async Task DispatchAsync(string location)
    {
        try
        {
            await _locationHandler(location).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Command-line open failed: {ex}");
        }
    }

    public void Dispose()
    {
        _shutdown.Cancel();
        _listenerTask = null;
        _shutdown.Dispose();
    }
}
