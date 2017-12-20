# git 取り消し関係
## git reset
### 言葉の定義
- ワーキングツリー[working tree]：最新のファイルの状態
- インデックス[index]（ステージ[stage]）：コミットするためのファイルの状態
- ローカルリポジトリ[local repository]：ファイルの変更履歴を記録（手元で管理）
- ヘッド[HEAD]：最新のコミットの状態
- リモートリポジトリ[remote repository]：ファイルの変更履歴を記録（みんなで共有）

###  基本コマンドの意味
- `add`:ワーキングツリー⇨インデックス
- `commit`:インデックス⇨ローカルリポジトリ 
- `push`:ローカルリポジトリ⇨リモートリポジトリ

### git resetのオプション
- `--hard`：「HEADの位置・インデックス・ワーキングツリー」全て
- `--mixed`（or オプション無し）：「HEADの位置・インデックス」
- `--soft`：「HEADの位置」のみ

### 流れ
- ファイルを変更するとワーキングツリーが変更(ファイルもどきみたいな)
- `add`するとインデックスが変更
- `commit`するとHEAD(最新コミットの記録)が一つ前に進む：変更の確定

### git resetの使い方
`add`や`commit`を取り消したい場合に`reset`を使う．
- `reset --hard`：全部元にに戻す．
- `reset --mixed`：commitとaddの取り消し．
- `reset --soft`：commitのみ取り消し．

## 実際に使う場面
### 直前のコミットのみを取り消したい．(コミット自体を消す)
```
$ git reset --soft HEAD^
```
`HEAD^`(一つ前のコミット)からの`--soft`(コミット)を`reset`(取り消し)て，HEADの位置を`HEAD^`に戻す．現在のHEADは`HEAD`．
- `HEAD^`：直前のコミットを意味する．
- `@^`、`HEAD~`も同じ意味．
- `HEAD~{n}` ：n個前のコミットを意味する．
- `HEAD^`や`HEAD~{n}`の代わりにコミットのハッシュ値を書いても良い．
- gitのv1.8.5からは、「`HEAD`」のエイリアスとして「`＠`」が用意されている．
- `HEAD^^^`と`HEAD~3`と`HEAD~~~`と`HEAD~{3}`と`@^^^`は同じ意味．
- `--soft`なので、インデックス・ワーキングツリーはそのまま．
上書きコミットしたいなら、`git commit --amend`を使うとラク！
### 直前のコミットをまるっと消したい．
```
$ git reset --hard HEAD^
```
- `--hard`なので`add`も`変更内容(ワーキングツリー)`も消える．
### コミット後の変更を消したい．(直前のコミット後の変更からまだ`git commit` してない)
```
$ git reset --hard HEAD
```

### コミット後のaddを消したい．
```
$ git reset --mixed HEAD
```
または，
```
$ git reset HEAD
```

### 昔の状態で動作を確認したい
```
$ git reset --hard 昔のコミットのハッシュ値
```
`--hard`で全て消えてしまうのでこれをやる前に`push`しておくべき．
動作確認後，最新の状態に戻すには，
```
$ git reset --hard ORIG_HEAD
```
- `reset`の `reset`:リセットをなかったことにする．
- `git reset`が相対的に未来の状態に行けることを示している．
- `git reset --hard 最新のコミットのハッシュ値`または`git rebase origin/master`でも良い．