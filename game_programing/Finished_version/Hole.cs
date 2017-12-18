using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace OopLecture
{
    public class Hole:GameObject
    {
        Image _img;
        public Hole(int x, int y, int w = 40, int h = 40) : base(x, y, w, h)
        {
            X = x;
            Y = y;
            W = w;
            H = h;
            IsAlive = true;
            _img = Image.FromFile(@"./hole/hole.png");
        }
        public virtual void Hole_Draw(Graphics g)
        {
            g.DrawImage(_img, new Point(X, Y));
        }
    }
}
