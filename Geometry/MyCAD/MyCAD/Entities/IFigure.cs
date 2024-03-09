using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCAD.Entities
{
    public interface IFigure
    {
        public List<Point> Points { get; set; }

        public Color Color { get; set; }
            
        //public void Create()
    }
}
