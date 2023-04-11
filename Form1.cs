using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VerletTower
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap bmp;
        VerletPoint point, point2, point3, point4, point5;
        VerletStick stick, stick2, stick3;
        bool pin = true;
        Box box;
        int timeM, timeSl, timeSa;
        int pos1, pos2, pos3, pos4, pos5;
        List<Box> boxesO;
        List<Box> boxes;
        int contCaja = 0;
        bool air;


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!air)
            {
                contCaja++;
                Box box2 = new Box(30, 30, point4/*,boxes*/);
                boxes.Add(box2);
                air = true;
            }
        }
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            pos1 = pictureBox1.Width / 2;
            pos2 = pictureBox1.Width / 2 +25;

            point = new VerletPoint(pos1, 0, pin);
            point2 = new VerletPoint(pictureBox1.Width / 2 - 25, 20, 1f);
            point3 = new VerletPoint(pictureBox1.Width / 2 - 50, 25, 1f);
            point4 = new VerletPoint(pictureBox1.Width / 2 - 70, 30, 1f);
            point5 = new VerletPoint(pictureBox1.Width / 2, pictureBox1.Height - 35);
            stick = new VerletStick(point, point2);
            stick2 = new VerletStick(point2, point3);
            stick3 = new VerletStick(point3, point4);
            point.draw = true;
            point2.draw = true;
            point3.draw = true;
            point4.draw = true;
            point5.draw = true;
            stick.draw = true;
            stick2.draw = true;
            stick3.draw = true;
            timer1.Enabled = true;


            boxes = new List<Box>();
            box = new Box(30, 30, point5/*, boxes*/);
            boxes.Add(box);

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            contCaja = 0;

            timeM = 0;
            timeSa= 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.Transparent);
            pictureBox1.BackgroundImage = Resource1.city;

            point.Render(g, pictureBox1.Width, pictureBox1.Height);
            point2.Render(g, pictureBox1.Width, pictureBox1.Height);
            point3.Render(g, pictureBox1.Width, pictureBox1.Height);
            point4.Render(g, pictureBox1.Width, pictureBox1.Height);
            stick.Render(g);
            stick2.Render(g);
            stick3.Render(g);
            label1.Text = "Cajas:";

            label2.Text = contCaja.ToString();

            if (contCaja > 0)
            {
                if (boxes[boxes.Count() - 1].p1.pos.Y + 40 > boxes[boxes.Count() - 2].p1.pos.Y)
                    air = false;
            }

            if (timeM < 20)
            {
                
                if (timeM < 15)
                {
                    point4.old.X -= 1f;
                    point4.old.Y -= 1;
                }
            }
            else if (timeM > 20 && timeM < 40)
            {
                
                if (timeM < 35)
                {
                    point4.old.X += 1f;
                    point4.old.Y -= 1;
                }

            }
            else if (timeM == 40)
                timeM = 0;
            timeM++;
            /*if(timeM%15 == 1)
            {
                timeSa ++;

                if (point.pos.X == pos1)
                    point.pos.X = pos2;
                else if(point.pos.X == pos2)
                    point.pos.X = pos1;
            }*/
            if (contCaja == 15)
            {
                timer1.Enabled = false;
                MessageBox.Show("Ganaste, score: " + (contCaja - 1));

                DialogResult dialogResult = MessageBox.Show("Jugar de nuevo?", "Cerrar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        Init();
                        break;

                    case DialogResult.No:
                        Close();
                        break;
                }
            }


            if (contCaja > 0)
            {

                float medAb = boxes[contCaja - 1].p9.pos.X;
                float medArr = boxes[contCaja].p6.pos.X;
                float der = medAb - medArr;
                float izq = medArr - medAb;

                if (boxes[contCaja].p4.pos.Y >= boxes[contCaja - 1].p1.pos.Y && 
                    ((boxes[contCaja].p6.pos.X <= boxes[contCaja - 1].p2.pos.X) &&
                    (boxes[contCaja].p6.pos.X >= boxes[contCaja - 1].p1.pos.X)
                    )
                    //((izq <= 10 && izq >= 0) || (der <= 10 && der >= 0))
                    )
                {
                    boxes[contCaja].p6.pinned = true;
                    boxes[contCaja].p9.pinned = true;


                    boxes[contCaja].p1.pos.Y = boxes[contCaja].p6.pos.Y; 
                    boxes[contCaja].p2.pos.Y = boxes[contCaja].p6.pos.Y; 
                    boxes[contCaja].p3.pos.Y = boxes[contCaja].p9.pos.Y; 
                    boxes[contCaja].p4.pos.Y = boxes[contCaja].p9.pos.Y; 
                    boxes[contCaja].p5.pos.Y = boxes[contCaja].p6.pos.Y; 
                    boxes[contCaja].p7.pos.Y = boxes[contCaja].p6.pos.Y; 
                    boxes[contCaja].p8.pos.Y = boxes[contCaja].p9.pos.Y; 
                    boxes[contCaja].p10.pos.Y = boxes[contCaja].p9.pos.Y;

                    boxes[contCaja].velZero();
                    boxes[contCaja].pinAll();

                }
                else if (boxes[contCaja].p9.pos.Y >= boxes[contCaja - 1].p6.pos.Y)
                {
                    if ((izq >10 && izq < 30) || der > 10 && der < 30)
                    {
                        if (der > izq && boxes[contCaja].p6.pinned == false)
                        {
                            boxes[contCaja].p1.pos.X -= 10;
                            boxes[contCaja].p2.pos.X -= 10;
                        }
                        else if(der < izq && boxes[contCaja].p6.pinned == false)
                        {
                            boxes[contCaja].p1.pos.X += 10;
                            boxes[contCaja].p2.pos.X += 10;
                        }
                    }
                }

                if (boxes[contCaja].p4.pos.Y >= pictureBox1.Height ||
                    boxes[contCaja].p3.pos.Y >= pictureBox1.Height ||
                    boxes[contCaja].p2.pos.Y >= pictureBox1.Height ||
                    boxes[contCaja].p1.pos.Y >= pictureBox1.Height
                    )
                {
                    timer1.Enabled = false;
                    MessageBox.Show("Perdiste, score: " + (contCaja-1));

                    DialogResult dialogResult = MessageBox.Show("Jugar de nuevo?", "Cerrar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    switch (dialogResult)
                    {
                        case DialogResult.Yes:
                            Init();
                            break;

                        case DialogResult.No:
                            Close();
                            break;
                    }
                }
            }



            for (int i = 0; i < boxes.Count(); i++)
            {
                boxes[i].Render(g, pictureBox1.Width, pictureBox1.Height);
            }


            pictureBox1.Invalidate();
        }
    }
}
/*if(point4.old.X>point4.pos.X && r)
{
    point4.old.X += 30;
    point4.old.Y -= 15;
    r = false;
    l = true;
}
            else if (point4.old.X < point4.pos.X && l)
{
    point4.old.X -= 30;
    point4.old.Y -= 15;
    r = true;
    l = false;
}*/
