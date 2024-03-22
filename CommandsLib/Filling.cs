using EntitiesLib;
using GeometryUtils;
using System.Drawing;

namespace CommandsLib;

/// <summary>
/// Команда заливки фигуры.
/// </summary>
public class Filling : IFigureCommand
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
        isCommandStart = false;
    }

    /// <inheritdoc/>
    public void ExecuteByColor(Color color)
    {
        if (figure is null)
            throw new ArgumentNullException($"Параметры не инициализованы!");
        isCommandStart = true;
        figure.FillColor = color;
    }

    /// <inheritdoc/>
    public void Stop()
    {
        figure = null;
        isCommandStart = false;
    }

    /// <inheritdoc/>
    /// <remarks>Для команды заливки этот метод недоступен.</remarks>
    public IFigure? ExecuteByOnePoint(Point2 point)
    {
        throw new NotImplementedException($"Для команды заливки этот метод недоступен!");
    }

    /// <inheritdoc/>
    /// <remarks>Для команды заливки этот метод недоступен.</remarks>
    public void ExecuteByTwoPoints(Point2 startPoint, Point2 point)
    {
        throw new NotImplementedException($"Для команды заливки этот метод недоступен!");
    }
}
