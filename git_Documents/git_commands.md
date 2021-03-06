# ローカルでの作業
いざ，共同開発を始めよう!
えっとまずどうすればいいか...
ローカルリポジトリを作成してリモートと紐づける．
- 基本 : git clone 
- git init + git pull

## git clone
クローンしたローカルリポジトリは変更履歴も複製されているので、
元々のリポジトリと全く同じように履歴の参照やコミットをすることが
できます。

`git clone`は`git init`と`git pull`の両方やってくれるので基本は`git clone`で良いかと．

```
$ cd <作業ディレクトリ>
$ git clone <リポジトリのアドレス> (<ディレクトリ名>)
```
上のコマンドで作業ディレクトリ配下にリモートリポジトリのコピー(ローカルリポジトリ)ができる．
名前を指定すると，その名前のディレクトリになる．

これで一応作業の準備はできた!!
共同作業の時には他にも気をつけるところはあるけど，とりあえず流れだけを確認．

作業を始める前に，自分のローカルリポジトリを**最新版に更新**しておかないといけない．
あとで出てくるけど，**競合**っていう問題が発生する原因になるので．

よって，**リモートリポジトリの内容を取り込む作業**が必要．それが`git pull`

### git pull
リモートリポジトリの内容でローカルリポジトリを更新する．
基本的には作業前にリモートリポジトリの内容を`pull`する．
```
$ git pull origin master

* branch            master     -> FETCH_HEAD
Updating b3ca6aa..ca605aa
Fast-forward
 README.md | 3 +++
 1 file changed, 3 insertions(+) #変更内容が出力される．
```
上のコマンドでリモートリポジトリの`masterブランチ`の内容が反映される．
`origin`がリモートリポジトリを表している．
`リモートリポジトリのmasterブランチをpullしますよ`という指示．

今度こそ作業の準備ができたので機能開発に移れる．


<ローカルで作業しました>


作業を完了したらそれをリモートに反映させたい．
反映させる手順としては`add`して`commit`して`push`する．
## git add 
意味的にはファイルをgitの管理の対象に入れますよ〜っていう宣言みたいなもの．
`インデックスにステージする`っていう言い方もする．

```
$ git add <ファイル名> 
```
で，特定のファイルだけを`add`できる．
でも，基本的には
```
$ git add . 
```
ってすると今のブランチ上の作業分が全てステージされるので楽．
ステージ後に，`git commit`ができるようになる．

## git commit 
ステージされたファイルをローカルリポジトリに登録する．

```
$ git commit -m '〇〇を変更'
```
`-m 'コメント'`をつけるとコメントも同時に登録できる．
逆に，つけないと画面切り替わってコメントつけるように要求される．

コミットしたのでようやくpushできるぞ
## git push
ローカルリポジトリにcommitされた変更を**リモートリポジトリに反映**する．
```
$ git push origin <現在作業しているブランチ名>

Counting objects: 6, done. 
Delta compression using up to 4 threads.
Compressing objects: 100% (6/6), done.
Writing objects: 100% (6/6), 12.07 KiB | 0 bytes/s, done.
Total 6 (delta 2), reused 0 (delta 0)
remote: Resolving deltas: 100% (2/2), completed with 2 local objects.
To https://github.com/zukako0930/git_tutorial.git
   3a91a73..265fd60  master -> master 
```
ブランチ名には現在作業しているブランチ名を入れる．
こうすることでリモートリポジトリ上に**プルリクエスト**を作ることができる．<br>
...なんでわざわざaddする必要があるの？ 
<br>![center 40%](./img/atama.jpg)


![60% center](./img/nagare.png)
<br>この図で登録にあたる部分が`add`
<br>`add`することで明示的にインデックスに追加されて`commit`できるようになる．
