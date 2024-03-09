using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint_2._0.Entities
{
    public class FigureContainer     //список всех существующих линий и квадратов. если будет удобнее, сделайте по-другому
    {
        public List<IFigure> Figures { get; set; }

        public void Add(IFigure figure)
        {
            Figures.Add(figure);
        }
    }
}

