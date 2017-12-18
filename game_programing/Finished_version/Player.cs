using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace OopLecture
{
    public class Player : MoveObject
    {
        Image _img_f;
        Image _img_l;
        Image _img_r;
        Image _img_b;
        Image _img;
        public Player(int x, int y, int w = 25, int h = 25) : base(x, y, w, h)
        {
            X = x;
            Y = y;
            W = w;
            H = h;
            IsAlive = true;
            _img_f = Image.FromFile(@"./braver/braver_f_1.png");
            _img_l = Image.FromFile(@"./braver/braver_left.png");
            _img_r = Image.FromFile(@"./braver/braver_right.png");
            _img_b = Image.FromFile(@"./braver/braver_b_1.png");
            _img = _img_f;
        }

        public void Player_Move(List<Keys> _pressedKeys, List<Wall> _wall)
        {
            if (_pressedKeys.Contains(Keys.Up))
            {
                _img = _img_b;
                Move(0, -10);
                if (Wall_Jadge(_wall)) Move(0, 10);
            }
            if (_pressedKeys.Contains(Keys.Down))
            {
                _img = _img_f;
                Move(0, 10);
                if (Wall_Jadge(_wall)) Move(0, -10);
            }
            if (_pressedKeys.Contains(Keys.Left))
            {
                _img = _img_l;
                Move(-10, 0);
                if (Wall_Jadge(_wall)) Move(10, 0);
            }
            if (_pressedKeys.Contains(Keys.Right))
            {
                _img = _img_r;
                Move(10, 0);
                if (Wall_Jadge(_wall)) Move(-10, 0);
            }
        }

        public virtual void Player_Draw(Graphics g)
        {
            g.DrawImage(_img, new Point(X, Y));
        }
    }
}
