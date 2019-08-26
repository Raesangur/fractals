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

        public triangle(Graphics g, Pen p)
        {
            G = g;
            P = p;
            gauche = new Point(50, 625);
            droite = new Point(650, 625);
            haut = new Point(350, 25);
        }
        public triangle(triangle t, int section)
        {
            G = t.G;
            P = t.P;
            if (section == 0)
            {
                gauche = new Point(t.gauche.X, t.gauche.Y);
                droite = new Point(((t.droite.X - t.gauche.X) / 2) + t.gauche.X, t.droite.Y);
                haut = new Point(((t.droite.X - t.gauche.X) / 4) + t.gauche.X, ((t.haut.Y - t.gauche.Y) / 2) + t.gauche.Y);
            }
            else if(section == 1)
            {
                gauche = new Point(((t.droite.X - t.gauche.X) / 2) + t.gauche.X, t.droite.Y);
                droite = new Point(t.droite.X, t.droite.Y);
                haut = new Point(((droite.X - gauche.X) / 2) + gauche.X,  ((t.haut.Y - t.gauche.Y) / 2) + t.gauche.Y);
            }
            else
            {
                int tempGauche = ((t.droite.X - t.gauche.X) / 2) + t.gauche.X;
                gauche = new Point(((t.droite.X - t.gauche.X) / 4) + t.gauche.X, ((t.haut.Y - t.gauche.Y) / 2) + t.gauche.Y);
                droite = new Point((t.droite.X - tempGauche) / 2 + tempGauche, ((t.haut.Y - t.gauche.Y) / 2) + t.gauche.Y);

                //gauche = new Point((t.droite.X - t.gauche.X) / 4, (t.haut.Y - t.gauche.Y) / 2);
                //droite = new Point(((t.droite.X - t.gauche.X) / 2) + gauche.X, ((t.haut.Y - t.droite.Y) / 2) + t.droite.Y);
                haut = new Point(t.haut.X, t.haut.Y);
            }
        }

        public void draw()
        {
            G.DrawLine(P, gauche, droite);
            G.DrawLine(P, droite, haut);
            G.DrawLine(P, haut, gauche);
        }
    }
}
