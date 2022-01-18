using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.shared;
using ZedGraph;

namespace DR
{
    public partial class Form1 : Form
    {
        NeuralNetwork network;
        PointPairList error;
        public Form1(float rate, int iteration)
        {
            
            InitializeComponent();
            network = new NeuralNetwork(rate, iteration);
            error = network.train();

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                float input = float.Parse(textBox1.Text);
                if (input > 1 || input < 0)
                    input = 0;
                Color color = Color.FromArgb((int)(255 - (input * 255)), (int)(255 - (input * 255)), (int)(255 - (input * 255)));
                ((MyButton)sender).color = input;
                ((MyButton)sender).BackColor = color;
            }
            catch (Exception er)
            {
                float input = 0;
                if (input > 1 || input < 0)
                    input = 0;
                Color color = Color.FromArgb((int)(255 - (input * 255)), (int)(255 - (input * 255)), (int)(255 - (input * 255)));
                ((MyButton)sender).color = input;
                ((MyButton)sender).BackColor = color;
            }
        }

        private void build_Click(object sender, EventArgs e)
        {
            List<float> input = new List<float>();
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    input.Add(button[j, i].color);
                }

            }
            label1.Text = network.test(input).ToString();
        }
        private void plot_Click(object sender, EventArgs e)
        {
            ZedGraphControl zg1 = new ZedGraphControl();
            zg1.Dock = DockStyle.Fill;
            zg1.GraphPane = new GraphPane();

            LineItem ACurve = zg1.GraphPane.AddCurve("Error", error, Color.Red, SymbolType.None);

           
            zg1.AxisChange();
            
            zg1.Invalidate();

            zg1.Show();
            this.Controls.Add(zg1);
            Form2 f2 = new Form2();
            f2.Controls.Add(zg1);
            f2.Show();
        }
    }


}
