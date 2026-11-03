using System.Windows;
using System.Threading;
using System.Windows.Controls;
using System.Linq;
using ExplorerTabUtility.UI.Views;
using ExplorerTabUtility.Helpers;
using ExplorerTabUtility.Languages.Manager;

namespace ExplorerTabUtility;

// ReSharper disable once RedundantExtendsListEntry
public partial class App : Application
{
    private Mutex? _mutex;

    protected override void OnStartup(StartupEventArgs e)
    {
        _mutex = new Mutex(true, Constants.MutexId, out var createdNew);

        if (createdNew)
        {
            base.OnStartup(e);
            SetupTooltipBehavior();

            var mainWindow = new MainWindow();
            if (e.Args.Length > 0)
            {
                foreach (var location in e.Args.Where(arg => !string.IsNullOrWhiteSpace(arg)))
                    _ = mainWindow.OpenLocation(location);
            }
            return;
        }

        if (e.Args.Length == 0 || !CommandLineBroker.TrySend(e.Args))
        {
            CustomMessageBox.Show(LangeuageHelper.Instance.LanguageFields.AlreadyRunning, Constants.AppName, icon: MessageBoxImage.Information);
        }

        Shutdown();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _mutex?.Dispose();
        base.OnExit(e);
    }

    private static void SetupTooltipBehavior()
    {
        ToolTipService.ShowDurationProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(3500));
        ToolTipService.InitialShowDelayProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(1700));
        ToolTipService.BetweenShowDelayProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(150));
        ToolTipService.ShowsToolTipOnKeyboardFocusProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(false));
    }
}
