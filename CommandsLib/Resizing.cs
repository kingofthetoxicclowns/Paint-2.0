using EntitiesLib;
using GeometryUtils;
using System.Drawing;

namespace CommandsLib;

public class Resizing : IFigureCommand
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
    /// <remarks>Для команды масштабирования этот метод недоступен.</remarks>
    public IFigure? ExecuteByOnePoint(Point2 point)
    {
        throw new NotImplementedException($"Для команды масштабирования этот метод недоступен!");
    }

    /// <inheritdoc/>
    /// <remarks>Для команды масштабирования этот метод недоступен.</remarks>
    public void ExecuteByColor(Color color)
    {
        throw new NotImplementedException($"Для команды масштабирования этот метод недоступен!");
    }

    /// <inheritdoc/>
    public void ExecuteByTwoPoints(Point2 startPoint, Point2 point)
    {
        if (figure is null)
            throw new ArgumentNullException($"Параметры не инициализованы!");
        isCommandStart = true;
        Vector2 vector = new(point.X - startPoint.X, point.Y - startPoint.Y);
        if (figure is Circle)
        {
            figure.Points[1].X += vector.X;
            figure.Points[1].Y += vector.Y;
        }
        if (figure is Line)
        {
            figure.Points[1].X += vector.X / 2;
            figure.Points[1].Y += vector.Y / 2;
            figure.Points[0].X -= vector.X / 2;
            figure.Points[0].Y -= vector.Y / 2;
        }
        if (figure is Square)
        {
            Vector2 diag1 = new(figure.Points[0].X - figure.Points[2].X, figure.Points[0].Y - figure.Points[2].Y);
            Vector2 diag2 = new(figure.Points[1].X - figure.Points[3].X, figure.Points[1].Y - figure.Points[3].Y);
            Point2 center = GeometryUtility.StraightLinesIntersection(figure.Points[0], figure.Points[2], figure.Points[1], figure.Points[3]);
            float vectorLength = ((new Vector2(point.X - center.X, point.Y - center.Y).Length
                < (new Vector2(startPoint.X - center.X, startPoint.Y - center.Y)).Length) 
                ? vector.Length
                : - vector.Length) / 2;          
            diag1.Normalize();
            diag2.Normalize();
            figure.Points[2].X += diag1.X * vectorLength;
            figure.Points[2].Y += diag1.Y * vectorLength;
            figure.Points[0].X -= diag1.X * vectorLength;
            figure.Points[0].Y -= diag1.Y * vectorLength;
            figure.Points[3].X += diag2.X * vectorLength;
            figure.Points[3].Y += diag2.Y * vectorLength;
            figure.Points[1].X -= diag2.X * vectorLength;
            figure.Points[1].Y -= diag2.Y * vectorLength;
        }
    }

    /// <inheritdoc/>
    /// <remarks>Параметр color вводить не нужно.</remarks>
    public void Start(IFigure figure, Color? color = null)
    {
        if (figure == null)
            throw new ArgumentNullException($"Необходимо задать фигуру!");
        this.figure = figure;
        isCommandStart = true;
    }

    public void Stop()
    {
        figure = null;
        color = null;
        startpoint = null;
        isCommandStart = false;
    }
}
