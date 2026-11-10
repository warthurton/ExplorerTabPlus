using System;
using System.Reflection;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Controls;
using System.Windows;

namespace ExplorerTabUtility.UI.Views;

// ReSharper disable once RedundantExtendsListEntry
public partial class AboutView : UserControl
{
    public string Version => Helpers.Constants.DisplayVersion;

    private sealed class CreditInfo(string name, string description, string url)
    {
        public string Name { get; } = name;
        public string Description { get; } = description;
        public string Url { get; } = url;
    }

    private static readonly CreditInfo[] Credits =
    [
        new("w4po / ExplorerTabUtility", "Original project and author, Abd-Alrahman Ghanem.", "https://github.com/w4po/ExplorerTabUtility"),
        new("lazyalex616 / ExplorerTabPlus", "The fork this one is based on: merged community fixes, bookmarks, multi-language UI, update source and release pipeline.", "https://github.com/lazyalex616/ExplorerTabPlus"),
        new("MeverikC / ExplorerTabUtility", "Command-line path forwarding to the running instance, reduced idle process scanning, and exclusion of the redirected window during tab reuse.", "https://github.com/MeverikC/ExplorerTabUtility"),
        new("NeedJustWord / ExplorerTabUtility", "Multi-language support and bookmark management (upstream PRs #131 and #140).", "https://github.com/NeedJustWord/ExplorerTabUtility"),
        new("aiolosking / ExplorerTabUtility", "Preserve the requested file selection when converting or reusing tabs (upstream PR #144).", "https://github.com/aiolosking/ExplorerTabUtility"),
        new("yueyangcode / ExplorerTabUtility", "Tab navigation event cleanup and no synchronous callback reentry (upstream PR #142).", "https://github.com/yueyangcode/ExplorerTabUtility"),
        new("taroyamadax / ExplorerTabUtility", "Fix ObjectDisposedException on shutdown (upstream PR #139).", "https://github.com/taroyamadax/ExplorerTabUtility"),
        new("youncyb / ExplorerTabUtility", "Prevent Explorer windows from becoming unopenable (upstream PR #137).", "https://github.com/youncyb/ExplorerTabUtility"),
    ];

    public AboutView()
    {
        InitializeComponent();
        CreditsItemsControl.ItemsSource = Credits;
    }
    private void StarClickAnimation_Completed(object _, EventArgs __)
    {
        // Restart the continuous animation after the click animation is done
        var continuousStoryboard = FindName("ContinuousStarStoryboard") as BeginStoryboard;
        continuousStoryboard?.Storyboard?.Begin();
    }

    private void OpenProjectPage(object _, RoutedEventArgs __) => OpenUrl("https://github.com/warthurton/ExplorerTabPlus");

    private void OpenCreditPage(object sender, RoutedEventArgs _)
    {
        if (sender is FrameworkElement { Tag: string url } && !string.IsNullOrWhiteSpace(url))
            OpenUrl(url);
    }

    private void OpenSupportPage(object sender, RoutedEventArgs _)
    {
        if (sender is Border { Tag: string profileUrl } && !string.IsNullOrWhiteSpace(profileUrl))
            OpenUrl(profileUrl);
    }

    private static void OpenUrl(string url)
    {
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
        catch
        {
            // Ignore
        }
    }
}