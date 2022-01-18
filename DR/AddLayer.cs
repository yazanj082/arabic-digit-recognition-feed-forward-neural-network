using DR.Data;
using DR.shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DR
{
    public partial class AddLayer : Form
    {
        public AddLayer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Layer result = new Layer();
                int number = int.Parse(textBox1.Text);
                if(number < 1)
                {
                    throw new Exception();
                }
                result.nodes = number;
                if (radioButton1.Checked)
                {
                    result.AFunc = false;
                }
                else { result.AFunc = true; }
                layers list = new layers();
                List<Layer> layer = list.Get();
                layer.Add(result);

                this.Close();

            }
            catch(Exception er)
            {
                label3.Text = "wrong values";
            }
        }
    }
}
