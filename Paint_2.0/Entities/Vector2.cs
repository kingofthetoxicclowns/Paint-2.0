using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint_2._0
{
    public class Vector2 //вектор направления. даётся 2 точки типа float - насколько смещается Х и насколько смещается Y у фигуры
    {
        private float x;
        private float y;
        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
        public float Y
        {
            get { return y; }
            set { y = value; }
        }
        public float X
        {
            get { return x; }
            set { x = value; }
        }


    }
}
