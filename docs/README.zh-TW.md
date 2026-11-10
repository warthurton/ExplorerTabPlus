<div align="center">

[English](../README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md)

<br>

> [!NOTE]
> 本翻譯未同步更新。有關此分支的最新變更及其來源（Layers of this fork），請參閱[英文 README](../README.md)。
> This translation is not kept up to date; the [English README](../README.md) is the source of truth.

<img src="../Assets/ExplorerTabUtilityLogo.gif" alt="ExplorerTabPlus logo" width="420">

# ExplorerTabPlus

**讓 Windows 11 新開啟的檔案總管視窗自動變成索引標籤 —— Explorer Tab Utility 的社群維護延續版。**

[![最新版本](https://img.shields.io/github/v/release/warthurton/ExplorerTabPlus?label=release&color=2ea44f)](https://github.com/warthurton/ExplorerTabPlus/releases/latest)
[![下載次數](https://img.shields.io/github/downloads/warthurton/ExplorerTabPlus/total?color=blue)](https://github.com/warthurton/ExplorerTabPlus/releases)
[![License: MIT](https://img.shields.io/github/license/warthurton/ExplorerTabPlus?color=yellow)](../LICENSE)
[![Windows 11 22H2+](https://img.shields.io/badge/Windows%2011-22H2%2B-0078D4?logo=windows11&logoColor=white)](https://www.microsoft.com/windows/windows-11)
[![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/download/dotnet/9.0)
[![.NET Framework 4.8.1](https://img.shields.io/badge/.NET%20Framework-4.8.1-512BD4)](https://dotnet.microsoft.com/download/dotnet-framework/net481)
[![Based on w4po/ExplorerTabUtility](https://img.shields.io/badge/based%20on-w4po%2FExplorerTabUtility-lightgrey?logo=github)](https://github.com/w4po/ExplorerTabUtility)

</div>

> [!IMPORTANT]
> 需要 Windows 11 22H2（組建 22621）或更新版本，且檔案總管支援索引標籤。

## 為什麼有這個分支

[@w4po](https://github.com/w4po) 開發的 [Explorer Tab Utility](https://github.com/w4po/ExplorerTabUtility) 非常好用，但原始儲存庫自 2025 年 5 月起就沒有再更新（最後一版為 v2.5.0）。這段期間社群陸續送出不少修正 —— 檔案總管視窗打不開、結束時當掉、檔案選取狀態遺失等實際問題 —— 還有多國語言介面、書籤等新功能，但這些 PR 一直沒有被合併。

ExplorerTabPlus 把它們整合在一起，以 CI 確保能正常編譯，並發佈可直接下載的版本。它可以**直接覆蓋安裝**：執行檔名稱、設定資料夾、開機啟動項目與安裝程式 ID 都沒有變，裝在原版上會保留你的設定和快速鍵設定檔。

## 與上游 v2.5.0 相比的新內容

以下每一項都來自上游儲存庫中尚未合併的 PR，合併時保留了原作者的提交紀錄。

| PR | 變更 | 作者 |
|---|---|---|
| [#139](https://github.com/w4po/ExplorerTabUtility/pull/139) | 修正結束時的 `ObjectDisposedException`（Shell 物件被重複釋放） | [@taroyamadax](https://github.com/taroyamadax) |
| [#137](https://github.com/w4po/ExplorerTabUtility/pull/137) | 修正檔案總管視窗無法開啟：清除失效的 COM 物件、睡眠／休眠喚醒後自動復原、轉換索引標籤失敗時保留原視窗 | [@youncyb](https://github.com/youncyb) |
| [#142](https://github.com/w4po/ExplorerTabUtility/pull/142) | 正確解除索引標籤導覽事件，避免在 COM 回呼中同步重入（與游標一直轉圈的問題有關） | [@yueyangcode](https://github.com/yueyangcode) |
| [#144](https://github.com/w4po/ExplorerTabUtility/pull/144) | 轉換或重複使用索引標籤時保留要選取的檔案（「在資料夾中顯示」、`explorer /select`） | [@aiolosking](https://github.com/aiolosking) |
| [#131](https://github.com/w4po/ExplorerTabUtility/pull/131) | 多國語言介面（英文、簡體中文） | [@NeedJustWord](https://github.com/NeedJustWord) |
| [#140](https://github.com/w4po/ExplorerTabUtility/pull/140) | 書籤管理：儲存、開啟、整理、匯入匯出書籤，可在目前索引標籤、新索引標籤或新視窗中開啟 | [@NeedJustWord](https://github.com/NeedJustWord) |

分支維護方面：程式內的自動更新改為檢查本儲存庫的發行版本，CI 會針對兩個目標框架編譯每一次變更，發行流程不再依賴上游的程式碼簽章服務。

## 功能

<details>
<summary><b>視窗自動轉為索引標籤</b></summary>

- 新開的檔案總管視窗會以索引標籤的形式併入現有視窗
- 若該路徑已開啟，直接切換到那個索引標籤
- 支援索引標籤的分離／合併，以及虛擬桌面切換
- 正確處理「在資料夾中顯示」的檔案選取，可一次開啟多個索引標籤

![視窗轉索引標籤](../Assets/WindowToTab.gif)
</details>

<details>
<summary><b>書籤</b>（新）</summary>

- 將目前索引標籤的位置存成書籤（快速鍵動作 `BookmarkSave`）
- 從書籤列彈出視窗開啟書籤（`BookmarkNavigate`）：直接點選在目前索引標籤開啟，按住 <kbd>Ctrl</kbd> 在新索引標籤開啟，按住 <kbd>Shift</kbd> 在新視窗開啟
- 完整的書籤管理員（`BookmarkManage`）：資料夾、拖放排序、重新命名、剪下／複製／貼上、搜尋、匯入匯出
</details>

<details>
<summary><b>多國語言介面</b>（新）</summary>

- 在主視窗選擇介面語言，內建英文與簡體中文
- 語言檔位於程式目錄下的 `Languages` 資料夾
</details>

<details>
<summary><b>複製目前索引標籤</b></summary>

- 以索引標籤或新視窗的方式複製目前的索引標籤／視窗
- 保留目前位置與選取的項目

![複製索引標籤](../Assets/DuplicateTab.gif)
</details>

<details>
<summary><b>重新開啟已關閉的索引標籤</b></summary>

- 復原最近關閉的索引標籤／視窗，連同位置與選取狀態
- 開啟「儲存關閉紀錄」後，重新啟動程式也不會遺失

![重新開啟已關閉的索引標籤](../Assets/ReopenClosedTab.gif)
</details>

<details>
<summary><b>還原先前的視窗</b></summary>

- 檔案總管當掉／重新啟動或系統重新開機後，自動還原先前開啟的視窗（「還原先前的視窗」）

![還原先前的視窗](../Assets/RestorePrevious.png)
</details>

<details>
<summary><b>分離與貼齊</b></summary>

- 將目前索引標籤分離成新視窗，並把視窗貼齊到螢幕邊緣
- 一個快速鍵可串接多個設定檔，延遲可調整

![分離與貼齊](../Assets/DetachSnap.gif)
</details>

<details>
<summary><b>上一頁、下一頁、上一層</b></summary>

- 透過自訂快速鍵，或在資料夾空白處點選滑鼠

![上一頁](../Assets/NavigateBack.gif)
</details>

<details>
<summary><b>自訂位置</b></summary>

- 為常用路徑、含環境變數的路徑（`%USERPROFILE%\Downloads`）、Shell CLSID、檔案或網址指定快速鍵

![自訂位置](../Assets/CustomLocation.gif)
</details>

<details>
<summary><b>索引標籤搜尋／切換</b></summary>

- 輸入資料夾名稱或路徑的一部分，快速找到並切換到任何已開啟的索引標籤
- 按住 <kbd>Shift</kbd> 在新視窗開啟，按住 <kbd>Ctrl</kbd> 即使已存在也再複製一份

![索引標籤搜尋](../Assets/TabSearch.gif)
</details>

<details>
<summary><b>按 Ctrl+Shift 強制開新視窗</b></summary>

- 開啟位置時按住 <kbd>Ctrl</kbd>+<kbd>Shift</kbd>，這一次不轉索引標籤，直接開新視窗
</details>

## 安裝

從[最新發行版本](https://github.com/warthurton/ExplorerTabPlus/releases/latest)下載。

**安裝程式（建議）：** `ExplorerTabUtility_<版本>_Setup.exe` 會依你的 CPU 自動選擇合適的版本。若未安裝 .NET 9 桌面執行階段，會詢問是否安裝，也可以改用 .NET Framework 4.8.1 版本。

**免安裝 zip：** 依執行階段與 CPU 架構挑一個。

| 執行階段 | 檔名後綴 | 需求 |
|---|---|---|
| .NET 9 | `_Net9.0_FrameworkDependent.zip` | 需安裝 [.NET 9 桌面執行階段](https://dotnet.microsoft.com/download/dotnet/9.0) |
| .NET Framework 4.8.1 | `_NetFW4.8.1.zip` | 不需額外安裝，Windows 11 內建 |

| 架構 | 適用 |
|---|---|
| `x64` | 絕大多數 Intel/AMD 電腦 |
| `arm64` | ARM 版 Windows（Snapdragon 等） |
| `x86` | 僅限 32 位元 Windows |

解壓縮到任意位置，執行 `ExplorerTabUtility.exe`，再到系統匣找圖示。

> [!NOTE]
> **從原版 Explorer Tab Utility 升級：** 直接執行安裝程式（或取代檔案）即可。執行檔名稱、設定資料夾 `%APPDATA%\ExplorerTabUtility\` 與安裝程式 ID 都和原版相同，會就地升級並保留設定。之後的更新會由本儲存庫提供。

> [!WARNING]
> **發行檔案沒有程式碼簽章。** Windows SmartScreen 可能顯示「Windows 已保護您的電腦」，請點「其他資訊」→「仍要執行」。與原版相同，部分防毒軟體可能因鍵盤／滑鼠攔截與 COM 自動化而誤判，這屬於誤報；你也可以隨時[從原始碼編譯](#從原始碼編譯)。

## 使用方式

程式常駐在系統匣。按兩下或右鍵點選系統匣圖示即可開啟設定。

![系統匣選單](../Assets/Menu.png)

**一般設定**

- **Window Hook** —— 自動將視窗轉為索引標籤
- **Reuse Tabs** —— 已開啟的路徑直接切換過去，不重複開啟
- **Keyboard Hook / Mouse Hook** —— 快速鍵與滑鼠導覽
- **Startup** —— 開機時啟動
- 設定儲存在 `%APPDATA%\ExplorerTabUtility\settings.json`，刪除此檔即可恢復預設值

**偏好設定：** 自動更新、自訂佈景主題時改用另一種視窗隱藏方式（「I have theme issues」）、儲存關閉紀錄、還原先前的視窗、隱藏系統匣圖示（需先設定一個 `ToggleVisibility` 快速鍵）。

![偏好設定](../Assets/Preferences.png)

**快速鍵設定檔。** 每個設定檔包含快速鍵、作用範圍（全域或僅限檔案總管）、動作、選用路徑、延遲，以及「Handled」開關（決定按鍵是否繼續傳給其他程式）。設定檔可以匯入與匯出。

| 動作 | 作用 |
|---|---|
| `Open` | 開啟指定位置（路徑留空 = 新索引標籤） |
| `Duplicate` | 複製目前索引標籤 |
| `ReopenClosed` | 重新開啟最近關閉的位置 |
| `TabSearch` | 開啟索引標籤搜尋視窗 |
| `NavigateBack` / `NavigateForward` / `NavigateUp` | 在目前索引標籤中上一頁／下一頁／上一層 |
| `SetTargetWindow` | 將目前視窗設為新索引標籤的目標視窗 |
| `ToggleWinHook` / `ToggleReuseTabs` / `ToggleVisibility` | 切換功能開關／顯示或隱藏主視窗 |
| `DetachTab` | 將目前索引標籤移到新視窗 |
| `SnapRight` / `SnapLeft` / `SnapUp` / `SnapDown` | 貼齊目前視窗 |
| `BookmarkSave` / `BookmarkNavigate` / `BookmarkManage` | 儲存、開啟、管理書籤（新） |

預設設定檔：<kbd>Win</kbd>+<kbd>E</kbd> 開啟首頁，<kbd>Ctrl</kbd>+<kbd>D</kbd> 複製索引標籤，<kbd>Ctrl</kbd>+<kbd>Shift</kbd>+<kbd>T</kbd> 重新開啟最近關閉的索引標籤。

![快速鍵設定檔](../Assets/Form.png)

## 從原始碼編譯

需求：Windows、已安裝「.NET 桌面開發」工作負載的 Visual Studio 2022（或 Build Tools），以及 .NET 9 SDK。專案參考了 COM 元件（`Shell32`、`SHDocVw`），必須使用完整版 **MSBuild** 編譯；只用 `dotnet build` 會出現 `MSB4803` 錯誤。

```powershell
git clone https://github.com/warthurton/ExplorerTabPlus.git
cd ExplorerTabPlus
msbuild ExplorerTabUtility/ExplorerTabUtility.csproj /restore /p:Configuration=Release /p:TargetFramework=net9.0-windows
# 或 /p:TargetFramework=net481
```

導覽回歸測試（來自 PR #142）：`dotnet run --project tests/NavigationCompletion.Tests.csproj -c Release`。

## 致謝

- **[@w4po](https://github.com/w4po)**（Abd-Alrahman Ghanem）—— [Explorer Tab Utility](https://github.com/w4po/ExplorerTabUtility) 的原作者，核心工作都出自他手。如果覺得好用，歡迎[贊助他](https://github.com/sponsors/w4po)。
- 本分支合併的社群 PR 作者：
  [@taroyamadax](https://github.com/taroyamadax)（#139）、
  [@youncyb](https://github.com/youncyb)（#137）、
  [@yueyangcode](https://github.com/yueyangcode)（#142）、
  [@aiolosking](https://github.com/aiolosking)（#144）、
  [@NeedJustWord](https://github.com/NeedJustWord)（#131、#140）。
- 使用的開源函式庫：[H.Hooks](https://github.com/HavenDV/H.Hooks)、[Hardcodet.NotifyIcon.Wpf](https://github.com/hardcodet/wpf-notifyicon)、[AutoUpdater.NET](https://github.com/ravibpatel/AutoUpdater.NET)、[gong-wpf-dragdrop](https://github.com/punker76/gong-wpf-dragdrop)。

問題回報與 PR 請提交到[本儲存庫的 Issues](https://github.com/warthurton/ExplorerTabPlus/issues)。

## 授權

[MIT](../LICENSE)，與原專案相同。原作著作權屬於 w4po。
