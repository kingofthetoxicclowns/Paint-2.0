using Paint_2._0.Commands;
using Paint_2._0.Entities;
using Paint_2._0.Utilities;
using System.Drawing;
using System.Drawing.Imaging;

namespace Paint_2._0;

public partial class Form1 : Form
{
    Bitmap bitmap;
    Graphics graphics;
    Pen pen = new Pen(Color.Black, 1);

    /// <summary>
    /// Текущая точка.
    /// </summary>
    private Point2 point;

    /// <summary>
    /// Предыдущая точка.
    /// </summary>
    private Point2 prevPoint;

    /// <summary>
    /// Команда создания фигуры.
    /// </summary>
    private Drawing drawing;

    /// <summary>
    /// Команда перемещения фигуры.
    /// </summary>
    private Moving moving;

    /// <summary>
    /// Контейнер с фигурами.
    /// </summary>
    private FigureContainer figureContainer;

    public Form1()
    {
        InitializeComponent();
        this.Width = 950;
        this.Height = 700;
        bitmap = new Bitmap(pic.Width, pic.Height);
        graphics = Graphics.FromImage(bitmap);
        graphics.Clear(Color.White);
        pic.Image = bitmap;

        point = new(0, 0);
        prevPoint = new(0, 0);
        drawing = new();
        moving = new();
        figureContainer = new();
    }

    private void UpdateLocation(object sender, MouseEventArgs e)
    {
        prevPoint = point;
        point = new Point2(e.Location.X, e.Location.Y);
    }

    private void pic_MouseDown(object sender, MouseEventArgs e)
    {
        if (drawing.Figure is not null)
            drawing.Draw(point);
        IFigure? figure = figureContainer.Select(new Point2(e.Location));
        if (figure is not null)
        {
            moving.Start(figure);
        }
        if (moving.IsCommandStart)
        {
            moving.Stop();
        }
    }

    private void pic_MouseMove(object sender, MouseEventArgs e)
    {
        if (moving.Figure is not null)
            moving.Move(prevPoint, point);
    
        pic.Refresh();
    }

    private void pic_MouseUp(object sender, MouseEventArgs e)
    {
        if (drawing.IsDraw)
        {
            if (drawing.Figure is not null)
                figureContainer.Add(drawing.Figure);

            drawing.End();
        }
    }

    private void btn_pencil_Click(object sender, EventArgs e)
    {

    }

    private void btn_eraser_Click(object sender, EventArgs e)
    {

    }

    private void btn_ellipse_Click(object sender, EventArgs e)
    {
        drawing.Start(new Circle(), pen.Color);
    }

    private void btn_rect_Click(object sender, EventArgs e)
    {
        drawing.Start(new Square(), pen.Color);
    }

    private void btn_line_Click(object sender, EventArgs e)
    {
        drawing.Start(new Line(), pen.Color);
    }

    private void pic_Paint(object sender, PaintEventArgs e)
    {
        Graphics graphics = e.Graphics;
        if (drawing.IsDraw)
        {
            IFigure? figure;
            if (drawing.Figure.Points.Count() == 0)
                drawing.Draw(prevPoint);
                
            figure = drawing.Draw(point);
        }
    }

    private void btn_clear_Click(object sender, EventArgs e)
    {
        graphics.Clear(Color.White);
        pic.Image = bitmap;
    }

    private void btn_color_Click(object sender, EventArgs e)
    {
        ColorDialog colorDialog = new ColorDialog();
        colorDialog.ShowDialog();
        pic_color.BackColor = colorDialog.Color;
        pen.Color = colorDialog.Color;
    }

    static Point set_point(PictureBox pb, Point pt)
    {
        float pX = 1f * pb.Image.Width / pb.Width;
        float pY = 1f * pb.Image.Height / pb.Height;
        return new Point((int)(pt.X * pX), (int)(pt.Y * pY));

    }

    private void color_picker_MouseClick(object sender, MouseEventArgs e)
    {
        Point point = set_point(color_picker, e.Location);
        pic_color.BackColor = ((Bitmap)color_picker.Image).GetPixel(point.X, point.Y);
        pen.Color = pic_color.BackColor;
    }
    private void validate(Bitmap bm, Stack<Point> sp, int x, int y, Color old_color, Color new_color)
    {
        Color cx = bm.GetPixel(x, y);
        if (cx == old_color)
        {
            sp.Push(new Point(x, y));
            bm.SetPixel(x, y, new_color);
        }
    }
    public void Fill(Bitmap bm, int x, int y, Color new_clr)
    {
        Color old_color = bm.GetPixel(x, y);
        Stack<Point> pixel = new Stack<Point>();
        pixel.Push(new Point(x, y));
        bm.SetPixel(x, y, new_clr);
        if (old_color == new_clr) return;

        while (pixel.Count > 0)
        {
            Point pt = (Point)pixel.Pop();
            if (pt.X > 0 && pt.Y > 0 && pt.X < bm.Width - 1 && pt.Y < bm.Height - 1)
            {
                validate(bm, pixel, pt.X - 1, pt.Y, old_color, new_clr);
                validate(bm, pixel, pt.X, pt.Y - 1, old_color, new_clr);
                validate(bm, pixel, pt.X + 1, pt.Y, old_color, new_clr);
                validate(bm, pixel, pt.X, pt.Y + 1, old_color, new_clr);
            }
        }
    }

    private void pic_MouseClick(object sender, MouseEventArgs e)
    {
        //if (index == 7)
        //{
        //    Point point = set_point(pic, e.Location);
        //    Fill(bitmap, point.X, point.Y, new_color);
        //}
    }

    private void btn_fill_Click(object sender, EventArgs e)
    {

    }

    private void btn_save_Click(object sender, EventArgs e)
    {
        var sfd = new SaveFileDialog
        {
            Filter = IO.IO.MakeFileFilter(),
            FileName = "Paint2.0-Image"
        };

        if (sfd.ShowDialog() == DialogResult.Cancel)
            return;

        //IO.IO.Save(container, sfd.FileName, pic.Width, pic.Height);
    }
}
