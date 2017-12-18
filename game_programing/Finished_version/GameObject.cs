using System;
using System.Drawing;

namespace OopLecture
{
    public class GameObject
    {
        public int X;
        public int Y;
        public int W;
        public int H;
        public bool IsAlive;
        public bool vectorflag;

        public GameObject(int x, int y, int w = 25, int h = 25)
        {
            X = x;
            Y = y;
            W = w;
            H = h;
            IsAlive = true;
        }

        public void Move(int x, int y)
        {
            X += x;
            Y += y;
        }

        public virtual bool Intersects(GameObject obj)
        {
            return X < obj.X + obj.W && X + W > obj.X &&
                   Y < obj.Y + obj.H && Y + H > obj.Y;
        }

        public virtual void Die()
        {
            IsAlive = false;
        }

        public virtual void Draw(Graphics g)
        {
            Console.WriteLine("x: " + X + ", y: " + Y);
            g.FillRectangle(Brushes.Red, X, Y, W, H);
        }
    }
}