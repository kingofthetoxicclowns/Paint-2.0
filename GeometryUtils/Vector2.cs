namespace GeometryUtils;

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
    /// Координата по оси Y.
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
        float _length = Length;
        if (_length != 0)
        {
            X /= _length;
            Y /= _length;
        }
    }
}
