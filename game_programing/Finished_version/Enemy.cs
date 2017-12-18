using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OopLecture
{
    public class Enemy : GameObject
    {
        Image _img;
        Image _img_0;//sita
        Image _img_1;//migi
        Image _img_2;//ue
        Image _img_3;//hidari
        int vector, move_xcount, move_ycount, range_x, range_y,type ,Turn;

        public Enemy(int x, int y, int r_x, int r_y,int t, int turn = 1, int w = 40, int h = 40) : base(x, y, w, h)
        {
            X = x;
            Y = y;
            W = w;
            H = h;
            type = t;
            if (type < 1) IsAlive = true;
            else IsAlive = false;
            _img_0 = Image.FromFile(@"./enemy/zako.png");
            _img_1 = Image.FromFile(@"./enemy/zako_right.png");
            _img_2 = Image.FromFile(@"./enemy/zako_back.png");
            _img_3 = Image.FromFile(@"./enemy/zako_left.png");
            _img = _img_0;
            vector = 0;
            range_x = r_x;
            range_y = r_y;
            move_xcount = 0;
            move_ycount = 0;
            Turn = turn;//1 or 3
            _img = _img_0;
        }
        public void Enemy_Move(bool flag)
        {
            if (!flag) IsAlive = true;
            Turn_Judge();
            switch (vector)
            {
                case 0:
                    Move(0, 20);
                    move_ycount++;
                    _img = _img_0;
                    break;
                case 1:
                    Move(20, 0);
                    move_xcount++;
                    _img = _img_1;
                    break;
                case 2:
                    Move(0, -20);
                    move_ycount++;
                    _img = _img_2;
                    break;
                case 3:
                    Move(-200, 0);
                    move_xcount++;
                    _img = _img_3;
                    break;
                default: break;
            }
        }
        private void Turn_Judge()
        {
            if (move_xcount >= range_x * 2 && (vector == 1 || vector == 3))
            {
                vector = (vector + Turn) % 4;
                move_xcount = 0;
                Turn_Judge();
            }

            if (move_ycount >= range_y * 2 && (vector == 0 || vector == 2))
            {
                vector = (vector + Turn) % 4;
                move_ycount = 0;
                Turn_Judge();
            }
        }

        public virtual void Enemy_Draw(Graphics g)
        {
            g.DrawImage(_img, new Point(X+20, Y));
        }

    }
}
