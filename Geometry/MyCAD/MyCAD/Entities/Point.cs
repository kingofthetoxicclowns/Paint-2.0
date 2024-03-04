using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCAD.Entities
{
    public class Point
    {
        private Vector3 position;
        private double thickness;

        public Point()
        {
            this.Position = Vector3.Zero;
            this.Thickness = 0.0;
        }

        public Point(Vector3 position)
        {
            this.Position = position;
            this.Thickness = 0.0;
        }
        public double Thickness
        {
            get { return thickness; }
            set { thickness = value; }
        }
        public Vector3 Position
        {
            get { return position; }
            set { position = value; }
        }
    }
}
