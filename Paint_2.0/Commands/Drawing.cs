using Paint_2._0.Entities;
using Paint_2._0.Utilities;

namespace Paint_2._0.Commands;

/// <summary>
/// Команда создания фигуры.
/// </summary>
public class Drawing
{
    /// <summary>
    /// Фишгура над которой выполняется команда.
    /// </summary>
    public IFigure? Figure { get; private set; }

    /// <summary>
    /// Была ли команда запущена.
    /// </summary>
    public bool IsDraw { get; private set; }

    /// <summary>
    /// Точка начала рисования.
    /// </summary>
    private Point2 startpoint = new(0, 0);

    /// <summary>
    /// Цвет пера рисования.
    /// </summary>
    private Color? color;

    /// <summary>
    /// Запуск команды.
    /// </summary>
    /// <param name="figure">Фигура</param>
    /// <param name="color">Цвет пера рисования</param>
    public void Start(IFigure figure, Color color)
    {
        Figure = figure;
        this.color = color;
    }

    /// <summary>
    /// Создание фигуры.
    /// </summary>
    /// <param name="point">Точка</param>
    /// <returns>Созданная фигура</returns>
    public IFigure? Draw(Point2 point)
    {
        if (Figure is null || !color.HasValue)
            return null;

        if (startpoint.IsEmpty)
        {
            startpoint = point;
            IsDraw = true;
        }
        else
        {
            Figure.Points.Clear();
            Figure.Create(startpoint, point, color.Value);
            return Figure;
        }
        return null;
    }

    /// <summary>
    /// Остановка команды.
    /// </summary>
    public void End()
    {
        Figure = null;
        color = null;
        startpoint = new(0, 0);
        IsDraw = false;
    }
}
