using Paint_2._0.Entities;
using Paint_2._0.Utilities;

namespace Paint_2._0.Commands;

/// <summary>
/// Интерфейс команд над фигурами.
/// </summary>
public interface IFigureCommand
{
    /// <summary>
    /// Фигура над которой выполняется команда.
    /// </summary>
    public IFigure? Figure { get;}

    /// <summary>
    /// Была ли команда запущена.
    /// </summary>
    public bool IsCommandStart { get;}

    /// <summary>
    /// Точка начала рисования.
    /// </summary>
    public Point2? Startpoint { get;}

    /// <summary>
    /// Цвет пера рисования.
    /// </summary>
    public Color? Color { get; }

    /// <summary>
    /// Запуск команды.
    /// </summary>
    /// <param name="figure">Фигура</param>
    /// <param name="color">Цвет пера рисования</param>
    public void Start(IFigure figure, Color? color = null);

    /// <summary>
    /// Создание фигуры.
    /// </summary>
    /// <param name="point">Точка</param>
    /// <returns>Созданная фигура</returns>
    public IFigure? ExecuteDraw(Point2 point);

    /// <summary>
    /// Перемещение фигуры.
    /// </summary>
    /// <param name="startPoint">Начальная точка</param>
    /// <param name="point">Конечная точка</param>
    public void ExecuteMove(Point2 startPoint, Point2 point);

    /// <summary>
    /// Заливка фигуры.
    /// </summary>
    /// <param name="color">Цвет заливки</param>
    public void ExecuteFill(Color color);

    /// <summary>
    /// Остановка команды.
    /// </summary>
    public void Stop();
}
