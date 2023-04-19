namespace FinalProjectMAT239_Windows
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Transformers Movie", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(446, 165);
            label1.Name = "label1";
            label1.Size = new Size(350, 24);
            label1.TabIndex = 0;
            label1.Text = "MAT239 - Mathematics for Computing";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Broadway", 30F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(358, 210);
            label2.Name = "label2";
            label2.Size = new Size(537, 68);
            label2.TabIndex = 1;
            label2.Text = "FINAL PROJECT";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(559, 314);
            label3.Name = "label3";
            label3.Size = new Size(124, 25);
            label3.TabIndex = 2;
            label3.Text = "By: Ryan Black";
            // 
            // button1
            // 
            button1.Location = new Point(295, 425);
            button1.Name = "button1";
            button1.Size = new Size(230, 89);
            button1.TabIndex = 3;
            button1.Text = "Game of Bridge";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(708, 425);
            button2.Name = "button2";
            button2.Size = new Size(230, 89);
            button2.TabIndex = 4;
            button2.Text = "Prisoners' Dilemma";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1233, 679);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
    }
}