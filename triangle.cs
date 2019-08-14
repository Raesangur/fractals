using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace fractale
{
    class triangle
    {
        public Graphics G;
        public Pen P;
        public Point haut;
        public Point gauche;
        public Point droite;
        public bool drawn = false;

        public triangle(Graphics g, Pen p)
        {
            G = g;
            P = p;
            gauche = new Point(0, 0);
            droite = new Point(200, 0);
            haut = new Point(100, 200);
        }
        public triangle(triangle t, int section)
        {
            G = t.G;
            P = t.P;
            if (section == 0)
            {
                gauche = new Point(t.gauche.X, t.gauche.Y);
                droite = new Point((t.droite.X - t.gauche.X) / 2, t.droite.Y);
                haut = new Point((t.droite.X - t.gauche.X) / 4, (t.droite.Y - t.gauche.Y) / 2);
            }
            else if(section == 1)
            {
                gauche = new Point((t.droite.X - t.gauche.X) / 2, t.droite.Y);
                droite = new Point(t.droite.X, t.droite.Y);
                haut = new Point(((t.droite.X - t.gauche.X) / 2) + droite.X, (t.droite.Y - t.gauche.Y) / 2);
            }
            else
            {
                gauche = new Point((t.droite.X - t.gauche.X) / 4, (t.droite.Y - t.gauche.Y) / 2);
                droite = new Point(((t.droite.X - t.gauche.X) / 2) + droite.X, (t.droite.Y - t.gauche.Y) / 2);
                haut = new Point(t.haut.X, t.haut.Y);
            }
        }

        public void draw()
        {
            if (drawn == false)
            {
                G.DrawLine(P, gauche, droite);
                G.DrawLine(P, droite, haut);
                G.DrawLine(P, haut, gauche);
                drawn = true;
            }
        }
    }
}
