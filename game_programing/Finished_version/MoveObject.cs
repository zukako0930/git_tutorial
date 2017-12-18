using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OopLecture
{
    public class MoveObject : GameObject
    {
        public MoveObject(int x, int y, int w = 20, int h = 20) : base(x, y, w, h)
        {
            X = x;
            Y = y;
            W = w;
            H = h;
            IsAlive = true;
        }

        public bool Wall_Jadge(List<Wall> _wall)
        {
            bool flag = false;
            foreach (var wall in _wall)
            {
                if (Intersects(wall))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public bool Bomb_Jadge(List<Bomb> _bombs)
        {
            bool flag = false;
            foreach (var bomb in _bombs)
            {
                if (Intersects(bomb))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public bool Missile_Jadge(List<Missile> _missiles)
        {
            bool flag = false;
            foreach (var missile in _missiles)
            {
                if (Intersects(missile) && missile.IsAlive == true)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public bool Hole_Jadge(Hole _hole)
        {
            bool flag = false;
            if (Intersects(_hole)) flag = true;
            return flag;
        }
    }
}
