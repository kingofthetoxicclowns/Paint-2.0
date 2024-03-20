using EntitiesLib;
using GeometryUtils;
using System.Drawing;

namespace CommandsLib;

/// <summary>
/// Команда перемещения фигуры.
/// </summary>
public class Moving : IFigureCommand
{
    private IFigure? figure;

    /// <inheritdoc/>
    public IFigure? Figure { get { return figure; } }

    private bool isCommandStart;

    /// <inheritdoc/>
    public bool IsCommandStart { get { return isCommandStart; } }

    private Point2? startpoint;

    /// <inheritdoc/>
    public Point2? Startpoint { get { return startpoint; } }

    private Color? color;

    /// <inheritdoc/>
    public Color? Color { get { return color; } }

    /// <inheritdoc/>
    /// <remarks>Параметр color вводить не нужно.</remarks>
    public void Start(IFigure figure, Color? color = null)
    {
        if (figure == null)
            throw new ArgumentNullException($"Необходимо задать фигуру!");
        this.figure = figure;
        isCommandStart = true;
    }

    /// <inheritdoc/>
    public void ExecuteMove(Point2 startPoint, Point2 point)
    {
        if (figure is null)
            throw new ArgumentNullException($"Параметры не инициализованы!");
        isCommandStart = true;
        Vector2 vector = new(point.X - startPoint.X, point.Y - startPoint.Y);
        for (int i = 0; i < figure.Points.Count(); i++)
        {
            figure.Points[i].X += vector.X;
            figure.Points[i].Y += vector.Y;
        }
    }

    /// <inheritdoc>
    public void Stop()
    {
        figure = null;
        isCommandStart = false;
    }

    /// <inheritdoc/>
    /// <remarks>Для команды перемещения этот метод недоступен.</remarks>
    public IFigure? ExecuteDraw(Point2 point)
    {
        throw new NotImplementedException($"Для команды перемещения этот метод недоступен!");
    }

    /// <inheritdoc/>
    /// <remarks>Для команды перемещения этот метод недоступен.</remarks>
    public void ExecuteFill(Color color)
    {
        throw new NotImplementedException($"Для команды перемещения этот метод недоступен!");
    }
}
