using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06.Catch_The_Button
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCatheMe_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonCatheMe_MouseEnter(object sender, EventArgs e)
        {
            Random rand = new Random();
            var maxWidth = this.ClientSize.Width - buttonCatheMe.ClientSize.Width;
            var maxHeight = this.ClientSize.Height - buttonCatheMe.ClientSize.Height;
            this.buttonCatheMe.Location = new Point(rand.Next(maxWidth), rand.Next(maxHeight));
            
        }

        private void buttonCatheMe_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Обичам те, Мацииии!!!");
        }
    }
}
