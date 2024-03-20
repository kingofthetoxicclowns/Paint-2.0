using EntitiesLib;
using GeometryUtils;

namespace Paint_2._0;

/// <summary>
/// Контейнер с фигурами.
/// </summary>
public class FigureContainer
{
    /// <summary>
    /// Список фигур.
    /// </summary>
    public List<IFigure> Figures { get; set; }

    public FigureContainer()
    {
        Figures = new();
    }

    /// <summary>
    /// Добавление фигуры в контейнер.
    /// </summary>
    /// <param name="figure">Фигура</param>
    public void Add(IFigure figure)
    {
        Figures.Add(figure);
    }

    /// <summary>
    /// Выбор фигуры из контейнера по точке.
    /// Для выбранной фигуры флаг IsSelect помечается true.
    /// </summary>
    /// <param name="point">Точка</param>
    /// <returns>Выбранная фигура</returns>
    public IFigure? Select(Point point)
    {
        Point2 point2 = new(point.X, point.Y);
        return Select(point2);
    }

    /// <summary>
    /// Выбор фигуры из контейнера по точке.
    /// Для выбранной фигуры флаг IsSelect помечается true.
    /// </summary>
    /// <param name="point">Точка</param>
    /// <returns>Выбранная фигура</returns>
    public IFigure? Select(Point2 point)
    {
        foreach (IFigure figure in Figures.Reverse<IFigure>())
        {
            if (figure is Square)
                if (GeometryUtility.IsPointInsidePolygon(point, figure.Points))
                {
                    if (!figure.IsSelect)
                    {
                        Figures.ForEach(f => f.IsSelect = false);
                        figure.IsSelect = true;
                    }
                    else
                        figure.IsSelect = false;
                    return figure;
                }
            if (figure is Circle)
            {
                float radius = (new Vector2(figure.Points[1].X - figure.Points[0].X, figure.Points[1].Y - figure.Points[0].Y)).Length;
                float section = (new Vector2(point.X - figure.Points[0].X, point.Y - figure.Points[0].Y)).Length;
                if (section <= radius)
                {
                    if (!figure.IsSelect)
                    {
                        Figures.ForEach(f => f.IsSelect = false);
                        figure.IsSelect = true;
                    }
                    else
                        figure.IsSelect = false;
                    return figure;
                }
            }
            if (figure is Line)
            {
                float lenght = (new Vector2(figure.Points[1].X - figure.Points[0].X, figure.Points[1].Y - figure.Points[0].Y)).Length;
                float section1 = (new Vector2(point.X - figure.Points[0].X, point.Y - figure.Points[0].Y)).Length;
                float section2 = (new Vector2(point.X - figure.Points[1].X, point.Y - figure.Points[1].Y)).Length;
                if (Math.Abs((section1 + section2) - lenght) < 0.1f)
                {
                    if (!figure.IsSelect)
                    {
                        Figures.ForEach(f => f.IsSelect = false);
                        figure.IsSelect = true;
                    }
                    else
                        figure.IsSelect = false;
                    return figure;
                }
            }
        }
        Figures.ForEach(f => f.IsSelect = false);
        return null;
    }
}