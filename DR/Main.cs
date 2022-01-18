using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DR
{
    public partial class Main : Form
    {   int count = 0;

        public Main()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            count++;
            label2.Text = count.ToString();
            AddLayer f2 = new AddLayer();
            
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                int iteration = int.Parse(textBox1.Text);
                float rate = float.Parse(textBox3.Text);
                if (rate > 1 || rate < 0 || iteration<0 || count ==0)
                {
                    throw new Exception();
                }

                Form1 f1 = new Form1(rate,iteration);
                this.Hide();
                f1.Show();
          
            }
            catch(Exception er)
            {
                label1.Text = "Enter value between 0-1 ,you must add at least one layer and iterations > 0";
            }
        }
    }
}
