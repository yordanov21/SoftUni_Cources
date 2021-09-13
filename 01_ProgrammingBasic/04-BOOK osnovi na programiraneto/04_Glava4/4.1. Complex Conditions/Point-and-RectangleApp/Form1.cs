using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Point_and_RectangleApp
{
    public partial class FormPointAndRectangle : Form
    {
        public FormPointAndRectangle()
        {
            InitializeComponent();
        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            Draw();
        }

        private void FormPointAndRectangle_Load(object sender, EventArgs e)
        {
            Draw();
        }

        private void numericUpDownX1_ValueChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void numericUpDownY1_ValueChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void numericUpDownX2_ValueChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void numericUpDownY2_ValueChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void numericUpDownX_ValueChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void numericUpDownY_ValueChanged(object sender, EventArgs e)
        {
            Draw();
        }
        
        private void Draw()
        {

        }
    }
}
