namespace Paint_2._0
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btn_save = new Button();
            btn_clear = new Button();
            color_picker = new PictureBox();
            btn_line = new Button();
            btn_rect = new Button();
            btn_ellipse = new Button();
            btn_rotate = new Button();
            btn_transform = new Button();
            btn_fill = new Button();
            pic_color = new Button();
            panel3 = new Panel();
            btn_color = new Button();
            panel2 = new Panel();
            pic = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)color_picker).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.YellowGreen;
            panel1.Controls.Add(btn_save);
            panel1.Controls.Add(btn_clear);
            panel1.Controls.Add(color_picker);
            panel1.Controls.Add(btn_line);
            panel1.Controls.Add(btn_rect);
            panel1.Controls.Add(btn_ellipse);
            panel1.Controls.Add(btn_rotate);
            panel1.Controls.Add(btn_transform);
            panel1.Controls.Add(btn_fill);
            panel1.Controls.Add(pic_color);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1042, 160);
            panel1.TabIndex = 0;
            // 
            // btn_save
            // 
            btn_save.BackColor = Color.YellowGreen;
            btn_save.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 0);
            btn_save.FlatAppearance.MouseOverBackColor = Color.Green;
            btn_save.FlatStyle = FlatStyle.Flat;
            btn_save.ForeColor = Color.White;
            btn_save.ImageAlign = ContentAlignment.TopCenter;
            btn_save.Location = new Point(823, 29);
            btn_save.Margin = new Padding(3, 4, 3, 4);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(96, 43);
            btn_save.TabIndex = 11;
            btn_save.Text = "Save";
            btn_save.UseVisualStyleBackColor = false;
            btn_save.Click += btn_save_Click;
            // 
            // btn_clear
            // 
            btn_clear.BackColor = Color.YellowGreen;
            btn_clear.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 0);
            btn_clear.FlatAppearance.MouseOverBackColor = Color.Green;
            btn_clear.FlatStyle = FlatStyle.Flat;
            btn_clear.ForeColor = Color.White;
            btn_clear.ImageAlign = ContentAlignment.TopCenter;
            btn_clear.Location = new Point(823, 84);
            btn_clear.Margin = new Padding(3, 4, 3, 4);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(96, 43);
            btn_clear.TabIndex = 10;
            btn_clear.Text = "Clear";
            btn_clear.UseVisualStyleBackColor = false;
            btn_clear.Click += btn_clear_Click;
            // 
            // color_picker
            // 
            color_picker.Cursor = Cursors.Hand;
            color_picker.Image = Properties.Resources.color_palette;
            color_picker.Location = new Point(0, -1);
            color_picker.Margin = new Padding(3, 4, 3, 4);
            color_picker.Name = "color_picker";
            color_picker.Size = new Size(231, 157);
            color_picker.SizeMode = PictureBoxSizeMode.StretchImage;
            color_picker.TabIndex = 9;
            color_picker.TabStop = false;
            color_picker.MouseClick += color_picker_MouseClick;
            // 
            // btn_line
            // 
            btn_line.BackColor = Color.YellowGreen;
            btn_line.Cursor = Cursors.Hand;
            btn_line.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 0);
            btn_line.FlatAppearance.MouseOverBackColor = Color.Green;
            btn_line.FlatStyle = FlatStyle.Flat;
            btn_line.ForeColor = Color.White;
            btn_line.Image = Properties.Resources.line1;
            btn_line.ImageAlign = ContentAlignment.TopCenter;
            btn_line.Location = new Point(709, 36);
            btn_line.Margin = new Padding(3, 4, 3, 4);
            btn_line.Name = "btn_line";
            btn_line.Size = new Size(82, 87);
            btn_line.TabIndex = 7;
            btn_line.TextAlign = ContentAlignment.BottomCenter;
            btn_line.UseVisualStyleBackColor = false;
            btn_line.Click += btn_line_Click;
            // 
            // btn_rect
            // 
            btn_rect.BackColor = Color.YellowGreen;
            btn_rect.Cursor = Cursors.Hand;
            btn_rect.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 0);
            btn_rect.FlatAppearance.MouseOverBackColor = Color.Green;
            btn_rect.FlatStyle = FlatStyle.Flat;
            btn_rect.ForeColor = Color.White;
            btn_rect.Image = Properties.Resources.rect;
            btn_rect.ImageAlign = ContentAlignment.TopCenter;
            btn_rect.Location = new Point(617, 36);
            btn_rect.Margin = new Padding(3, 4, 3, 4);
            btn_rect.Name = "btn_rect";
            btn_rect.Size = new Size(85, 87);
            btn_rect.TabIndex = 6;
            btn_rect.TextAlign = ContentAlignment.BottomCenter;
            btn_rect.UseVisualStyleBackColor = false;
            btn_rect.Click += btn_rect_Click;
            // 
            // btn_ellipse
            // 
            btn_ellipse.BackColor = Color.YellowGreen;
            btn_ellipse.Cursor = Cursors.Hand;
            btn_ellipse.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 0);
            btn_ellipse.FlatAppearance.MouseOverBackColor = Color.Green;
            btn_ellipse.FlatStyle = FlatStyle.Flat;
            btn_ellipse.ForeColor = Color.White;
            btn_ellipse.Image = Properties.Resources.circle1;
            btn_ellipse.ImageAlign = ContentAlignment.TopCenter;
            btn_ellipse.Location = new Point(528, 36);
            btn_ellipse.Margin = new Padding(3, 4, 3, 4);
            btn_ellipse.Name = "btn_ellipse";
            btn_ellipse.Size = new Size(82, 87);
            btn_ellipse.TabIndex = 5;
            btn_ellipse.TextAlign = ContentAlignment.BottomCenter;
            btn_ellipse.UseVisualStyleBackColor = false;
            btn_ellipse.Click += btn_ellipse_Click;
            // 
            // btn_rotate
            // 
            btn_rotate.BackColor = Color.YellowGreen;
            btn_rotate.Cursor = Cursors.Hand;
            btn_rotate.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 0);
            btn_rotate.FlatAppearance.MouseOverBackColor = Color.Green;
            btn_rotate.FlatStyle = FlatStyle.Flat;
            btn_rotate.ForeColor = Color.White;
            btn_rotate.Image = Properties.Resources.rotation;
            btn_rotate.ImageAlign = ContentAlignment.BottomCenter;
            btn_rotate.Location = new Point(481, 84);
            btn_rotate.Margin = new Padding(3, 4, 3, 4);
            btn_rotate.Name = "btn_rotate";
            btn_rotate.Size = new Size(40, 40);
            btn_rotate.TabIndex = 4;
            btn_rotate.TextAlign = ContentAlignment.BottomCenter;
            btn_rotate.UseVisualStyleBackColor = false;
            btn_rotate.Click += btn_eraser_Click;
            // 
            // btn_transform
            // 
            btn_transform.BackColor = Color.YellowGreen;
            btn_transform.Cursor = Cursors.Hand;
            btn_transform.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 0);
            btn_transform.FlatAppearance.MouseOverBackColor = Color.Green;
            btn_transform.FlatStyle = FlatStyle.Flat;
            btn_transform.ForeColor = Color.White;
            btn_transform.Image = Properties.Resources.transform;
            btn_transform.ImageAlign = ContentAlignment.BottomCenter;
            btn_transform.Location = new Point(481, 36);
            btn_transform.Margin = new Padding(3, 4, 3, 4);
            btn_transform.Name = "btn_transform";
            btn_transform.Size = new Size(40, 40);
            btn_transform.TabIndex = 3;
            btn_transform.TextAlign = ContentAlignment.BottomCenter;
            btn_transform.UseVisualStyleBackColor = false;
            btn_transform.Click += btn_pencil_Click;
            // 
            // btn_fill
            // 
            btn_fill.BackColor = Color.YellowGreen;
            btn_fill.Cursor = Cursors.Hand;
            btn_fill.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 0);
            btn_fill.FlatAppearance.MouseOverBackColor = Color.Green;
            btn_fill.FlatStyle = FlatStyle.Flat;
            btn_fill.ForeColor = Color.White;
            btn_fill.Image = Properties.Resources.fill;
            btn_fill.ImageAlign = ContentAlignment.MiddleLeft;
            btn_fill.Location = new Point(392, 36);
            btn_fill.Margin = new Padding(3, 4, 3, 4);
            btn_fill.Name = "btn_fill";
            btn_fill.Size = new Size(82, 87);
            btn_fill.TabIndex = 2;
            btn_fill.TextAlign = ContentAlignment.BottomCenter;
            btn_fill.UseVisualStyleBackColor = false;
            btn_fill.Click += btn_fill_Click;
            // 
            // pic_color
            // 
            pic_color.BackColor = Color.White;
            pic_color.Location = new Point(238, 52);
            pic_color.Margin = new Padding(3, 4, 3, 4);
            pic_color.Name = "pic_color";
            pic_color.Size = new Size(47, 55);
            pic_color.TabIndex = 0;
            pic_color.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Green;
            panel3.Controls.Add(btn_color);
            panel3.Location = new Point(291, 16);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(639, 125);
            panel3.TabIndex = 8;
            // 
            // btn_color
            // 
            btn_color.BackColor = Color.YellowGreen;
            btn_color.Cursor = Cursors.Hand;
            btn_color.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 0);
            btn_color.FlatAppearance.MouseOverBackColor = Color.Green;
            btn_color.FlatStyle = FlatStyle.Flat;
            btn_color.ForeColor = Color.White;
            btn_color.Image = Properties.Resources.color1;
            btn_color.ImageAlign = ContentAlignment.MiddleLeft;
            btn_color.Location = new Point(11, 20);
            btn_color.Margin = new Padding(3, 4, 3, 4);
            btn_color.Name = "btn_color";
            btn_color.Size = new Size(82, 87);
            btn_color.TabIndex = 1;
            btn_color.TextAlign = ContentAlignment.BottomCenter;
            btn_color.UseVisualStyleBackColor = false;
            btn_color.Click += btn_color_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.YellowGreen;
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 656);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1042, 25);
            panel2.TabIndex = 1;
            // 
            // pic
            // 
            pic.BackColor = Color.White;
            pic.Location = new Point(57, 0);
            pic.Margin = new Padding(3, 4, 3, 4);
            pic.Name = "pic";
            pic.Size = new Size(1042, 681);
            pic.TabIndex = 0;
            pic.TabStop = false;
            pic.Paint += pic_Paint;
            pic.MouseClick += pic_MouseClick;
            pic.MouseDown += pic_MouseDown;
            pic.MouseMove += pic_MouseMove;
            pic.MouseUp += pic_MouseUp;
            pic.MouseDown += UpdateLocation;
            pic.MouseMove += UpdateLocation;
            pic.MouseUp += UpdateLocation;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1042, 681);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pic);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Paint 2.0";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)color_picker).EndInit();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pic).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pic;
        private Button pic_color;
        private Button btn_color;
        private Button btn_fill;
        private Button btn_ellipse;
        private Button btn_rotate;
        private Button btn_transform;
        private Button btn_line;
        private Button btn_rect;
        private Panel panel3;
        private PictureBox color_picker;
        private Button btn_clear;
        private Button btn_save;
    }
}
