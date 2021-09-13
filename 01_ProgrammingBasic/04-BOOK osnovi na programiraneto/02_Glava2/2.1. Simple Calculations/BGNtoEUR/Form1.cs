using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BGNtoEUR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDownAmount_ValueChanged(object sender, EventArgs e)
        {
            Convert();
        }

        void Convert()
        {
            var amount = this.numericUpDownAmount.Value;
            var amountToEuro = amount * 1.95583m;

            this.labelResult.Text = 
                amount+" лева = "+
                Math.Round( amountToEuro,2) +" евро";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
