<div align="center">

[English](../README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語**

<br>

> [!NOTE]
> この翻訳は最新ではありません。このフォークの変更内容と出典（Layers of this fork）は[英語版 README](../README.md)をご覧ください。
> This translation is not kept up to date; the [English README](../README.md) is the source of truth.

<img src="../Assets/ExplorerTabUtilityLogo.gif" alt="ExplorerTabPlus logo" width="420">

# ExplorerTabPlus

**Windows 11 で新しく開いたエクスプローラーのウィンドウを自動でタブにまとめる —— Explorer Tab Utility のコミュニティ版。**

[![最新リリース](https://img.shields.io/github/v/release/warthurton/ExplorerTabPlus?label=release&color=2ea44f)](https://github.com/warthurton/ExplorerTabPlus/releases/latest)
[![ダウンロード数](https://img.shields.io/github/downloads/warthurton/ExplorerTabPlus/total?color=blue)](https://github.com/warthurton/ExplorerTabPlus/releases)
[![License: MIT](https://img.shields.io/github/license/warthurton/ExplorerTabPlus?color=yellow)](../LICENSE)
[![Windows 11 22H2+](https://img.shields.io/badge/Windows%2011-22H2%2B-0078D4?logo=windows11&logoColor=white)](https://www.microsoft.com/windows/windows-11)
[![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/download/dotnet/9.0)
[![.NET Framework 4.8.1](https://img.shields.io/badge/.NET%20Framework-4.8.1-512BD4)](https://dotnet.microsoft.com/download/dotnet-framework/net481)
[![Based on w4po/ExplorerTabUtility](https://img.shields.io/badge/based%20on-w4po%2FExplorerTabUtility-lightgrey?logo=github)](https://github.com/w4po/ExplorerTabUtility)

</div>

> [!IMPORTANT]
> Windows 11 22H2（ビルド 22621）以降、かつエクスプローラーのタブ機能が必要です。

## このフォークについて

[@w4po](https://github.com/w4po) 氏による [Explorer Tab Utility](https://github.com/w4po/ExplorerTabUtility) はとても便利なツールですが、元のリポジトリは 2025 年 5 月以降更新が止まっています（最終リリースは v2.5.0）。その間にもコミュニティからは、エクスプローラーのウィンドウが開けなくなる、終了時にクラッシュする、ファイルの選択状態が失われるといった実際の不具合の修正や、多言語 UI・ブックマークといった新機能のプルリクエストが届いていましたが、マージされないままでした。

ExplorerTabPlus はそれらをひとつにまとめ、CI でビルドを確認したうえでリリースを公開しています。**上書きインストールにそのまま対応**しています。実行ファイル名、設定フォルダー、スタートアップ登録、インストーラー ID は変更していないため、元のアプリの上にインストールしても設定やホットキーのプロファイルはそのまま引き継がれます。

## 上流 v2.5.0 からの変更点

以下はすべて上流リポジトリで未マージだったプルリクエストで、元の作者のコミットを残したままマージしています。

| PR | 内容 | 作者 |
|---|---|---|
| [#139](https://github.com/w4po/ExplorerTabUtility/pull/139) | 終了時の `ObjectDisposedException` を修正（Shell オブジェクトの二重解放） | [@taroyamadax](https://github.com/taroyamadax) |
| [#137](https://github.com/w4po/ExplorerTabUtility/pull/137) | エクスプローラーのウィンドウが開けなくなる問題を修正：無効な COM オブジェクトの整理、スリープ／休止状態からの復帰後の再初期化、タブ化に失敗したときは元のウィンドウを表示したままにする | [@youncyb](https://github.com/youncyb) |
| [#142](https://github.com/w4po/ExplorerTabUtility/pull/142) | タブのナビゲーションイベントを確実に解除し、COM コールバック内での同期的な再入を回避（カーソルが読み込み中のままになる問題に関連） | [@yueyangcode](https://github.com/yueyangcode) |
| [#144](https://github.com/w4po/ExplorerTabUtility/pull/144) | タブへの変換・既存タブの再利用時にも、指定されたファイルの選択（「フォルダーに表示」、`explorer /select`）を維持 | [@aiolosking](https://github.com/aiolosking) |
| [#131](https://github.com/w4po/ExplorerTabUtility/pull/131) | 多言語 UI（英語、簡体字中国語） | [@NeedJustWord](https://github.com/NeedJustWord) |
| [#140](https://github.com/w4po/ExplorerTabUtility/pull/140) | ブックマーク管理：保存、移動、整理、インポート／エクスポート。現在のタブ・新しいタブ・新しいウィンドウで開ける | [@NeedJustWord](https://github.com/NeedJustWord) |

フォークとしての保守：アプリ内の自動更新はこのリポジトリのリリースを確認するようになり、CI ですべての変更を両方のターゲットフレームワークでビルドし、リリースは上流のコード署名サービスを使わずに作成しています。

## 機能

<details>
<summary><b>ウィンドウを自動でタブに変換</b></summary>

- 新しく開いたエクスプローラーのウィンドウを既存ウィンドウのタブにまとめる
- 同じパスがすでに開いていれば、そのタブに切り替える
- タブの切り離し／結合、仮想デスクトップの切り替えに対応
- 「フォルダーに表示」によるファイル選択や、複数タブの一括オープンにも対応

![ウィンドウをタブに変換](../Assets/WindowToTab.gif)
</details>

<details>
<summary><b>ブックマーク</b>（新機能）</summary>

- 現在のタブの場所をブックマークとして保存（ホットキーのアクション `BookmarkSave`）
- ブックマークバーのポップアップから開く（`BookmarkNavigate`）：クリックで現在のタブ、<kbd>Ctrl</kbd> で新しいタブ、<kbd>Shift</kbd> で新しいウィンドウ
- ブックマークマネージャー（`BookmarkManage`）：フォルダー、ドラッグ＆ドロップでの並べ替え、名前の変更、切り取り／コピー／貼り付け、検索、インポート／エクスポート
</details>

<details>
<summary><b>多言語 UI</b>（新機能）</summary>

- メインウィンドウで表示言語を選択。英語と簡体字中国語を同梱
- 言語ファイルは実行ファイルと同じ場所の `Languages` フォルダーにあります
</details>

<details>
<summary><b>現在のタブを複製</b></summary>

- 現在のタブ／ウィンドウを、タブまたは新しいウィンドウとして複製
- 場所と選択中の項目も引き継ぐ

![タブの複製](../Assets/DuplicateTab.gif)
</details>

<details>
<summary><b>閉じたタブを再び開く</b></summary>

- 最近閉じたタブ／ウィンドウを、場所と選択状態ごと復元
- 「閉じた履歴を保存」を有効にすると、アプリを再起動しても履歴が残る

![閉じたタブを再び開く](../Assets/ReopenClosedTab.gif)
</details>

<details>
<summary><b>以前のウィンドウを復元</b></summary>

- エクスプローラーのクラッシュ／再起動や PC の再起動後に、開いていたウィンドウを自動で復元（「以前のウィンドウを復元」）

![以前のウィンドウを復元](../Assets/RestorePrevious.png)
</details>

<details>
<summary><b>切り離しとスナップ</b></summary>

- 現在のタブを新しいウィンドウに切り離し、画面の端にスナップ
- 1 つのホットキーで複数のプロファイルを連続実行でき、遅延も調整可能

![切り離しとスナップ](../Assets/DetachSnap.gif)
</details>

<details>
<summary><b>戻る・進む・上の階層へ</b></summary>

- カスタムホットキー、またはフォルダー内の空白部分のクリックで操作

![戻る](../Assets/NavigateBack.gif)
</details>

<details>
<summary><b>任意の場所を開く</b></summary>

- よく使うパス、環境変数を含むパス（`%USERPROFILE%\Downloads`）、シェルの CLSID、ファイル、URL にホットキーを割り当て

![任意の場所](../Assets/CustomLocation.gif)
</details>

<details>
<summary><b>タブ検索／切り替え</b></summary>

- フォルダー名やパスの一部を入力して、開いているタブをすばやく検索・切り替え
- <kbd>Shift</kbd> で新しいウィンドウ、<kbd>Ctrl</kbd> ですでに開いていても複製

![タブ検索](../Assets/TabSearch.gif)
</details>

<details>
<summary><b>Ctrl+Shift で新しいウィンドウを強制</b></summary>

- 場所を開くときに <kbd>Ctrl</kbd>+<kbd>Shift</kbd> を押しておくと、その 1 回だけタブ化せず新しいウィンドウで開く
</details>

## インストール

[最新リリース](https://github.com/warthurton/ExplorerTabPlus/releases/latest)からダウンロードしてください。

**インストーラー（おすすめ）：** `ExplorerTabUtility_<バージョン>_Setup.exe` が CPU に合ったビルドを自動で選びます。.NET 9 デスクトップ ランタイムが入っていない場合は、インストールするか .NET Framework 4.8.1 版を使うかを選べます。

**ポータブル zip：** ランタイムと CPU アーキテクチャで 1 つ選びます。

| ランタイム | ファイル名の末尾 | 必要なもの |
|---|---|---|
| .NET 9 | `_Net9.0_FrameworkDependent.zip` | [.NET 9 デスクトップ ランタイム](https://dotnet.microsoft.com/download/dotnet/9.0) |
| .NET Framework 4.8.1 | `_NetFW4.8.1.zip` | 追加不要（Windows 11 に標準搭載） |

| アーキテクチャ | 対象 |
|---|---|
| `x64` | ほとんどの Intel/AMD PC |
| `arm64` | ARM 版 Windows（Snapdragon など） |
| `x86` | 32 ビット版 Windows のみ |

好きな場所に展開して `ExplorerTabUtility.exe` を起動し、通知領域のアイコンを確認してください。

> [!NOTE]
> **元の Explorer Tab Utility からのアップグレード：** インストーラーを実行する（またはファイルを置き換える）だけです。実行ファイル名、設定フォルダー `%APPDATA%\ExplorerTabUtility\`、インストーラー ID は元のアプリと同じなので、その場でアップグレードされ設定も残ります。今後の更新はこのリポジトリから配信されます。

> [!WARNING]
> **リリースファイルはコード署名されていません。** Windows SmartScreen に「Windows によって PC が保護されました」と表示された場合は、「詳細情報」→「実行」を選んでください。元のアプリと同様に、キーボード／マウスのフックや COM 操作のため一部のウイルス対策ソフトが警告することがありますが、誤検知です。いつでも[ソースからビルド](#ソースからビルド)できます。

## 使い方

アプリは通知領域（システムトレイ）に常駐します。アイコンをダブルクリックまたは右クリックすると設定を開けます。

![トレイメニュー](../Assets/Menu.png)

**一般設定**

- **Window Hook** —— ウィンドウを自動でタブに変換
- **Reuse Tabs** —— 同じパスが開いていれば重複させずに切り替え
- **Keyboard Hook / Mouse Hook** —— ホットキーとマウス操作
- **Startup** —— Windows 起動時に開始
- 設定は `%APPDATA%\ExplorerTabUtility\settings.json` に保存されます。削除すると既定値に戻ります

**詳細設定：** 自動更新、カスタムテーマ使用時の別のウィンドウ非表示方式（「I have theme issues」）、閉じた履歴の保存、以前のウィンドウの復元、トレイアイコンの非表示（先に `ToggleVisibility` のホットキーを設定する必要があります）。

![詳細設定](../Assets/Preferences.png)

**ホットキープロファイル。** 各プロファイルには、ホットキー、適用範囲（グローバルまたはエクスプローラーのみ）、アクション、任意のパス、遅延、そしてキー入力を他のアプリに渡すかどうかを決める「Handled」スイッチがあります。プロファイルはインポート／エクスポートできます。

| アクション | 動作 |
|---|---|
| `Open` | 指定した場所を開く（パスが空なら新しいタブ） |
| `Duplicate` | 現在のタブを複製 |
| `ReopenClosed` | 最後に閉じた場所を再び開く |
| `TabSearch` | タブ検索ポップアップを開く |
| `NavigateBack` / `NavigateForward` / `NavigateUp` | 現在のタブで戻る／進む／上の階層へ |
| `SetTargetWindow` | 現在のウィンドウを新しいタブの追加先に設定 |
| `ToggleWinHook` / `ToggleReuseTabs` / `ToggleVisibility` | 機能のオン／オフ、メインウィンドウの表示切り替え |
| `DetachTab` | 現在のタブを新しいウィンドウに移動 |
| `SnapRight` / `SnapLeft` / `SnapUp` / `SnapDown` | 現在のウィンドウをスナップ |
| `BookmarkSave` / `BookmarkNavigate` / `BookmarkManage` | ブックマークの保存・移動・管理（新機能） |

既定のプロファイル：<kbd>Win</kbd>+<kbd>E</kbd> でホームを開く、<kbd>Ctrl</kbd>+<kbd>D</kbd> でタブを複製、<kbd>Ctrl</kbd>+<kbd>Shift</kbd>+<kbd>T</kbd> で最後に閉じたタブを再び開く。

![ホットキープロファイル](../Assets/Form.png)

## ソースからビルド

必要なもの：Windows、「.NET デスクトップ開発」ワークロードを含む Visual Studio 2022（または Build Tools）、.NET 9 SDK。COM 参照（`Shell32`、`SHDocVw`）を使っているため、フル版の **MSBuild** でビルドする必要があります。`dotnet build` だけでは `MSB4803` エラーになります。

```powershell
git clone https://github.com/warthurton/ExplorerTabPlus.git
cd ExplorerTabPlus
msbuild ExplorerTabUtility/ExplorerTabUtility.csproj /restore /p:Configuration=Release /p:TargetFramework=net9.0-windows
# または /p:TargetFramework=net481
```

ナビゲーションの回帰テスト（PR #142 由来）：`dotnet run --project tests/NavigationCompletion.Tests.csproj -c Release`

## クレジット

- **[@w4po](https://github.com/w4po)**（Abd-Alrahman Ghanem）氏 —— [Explorer Tab Utility](https://github.com/w4po/ExplorerTabUtility) の原作者で、中核部分はすべて氏の仕事です。役に立ったら、ぜひ[スポンサー](https://github.com/sponsors/w4po)をご検討ください。
- このフォークにマージしたプルリクエストの作者：
  [@taroyamadax](https://github.com/taroyamadax)（#139）、
  [@youncyb](https://github.com/youncyb)（#137）、
  [@yueyangcode](https://github.com/yueyangcode)（#142）、
  [@aiolosking](https://github.com/aiolosking)（#144）、
  [@NeedJustWord](https://github.com/NeedJustWord)（#131、#140）
- 使用ライブラリ：[H.Hooks](https://github.com/HavenDV/H.Hooks)、[Hardcodet.NotifyIcon.Wpf](https://github.com/hardcodet/wpf-notifyicon)、[AutoUpdater.NET](https://github.com/ravibpatel/AutoUpdater.NET)、[gong-wpf-dragdrop](https://github.com/punker76/gong-wpf-dragdrop)

不具合報告やプルリクエストは[このリポジトリの Issues](https://github.com/warthurton/ExplorerTabPlus/issues) へどうぞ。

## ライセンス

元のプロジェクトと同じく [MIT](../LICENSE) です。原著作権は w4po 氏に帰属します。
