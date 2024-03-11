using Paint_2._0.Entities;
using Paint_2._0.Utilities;

namespace Paint_2._0.Commands;

/// <summary>
/// Команда перемещения фигуры.
/// </summary>
public class Moving
{
    /// <summary>
    /// Фигура над которой выполняется команда.
    /// </summary>
    public IFigure? Figure { get; set; }

    /// <summary>
    /// Была ли команда запущена.
    /// </summary>
    public bool IsCommandStart { get; set; }

    /// <summary>
    /// Зпуск команды.
    /// </summary>
    /// <param name="figure">Фигура</param>
    public void Start(IFigure figure)
    {
        Figure = figure;
    }

    /// <summary>
    /// Перемещение фигуры.
    /// </summary>
    /// <param name="startPoint">Начальная точка</param>
    /// <param name="point">Конечная точка</param>
    public void Move(Point2 startPoint, Point2 point)
    {
        if (Figure is null)
            return;

        IsCommandStart = true;

        Vector2 vector = new(point.X - startPoint.X, point.Y - startPoint.Y);
        for (int i = 0; i < Figure.Points.Count(); i++)
        {
            Figure.Points[i].X += vector.X;
            Figure.Points[i].Y += vector.Y;
        }
    }

    /// <summary>
    /// Остановка команды.
    /// </summary>
    public void Stop()
    {
        Figure = null;
        IsCommandStart = false;
    }
}
