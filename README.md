# XsReader
## What's this
XsReaderはポケットモンスター ブリリアントダイヤモンド・シャイニングパール(以下BDSP)における乱数調整ツールです.

このツールを用いてフィールド上での主人公の瞬きを観測することで,

- 基準seedの特定
- 基準seedからのadvance(どれだけ乱数が消費されたか)の特定
- タイムラインの生成
- 固定シンボルを考慮したタイムラインの生成

を行うことが出来ます.

このツールはPythonやJavaのように外部ランタイムを必要としません. 必要な実行環境は殆どのWindowsではデフォルトでインストールされています.

また, OBSなどのプレビュー画面越しに観測を行うためキャプチャーボードを占有することもありません. 

プロジェクト名である _Project_eXcelSior_ には, 拙作の[Project_Xs](https://github.com/niart120/Project_Xs)よりも利便性の高い乱数調整環境を提供するという願いを込めています.

## 使い方
TBA

## 使用ライブラリ
- OpenCV
- PokemonPRNGLibrary
- PokemonBDSPRNGLibrary
- Math.NET
- BlinkReaderLib

## 謝辞
ツール作成に当たって利用した各種ライブラリ製作者に御礼申し上げます.

特に, PokemonPRNGLibraryをはじめとするRNG関連のライブラリを整備してくださっている夜綱氏には開発中においてもいくつかご助言をいただきました. この場をお借りして改めて感謝申し上げます. 
