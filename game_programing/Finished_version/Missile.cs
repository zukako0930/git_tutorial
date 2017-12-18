using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OopLecture
{
    public class Missile : MoveObject
    {
        Image _img;
        Image _img_off;//sita
        Image _img_0;//sita
        Image _img_1;//ue
        private GameObject Homing_Area;
        int startX, startY, type;
        public Missile(int x, int y, int homingX, int homingY, int rangeX, int rangeY, int t, int w = 30, int h = 30) : base(x, y, w, h)
        {
            startX = x;
            startY = y;
            type = t;//type0:静的,type1:動的
            X = x;
            Y = y;
            W = w;
            H = h;
            if(type <2) IsAlive = true;
            else IsAlive = false;
            _img_off = Image.FromFile(@"./enemy/monster_off.png");
            _img_0 = Image.FromFile(@"./enemy/monster.png");
            _img_1 = Image.FromFile(@"./enemy/monster_back.png");
            _img = _img_off;
            Homing_Area = new GameObject(homingX, homingY, rangeX, rangeY);
        }

        public void Missile_Move(int tagetX, int tagetY, List<Wall> _wall, Player _player, bool flag)
        {
            if (!flag) IsAlive = true;
            if (IsAlive &&(_player.Intersects(Homing_Area) || (!flag && type%2 == 1)))
            {
                _img = _img_0;
                if (tagetX - X > 5)
                {
                    Move(10, 0);
                    if (Wall_Jadge(_wall)) Move(-10, 0);
                }
                else if (tagetX - X < -5)
                {
                    Move(-10, 0);
                    if (Wall_Jadge(_wall)) Move(10, 0);
                }
                if (tagetY - Y > 5)
                {
                    Move(0, 10);
                    if (Wall_Jadge(_wall)) Move(0, -10);
                }
                else if (tagetY - Y < -5)
                {
                    Move(0, -10);
                    if (Wall_Jadge(_wall)) Move(0, 10);
                    _img = _img_1;
                }
            }
            else
            {
                _img = _img_off;
            }
        }
        public void Missile_Restart()
        {
            X = startX;
            Y = startY;
            _img = _img_off;
            if (type < 2) IsAlive = true;
            else IsAlive = false;
        }

        public virtual void Missile_Draw(Graphics g)
        {
            g.DrawImage(_img, new Point(X, Y));
        }

    }
}
