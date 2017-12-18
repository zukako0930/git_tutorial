using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OopLecture
{
    public partial class Form1 : Form
    {
        private Bitmap _bmp; //_bmpf;
        private Graphics _graphics; //_graphicsf;
        private Scene _scene;
        private Player _player;
        private List<Wall> _wall;
        private Goal _goal;
        private Hole _hole;
        private Stone _stone;
        private List<Enemy> _enemies;
        private List<Missile> _missiles;
        private List<Bomb> _bombs;
        private List<Keys> _pressedKeys;
        private int startx, starty;
        private List<String> code;
        private List<String> code_disp;
        private List<int> code_depth;
        private int size;



        enum Scene
        {
            Title,
            stage1,
            stage2,
            stage3,
            stage4,
            stage5,
            stage6,
            stage7,
            stage8,
            stage9,
            stage10,
            clear
        }
        public Form1()
        {
            InitializeComponent();

            size = 40;

            //picturebox1用の変数
            _bmp = new Bitmap(size * 20, size * 15); //ビットマップオブジェクトの生成
            _graphics = Graphics.FromImage(_bmp); //貼り付けるグラフィックの生成
            _graphics.Clear(Color.White);
            pictureBox1.Image = _bmp;

            timer1.Start();//速い
            timer2.Start();//遅い
            timer3.Start();//ゴーレム

            _wall = new List<Wall>();
            _enemies = new List<Enemy>();
            _missiles = new List<Missile>();
            _pressedKeys = new List<Keys>();
            _player = new Player(0, 0);
            _goal = new Goal(30, 0);
            _hole = new Hole(50, 0);
            _stone = new Stone(70, 0);
            _bombs = new List<Bomb>();
            _scene = Scene.Title;
            pictureBox1.BackgroundImage = Image.FromFile(@"./background/title.png");

            code = new List<string>();
            code_disp = new List<string>();
            code_depth = new List<int>();
            ConboBox_Initialize();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_pressedKeys.Contains(e.KeyCode)) _pressedKeys.Add(e.KeyCode);
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    _scene = Scene.Title;
                    pictureBox1.BackgroundImage = Image.FromFile(@"./background/title.png");
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            _pressedKeys.Remove(e.KeyCode);
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //それぞれのオブジェクトの動き方

            //勇者の動き
            _player.Player_Move(_pressedKeys, _wall);
            //goalについたらclear画面（次のステージに移る画面を作りたい）
            if (_player.Intersects(_goal))
            {
                _hole.IsAlive = true;
                _stone.IsAlive = true;
                _scene = Scene.clear;
                pictureBox1.BackgroundImage = Image.FromFile(@"./background/clear.png");
            }

            //holeに落ちたら勇者は死ぬ
            if (_player.Intersects(_hole) && _hole.IsAlive == true)
            {
                _player.Die();
                _player.X = startx;
                _player.Y = starty;
                _player.IsAlive = true;
                foreach (var missile in _missiles)
                {
                    missile.Missile_Restart();
                }
            }

            //bombに触れたら勇者は死ぬ
            foreach (var bomb in _bombs)
            {
                if (_player.Intersects(bomb) && bomb.IsAlive == true)
                {
                    _player.Die();
                    _player.X = startx;
                    _player.Y = starty;
                    _player.IsAlive = true;
                    foreach (var missile in _missiles)
                    {
                        missile.Missile_Restart();
                    }
                    break;
                }
            }

            //enemyに触れたら勇者は死ぬ
            foreach (var enemy in _enemies)
            {
                if (_player.Intersects(enemy) && enemy.IsAlive == true)
                {
                    _player.Die();
                    _player.X = startx;
                    _player.Y = starty;
                    _player.IsAlive = true;
                    foreach (var missile in _missiles)
                    {
                        missile.Missile_Restart();
                    }
                    break;
                }
            }

            //missileに触れたら勇者は死ぬ
            foreach (var missile in _missiles)
            {
                if (_player.Intersects(missile) && missile.IsAlive == true)
                {
                    _player.Die();
                    _player.X = startx;
                    _player.Y = starty;
                    _player.IsAlive = true;
                    missile.Missile_Restart();
                    foreach (var missile2 in _missiles)
                    {
                        missile2.Missile_Restart();
                    }
                    break;
                }
            }
            Draw_PictureBox1_Stage();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            foreach (var enemy in _enemies)
            {
                enemy.Enemy_Move(_hole.IsAlive);
            }

            foreach (var missile in _missiles)
            {
                missile.Missile_Move(_player.X, _player.Y, _wall, _player, _hole.IsAlive);
            }
            Draw_PictureBox1_Stage();
        }


        private void timer3_Tick(object sender, EventArgs e)
        {
            if (_stone.route.Count > 0)
            {
                _stone.Stone_Go();
                _stone.route.RemoveAt(0);
                if (_stone.Intersects(_hole)) _hole.Die();
                Draw_PictureBox1_Stage();
            }
            else if (!_stone.IsAlive && _hole.IsAlive)
            {
                _stone.Stone_Restart();
            }
        }


        private void Draw_PictureBox1_Stage()
        {
            //描画
            _graphics.Clear(Color.Transparent);

            if (!(_scene == Scene.Title || _scene == Scene.clear))
            {
                //穴
                if (_hole.IsAlive) _hole.Hole_Draw(_graphics);

                //ドラゴン
                foreach (var bomb in _bombs)
                {
                    if (bomb.IsAlive) bomb.Bomb_Draw(_graphics);
                }

                //ゴーレム
                _stone.Stone_Draw(_graphics);

                //鳥
                foreach (var enemy in _enemies)
                {
                    if (enemy.IsAlive) 
                    {
                        enemy.Enemy_Draw(_graphics);
                    }
                }

                //モンスター
                foreach (var missile in _missiles)
                {
                    if (missile.IsAlive)
                    {
                        missile.Missile_Draw(_graphics);
                    }
                }

                //勇者
                if (_player.IsAlive) _player.Player_Draw(_graphics);

                ////初期位置チェック用
                //_player.Draw(_graphics);
                //_hole.Draw(_graphics);
                //_goal.Draw(_graphics);
                //foreach (var wall in _wall)
                //{
                //    wall.Draw(_graphics);
                //}
                //foreach (var enemy in _enemies)
                //{
                //    if (enemy.IsAlive) enemy.Draw(_graphics);
                //}
            }
            pictureBox1.Image = _bmp;  //aru timer1 no bmp wo reflesh
            pictureBox1.Refresh();
        }


        private void Draw_ListBox1()
        {
            listBox1.Items.Clear();
            for (int i = 0; i < code_disp.Count; i++)
            {
                String dep_code = code_disp[i];
                for (int j = 0; j < code_depth[i]; j++)
                {
                    dep_code = "\t" + dep_code;
                }
                listBox1.Items.Add(dep_code);
            }
        }




        /// <summary>
        /// ここからコード読み込み＆ボタン処理関連///
        /// </summary>

        private int count = 0;
        List<int> keep = new List<int>();
        private bool[] if_flag;
        private void Code_Read(int index, int loop, List<int[]> range)
        {
            keep.Add(count);
            for (int i = 0; i < loop; i++)
            {
                count = keep[keep.Count - 1];
                if (!_stone.IsAlive) break;
                for (int j = range[index][0] + 2; j < range[index][1]; j++)
                {
                    if (!_stone.IsAlive) break;
                    switch (code[j])
                    {
                        case "for":
                            count++;
                            Code_Read(count, int.Parse(code[j + 1]), range);
                            j = range[count][1];
                            break;
                        case "if":
                            count++;
                            Code_If(count, code[j + 1], range, code_depth);
                            j = range[count][1];
                            break;
                        default:
                            switch (code[j])
                            {
                                case "walk":
                                    _stone.Stone_Move(_wall, _bombs, _missiles, _hole);
                                    break;
                                case "back":
                                    _stone.Stone_Turn(2);
                                    break;
                                case "right":
                                    _stone.Stone_Turn(1);
                                    break;
                                case "left":
                                    _stone.Stone_Turn(3);
                                    break;
                                default: break;
                            }
                            break;
                    }
                }
                if_flag[code_depth[(range[index][1] - 2) / 2]] = false;//forによるif判定のreset
            }
            keep.RemoveAt(keep.Count - 1);
        }

        private void ConboBox_Initialize()
        {
            comboBox_if.Items.Add("前がかべなら");
            comboBox_if.Items.Add("前が敵なら");
            comboBox_if.Items.Add("前が道なら");
            comboBox_if.Items.Add("左がかべなら");
            comboBox_if.Items.Add("左が敵なら");
            comboBox_if.Items.Add("左が道なら");
            comboBox_if.Items.Add("後ろがかべなら");
            comboBox_if.Items.Add("後ろが敵なら");
            comboBox_if.Items.Add("後ろが道なら");
            comboBox_if.Items.Add("右がかべなら");
            comboBox_if.Items.Add("右が敵なら");
            comboBox_if.Items.Add("右が道なら");
            comboBox_if.SelectedIndex = 0;
        }

        private void Code_If(int index, String order, List<int[]> range, List<int> code_depth)//仮/////////////////////////////////////////
        {
            int if_depth = code_depth[range[index][0] / 2]; ////////////////////////ifの階層
            switch (order)
            {
                case "i0":
                    if (_stone.Around_Check(_wall, _bombs, _missiles, 0) == 1 && !if_flag[if_depth])
                    {
                        Code_Read(index, 1, range);
                        if_flag[if_depth] = true;
                    }
                    break;
                case "i1":
                    if (_stone.Around_Check(_wall, _bombs, _missiles, 0) == 2 && !if_flag[if_depth])
                    {
                        Code_Read(index, 1, range);
                        if_flag[if_depth] = true;
                    }
                    break;
                case "i2":
                    if (_stone.Around_Check(_wall, _bombs, _missiles, 0) == 0 && !if_flag[if_depth])
                    {
                        Code_Read(index, 1, range);
                        if_flag[if_depth] = true;
                    }
                    break;
                case "i3":
                    if (_stone.Around_Check(_wall, _bombs, _missiles, 3) == 1 && !if_flag[if_depth])
                    {
                        Code_Read(index, 1, range);
                        if_flag[if_depth] = true;
                    }
                    break;
                case "i4":
                    if (_stone.Around_Check(_wall, _bombs, _missiles, 3) == 2 && !if_flag[if_depth])
                    {
                        Code_Read(index, 1, range);
                        if_flag[if_depth] = true;
                    }
                    break;
                case "i5":
                    if (_stone.Around_Check(_wall, _bombs, _missiles, 3) == 0 && !if_flag[if_depth])
                    {
                        Code_Read(index, 1, range);
                        if_flag[if_depth] = true;
                    }
                    break;
                case "i6":
                    if (_stone.Around_Check(_wall, _bombs, _missiles, 2) == 1 && !if_flag[if_depth])
                    {
                        Code_Read(index, 1, range);
                        if_flag[if_depth] = true;
                    }
                    break;
                case "i7":
                    if (_stone.Around_Check(_wall, _bombs, _missiles, 2) == 2 && !if_flag[if_depth])
                    {
                        Code_Read(index, 1, range);
                        if_flag[if_depth] = true;
                    }
                    break;
                case "i8":
                    if (_stone.Around_Check(_wall, _bombs, _missiles, 2) == 0 && !if_flag[if_depth])
                    {
                        Code_Read(index, 1, range);
                        if_flag[if_depth] = true;
                    }
                    break;
                case "i9":
                    if (_stone.Around_Check(_wall, _bombs, _missiles, 1) == 1 && !if_flag[if_depth])
                    {
                        Code_Read(index, 1, range);
                        if_flag[if_depth] = true;
                    }
                    break;
                case "i10":
                    if (_stone.Around_Check(_wall, _bombs, _missiles, 1) == 2 && !if_flag[if_depth])
                    {
                        Code_Read(index, 1, range);
                        if_flag[if_depth] = true;
                    }
                    break;
                case "i11":
                    if (_stone.Around_Check(_wall, _bombs, _missiles, 1) == 0 && !if_flag[if_depth])
                    {
                        Code_Read(index, 1, range);
                        if_flag[if_depth] = true;
                    }
                    break;
                default:
                    break;
            }
        }

        private void button_execution_Click(object sender, EventArgs e)
        {
            List<int> task = new List<int>();
            List<int[]> range = new List<int[]>();
            for (int i = 0; i < code.Count; i++)
            {
                switch (code[i])
                {
                    case "start":
                    case "for":
                    case "if":
                        int[] pair = new int[2];
                        range.Add(pair);
                        task.Add(range.Count - 1);
                        range[task[task.Count - 1]][0] = i;
                        break;
                    case "end":
                    case "for_end":
                    case "if_end":
                        range[task[task.Count - 1]][1] = i;
                        task.RemoveAt(task.Count - 1);
                        break;
                    default:
                        break;
                }
            }
            if (Error_Check(range))
            {
                if_flag = new bool[range.Count + 1];
                Code_Read(count, 1, range);
                if (_stone.route.Count > 0)
                {
                    _stone.Stone_Go();
                }
                count = 0;
                code.Clear();
                code_depth.Clear();
                code_disp.Clear();
                Draw_ListBox1();
            }
        }
        private bool Error_Check(List<int[]> range)
        {
            if (code.Count <= 0)
            {
                return false;
            }
            else if (code[0] != "start")
            {
                MessageBox.Show("一行目は「スタート」から始めよう。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (code[code.Count - 2] != "end")
            {
                MessageBox.Show("最後は「エンド」で終わろう。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                for (int i = 0; i < range.Count; i++)
                {
                    switch (code[range[i][0]])
                    {
                        case "start":
                            if (code[range[i][1]] != "end")
                            {
                                MessageBox.Show("「スタート」と「エンド」の範囲を確認しよう！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            break;
                        case "for":
                            if (code[range[i][1]] != "for_end")
                            {
                                MessageBox.Show("「くり返し」の範囲を確認しよう！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            break;
                        case "if":
                            if (code[range[i][1]] != "if_end")
                            {
                                MessageBox.Show("「もし」の範囲を確認しよう！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return true;
        }

        private int depth = 0;
        private void button_delete_Click(object sender, EventArgs e)
        {
            if (code.Count >= 2)
            {
                switch (code[code.Count - 2])
                {
                    case "start":
                        depth--;
                        break;
                    case "for":
                        depth--;
                        break;
                    case "if":
                        depth--;
                        break;
                    case "end":
                        depth++;
                        break;
                    case "for_end":
                        depth++;
                        break;
                    case "if_end":
                        depth++;
                        break;
                    default:
                        break;
                }
                code.RemoveAt(code.Count - 1);
                code.RemoveAt(code.Count - 1);
                code_disp.RemoveAt(code_disp.Count - 1);
                code_depth.RemoveAt(code_depth.Count - 1);
            }
            Draw_ListBox1();
        }


        private void button_start_Click(object sender, EventArgs e)
        {
            code_depth.Add(depth);
            code.Add("start");
            code.Add("");
            code_disp.Add("スタート");
            depth++;
            Draw_ListBox1();
        }
        private void button_end_Click(object sender, EventArgs e)
        {
            if (depth > 0)
            {
                depth--;
                code_depth.Add(depth);
                code.Add("end");
                code.Add("");
                code_disp.Add("エンド");
                Draw_ListBox1();
            }
        }

        private void button_if_Click(object sender, EventArgs e)
        {
            code_depth.Add(depth);
            code.Add("if");
            code.Add("i" + comboBox_if.SelectedIndex.ToString());
            code_disp.Add("もし" + comboBox_if.Text);
            depth++;
            Draw_ListBox1();
        }
        private void button_if_end_Click(object sender, EventArgs e)
        {
            if (depth > 0)
            {
                depth--;
                code_depth.Add(depth);
                code.Add("if_end");
                code.Add("");
                code_disp.Add("もし（終わり）");
                Draw_ListBox1();
            }
        }

        private void button_loop_Click(object sender, EventArgs e)
        {
            code_depth.Add(depth);
            code.Add("for");
            code.Add(numericUpDown1.Value.ToString());
            code_disp.Add("くり返し" + "　" + numericUpDown1.Value.ToString() + "回");
            depth++;
            Draw_ListBox1();
        }

        private void button_loop_end_Click(object sender, EventArgs e)
        {
            if (depth > 0)
            {
                depth--;
                code_depth.Add(depth);
                code.Add("for_end");
                code.Add("");
                code_disp.Add("くり返し（終わり）");
                Draw_ListBox1();
            }
        }

        private void button_walk_Click(object sender, EventArgs e)
        {
            code_depth.Add(depth);
            code.Add("walk");
            code.Add("");
            code_disp.Add("前に進む");
            Draw_ListBox1();
        }

        private void button_left_Click(object sender, EventArgs e)
        {
            code_depth.Add(depth);
            code.Add("left");
            code.Add("");
            code_disp.Add("左を向く");
            Draw_ListBox1();
        }

        private void button_right_Click(object sender, EventArgs e)
        {
            code_depth.Add(depth);
            code.Add("right");
            code.Add("");
            code_disp.Add("右を向く");
            Draw_ListBox1();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            code_depth.Add(depth);
            code.Add("back");
            code.Add("");
            code_disp.Add("後ろを向く");
            Draw_ListBox1();
        }

        ///////ここからステージ作り///////
        private void button_stage1_Click(object sender, EventArgs e)
        {
            _scene = Scene.stage1;
            _wall.Clear();
            _hole.IsAlive = true;
            _stone.IsAlive = true;

            //player
            startx = size * 1 + 5;
            starty = size * 8 + 5;
            _player = new Player(startx, starty);

            //Wall
            for (int i = 0; i < pictureBox1.Width / size; i++)
            {
                for (int j = 0; j < pictureBox1.Height / size; j++)
                {
                    if (j == 6 || j == 7 || j == 8) // 通路分
                    {
                        continue;
                    }
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            _wall.Add(new Wall(size * 0, size * 6));
            _wall.Add(new Wall(size * 0, size * 7));
            _wall.Add(new Wall(size * 0, size * 8));
            _wall.Add(new Wall(size * 18, size * 6));
            _wall.Add(new Wall(size * 18, size * 7));
            _wall.Add(new Wall(size * 18, size * 8));
            _wall.Add(new Wall(size * 19, size * 6));
            _wall.Add(new Wall(size * 19, size * 7));
            _wall.Add(new Wall(size * 19, size * 8));
            _wall.Add(new Wall(size * 7, size * 6));
            _wall.Add(new Wall(size * 7, size * 7));
            _wall.Add(new Wall(size * 8, size * 6));
            _wall.Add(new Wall(size * 8, size * 7));

            //goal
            _goal = new Goal(size * 16, size * 7);

            //hole
            _hole = new Hole(size * 7, size * 8);

            //stone
            _stone = new Stone(size * 8, size * 8);

            //bomb
            _bombs = new List<Bomb>();

            //enemy
            _enemies = new List<Enemy>();
            _enemies.Add(new Enemy(size * 4, size * 6, 2, 2, 0));

            //missile
            _missiles = new List<Missile>();
            _missiles.Add(new Missile(size * 9, size * 6, size * 9, size * 6, size * 9, size * 3, 1));

            //background
            pictureBox1.BackgroundImage = Image.FromFile(@"./background/stage_1.png");
        }

        private void button_stage2_Click(object sender, EventArgs e)
        {
            _wall.Clear();
            _scene = Scene.stage2;
            _hole.IsAlive = true;
            _stone.IsAlive = true;

            //player
            startx = size * 6 + 5;
            starty = size * 4 + 5;
            _player = new Player(startx, starty);

            //Wall
            for (int i = 0; i <= 19; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            for (int i = 15; i <= 19; i++)
            {
                for (int j = 4; j <= 9; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            for (int i = 0; i <= 19; i++)
            {
                for (int j = 10; j <= 14; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            for (int i = 7; i <= 14; i++)
            {
                _wall.Add(new Wall(size * i, size * 4));
            }
            for (int i = 7; i <= 10; i++)
            {
                _wall.Add(new Wall(size * i, size * 5));
            }
            _wall.Add(new Wall(size * 7, size * 6));
            for (int i = 5; i <= 7; i++)
            {
                for (int j = 7; j <= 8; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            for (int i = 11; i <= 12; i++)
            {
                _wall.Add(new Wall(size * i, size * 7));
            }
            for (int i = 9; i <= 14; i++)
            {
                for (int j = 8; j <= 9; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }

            //goal
            _goal = new Goal(size * 14, size * 7);
            //hole
            _hole = new Hole(size * 7, size * 9);
            //stone
            _stone = new Stone(size * 8, size * 8);

            //bomb
            _bombs = new List<Bomb>();

            //enemy
            _enemies = new List<Enemy>();
            _enemies.Add(new Enemy(size * 5, size * 4, 2, 2, 0, 3));

            //missile
            _missiles = new List<Missile>();
            _missiles.Add(new Missile(size * 13 + 10, size * 7 + 10, size * 10, size * 5, size * 5, size * 3, 0));

            //background
            pictureBox1.BackgroundImage = Image.FromFile(@"./background/stage_2.png");
        }


        private void button_stage3_Click(object sender, EventArgs e)
        {
            _wall.Clear();
            _scene = Scene.stage3;
            _hole.IsAlive = true;
            _stone.IsAlive = true;

            //player
            startx = size * 1 + 5;
            starty = size * 7 + 5;
            _player = new Player(startx, starty);

            //Wall
            for (int i = 0; i <= 19; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            for (int i = 0; i <= 19; i++)
            {
                for (int j = 9; j <= 14; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            for (int j = 6; j <= 8; j++)
            {
                _wall.Add(new Wall(0, size * j));
            }
            for (int j = 6; j <= 8; j++)
            {
                _wall.Add(new Wall(size * 19, size * j));
            }
            _wall.Add(new Wall(size * 18, size * 6));
            _wall.Add(new Wall(size * 18, size * 8));

            //goal
            _goal = new Goal(size * 18, size * 7);
            //hole
            _hole = new Hole(size * 17, size * 7);
            //stone
            _stone = new Stone(size * 3, size * 7);

            //bomb
            _bombs = new List<Bomb>();

            //enemy
            _enemies = new List<Enemy>();
            _enemies.Add(new Enemy(size * 1, size * 6, 16, 0, 0));
            _enemies.Add(new Enemy(size * 1, size * 8, 16, 0, 0));

            //missile
            _missiles = new List<Missile>();

            //background
            pictureBox1.BackgroundImage = Image.FromFile(@"./background/stage_3.png");
        }


        private void button_stage4_Click(object sender, EventArgs e)
        {
            _wall.Clear();
            _scene = Scene.stage4;
            _hole.IsAlive = true;
            _stone.IsAlive = true;

            //player
            startx = size * 7 + 5;
            starty = size * 7 + 5;
            _player = new Player(startx, starty);

            //Wall
            for (int i = 0; i <= 19; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            for (int i = 0; i <= 19; i++)
            {
                for (int j = 9; j <= 14; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            for (int i = 0; i <= 6; i++)
            {
                for (int j = 6; j <= 8; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }

            for (int i = 15; i <= 19; i++)
            {
                for (int j = 6; j <= 8; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            _wall.Add(new Wall(size * 14, size * 6));
            _wall.Add(new Wall(size * 14, size * 8));

            //goal
            _goal = new Goal(size * 14, size * 7);
            //hole
            _hole = new Hole(size * 13, size * 7);
            //stone
            _stone = new Stone(size * 9, size * 7);

            //bomb
            _bombs = new List<Bomb>();
            _bombs.Add(new Bomb(size * 12, size * 7));

            //enemy
            _enemies = new List<Enemy>();

            //missile
            _missiles = new List<Missile>();

            //background
            pictureBox1.BackgroundImage = Image.FromFile(@"./background/stage_4.png");
        }



        private void button_stage5_Click(object sender, EventArgs e)
        {
            _wall.Clear();
            _scene = Scene.stage5;
            _hole.IsAlive = true;
            _stone.IsAlive = true;

            //player
            startx = size * 2 + 5;
            starty = size * 11 + 5;
            _player = new Player(startx, starty);

            //Wall
            for (int i = 0; i <= 19; i++)
            {
                _wall.Add(new Wall(size * i, size * 0));
            }
            for (int i = 0; i <= 13; i++)
            {
                _wall.Add(new Wall(size * i, size * 1));
            }
            for (int i = 15; i <= 19; i++)
            {
                _wall.Add(new Wall(size * i, size * 1));
            }
            for (int i = 0; i <= 19; i++)
            {
                for (int j = 13; j <= 14; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            for (int i = 0; i <= 12; i++)
            {
                for (int j = 2; j <= 9; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }

            for (int i = 16; i <= 19; i++)
            {
                for (int j = 2; j <= 12; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            for (int i = 0; i <= 1; i++)
            {
                for (int j = 10; j <= 12; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            _wall.Add(new Wall(size * 15, size * 11));


            //goal
            _goal = new Goal(size * 14, size * 1);
            //hole
            _hole = new Hole(size * 14, size * 2);
            //stone
            _stone = new Stone(size * 4, size * 11);

            //bomb
            _bombs = new List<Bomb>();

            //enemy
            _enemies = new List<Enemy>();

            //missile
            _missiles = new List<Missile>();
            _missiles.Add(new Missile(size * 13, size * 2, size * 13, size * 2, size * 3, size * 8, 0));
            _missiles.Add(new Missile(size * 15 + 10, size * 2, size * 13, size * 2, size * 3, size * 4, 0));
            _missiles.Add(new Missile(size * 13, size * 12 + 10, size * 13, size * 3, size * 3, size * 7, 1));
            _missiles.Add(new Missile(size * 15 + 10, size * 12 + 10, size * 13, size * 3, size * 3, size * 7, 1));

            //background
            pictureBox1.BackgroundImage = Image.FromFile(@"./background/stage_5.png");
        }

        private void button_stage6_Click(object sender, EventArgs e)
        {
            _wall.Clear();
            _scene = Scene.stage6;
            _hole.IsAlive = true;
            _stone.IsAlive = true;

            //player
            startx = size * 4 + 5;
            starty = size * 13 + 5;
            _player = new Player(startx, starty);

            //Wall
            for (int i = 0; i <= 19; i++)
            {
                _wall.Add(new Wall(size * i, size * 0));
            }
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 1; j <= 14; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            for (int i = 18; i <= 19; i++)
            {
                for (int j = 1; j <= 14; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }

            for (int i = 3; i <= 17; i++)
            {
                _wall.Add(new Wall(size * i, size * 14));
            }
            for (int i = 3; i <= 15; i++)
            {
                _wall.Add(new Wall(size * i, size * 11));
            }
            for (int j = 3; j <= 10; j++)
            {
                _wall.Add(new Wall(size * 15, size * j));
            }
            for (int i = 5; i <= 14; i++)
            {
                _wall.Add(new Wall(size * i, size * 3));
            }
            for (int j = 4; j <= 8; j++)
            {
                _wall.Add(new Wall(size * 5, size * j));
            }
            for (int i = 6; i <= 9; i++)
            {
                _wall.Add(new Wall(size * i, size * 8));
            }
            for (int i = 10; i <= 12; i++)
            {
                for (int j = 6; j <= 8; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            _wall.Add(new Wall(size * 8, size * 6));
            _wall.Add(new Wall(size * 9, size * 6));


            //goal
            _goal = new Goal(size * 9, size * 7);
            //hole
            _hole = new Hole(size * 7, size * 7);
            //stone
            _stone = new Stone(size * 6, size * 13);

            //bomb
            _bombs = new List<Bomb>();

            //enemy
            _enemies = new List<Enemy>();
            _enemies.Add(new Enemy(size * 13, size * 4, 0, 6, 1));

            //missile
            _missiles = new List<Missile>();
            _missiles.Add(new Missile(size * 9, size * 5, size * 0, size * 0, size * 20, size * 15, 2));
            _missiles.Add(new Missile(size * 17 + 10, size * 1, size * 16, size * 1, size * 2, size * 13, 2));
            _missiles.Add(new Missile(size * 3, size * 12, size * 5, size * 9, size * 13, size * 5, 2));

            //background
            pictureBox1.BackgroundImage = Image.FromFile(@"./background/stage_6_7_9.png");
        }

        private void button_stage7_Click(object sender, EventArgs e)
        {
            _wall.Clear();
            _scene = Scene.stage7;
            _hole.IsAlive = true;
            _stone.IsAlive = true;

            //player
            startx = size * 4 + 5;
            starty = size * 13 + 5;
            _player = new Player(startx, starty);

            //Wall
            for (int i = 0; i <= 19; i++)
            {
                _wall.Add(new Wall(size * i, size * 0));
            }
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 1; j <= 14; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            for (int i = 18; i <= 19; i++)
            {
                for (int j = 1; j <= 14; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }

            for (int i = 3; i <= 17; i++)
            {
                _wall.Add(new Wall(size * i, size * 14));
            }
            for (int i = 3; i <= 15; i++)
            {
                _wall.Add(new Wall(size * i, size * 11));
            }
            for (int j = 3; j <= 10; j++)
            {
                _wall.Add(new Wall(size * 15, size * j));
            }
            for (int i = 5; i <= 14; i++)
            {
                _wall.Add(new Wall(size * i, size * 3));
            }
            for (int j = 4; j <= 8; j++)
            {
                _wall.Add(new Wall(size * 5, size * j));
            }
            for (int i = 6; i <= 9; i++)
            {
                _wall.Add(new Wall(size * i, size * 8));
            }
            for (int i = 10; i <= 12; i++)
            {
                for (int j = 6; j <= 8; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            _wall.Add(new Wall(size * 8, size * 6));
            _wall.Add(new Wall(size * 9, size * 6));


            //goal
            _goal = new Goal(size * 9, size * 7);
            //hole
            _hole = new Hole(size * 7, size * 7);
            //stone
            _stone = new Stone(size * 6, size * 13);

            //bomb
            _bombs = new List<Bomb>();
            _bombs.Add(new Bomb(size * 3, size * 7));
            _bombs.Add(new Bomb(size * 7, size * 1));
            _bombs.Add(new Bomb(size * 9, size * 4));
            _bombs.Add(new Bomb(size * 14, size * 6));
            _bombs.Add(new Bomb(size * 17, size * 5));
            _bombs.Add(new Bomb(size * 11, size * 10));
            _bombs.Add(new Bomb(size * 10, size * 13));

            //enemy
            _enemies = new List<Enemy>();
            _enemies.Add(new Enemy(size * 16, size * 2, 0, 3, 1));
            _enemies.Add(new Enemy(size * 16, size * 6, 0, 3, 1));
            _enemies.Add(new Enemy(size * 4, size * 4, 0, 3, 1));
            _enemies.Add(new Enemy(size * 4, size * 7, 0, 3, 1));
            //missile
            _missiles = new List<Missile>();

            //background
            pictureBox1.BackgroundImage = Image.FromFile(@"./background/stage_6_7_9.png");
        }

        private void button_stage8_Click(object sender, EventArgs e)
        {
            _wall.Clear();
            _scene = Scene.stage8;
            _hole.IsAlive = true;
            _stone.IsAlive = true;

            //player
            startx = size * 1 + 5;
            starty = size * 13 + 5;
            _player = new Player(startx, starty);

            //Wall
            for (int i = 0; i <= 19; i++)
            {
                _wall.Add(new Wall(size * i, size * 0));
            }
            for (int i = 0; i <= 19; i++)
            {
                _wall.Add(new Wall(size * i, size * 14));
            }
            for (int i = 0; i <= 12; i++)
            {
                for (int j = 13 - i; j >= 1; j--)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            for (int i = 3; i <= 5; i++)
            {
                for (int j = 13 + 3 - i; j <= 13; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            for (int i = 6; i <= 9; i++)
            {
                for (int j = 10 + 6 - i; j <= 10; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            for (int i = 10; i <= 13; i++)
            {
                for (int j = 6 + 10 - i; j <= 6; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            for (int j = 12; j <= 13; j++)
            {
                _wall.Add(new Wall(size * 7, size * j));
            }
            for (int j = 11; j <= 12; j++)
            {
                _wall.Add(new Wall(size * 9, size * j));
            }
            for (int j = 8; j <= 13; j++)
            {
                _wall.Add(new Wall(size * 11, size * j));
            }
            for (int j = 7; j <= 12; j++)
            {
                _wall.Add(new Wall(size * 13, size * j));
            }
            for (int j = 4; j <= 13; j++)
            {
                _wall.Add(new Wall(size * 15, size * j));
            }
            for (int j = 2; j <= 12; j++)
            {
                _wall.Add(new Wall(size * 17, size * j));
            }
            for (int i = 14; i <= 16; i++)
            {
                _wall.Add(new Wall(size * i, size * 2));
            }
            for (int j = 1; j <= 13; j++)
            {
                _wall.Add(new Wall(size * 19, size * j));
            }

            //goal
            _goal = new Goal(size * 6, size * 13);
            //hole
            _hole = new Hole(size * 6, size * 12);
            //stone
            _stone = new Stone(size * 2, size * 12);

            //bomb
            _bombs = new List<Bomb>();

            //enemy
            _enemies = new List<Enemy>();
            _enemies.Add(new Enemy(size * 7, size * 7, 11, 0, 1));
            _enemies.Add(new Enemy(size * 8, size * 12, 2, 0, 1));
            _enemies.Add(new Enemy(size * 8, size * 13, 6, 0, 1));
            _enemies.Add(new Enemy(size * 12, size * 12, 4, 0, 1));


            //missile
            _missiles = new List<Missile>();

            //background
            pictureBox1.BackgroundImage = Image.FromFile(@"./background/stage_8.png");
        }

        private void button_stage9_Click(object sender, EventArgs e)
        {
            _wall.Clear();
            _scene = Scene.stage9;
            _hole.IsAlive = true;
            _stone.IsAlive = true;

            //player
            startx = size * 4 + 5;
            starty = size * 13 + 5;
            _player = new Player(startx, starty);

            //Wall
            for (int i = 0; i <= 19; i++)
            {
                _wall.Add(new Wall(size * i, size * 0));
            }
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 1; j <= 14; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            for (int i = 18; i <= 19; i++)
            {
                for (int j = 1; j <= 14; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }

            for (int i = 3; i <= 17; i++)
            {
                _wall.Add(new Wall(size * i, size * 14));
            }
            for (int i = 3; i <= 15; i++)
            {
                _wall.Add(new Wall(size * i, size * 11));
            }
            for (int j = 3; j <= 10; j++)
            {
                _wall.Add(new Wall(size * 15, size * j));
            }
            for (int i = 5; i <= 14; i++)
            {
                _wall.Add(new Wall(size * i, size * 3));
            }
            for (int j = 4; j <= 8; j++)
            {
                _wall.Add(new Wall(size * 5, size * j));
            }
            for (int i = 6; i <= 9; i++)
            {
                _wall.Add(new Wall(size * i, size * 8));
            }
            for (int i = 10; i <= 12; i++)
            {
                for (int j = 6; j <= 8; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            _wall.Add(new Wall(size * 8, size * 6));
            _wall.Add(new Wall(size * 9, size * 6));


            //goal
            _goal = new Goal(size * 9, size * 7);
            //hole
            _hole = new Hole(size * 7, size * 7);
            //stone
            _stone = new Stone(size * 6, size * 13);
            //bomb
            _bombs = new List<Bomb>();
            _bombs.Add(new Bomb(size * 3, size * 6));
            _bombs.Add(new Bomb(size * 3, size * 7));
            _bombs.Add(new Bomb(size * 3, size * 8));
            _bombs.Add(new Bomb(size * 6, size * 1));
            _bombs.Add(new Bomb(size * 7, size * 1));
            _bombs.Add(new Bomb(size * 8, size * 4));
            _bombs.Add(new Bomb(size * 9, size * 4));
            _bombs.Add(new Bomb(size * 10, size * 4));
            _bombs.Add(new Bomb(size * 14, size * 6));
            _bombs.Add(new Bomb(size * 17, size * 5));
            _bombs.Add(new Bomb(size * 10, size * 10));
            _bombs.Add(new Bomb(size * 11, size * 10));
            _bombs.Add(new Bomb(size * 10, size * 13));

            //enemy
            _enemies = new List<Enemy>();
            _enemies.Add(new Enemy(size * 3, size * 9, 2, 1, 1));
            _enemies.Add(new Enemy(size * 4, size * 9, 2, 1, 1));
            _enemies.Add(new Enemy(size * 6, size * 5, 7, 0, 1));


            //missile
            _missiles = new List<Missile>();

            //background
            pictureBox1.BackgroundImage = Image.FromFile(@"./background/stage_6_7_9.png");
        }

        private void button_stage10_Click(object sender, EventArgs e)
        {
            _wall.Clear();
            _scene = Scene.stage10;
            _hole.IsAlive = true;
            _stone.IsAlive = true;

            //player
            startx = size * 8 + 5;
            starty = size * 8 + 5;
            _player = new Player(startx, starty);

            //Wall
            for (int i = 0; i <= 19; i++)
            {
                _wall.Add(new Wall(size * i, size * 0));
            }
            for (int i = 0; i <= 19; i++)
            {
                _wall.Add(new Wall(size * i, size * 14));
            }
            for (int j = 1; j <= 13; j++)
            {
                _wall.Add(new Wall(size * 0, size * j));
            }
            for (int j = 1; j <= 13; j++)
            {
                _wall.Add(new Wall(size * 19, size * j));
            }
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 2; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            for (int j = 3; j <= 4; j++)
            {
                _wall.Add(new Wall(size * 1, size * j));
            }
            for (int i = 1; i <= 6; i++)
            {
                _wall.Add(new Wall(size * i, size * 8));
            }
            for (int i = 2; i <= 8; i++)
            {
                _wall.Add(new Wall(size * i, size * 10));
            }
            for (int i = 1; i <= 6; i++)
            {
                _wall.Add(new Wall(size * i, size * 12));
            }
            for (int j = 2; j <= 4; j++)
            {
                _wall.Add(new Wall(size * 5, size * j));
            }
            for (int i = 3; i <= 4; i++)
            {
                _wall.Add(new Wall(size * i, size * 4));
            }
            for (int i = 3; i <= 8; i++)
            {
                _wall.Add(new Wall(size * i, size * 5));
            }
            for (int i = 2; i <= 8; i++)
            {
                _wall.Add(new Wall(size * i, size * 6));
            }
            for (int j = 1; j <= 3; j++)
            {
                _wall.Add(new Wall(size * 7, size * j));
            }
            for (int i = 9; i <= 10; i++)
            {
                for (int j = 3; j <= 13; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            for (int j = 2; j <= 3; j++)
            {
                _wall.Add(new Wall(size * 11, size * j));
            }
            for (int i = 11; i <= 13; i++)
            {
                for (int j = 4; j <= 6; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            for (int i = 14; i <= 15; i++)
            {
                _wall.Add(new Wall(size * i, size * 6));
            }
            for (int i = 11; i <= 13; i++)
            {
                _wall.Add(new Wall(size * i, size * 8));
            }
            for (int i = 15; i <= 17; i++)
            {
                _wall.Add(new Wall(size * i, size * 8));
            }
            for (int i = 13; i <= 17; i++)
            {
                _wall.Add(new Wall(size * i, size * 10));
            }
            for (int i = 13; i <= 16; i++)
            {
                for (int j = 1; j <= 2; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            for (int i = 15; i <= 16; i++)
            {
                for (int j = 3; j <= 4; j++)
                {
                    _wall.Add(new Wall(size * i, size * j));
                }
            }
            for (int j = 1; j <= 12; j++)
            {
                _wall.Add(new Wall(size * 18, size * j));
            }
            _wall.Add(new Wall(size * 17, size * 1));
            //goal
            _goal = new Goal(size * 18, size * 13);
            //hole
            _hole = new Hole(size * 17, size * 13);
            //stone
            _stone = new Stone(size * 1, size * 13);
            //bomb
            _bombs = new List<Bomb>();
            _bombs.Add(new Bomb(size * 16, size * 12));

            //enemy
            _enemies = new List<Enemy>();
            _enemies.Add(new Enemy(size * 1, size * 7, 16, 0, 1));
            _enemies.Add(new Enemy(size * 11, size * 9, 0, 4, 1));
            _enemies.Add(new Enemy(size * 12, size * 13, 4, 0, 1));


            //missile
            _missiles = new List<Missile>();
            _missiles.Add(new Missile(size * 14, size * 11, size * 11, size * 11, size * 7, size * 3, 0));
            _missiles.Add(new Missile(size * 17, size * 2, size * 11, size * 5, size * 7, size * 9, 0));
            _missiles.Add(new Missile(size * 11, size * 7, size * 11, size * 5, size * 7, size * 9, 0));
            //_missiles.Add(new Missile(size * 15 + 10, size * 3, size * 13, size * 3, size * 3, size * 5));
            //_missiles.Add(new Missile(size * 13, size * 12 + 10, size * 13, size * 3, size * 3, size * 7));
            //_missiles.Add(new Missile(size * 15 + 10, size * 12 + 10, size * 13, size * 3, size * 3, size * 7));

            //background
            pictureBox1.BackgroundImage = Image.FromFile(@"./background/stage_10.png");
        }
    }
}