using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCAD.Entities
{
    public class FigureBox
    {
        public List<IFigure> Figures { get; set; }

        public void Add(IFigure figure)
        {
            Figures.Add(figure);
        }

        //в этом классе сделать методы вроде выбора, добавления и удаления фигур
    }
}
