ソフトの概要
	Codeer.Friendlyの上位ライブラリです。
	.Netの基本的なコントロールの操作するための機能が定義されています。
	詳細な情報は以下のサイトを参照お願いします。
	http://onigiri-soft.com/

作者への連絡先
	info@onigiri-soft.com

取り扱い種別
	無料ソフトです。
	ただし、以下のソフトウェア使用許諾契約に同意お願いします。

ソフトウェア使用許諾契約
	onigiri-soft（以下、「弊社」といいます。）は、お客様が以下のソフトウェア使用許諾契約（以下「本契約」といいます。）
	に同意いただける場合にかぎり、Ong.Friendly.FormsStandardControl_V1.7.1にてインストールされる全てのソフトウェア
	（以下、「本ソフトウェア」といいます。）の使用を許諾いたします。

	①本ソフトウェアは商用利用可能です。
	②本ソフトウェアは再配布可能です。
	③本ソフトウェアは、お客様の開発するソフトウェアをテスト、デバッグすることを目的とします。目的外の使用を禁止します。
	④本ソフトウェアをインストール、および利用することによって生じる、あらゆる現象、あらゆる損害に関して、弊社は一切責任を負いません。
	⑤本ソフトウェアは本ソフトウェアにより、お客様もしくは第三者の特許を侵害しない地域でのみ、インストール、および使用可能です。
	⑥本契約は、日本国法に準拠するものとします。

事前にGAC登録の必要があるもの
	Codeer.Friendly.dll(1.7.0.0)
	Codeer.Friendly.Windows.dll(1.7.0.0)
	Codeer.Friendly.Windows.Grasp.dll(1.7.0.0)	
	（CodeerFriendlyAndToolsV1.7をインストールしていれば、GAC登録されています。)

動作環境
	対応OS
		WindowsXP,WindowsVista,Windows7,Windows8
	Windows8にインストールされる場合
		事前に.netframework3.5を有効にしてください。
		コントロールパネル→プログラム→Windowsの機能の有効化または無効化から有効にできます。）
		無効のままインストールすると、.netframework2.0がインストールされます。
	.netframework4.0以上のアプリケーションをテストされる場合
		「Visual C++ 2010 ランタイムライブラリ」が必要となります。
		インストールされていない場合はマイクロソフトのサイトから「Microsoft Visual C++ 2010 再頒布可能パッケージ (x86)」をダウンロードしてインストールしてください。
		64bitOSの場合は,x64とx86の両方をインストールしてください。
		（サービスパックのあたっているものと、そうでないものがあり、どちらを使用するかはお客様の選択に委ねます。）

インストール方法
	setup.exeを起動してインストールしてください。

TestAssistantへのプラグイン方法
	このインストーラではTestAssistant1.7にプラグインも実施します。
	しかし、TestAssistantをデフォルト以外のフォルダにインストールされているお客様に関しては正しくプラグインされない可能性があります。
	その場合は、手動でTestAssistantのインストールフォルダに以下のファイルをコピーしてください。
	プラグインに関する詳細はCodeer.Friendly提供元のサイト情報を参照お願いします。
	http://www.codeer.co.jp/

	・Ong.Friendly.FormsStandardControls.dll
		\Codeer\TestAssistant\v1.7.0.0\Ong.Friendly.FormsStandardControls.dll
	・Codeer.Friendly.FormsStandardControls.Plugin.xml
		\Codeer\TestAssistant\v1.7.0.0\Plugin\Ong.Friendly.FormsStandardControls.Plugin.xml


アンインストール方法
	『プログラムの追加と削除』からOng.Friendly.FormsStandardControl_V1.7.1を削除してください。
