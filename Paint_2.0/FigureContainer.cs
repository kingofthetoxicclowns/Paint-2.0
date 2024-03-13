using Paint_2._0.Entities;
using Paint_2._0.Utilities;

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
    /// <param name="point"></param>
    /// <returns></returns>
    public IFigure? Select(Point2 point)
    {
        foreach (IFigure figure in Figures)
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
        Figures.ForEach(f => f.IsSelect = false);
        return null;
    }
}

