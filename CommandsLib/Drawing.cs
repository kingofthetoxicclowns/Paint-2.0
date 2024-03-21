using EntitiesLib;
using GeometryUtils;
using System.Drawing;

namespace CommandsLib;

/// <summary>
/// Команда создания фигуры.
/// </summary>
public class Drawing : IFigureCommand
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
    /// <remarks>Параметр color - обязателен.</remarks>
    public void Start(IFigure figure, Color? color)
    {
        if (figure == null)
            throw new ArgumentNullException($"Необходимо задать фигуру!");
        if (color == null)
            throw new ArgumentNullException($"Для команды рисования необходимо определить цвет пера!");
        this.figure = figure;
        this.color = color;
        startpoint = new(0, 0);
        isCommandStart = false;
    }

    /// <inheritdoc/>
    public IFigure? ExecuteByOnePoint(Point2 point)
    {
        if (figure is null
            || !color.HasValue
            || startpoint == null)
            throw new ArgumentNullException($"Параметры не инициализованы!");

        if (startpoint.IsEmpty)
        {
            startpoint = point;
            isCommandStart = true;
        }
        else if (!startpoint.Equals(point))
        {
            figure.Points.Clear();
            figure.Create(startpoint, point, color.Value);
            return figure;
        }
        return null;
    }

    /// <inheritdoc/>
    public void Stop()
    {
        figure = null;
        color = null;
        startpoint = null;
        isCommandStart = false;
    }

    /// <inheritdoc/>
    /// <remarks>Для команды рисования этот метод недоступен.</remarks>
    public void ExecuteByTwoPoints(Point2 startPoint, Point2 point)
    {
        throw new NotImplementedException($"Для команды рисования этот метод недоступен!");
    }

    /// <inheritdoc/>
    /// <remarks>Для команды рисования этот метод недоступен.</remarks>
    public void ExecuteByColor(Color color)
    {
        throw new NotImplementedException($"Для команды рисования этот метод недоступен!");
    }
}
