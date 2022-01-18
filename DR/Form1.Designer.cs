
using System.Drawing;
using WinFormsApp1.shared;

namespace DR
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
            int width = 5;
            int height = 7;

            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.build = new MyButton();
            this.plot = new MyButton();
            this.button = new MyButton[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    this.button[i, j] = new MyButton();
                    this.button[i, j].x = i;
                    this.button[i, j].y = j;
                   
                }
            }
            this.SuspendLayout();
            const int MAXWIDTH = 600;
            const int MAXHEIGHT = 600;
            int butonx = MAXWIDTH / 7;
            int buttony = MAXHEIGHT / height;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    this.button[i, j].Location = new System.Drawing.Point(i * butonx, j * buttony);
                    this.button[i, j].Name = "button";
                    this.button[i, j].Size = new System.Drawing.Size(butonx, buttony);
                    this.button[i, j].TabIndex = 0;
                    this.button[i, j].Text = "";
                    this.button[i, j].UseVisualStyleBackColor = true;
                    this.button[i, j].Click += new System.EventHandler(this.button1_Click);
                    this.button[i, j].UseVisualStyleBackColor = false;
                    this.button[i, j].BackColor = Color.White;
                    this.Controls.Add(this.button[i, j]);
                }
            }


            
      


            this.build.Location = new System.Drawing.Point(MAXWIDTH, 325);
            this.build.Name = "build";
            this.build.Size = new System.Drawing.Size(50, 50);
            this.build.TabIndex = 0;
            this.build.Text = "test";
            this.build.UseVisualStyleBackColor = true;
            this.build.Click += new System.EventHandler(this.build_Click);


            this.plot.Location = new System.Drawing.Point(MAXWIDTH, 380);
            this.plot.Name = "plot";
            this.plot.Size = new System.Drawing.Size(50, 50);
            this.plot.TabIndex = 0;
            this.plot.Text = "plot";
            this.plot.UseVisualStyleBackColor = true;
            this.plot.Click += new System.EventHandler(this.plot_Click);



            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(MAXWIDTH, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "";

            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(MAXWIDTH+50, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "0-1 (0:white , 1:black)";


            this.textBox1.Location = new System.Drawing.Point(MAXWIDTH, 102);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(50, 50);
            this.textBox1.TabIndex = 1;


            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.build);
            this.Controls.Add(this.plot);
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Text = "Form2";

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private MyButton build;
        private MyButton[,] button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MyButton plot;
    }

}
