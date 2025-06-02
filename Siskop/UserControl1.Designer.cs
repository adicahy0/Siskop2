namespace Siskop
{
    partial class UserControl1
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            lbNama = new Label();
            button1 = new Button();
            label2 = new Label();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // lbNama
            // 
            lbNama.AutoSize = true;
            lbNama.BackColor = Color.Transparent;
            lbNama.Font = new Font("Times New Roman", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbNama.Location = new Point(235, 56);
            lbNama.MaximumSize = new Size(321, 0);
            lbNama.Name = "lbNama";
            lbNama.Size = new Size(105, 40);
            lbNama.TabIndex = 1;
            lbNama.Text = "Nama";
            lbNama.TextAlign = ContentAlignment.TopCenter;
            // 
            // button1
            // 
            button1.AutoEllipsis = true;
            button1.Location = new Point(571, 34);
            button1.Name = "button1";
            button1.Size = new Size(71, 30);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Times New Roman", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(46, 54);
            label2.MaximumSize = new Size(58, 42);
            label2.Name = "label2";
            label2.Size = new Size(58, 42);
            label2.TabIndex = 3;
            label2.Text = "ID123413";
            // 
            // button2
            // 
            button2.Location = new Point(571, 83);
            button2.Name = "button2";
            button2.Size = new Size(71, 30);
            button2.TabIndex = 4;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.download__1_;
            pictureBox1.Location = new Point(24, 18);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(643, 114);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(lbNama);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "UserControl1";
            Size = new Size(690, 150);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lbNama;
        private Button button1;
        private Label label2;
        private Button button2;
        private PictureBox pictureBox1;
    }
}
