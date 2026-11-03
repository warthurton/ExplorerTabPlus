<div align="center">

**English** | [简体中文](docs/README.zh-CN.md) | [繁體中文](docs/README.zh-TW.md) | [日本語](docs/README.ja.md)

<br>

<img src="Assets/ExplorerTabUtilityLogo.gif" alt="ExplorerTabPlus logo" width="420">

# ExplorerTabPlus

**Force new File Explorer windows to open as tabs on Windows 11 — a community-maintained continuation of Explorer Tab Utility.**

[![Latest release](https://img.shields.io/github/v/release/lazyalex616/ExplorerTabPlus?label=release&color=2ea44f)](https://github.com/lazyalex616/ExplorerTabPlus/releases/latest)
[![Downloads](https://img.shields.io/github/downloads/lazyalex616/ExplorerTabPlus/total?color=blue)](https://github.com/lazyalex616/ExplorerTabPlus/releases)
[![License: MIT](https://img.shields.io/github/license/lazyalex616/ExplorerTabPlus?color=yellow)](LICENSE)
[![Windows 11 22H2+](https://img.shields.io/badge/Windows%2011-22H2%2B-0078D4?logo=windows11&logoColor=white)](https://www.microsoft.com/windows/windows-11)
[![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/download/dotnet/9.0)
[![.NET Framework 4.8.1](https://img.shields.io/badge/.NET%20Framework-4.8.1-512BD4)](https://dotnet.microsoft.com/download/dotnet-framework/net481)
[![Based on w4po/ExplorerTabUtility](https://img.shields.io/badge/based%20on-w4po%2FExplorerTabUtility-lightgrey?logo=github)](https://github.com/w4po/ExplorerTabUtility)

</div>

> [!IMPORTANT]
> Requires Windows 11 22H2 (build 22621) or later, with File Explorer tabs.

## Why this fork

[Explorer Tab Utility](https://github.com/w4po/ExplorerTabUtility) by [@w4po](https://github.com/w4po) is an excellent tool, but the original repository has had no activity since May 2025 (last release v2.5.0). In the meantime the community kept sending fixes for real bugs — windows that could no longer be opened, crashes on shutdown, lost file selection — and new features such as a multi-language UI and bookmarks. Those pull requests were never merged.

ExplorerTabPlus collects them into one build, keeps it compiling on CI, and publishes releases. It is a **drop-in upgrade**: the executable, settings folder, startup entry and installer ID are unchanged, so installing it over the original keeps your settings and hotkey profiles.

## What's new compared with upstream v2.5.0

Every change below is an open pull request from the upstream repository, merged here with the original author's commits intact.

| PR | Change | Author |
|---|---|---|
| [#139](https://github.com/w4po/ExplorerTabUtility/pull/139) | Fix `ObjectDisposedException` on shutdown (double dispose of shell objects) | [@taroyamadax](https://github.com/taroyamadax) |
| [#137](https://github.com/w4po/ExplorerTabUtility/pull/137) | Fix Explorer windows becoming unopenable: stale COM cleanup, recovery after sleep/hibernate, keep the window visible if tab conversion fails | [@youncyb](https://github.com/youncyb) |
| [#142](https://github.com/w4po/ExplorerTabUtility/pull/142) | Clean up tab navigation event handlers and avoid synchronous COM callback re-entry (related to the stuck loading cursor) | [@yueyangcode](https://github.com/yueyangcode) |
| [#144](https://github.com/w4po/ExplorerTabUtility/pull/144) | Preserve the requested file selection ("Show in folder", `explorer /select`) when converting or reusing tabs | [@aiolosking](https://github.com/aiolosking) |
| [#131](https://github.com/w4po/ExplorerTabUtility/pull/131) | Multi-language UI (English, Simplified Chinese) | [@NeedJustWord](https://github.com/NeedJustWord) |
| [#140](https://github.com/w4po/ExplorerTabUtility/pull/140) | Bookmark management: save, navigate, organize, import/export bookmarks, open them in the current tab, a new tab or a new window | [@NeedJustWord](https://github.com/NeedJustWord) |

Fork maintenance: the in-app updater checks this repository's releases, CI builds every change for both target frameworks, and releases are built without the upstream signing service.

## Features

<details>
<summary><b>Automatic window-to-tab conversion</b></summary>

- New Explorer windows open as tabs in an existing window
- Switches to an existing tab if the path is already open
- Supports attaching/detaching tabs and virtual desktop switching
- Handles "Show in folder" file selection and opening multiple tabs at once

![Window to tab conversion](Assets/WindowToTab.gif)
</details>

<details>
<summary><b>Bookmarks</b> (new)</summary>

- Save the current tab's location as a bookmark (`BookmarkSave` hotkey action)
- Open bookmarks from a bookmark bar popup (`BookmarkNavigate`): plain click opens in the current tab, <kbd>Ctrl</kbd> opens a new tab, <kbd>Shift</kbd> opens a new window
- Full bookmark manager (`BookmarkManage`): folders, drag-and-drop reordering, rename, cut/copy/paste, search, import/export
</details>

<details>
<summary><b>Multi-language UI</b> (new)</summary>

- Choose the UI language in the main window; English and Simplified Chinese are included
- Language files live in the `Languages` folder next to the executable
</details>

<details>
<summary><b>Duplicate current tab</b></summary>

- Duplicate the current tab or window, as a tab or as a new window
- Keeps the location and selected items

![Duplicate current tab](Assets/DuplicateTab.gif)
</details>

<details>
<summary><b>Reopen closed tabs</b></summary>

- Reopen recently closed tabs/windows with their location and selection
- History can persist across restarts ("Save closed history")

![Reopen closed tabs](Assets/ReopenClosedTab.gif)
</details>

<details>
<summary><b>Restore previous windows</b></summary>

- Restores windows that were open before an Explorer crash/restart or a reboot ("Restore previous windows")

![Restore previous windows](Assets/RestorePrevious.png)
</details>

<details>
<summary><b>Detach and snap</b></summary>

- Detach the current tab to a new window and snap windows to screen edges
- Chain several profiles on one hotkey, with configurable delays

![Detach and snap](Assets/DetachSnap.gif)
</details>

<details>
<summary><b>Navigate back, forward and up</b></summary>

- Via customizable hotkeys or by clicking empty space in a folder

![Navigate back](Assets/NavigateBack.gif)
</details>

<details>
<summary><b>Custom locations</b></summary>

- Assign hotkeys to paths, environment-variable paths (`%USERPROFILE%\Downloads`), shell CLSIDs, files and URLs

![Custom location](Assets/CustomLocation.gif)
</details>

<details>
<summary><b>Tab search / switcher</b></summary>

- Type part of a folder name or path to find and switch to any open tab
- <kbd>Shift</kbd> opens in a new window, <kbd>Ctrl</kbd> duplicates even if the tab exists

![Tab search](Assets/TabSearch.gif)
</details>

<details>
<summary><b>Force a new window with Ctrl+Shift</b></summary>

- Hold <kbd>Ctrl</kbd>+<kbd>Shift</kbd> while opening a location to bypass the window hook once
</details>

## Installation

Download from the [latest release](https://github.com/lazyalex616/ExplorerTabPlus/releases/latest).

**Installer (recommended):** `ExplorerTabUtility_<version>_Setup.exe` picks the right build for your CPU. If the .NET 9 Desktop Runtime is missing it offers to install it, or falls back to the .NET Framework 4.8.1 build.

**Portable zip:** pick one file by runtime and CPU architecture.

| Runtime | File suffix | Needs |
|---|---|---|
| .NET 9 | `_Net9.0_FrameworkDependent.zip` | [.NET 9 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/9.0) |
| .NET Framework 4.8.1 | `_NetFW4.8.1.zip` | Nothing — included with Windows 11 |

| Architecture | Use when |
|---|---|
| `x64` | Most Intel/AMD PCs |
| `arm64` | Windows on ARM (Snapdragon, etc.) |
| `x86` | 32-bit Windows only |

Unzip anywhere and run `ExplorerTabUtility.exe`. Look for the tray icon.
### Command-line opening

Pass one or more locations to the executable to open them through the running tray instance:

```powershell
ExplorerTabUtility.exe "C:\Users\Documents"
ExplorerTabUtility.exe "C:\Users\Documents" "D:\Projects"
```

If Explorer Tab Utility is already running, the new process forwards the locations to the existing instance and exits. Each location is opened as a tab, and an already-open matching location is activated instead of duplicated.


> [!NOTE]
> **Upgrading from the original Explorer Tab Utility:** just run the installer (or replace the files). The app keeps the same executable name, the same settings at `%APPDATA%\ExplorerTabUtility\`, and the same installer ID, so it upgrades in place and keeps your settings. Future updates are offered from this repository.

> [!WARNING]
> **Builds are not code-signed.** Windows SmartScreen may show "Windows protected your PC" — choose *More info* → *Run anyway*. Like the original, some antivirus products may flag the keyboard/mouse hooks and COM automation as suspicious; this is a false positive, and you can always [build from source](#build-from-source).

## Usage

The app runs in the system tray. Double-click or right-click the tray icon to open settings.

![Tray menu](Assets/Menu.png)

**General settings**

- **Window Hook** — automatic window-to-tab conversion
- **Reuse Tabs** — switch to an existing tab instead of opening a duplicate
- **Keyboard Hook / Mouse Hook** — hotkeys and mouse navigation
- **Startup** — start with Windows
- Settings are stored in `%APPDATA%\ExplorerTabUtility\settings.json`; delete it to reset

**Preferences:** auto update, alternative window hiding for custom themes ("I have theme issues"), save closed history, restore previous windows, hide tray icon (requires a `ToggleVisibility` hotkey first).

![Preferences](Assets/Preferences.png)

**Hotkey profiles.** Each profile has a hotkey, a scope (Global or Explorer-only), an action, an optional path, a delay and a "Handled" toggle that decides whether the keystroke is passed on to other apps. Profiles can be imported and exported.

| Action | What it does |
|---|---|
| `Open` | Open a location (empty path = new tab) |
| `Duplicate` | Duplicate the current tab |
| `ReopenClosed` | Reopen the last closed location |
| `TabSearch` | Open the tab search popup |
| `NavigateBack` / `NavigateForward` / `NavigateUp` | Navigate in the current tab |
| `SetTargetWindow` | Mark the current window as the target for new tabs |
| `ToggleWinHook` / `ToggleReuseTabs` / `ToggleVisibility` | Toggle features / main window |
| `DetachTab` | Move the current tab into a new window |
| `SnapRight` / `SnapLeft` / `SnapUp` / `SnapDown` | Snap the current window |
| `BookmarkSave` / `BookmarkNavigate` / `BookmarkManage` | Save, open and manage bookmarks (new) |

Default profiles: <kbd>Win</kbd>+<kbd>E</kbd> opens Home, <kbd>Ctrl</kbd>+<kbd>D</kbd> duplicates the tab, <kbd>Ctrl</kbd>+<kbd>Shift</kbd>+<kbd>T</kbd> reopens the last closed tab.

![Hotkey profile form](Assets/Form.png)

## Build from source

Requirements: Windows, Visual Studio 2022 (or Build Tools) with the .NET desktop workload, and the .NET 9 SDK. The project uses COM references (`Shell32`, `SHDocVw`), so it must be built with full-framework **MSBuild**; `dotnet build` alone fails with `MSB4803`.

```powershell
git clone https://github.com/lazyalex616/ExplorerTabPlus.git
cd ExplorerTabPlus
msbuild ExplorerTabUtility/ExplorerTabUtility.csproj /restore /p:Configuration=Release /p:TargetFramework=net9.0-windows
# or /p:TargetFramework=net481
```

Navigation regression checks (from PR #142): `dotnet run --project tests/NavigationCompletion.Tests.csproj -c Release`.

## Credits

- **[@w4po](https://github.com/w4po)** (Abd-Alrahman Ghanem) — original author of [Explorer Tab Utility](https://github.com/w4po/ExplorerTabUtility). All the core work is his; if you find the app useful, consider [sponsoring him](https://github.com/sponsors/w4po).
- Community pull requests merged in this fork:
  [@taroyamadax](https://github.com/taroyamadax) (#139),
  [@youncyb](https://github.com/youncyb) (#137),
  [@yueyangcode](https://github.com/yueyangcode) (#142),
  [@aiolosking](https://github.com/aiolosking) (#144),
  [@NeedJustWord](https://github.com/NeedJustWord) (#131, #140).
- Libraries: [H.Hooks](https://github.com/HavenDV/H.Hooks), [Hardcodet.NotifyIcon.Wpf](https://github.com/hardcodet/wpf-notifyicon), [AutoUpdater.NET](https://github.com/ravibpatel/AutoUpdater.NET), [gong-wpf-dragdrop](https://github.com/punker76/gong-wpf-dragdrop).

Bug reports and pull requests are welcome in [this repository's issues](https://github.com/lazyalex616/ExplorerTabPlus/issues).

## License

[MIT](LICENSE), same as the original project. Original work © w4po.
