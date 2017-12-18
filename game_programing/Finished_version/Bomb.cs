using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace OopLecture
{
    public class Bomb : GameObject
    {
        Image _img;
        public Bomb(int x, int y, int w = 25, int h = 25) : base(x, y, w, h)
        {
            X = x;
            Y = y;
            W = w;
            H = h;
            IsAlive = true;
            _img = Image.FromFile(@"./dragon/dragon.png");
        }

        public virtual void Bomb_Draw(Graphics g)
        {
            g.DrawImage(_img, new Point(X, Y));
        }

    }
}
