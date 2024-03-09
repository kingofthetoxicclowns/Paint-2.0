using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MyCAD.Entities
{
    public class Circle
    {
        private Vector3 vector3;
        private double radius;
        private double thickness;


        public Circle()
            :this(Vector3.Zero, 1.0)
        {

        }
        public Circle(Vector3 center, double radius)
        {
            this.Center = center;
            this.Radius = radius;
            this.Thickness = thickness;
        }
        public double Thickness
        {
            get { return thickness; }
            set { thickness = value; }
        }
        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }
        public Vector3 Center
        {
            get { return vector3; }
            set { vector3 = value; }
        }
        public double Diameter
        {
            get { return this.Radius * 2.0; }
        }
    }
}
