namespace MyCAD
{
    partial class GraphicsForm
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
            drawing = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            pointBtn = new Button();
            lineBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)drawing).BeginInit();
            SuspendLayout();
            // 
            // drawing
            // 
            drawing.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            drawing.BackColor = SystemColors.Window;
            drawing.Location = new Point(0, 0);
            drawing.Name = "drawing";
            drawing.Size = new Size(1043, 580);
            drawing.TabIndex = 0;
            drawing.TabStop = false;
            drawing.Click += drawing_Click;
            drawing.Paint += drawing_Paint;
            drawing.MouseDown += drawing_MouseDown;
            drawing.MouseMove += drawing_MouseMove;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 593);
            label1.Name = "label1";
            label1.Size = new Size(49, 19);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 628);
            label2.Name = "label2";
            label2.Size = new Size(49, 19);
            label2.TabIndex = 2;
            label2.Text = "label2";
            // 
            // pointBtn
            // 
            pointBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pointBtn.Location = new Point(1135, 19);
            pointBtn.Name = "pointBtn";
            pointBtn.Size = new Size(80, 31);
            pointBtn.TabIndex = 3;
            pointBtn.Text = "Point";
            pointBtn.UseVisualStyleBackColor = true;
            pointBtn.Click += pointBtn_Click;
            // 
            // lineBtn
            // 
            lineBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lineBtn.Location = new Point(1135, 56);
            lineBtn.Name = "lineBtn";
            lineBtn.Size = new Size(80, 31);
            lineBtn.TabIndex = 4;
            lineBtn.Text = "Line";
            lineBtn.UseVisualStyleBackColor = true;
            lineBtn.Click += lineBtn_Click;
            // 
            // GraphicsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1316, 656);
            Controls.Add(lineBtn);
            Controls.Add(pointBtn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(drawing);
            Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(3, 4, 3, 4);
            Name = "GraphicsForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)drawing).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox drawing;
        private Label label1;
        private Label label2;
        private Button pointBtn;
        private Button lineBtn;
    }
}
