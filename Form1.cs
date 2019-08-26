using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fractale
{
    public partial class Form1 : Form
    {
        List<triangle> tri = new List<triangle>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Brush B = new SolidBrush(Color.White);
            Pen P = new Pen(B);
            Graphics G = this.CreateGraphics();

            triangle t = new triangle(G, P);
            tri.Add(t);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach(triangle t in tri)
            {
                t.draw();
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            int count = tri.Count;
            for (int i = 0; i < count; i++)
            {
                triangle t1 = new triangle(tri[i], 0);
                triangle t2 = new triangle(tri[i], 1);
                triangle t3 = new triangle(tri[i], 2);
                tri.Add(t1);
                tri.Add(t2);
                tri.Add(t3);
            }
            this.Refresh();
        }
    }
}
