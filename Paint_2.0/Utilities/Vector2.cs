namespace Paint_2._0.Utilities;

/// <summary>
/// Вектор с координатами вещественного типа в двумерном простанстве.
/// </summary>
public class Vector2
{
    /// <summary>
    /// Координата по оси X.
    /// </summary>
    public float X { get; set; }

    /// <summary>
    /// Координата по оси X.
    /// </summary>
    public float Y { get; set; }

    /// <summary>
    /// Длина вектора.
    /// </summary>
    public float Length
    {
        get
        {
            return (float)Math.Sqrt(X * X + Y * Y);
        }
    }

    public Vector2(float x, float y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// Нормирует вектор.
    /// </summary>
    public void Normalize()
    {
        X /= Length;
        Y /= Length;
    }
}
