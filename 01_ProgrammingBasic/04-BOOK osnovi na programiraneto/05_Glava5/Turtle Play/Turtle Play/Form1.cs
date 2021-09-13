using Nakov.TurtleGraphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turtle_Play
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Draw_Click(object sender, EventArgs e)
        {
           
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Turtle.Reset();
        }

        private void Hide_Turtle_Click(object sender, EventArgs e)
        {
            if (Turtle.ShowTurtle)
            {
                Turtle.ShowTurtle = false;
                this.Hide_Turtle.Text = "Show Turtle";
            }
            else
            {
                Turtle.ShowTurtle = true;
                this.Hide_Turtle.Text = "Hide Turtle";
            }
        }

        private void Hexagon_Click(object sender, EventArgs e)
        {
            
           Turtle.Delay = 100;
           for (int i = 0; i <6; i++)
           {
               Turtle.Forward(100);
               Turtle.Rotate(60);
           }
        }

        private void Star_Click(object sender, EventArgs e)
        {
            Turtle.PenColor = Color.GreenYellow;
            Turtle.Delay = 150;
            for (int i = 0; i < 5; i++)
            {
                Turtle.Forward(200);
                Turtle.Rotate(144);
            }
           
        }

        private void Spiral_Click(object sender, EventArgs e)
        {
            Turtle.PenColor = Color.Green;
            Turtle.Delay = 150;
            for (int i = 0; i < 20; i++)
            {
                Turtle.Forward(20+10*i);
                Turtle.Rotate(60);
            }
        }

        private void Sun_Click(object sender, EventArgs e)
        {
            Turtle.PenColor = Color.Green;
            Turtle.PenSize = 2;
            Turtle.Delay = 50;
            for (int i = 0; i < 36; i++)
            {
                Turtle.Forward(100);
                Turtle.Rotate(170);
                Turtle.Forward(100);
                Turtle.Rotate(10);
                Turtle.Rotate(10);
            }
        }

        private void Triangle_Click(object sender, EventArgs e)
        {
            Turtle.PenColor = Color.Green;
            Turtle.PenSize = 2;
            Turtle.Delay = 50;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 22; j++)
                {
                    Turtle.Forward(20 + 10 * j);
                    Turtle.Rotate(120);
                }

            } 
        }

        private void Cristmas_Tree_Click(object sender, EventArgs e)
        {
            Turtle.PenColor = Color.Green;
            Turtle.PenSize = 2;
            Turtle.Delay = 10;
            Turtle.Rotate(30);

            for (int d = 0; d < 6; d++)
            {

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 22; j++)
                    {
                        Turtle.Forward(20 + 5 * j);
                        Turtle.Rotate(120);
                    }
                    Turtle.Rotate(240);
                    Turtle.Forward(20 - i * 5);
                }
                Turtle.Rotate(90);
            }
            
        }
    }
}
