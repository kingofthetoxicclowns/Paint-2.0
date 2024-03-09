using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCAD.Entities
{
    public class Ellipse
    {
        private Vector3 center;
        private double majorAxis;
        private double minorAxis;
        private double rotation;
        private double startAngle;
        private double endAngle;
        private double thickness;
        public Ellipse(Vector3 center, double majoraxis, double minoraxis)
        {
            this.center = center;
            this.MajorAxis = majoraxis;
            this.MinorAxis = minoraxis;
            this.startAngle = 0.0;
            this.endAngle = 360.0;
            this.Rotation = 0.0;
            this.Thickness = 0.0;
        }

        public double Thickness
        {
            get { return thickness; }
            set { thickness = value; }
        }
        public double EndAngle
        {
            get { return endAngle; }
            set { endAngle = value; }
        }
        public double StartAngle
        {
            get { return startAngle; }
            set { startAngle = value; }
        }
        public double Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }
        public double MinorAxis
        {
            get { return minorAxis; }
            set { minorAxis = value; }
        }
        public double MajorAxis
        {
            get { return majorAxis; }
            set { majorAxis = value; }
        }
        public Vector3 Center
        {
            get { return center; }
            set { center = value; }
        }
    }
}
