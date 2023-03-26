using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerletTower
{
    public class Box
    {
        public VerletPoint p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12;
        public VerletStick s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16, s17, s18, s19, s20, s21, s22, s23, s24, s25, s26;
        PointF pi1, pi2, pi3, pi4;
        static Random rand = new Random();
        //private List<Box> boxes = new List<Box>();
        Image particleImage = Image.FromFile("C:\\Users\\Omar\\Documents\\Udlap\\Sexto semestre\\Graficación y  videojuegos\\assets\\block.png");
        public Box(int height, int width, VerletPoint punta/*, List<Box> boxes*/)
        {
            //this.boxes = boxes;
            //this.boxes.Add(this);
            p1 = new VerletPoint(punta.pos.X - 2 * width / 4, punta.pos.Y);
            p2 = new VerletPoint(punta.pos.X + 2 * width / 4, punta.pos.Y);
            p3 = new VerletPoint(punta.pos.X + 2 * width / 4, punta.pos.Y + 30);
            p4 = new VerletPoint(punta.pos.X - 2 * width / 4, punta.pos.Y + 30);
            //Relleno arriba+

            p5 = new VerletPoint(punta.pos.X - width / 4, punta.pos.Y);
            p6 = new VerletPoint(punta.pos.X, punta.pos.Y, punta.vel.X, punta.vel.Y);
            p7 = new VerletPoint(punta.pos.X + width / 4, punta.pos.Y);
            //Relleno abajo
            p8 = new VerletPoint(punta.pos.X - width / 4, punta.pos.Y + 30);
            p9 = new VerletPoint(punta.pos.X, punta.pos.Y + 30);
            p10 = new VerletPoint(punta.pos.X + width / 4, punta.pos.Y + 30);



            s1 = new VerletStick(p1, p2);
            s2 = new VerletStick(p2, p3);
            s3 = new VerletStick(p3, p4);
            s4 = new VerletStick(p4, p1);
            s5 = new VerletStick(p1, p3);
            s6 = new VerletStick(p2, p4);

            s7 = new VerletStick(p1, p5);
            s8 = new VerletStick(p6, p5);
            s9 = new VerletStick(p6, p7);
            s10 = new VerletStick(p7, p2);
            s11 = new VerletStick(p4, p8);
            s12 = new VerletStick(p8, p9);
            s13 = new VerletStick(p9, p10);
            s14 = new VerletStick(p10, p3);

            s15 = new VerletStick(p1, p8);
            s16 = new VerletStick(p5, p4);
            s17 = new VerletStick(p5, p9);
            s18 = new VerletStick(p6, p8);
            s19 = new VerletStick(p6, p10);
            s20 = new VerletStick(p7, p9);
            s21 = new VerletStick(p7, p3);
            s22 = new VerletStick(p2, p10);


        }
        public void pinAll()
        {
            p1.pinned = true;
            p2.pinned = true;
            p3.pinned = true;
            p4.pinned = true;
            p5.pinned = true;
            p6.pinned = true;
            p7.pinned = true;
            p8.pinned = true;
            p9.pinned = true;
            p10.pinned = true;
        }

        public void velZero()
        {
            p1.vel.X = 0; p1.vel.Y = 0;
            p2.vel.X = 0; p2.vel.Y = 0;
            p3.vel.X = 0; p3.vel.Y = 0;
            p4.vel.X = 0; p4.vel.Y = 0; 
            p5.vel.X = 0; p5.vel.Y = 0;
            p6.vel.X = 0; p6.vel.Y = 0;
            p7.vel.X = 0; p7.vel.Y = 0;
            p8.vel.X = 0; p8.vel.Y = 0;
            p9.vel.X = 0; p9.vel.Y = 0;
            p10.vel.X = 0; p10.vel.Y = 0;
        }

        public void Render(Graphics g, int width, int height)
        {
            p1.Render(g, width, height);
            p2.Render(g, width, height);
            p3.Render(g, width, height);
            p4.Render(g, width, height);
            p5.Render(g, width, height);
            p6.Render(g, width, height);
            p7.Render(g, width, height);
            p8.Render(g, width, height);
            p9.Render(g, width, height);
            p10.Render(g, width, height);


            s1.Render(g);
            s2.Render(g);
            s3.Render(g);
            s4.Render(g);
            s5.Render(g);
            s6.Render(g);
            s7.Render(g);
            s8.Render(g);
            s9.Render(g);
            s10.Render(g);
            s11.Render(g);
            s12.Render(g);
            s13.Render(g);
            s14.Render(g);
            s15.Render(g);
            s16.Render(g);
            s17.Render(g);
            s18.Render(g);
            s19.Render(g);
            s20.Render(g);
            s21.Render(g);
            s22.Render(g);

            pi1.X = p1.pos.X; pi1.Y = p1.pos.Y;
            pi2.X = p2.pos.X; pi2.Y = p2.pos.Y;
            pi3.X = p3.pos.X; pi3.Y = p3.pos.Y;
            pi4.X = p4.pos.X; pi4.Y = p4.pos.Y;
            //g.DrawImage(particleImage, pi1.X - 2, pi1.Y - 2, 40, 40);
        }
    }
}
