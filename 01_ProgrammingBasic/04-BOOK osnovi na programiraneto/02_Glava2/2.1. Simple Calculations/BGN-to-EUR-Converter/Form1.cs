using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BGN_to_EUR_Converter
{
    public partial class FormConverter : Form
    {
        public FormConverter()
        {
         
             InitializeComponent();
        }

        private void numericUpDownAmount_ValueChanged(object sender, EventArgs e)
        {
            Convert();
        }

        void Convert()
        {
            var amount = this.numericUpDownAmount.Value;
            var amountInEuro = amount * 1.95583m;
            this.labelResult.Text = amountInEuro.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Convert();
        }

        private void labelResult_Click(object sender, EventArgs e)
        {
            Convert();
        }
    }
}
