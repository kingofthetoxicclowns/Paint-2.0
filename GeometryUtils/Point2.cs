using System.Drawing;

namespace GeometryUtils;

/// <summary>
/// Точка с координатами вещественного типа в двумерном простанстве.
/// </summary>
public class Point2
{
    /// <summary>
    /// Координата по оси X.
    /// </summary>
    public float X { get; set; } = 0;

    /// <summary>
    /// Координата по оси Y.
    /// </summary>
    public float Y { get; set; } = 0;

    /// <summary>
    /// Является ли точка незаданной.
    /// </summary>
    public bool IsEmpty
    {
        get
        {
            return X == 0 && Y == 0;
        }
    }

    public Point2(float x, float y)
    {
        X = x;
        Y = y;
    }


    public Point2(Point point)
    {
        X = point.X;
        Y = point.Y;
    }

    public static Point2 operator +(Point2 one, Point2 two)
    {
        return new Point2(one.X + two.X, one.Y + two.Y);
    }

    public static Point2 operator ++(Point2 one)
    {
        return new Point2(one.X + 1, one.Y + 1);
    }

    public override bool Equals(object? obj)
    {
        if (obj is Point2 otherPoint)
            return otherPoint.X == X && otherPoint.Y == Y;
        return false;
    }
}
