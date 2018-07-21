using System;
using System.Windows.Forms;

namespace Servis_last_VERSO
{
    internal class ZZ_Class_for_count
    {
        private decimal work, price, sum;


        public void couting(TextBox textbx, TextBox textbx2, Label totall)
        {
            if (string.IsNullOrEmpty(textbx.Text) == false)
                work = Convert.ToDecimal(textbx.Text);
            else
                textbx.Text = "0";
            if (string.IsNullOrEmpty(textbx2.Text) == false)
                price = Convert.ToDecimal(textbx2.Text);
            else
                textbx2.Text = "0";
            sum = work + price;
            totall.Text = Convert.ToString(sum);
        }
    }
}