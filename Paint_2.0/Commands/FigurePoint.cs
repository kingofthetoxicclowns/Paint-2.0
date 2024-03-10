namespace Paint_2._0;

public class FigurePoint
{
    public float X { get; set; } = 0;
    public float Y { get; set; } = 0;
    public bool IsEmpty
    {
        get
        {
            return X == 0 && Y == 0;
        }
    }
    public FigurePoint(float x, float y)
    {
        X = x;
        Y = y;
    }

    public FigurePoint(System.Drawing.Point point)
    {
        X = point.X;
        Y = point.Y;
    }

    public static FigurePoint operator +(FigurePoint one, FigurePoint two)
    {
        return (new FigurePoint(one.X + two.X, one.Y + two.Y));
    }
    public static FigurePoint operator *(FigurePoint one, FigurePoint two)
    {
        return (new FigurePoint(one.X * two.X, one.Y * two.Y));
    }
    public static FigurePoint operator ++(FigurePoint one)
    {
        return (new FigurePoint(one.X + 1, one.Y + 1));
    }
}
