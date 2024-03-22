using CommandsLib;
using EntitiesLib;
using GeometryUtils;

namespace Paint_2._0;

public partial class Form1 : Form
{
    Bitmap bitmap;
    Graphics graphics;
    Pen pen;

    /// <summary>
    /// Текущая точка.
    /// </summary>
    private Point2 point;

    /// <summary>
    /// Предыдущая точка.
    /// </summary>
    private Point2 prevPoint;

    /// <summary>
    /// Команда для работы с фигурами.
    /// </summary>
    private IFigureCommand? command;

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
        pen = new Pen(Color.Black, 1);
        pic_color.BackColor = Color.Black;

        point = new(0, 0);
        prevPoint = new(0, 0);
        figureContainer = new();
    }

    private void UpdateLocation(object sender, MouseEventArgs e)
    {
        prevPoint = point;
        point = new Point2(e.Location.X, e.Location.Y);
    }

    private void Draw(Graphics graphics, IFigure figure)
    {
        if (figure.Points.Count() < 2)
            return;
        float width = 1;
        if (figure.IsSelect)
            width = 3;
        Pen pen = new Pen(figure.StrokeColor, width);
        Brush? brush = figure.FillColor.HasValue ? new SolidBrush(figure.FillColor.Value) : null;
        if (figure is Circle)
        {
            if (!figure.FillColor.HasValue)
            {
                float radius = (new Vector2(
                figure.Points[1].X - figure.Points[0].X,
                figure.Points[1].Y - figure.Points[0].Y)).Length * 2;
                graphics.DrawEllipse(
                    pen,
                    figure.Points[0].X - radius / 2,
                    figure.Points[0].Y - radius / 2,
                    radius,
                    radius);
            }
            else
            {
                float radius = (new Vector2(
                figure.Points[1].X - figure.Points[0].X,
                figure.Points[1].Y - figure.Points[0].Y)).Length * 2;
                graphics.FillEllipse(
                    brush,
                    figure.Points[0].X - radius / 2,
                    figure.Points[0].Y - radius / 2,
                    radius,
                    radius);
            }
        }
        else
        if (!figure.FillColor.HasValue)
        {
            graphics.DrawPolygon(pen, figure.Points
                .Select(p => new PointF(p.X, p.Y))
                .ToArray());
        }
        else
            graphics.FillPolygon(brush, figure.Points
                .Select(p => new PointF(p.X, p.Y))
                .ToArray());
    }

    private void pic_MouseDown(object sender, MouseEventArgs e)
    {
        if (command is Drawing)
            command.ExecuteByOnePoint(point);
        else
        {
            IFigure? figure = figureContainer.Select(e.Location);
            if (command is Filling && figure != null)
            {
                command.Start(figure);
                command.ExecuteByColor(pen.Color);
                command.Stop();
                command = null;
                graphics.Clear(Color.White);
                foreach (IFigure figure1 in figureContainer.Figures)
                    Draw(graphics, figure1);
            }
            else if (command == null)
            {
                command = new Moving();
                if (figure != null)
                    command.Start(figure);
            }
            else if (command is Resizing && figure != null)
            {
                command.Start(figure);
                command.ExecuteByTwoPoints(prevPoint, point);
            }
            if (figure != null)
                Draw(graphics, figure);
        }
    }

    private void pic_MouseMove(object sender, MouseEventArgs e)
    {
        if (command is Moving && command.IsCommandStart)
            command.ExecuteByTwoPoints(prevPoint, point);
        else if (command is Resizing && command.IsCommandStart)
            command.ExecuteByTwoPoints(prevPoint, point);

        pic.Refresh();
    }

    private void pic_MouseUp(object sender, MouseEventArgs e)
    {
        if (command != null)
        {
            if (command is Drawing && command.Figure != null)
                figureContainer.Add(command.Figure);
            if (command.Figure != null)
                command.Figure.IsSelect = false;
            command.Stop();
            command = null;
        }
        graphics.Clear(Color.White);
        foreach (IFigure figure in figureContainer.Figures)
            Draw(graphics, figure);
    }

    // трансформация
    private void btn_pencil_Click(object sender, EventArgs e)
    {
        command = new Resizing();
    }

    // поворот
    private void btn_eraser_Click(object sender, EventArgs e)
    {

    }

    private void btn_ellipse_Click(object sender, EventArgs e)
    {
        command = new Drawing();
        command.Start(new Circle(), pen.Color);
    }

    private void btn_rect_Click(object sender, EventArgs e)
    {
        command = new Drawing();
        command.Start(new Square(), pen.Color);
    }

    private void btn_line_Click(object sender, EventArgs e)
    {
        command = new Drawing();
        command.Start(new Line(), pen.Color);
    }

    private void pic_Paint(object sender, PaintEventArgs e)
    {
        Graphics top_graphics = e.Graphics;
        if (command is Drawing && command.IsCommandStart)
        {
            IFigure? figure;
            if (command.Figure?.Points.Count() == 0)
                command.ExecuteByOnePoint(prevPoint);

            figure = command.ExecuteByOnePoint(point);
            if (figure != null)
                Draw(top_graphics, figure);
        }
        if (command is Moving || command is Resizing)
        {
            graphics.Clear(Color.White);
            foreach (IFigure figure in figureContainer.Figures)
                Draw(graphics, figure);
        }

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
        command = new Filling();
    }

    private void clearToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // очистка экрана
        figureContainer.Figures.Clear();
        graphics.Clear(Color.White);
        pic.Image = bitmap;
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var ofd = new OpenFileDialog
        {
            Filter = IO.IO.MakeFileFilter()
        };

        if (ofd.ShowDialog() == DialogResult.Cancel)
            return;

        figureContainer = IO.IO.SVGToCanvas(ofd.FileName);
        foreach (IFigure figure1 in figureContainer.Figures)
            Draw(graphics, figure1);
    }

    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var sfd = new SaveFileDialog
        {
            Filter = IO.IO.MakeFileFilter(),
            FileName = "Paint2.0-Image"
        };

        if (sfd.ShowDialog() == DialogResult.Cancel)
            return;

        IO.IO.Save(figureContainer, sfd.FileName, pic.Width, pic.Height);

    }

    private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // открытие отдельного окна "кто где над чем работал"
        Form2 credits = new Form2();
        credits.Show();
    }

    // изменение тем приложения (в процессе)
    private void customToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // что есть сейчас

        panel1.BackColor = Color.YellowGreen;
        panel2.BackColor = Color.YellowGreen;
        panel3.BackColor = Color.Green;

        btn_color.BackColor = Color.YellowGreen;
        btn_fill.BackColor = Color.YellowGreen;
        btn_transform.BackColor = Color.YellowGreen;
        btn_rotate.BackColor = Color.YellowGreen;
        btn_ellipse.BackColor = Color.YellowGreen;
        btn_rect.BackColor = Color.YellowGreen;
        btn_line.BackColor = Color.YellowGreen;
        menuStrip1.BackColor = Color.Beige;

        btn_color.ForeColor = Color.Black;
        btn_fill.ForeColor = Color.Black;
        btn_transform.ForeColor = Color.Black;
        btn_rotate.ForeColor = Color.Black;
        btn_ellipse.ForeColor = Color.Black;
        btn_rect.ForeColor = Color.Black;
        btn_line.ForeColor = Color.Black;
        menuStrip1.ForeColor = Color.Black;
    }

    private void monochromelightToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // ч/б светлый
        panel1.BackColor = Color.White;
        panel2.BackColor = Color.White;
        panel3.BackColor = Color.LightGray;

        btn_color.BackColor = Color.White;
        btn_fill.BackColor = Color.White;
        btn_transform.BackColor = Color.White;
        btn_rotate.BackColor = Color.White;
        btn_ellipse.BackColor = Color.White;
        btn_rect.BackColor = Color.White;
        btn_line.BackColor = Color.White;
        menuStrip1.BackColor = Color.White;

        btn_color.ForeColor = Color.Black;
        btn_fill.ForeColor = Color.Black;
        btn_transform.ForeColor = Color.Black;
        btn_rotate.ForeColor = Color.Black;
        btn_ellipse.ForeColor = Color.Black;
        btn_rect.ForeColor = Color.Black;
        btn_line.ForeColor = Color.Black;
        menuStrip1.ForeColor = Color.Black;
    }

    private void monochromedarkToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // ч/б темный
        panel1.BackColor = Color.DarkGray;
        panel2.BackColor = Color.DarkGray;
        panel3.BackColor = Color.Black;

        btn_color.BackColor = Color.DarkGray;
        btn_fill.BackColor = Color.DarkGray;
        btn_transform.BackColor = Color.DarkGray;
        btn_rotate.BackColor = Color.DarkGray;
        btn_ellipse.BackColor = Color.DarkGray;
        btn_rect.BackColor = Color.DarkGray;
        btn_line.BackColor = Color.DarkGray;
        menuStrip1.BackColor = Color.DarkGray;

        btn_color.ForeColor = Color.White;
        btn_fill.ForeColor = Color.White;
        btn_transform.ForeColor = Color.White;
        btn_rotate.ForeColor = Color.White;
        btn_ellipse.ForeColor = Color.White;
        btn_rect.ForeColor = Color.White;
        btn_line.ForeColor = Color.White;
        menuStrip1.ForeColor = Color.White;
    }
}
