using Paint_2._0.Entities;
using Paint_2._0.Utilities;

namespace Paint_2._0.Commands;

public class Drawing
{
    public IFigure? Figure { get; private set; }
    public bool IsDraw { get; private set; }

    private Point2 startpoint = new(0, 0);

    private Color? color;

    public void Start(IFigure figure, Color color)
    {
        Figure = figure;
        this.color = color;
    }
    public void Draw(Point2 point)
    {
        if (Figure is null || !color.HasValue)
            return;

        if (startpoint.IsEmpty)
        {
            startpoint = point;
            IsDraw = true;
        }
        else
        {
            Figure.Points.Clear();
            Figure.Create(startpoint, point, color.Value);
        }
    }
    public IFigure? End()
    {
        if (Figure is null || !color.HasValue || !IsDraw)
            return null;
        IFigure? figure = Figure;
        Figure = null;
        color = null;
        startpoint = new(0, 0);
        IsDraw = false;
        return figure;
    }
}
