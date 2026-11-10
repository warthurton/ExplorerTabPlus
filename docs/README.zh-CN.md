<div align="center">

[English](../README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md)

<br>

> [!NOTE]
> 本翻译未同步更新，因为维护者无法可靠地验证译文的准确性。有关此分支的最新改动及其来源（Layers of this fork），请参阅[英文 README](../README.md)。
> This translation is not updated because the maintainer cannot reliably validate it; the [English README](../README.md) is the source of truth.

<img src="../Assets/ExplorerTabUtilityLogo.gif" alt="ExplorerTabPlus logo" width="420">

# ExplorerTabPlus

**让 Windows 11 新打开的资源管理器窗口自动变成标签页 —— Explorer Tab Utility 的社区维护续作。**

[![最新版本](https://img.shields.io/github/v/release/warthurton/ExplorerTabPlus?label=release&color=2ea44f)](https://github.com/warthurton/ExplorerTabPlus/releases/latest)
[![下载量](https://img.shields.io/github/downloads/warthurton/ExplorerTabPlus/total?color=blue)](https://github.com/warthurton/ExplorerTabPlus/releases)
[![License: MIT](https://img.shields.io/github/license/warthurton/ExplorerTabPlus?color=yellow)](../LICENSE)
[![Windows 11 22H2+](https://img.shields.io/badge/Windows%2011-22H2%2B-0078D4?logo=windows11&logoColor=white)](https://www.microsoft.com/windows/windows-11)
[![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/download/dotnet/9.0)
[![.NET Framework 4.8.1](https://img.shields.io/badge/.NET%20Framework-4.8.1-512BD4)](https://dotnet.microsoft.com/download/dotnet-framework/net481)
[![Based on w4po/ExplorerTabUtility](https://img.shields.io/badge/based%20on-w4po%2FExplorerTabUtility-lightgrey?logo=github)](https://github.com/w4po/ExplorerTabUtility)

</div>

> [!IMPORTANT]
> 需要 Windows 11 22H2（内部版本 22621）或更高版本，且资源管理器支持标签页。

## 为什么有这个分支

[@w4po](https://github.com/w4po) 开发的 [Explorer Tab Utility](https://github.com/w4po/ExplorerTabUtility) 非常好用，但原仓库自 2025 年 5 月起就没有再更新（最后一版是 v2.5.0）。这期间社区陆续提交了不少修复 —— 资源管理器窗口打不开、退出时崩溃、文件选中状态丢失等真实问题 —— 还有多语言界面、书签这样的新功能，可这些 PR 一直没人合并。

ExplorerTabPlus 把它们合到一起，用 CI 保证能正常编译，并发布可直接下载的版本。它可以**直接覆盖安装**：程序名、设置目录、开机启动项和安装程序 ID 都没变，装在原版上面会保留你的设置和快捷键方案。

## 相比上游 v2.5.0 新增了什么

下面每一项都来自上游仓库中未合并的 PR，合并时保留了原作者的提交记录。

| PR | 改动 | 作者 |
|---|---|---|
| [#139](https://github.com/w4po/ExplorerTabUtility/pull/139) | 修复退出时的 `ObjectDisposedException`（Shell 对象被重复释放） | [@taroyamadax](https://github.com/taroyamadax) |
| [#137](https://github.com/w4po/ExplorerTabUtility/pull/137) | 修复资源管理器窗口无法打开：清理失效的 COM 对象、睡眠/休眠唤醒后自动恢复、转换标签页失败时保留原窗口 | [@youncyb](https://github.com/youncyb) |
| [#142](https://github.com/w4po/ExplorerTabUtility/pull/142) | 正确解绑标签页导航事件，避免在 COM 回调中同步重入（与鼠标一直转圈的问题有关） | [@yueyangcode](https://github.com/yueyangcode) |
| [#144](https://github.com/w4po/ExplorerTabUtility/pull/144) | 转换或复用标签页时保留要选中的文件（"在文件夹中显示"、`explorer /select`） | [@aiolosking](https://github.com/aiolosking) |
| [#131](https://github.com/w4po/ExplorerTabUtility/pull/131) | 多语言界面（英文、简体中文） | [@NeedJustWord](https://github.com/NeedJustWord) |
| [#140](https://github.com/w4po/ExplorerTabUtility/pull/140) | 书签管理：保存、打开、整理、导入导出书签，可在当前标签页、新标签页或新窗口中打开 | [@NeedJustWord](https://github.com/NeedJustWord) |

分支维护方面：程序内的自动更新改为检查本仓库的发布，CI 会针对两个目标框架编译每次改动，发布流程不再依赖上游的代码签名服务。

## 功能

<details>
<summary><b>窗口自动转为标签页</b></summary>

- 新开的资源管理器窗口会作为标签页并入已有窗口
- 如果该路径已经打开，直接切换到那个标签页
- 支持标签页的拆分/合并，以及虚拟桌面切换
- 正确处理"在文件夹中显示"的文件选中，可一次打开多个标签页

![窗口转标签页](../Assets/WindowToTab.gif)
</details>

<details>
<summary><b>书签</b>（新）</summary>

- 把当前标签页的位置存为书签（快捷键动作 `BookmarkSave`）
- 从书签栏弹窗打开书签（`BookmarkNavigate`）：直接点击在当前标签页打开，按住 <kbd>Ctrl</kbd> 在新标签页打开，按住 <kbd>Shift</kbd> 在新窗口打开
- 完整的书签管理器（`BookmarkManage`）：文件夹、拖拽排序、重命名、剪切/复制/粘贴、搜索、导入导出
</details>

<details>
<summary><b>多语言界面</b>（新）</summary>

- 在主窗口选择界面语言，内置英文和简体中文
- 语言文件位于程序目录下的 `Languages` 文件夹
</details>

<details>
<summary><b>复制当前标签页</b></summary>

- 以标签页或新窗口的方式复制当前标签页/窗口
- 保留当前位置和选中的项目

![复制标签页](../Assets/DuplicateTab.gif)
</details>

<details>
<summary><b>重新打开关闭的标签页</b></summary>

- 恢复最近关闭的标签页/窗口，连同位置和选中状态
- 开启"保存关闭历史"后，重启程序也不会丢失

![重新打开关闭的标签页](../Assets/ReopenClosedTab.gif)
</details>

<details>
<summary><b>恢复之前的窗口</b></summary>

- 资源管理器崩溃/重启或系统重启后，自动恢复之前打开的窗口（"恢复之前的窗口"）

![恢复之前的窗口](../Assets/RestorePrevious.png)
</details>

<details>
<summary><b>拆分与贴靠</b></summary>

- 把当前标签页拆成新窗口，并把窗口贴靠到屏幕边缘
- 一个快捷键可以串联多个方案，延迟可调

![拆分与贴靠](../Assets/DetachSnap.gif)
</details>

<details>
<summary><b>后退、前进、上一级</b></summary>

- 用自定义快捷键，或在文件夹空白处点击鼠标即可

![后退](../Assets/NavigateBack.gif)
</details>

<details>
<summary><b>自定义位置</b></summary>

- 给常用路径、带环境变量的路径（`%USERPROFILE%\Downloads`）、Shell CLSID、文件或网址分配快捷键

![自定义位置](../Assets/CustomLocation.gif)
</details>

<details>
<summary><b>标签页搜索/切换</b></summary>

- 输入文件夹名或路径的一部分，快速找到并切换到任意打开的标签页
- 按住 <kbd>Shift</kbd> 在新窗口打开，按住 <kbd>Ctrl</kbd> 即使已存在也再复制一份

![标签页搜索](../Assets/TabSearch.gif)
</details>

<details>
<summary><b>按 Ctrl+Shift 强制新窗口</b></summary>

- 打开位置时按住 <kbd>Ctrl</kbd>+<kbd>Shift</kbd>，本次不转标签页，直接开新窗口
</details>

## 安装

从[最新发布页](https://github.com/warthurton/ExplorerTabPlus/releases/latest)下载。

**安装程序（推荐）：** `ExplorerTabUtility_<版本>_Setup.exe` 会根据你的 CPU 自动选择合适的版本。如果没装 .NET 9 桌面运行时，会询问是否安装，也可以改用 .NET Framework 4.8.1 版本。

**便携 zip：** 按运行时和 CPU 架构选一个。

| 运行时 | 文件名后缀 | 前提 |
|---|---|---|
| .NET 9 | `_Net9.0_FrameworkDependent.zip` | 需要安装 [.NET 9 桌面运行时](https://dotnet.microsoft.com/download/dotnet/9.0) |
| .NET Framework 4.8.1 | `_NetFW4.8.1.zip` | 无需额外安装，Windows 11 自带 |

| 架构 | 适用 |
|---|---|
| `x64` | 绝大多数 Intel/AMD 电脑 |
| `arm64` | ARM 版 Windows（骁龙等） |
| `x86` | 仅 32 位 Windows |

解压到任意位置，运行 `ExplorerTabUtility.exe`，然后在托盘区找图标。

> [!NOTE]
> **从原版 Explorer Tab Utility 升级：** 直接运行安装程序（或替换文件）即可。程序名、设置目录 `%APPDATA%\ExplorerTabUtility\` 和安装程序 ID 都和原版相同，会原地升级并保留设置。之后的更新会从本仓库推送。

> [!WARNING]
> **发布文件没有代码签名。** Windows SmartScreen 可能提示"Windows 已保护你的电脑"，点"更多信息"→"仍要运行"即可。和原版一样，部分杀毒软件可能因为键盘/鼠标钩子和 COM 自动化而误报，这属于误报；你也可以随时[从源码编译](#从源码编译)。

## 使用

程序常驻系统托盘。双击或右键托盘图标打开设置。

![托盘菜单](../Assets/Menu.png)

**常规设置**

- **Window Hook** —— 自动把窗口转为标签页
- **Reuse Tabs** —— 已打开的路径直接切换过去，不再重复打开
- **Keyboard Hook / Mouse Hook** —— 快捷键和鼠标导航
- **Startup** —— 开机启动
- 设置保存在 `%APPDATA%\ExplorerTabUtility\settings.json`，删除该文件即可恢复默认

**偏好设置：** 自动更新、自定义主题时使用另一种窗口隐藏方式（"I have theme issues"）、保存关闭历史、恢复之前的窗口、隐藏托盘图标（需先配置一个 `ToggleVisibility` 快捷键）。

![偏好设置](../Assets/Preferences.png)

**快捷键方案。** 每个方案包含快捷键、作用范围（全局或仅资源管理器）、动作、可选路径、延迟，以及"Handled"开关（决定按键是否继续传给其他程序）。方案可以导入导出。

| 动作 | 作用 |
|---|---|
| `Open` | 打开指定位置（路径留空 = 新标签页） |
| `Duplicate` | 复制当前标签页 |
| `ReopenClosed` | 重新打开最近关闭的位置 |
| `TabSearch` | 打开标签页搜索弹窗 |
| `NavigateBack` / `NavigateForward` / `NavigateUp` | 在当前标签页中后退/前进/上一级 |
| `SetTargetWindow` | 把当前窗口设为新标签页的目标窗口 |
| `ToggleWinHook` / `ToggleReuseTabs` / `ToggleVisibility` | 切换功能开关 / 显示隐藏主窗口 |
| `DetachTab` | 把当前标签页移到新窗口 |
| `SnapRight` / `SnapLeft` / `SnapUp` / `SnapDown` | 贴靠当前窗口 |
| `BookmarkSave` / `BookmarkNavigate` / `BookmarkManage` | 保存、打开、管理书签（新） |

默认方案：<kbd>Win</kbd>+<kbd>E</kbd> 打开主页，<kbd>Ctrl</kbd>+<kbd>D</kbd> 复制标签页，<kbd>Ctrl</kbd>+<kbd>Shift</kbd>+<kbd>T</kbd> 重新打开最近关闭的标签页。

![快捷键方案](../Assets/Form.png)

## 从源码编译

需要：Windows、装有 .NET 桌面开发工作负载的 Visual Studio 2022（或 Build Tools），以及 .NET 9 SDK。项目引用了 COM 组件（`Shell32`、`SHDocVw`），必须用完整版 **MSBuild** 编译，只用 `dotnet build` 会报 `MSB4803`。

```powershell
git clone https://github.com/warthurton/ExplorerTabPlus.git
cd ExplorerTabPlus
msbuild ExplorerTabUtility/ExplorerTabUtility.csproj /restore /p:Configuration=Release /p:TargetFramework=net9.0-windows
# 或 /p:TargetFramework=net481
```

导航回归测试（来自 PR #142）：`dotnet run --project tests/NavigationCompletion.Tests.csproj -c Release`。

## 致谢

- **[@w4po](https://github.com/w4po)**（Abd-Alrahman Ghanem）—— [Explorer Tab Utility](https://github.com/w4po/ExplorerTabUtility) 的原作者，核心工作都出自他手。如果觉得好用，欢迎[赞助他](https://github.com/sponsors/w4po)。
- 本分支合并的社区 PR 作者：
  [@taroyamadax](https://github.com/taroyamadax)（#139）、
  [@youncyb](https://github.com/youncyb)（#137）、
  [@yueyangcode](https://github.com/yueyangcode)（#142）、
  [@aiolosking](https://github.com/aiolosking)（#144）、
  [@NeedJustWord](https://github.com/NeedJustWord)（#131、#140）。
- 使用的开源库：[H.Hooks](https://github.com/HavenDV/H.Hooks)、[Hardcodet.NotifyIcon.Wpf](https://github.com/hardcodet/wpf-notifyicon)、[AutoUpdater.NET](https://github.com/ravibpatel/AutoUpdater.NET)、[gong-wpf-dragdrop](https://github.com/punker76/gong-wpf-dragdrop)。

问题反馈和 PR 请提交到[本仓库的 Issues](https://github.com/warthurton/ExplorerTabPlus/issues)。

## 许可证

[MIT](../LICENSE)，与原项目相同。原作版权归 w4po 所有。
