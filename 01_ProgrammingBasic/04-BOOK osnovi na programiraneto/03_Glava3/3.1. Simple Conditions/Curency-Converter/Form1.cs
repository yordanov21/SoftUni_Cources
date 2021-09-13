using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curency_Converter
{
    public partial class FormConverter : System.Windows.Forms.Form
    {
        public FormConverter()
        {
            InitializeComponent();
        }

        private void labelResult_Click(object sender, EventArgs e)
        {

        }

        private void FormConverter_Load(object sender, EventArgs e)
        {
            this.comboBoxCurrency.SelectedItem = "EUR";
            this.textBoxCoursEUR.SelectedText = "1.95583";
            this.textBoxCourseUSD.SelectedText = "1.80810";
            this.textBoxCourseGBP.SelectedText = "2.54990";
        }

        private void numericUpDownAmount_ValueChanged(object sender, EventArgs e)
        {
            ConvertCurrency();
        }

        private void comboBoxCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConvertCurrency();
        }

        private void ConvertCurrency()
        {
            var originalAmount = this.numericUpDownAmount.Value;
            var convertedAmount = originalAmount;
            if (this.comboBoxCurrency.SelectedItem.ToString() == "EUR")
            {
                decimal eur = decimal.Parse(textBoxCoursEUR.Text);
                convertedAmount = originalAmount / eur;
            }
            else if (this.comboBoxCurrency.SelectedItem.ToString() == "USD")
            {
                convertedAmount = originalAmount / 1.80810m;
            }
            else if (this.comboBoxCurrency.SelectedItem.ToString() == "GBP")
            {
                convertedAmount = originalAmount / 2.54990m;
            }
            this.labelResult.Text = originalAmount + " лв. = " +
            Math.Round(convertedAmount, 2) + " " + this.comboBoxCurrency.SelectedItem;
        }

        private void textBoxCoursEUR_TextChanged(object sender, EventArgs e)
        {
          

        }

        private void textBoxCourseUSD_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBoxCourseGBP_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
