using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace OopLecture
{
    public class Stone : MoveObject
    {
        Image _img_0;//sita
        Image _img_1;//hidari
        Image _img_2;//ue
        Image _img_3;//migi
        Image _img_4;//die
        Image _img_5;//fit
        Image _img;
        int vector;
        public int startX, startY;
        public List<int[]> route;
        private MoveObject _ghost;
        public Stone(int x, int y, int w = 40, int h = 40) : base(x, y, w, h)
        {
            startX = x;
            startY = y;
            X = x;
            Y = y;
            W = w;
            H = h;
            IsAlive = true;
            _img_0 = Image.FromFile(@"./hole/iwa.png");
            _img_1 = Image.FromFile(@"./hole/iwa_left.png");
            _img_2 = Image.FromFile(@"./hole/iwa_back.png");
            _img_3 = Image.FromFile(@"./hole/iwa_right.png");
            _img_4 = Image.FromFile(@"./hole/iwa_die.png");
            _img_5 = Image.FromFile(@"./hole/hole_after.png");
            _img = _img_0;
            vector = 0;
            route = new List<int[]>();
            _ghost = new MoveObject(x, y);
        }
        public void Stone_Move(List<Wall> _wall, List<Bomb> _bombs, List<Missile> _missiles, Hole _hole)
        {
            switch (Around_Check(_wall, _bombs, _missiles, 0))
            {
                case 0:
                    switch (vector)
                    {
                        case 0:
                            Move(0, 40);
                            break;
                        case 1:
                            Move(-40, 0);
                            break;
                        case 2:
                            Move(0, -40);
                            break;
                        case 3:
                            Move(40, 0);
                            break;
                        default: break;
                    }
                    if (Intersects(_hole))
                    {
                        Stone_In();
                    }
                    break;
                case 2:
                    Stone_Die();
                    for (int i = 0; i < 4; i++)
                    {
                        route.Add(new int[] { X, Y, vector });
                    }
                    break;
                default: break;
            }
            route.Add(new int[] { X, Y, vector });
        }

        public void Stone_Turn(int x)
        {
            vector = (vector + x) % 4;
            route.Add(new int[] { X, Y, vector });
        }
        public virtual void Stone_Draw(Graphics g)
        {
            g.DrawImage(_img, new Point(X, Y));
        }
        public void Stone_Die()
        {
            IsAlive = false;
            vector = -1;
        }
        public void Stone_In()
        {
            IsAlive = false;
            vector = -2;
        }
        public void Stone_Go()
        {
            X = route[0][0];
            Y = route[0][1];
            switch (route[0][2])
            {
                case 0:
                    _img = _img_0;
                    break;
                case 1:
                    _img = _img_1;
                    break;
                case 2:
                    _img = _img_2;
                    break;
                case 3:
                    _img = _img_3;
                    break;
                case -1:
                    _img = _img_4;
                    break;
                case -2:
                    _img = _img_5;
                    break;
                default: break;
            }
        }

        public void Stone_Restart()
        {
            X = startX;
            Y = startY;
            vector = 0;
            _img = _img_0;
            IsAlive = true;
        }

        public int Around_Check(List<Wall> _wall, List<Bomb> _bombs, List<Missile> _missiles, int dire)
        {
            //道は０、壁は１、敵は２
            //前は＋０、右は＋１、後ろは＋２、左は＋３でチェック可能
            _ghost.X = X;
            _ghost.Y = Y;
            int result = 0;
            switch ((vector + dire) % 4)
            {
                case 0:
                    _ghost.Move(0, 40);
                    break;
                case 1:
                    _ghost.Move(-40, 0);
                    break;
                case 2:
                    _ghost.Move(0, -40);
                    break;
                case 3:
                    _ghost.Move(40, 0);
                    break;
                default: break;
            }
            if (_ghost.Wall_Jadge(_wall)) result = 1;
            if (_ghost.Bomb_Jadge(_bombs) || _ghost.Missile_Jadge(_missiles)) result = 2;
            return result;
        }

    }
}
