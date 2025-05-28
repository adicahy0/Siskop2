namespace Siskop
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
            usernameBox = new TextBox();
            passwordBox = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // usernameBox
            // 
            usernameBox.BorderStyle = BorderStyle.None;
            usernameBox.ForeColor = SystemColors.ActiveBorder;
            usernameBox.Location = new Point(583, 157);
            usernameBox.Multiline = true;
            usernameBox.Name = "usernameBox";
            usernameBox.Size = new Size(169, 39);
            usernameBox.TabIndex = 0;
            usernameBox.TextChanged += textBox1_TextChanged;
            // 
            // passwordBox
            // 
            passwordBox.BorderStyle = BorderStyle.None;
            passwordBox.Location = new Point(583, 222);
            passwordBox.Multiline = true;
            passwordBox.Name = "passwordBox";
            passwordBox.Size = new Size(169, 37);
            passwordBox.TabIndex = 1;
            passwordBox.TextChanged += PasswordBox_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(618, 278);
            button1.Name = "button1";
            button1.Size = new Size(103, 36);
            button1.TabIndex = 2;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(passwordBox);
            Controls.Add(usernameBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox usernameBox;
        private TextBox passwordBox;
        private Button button1;
    }
}
