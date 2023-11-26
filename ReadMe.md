# 初期サウンド再生プラグイン
BVE起動時から[任意サウンド]を[任意キーが押されるまで]鳴らし続けるプラグイン

## つかいかた
0. DL後、zipファイルまたはdllファイルの「ゾーン識別子」を削除してください。(ファイルプロパティ内)
1. dllファイルと同一名称(拡張子より前)のiniファイル内を下記指定してください。
2. 上dllファイルとiniファイルは同一階層に格納してください。
3. DetailManager.dll(detailmodules.txt)にてdllへパスを通してください。

iniファイルでの設定項目
[任意サウンド]
　[ATS]サウンドインデックス20番
[任意キー]
　[Key H] デフォルトはD6(数字キーの6)（指定可能キー:S,A1,A2,B1,B2,C1,C2,D,E,F,G,H,I,J,K,L)

> [!WARNING]
> `ご使用は自己責任でお願いいたします。本内容による損害等については一切の責任を負いません。`

## 謝辞
本プラグインはTstsuOtter様のBVE_ATSPITempを使用して記述しております。  
BVE_ATSPITemp(https://github.com/TetsuOtter/BVE_ATSPITemp)
厚く御礼申し上げます。
