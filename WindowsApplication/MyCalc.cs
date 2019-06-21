using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsApplication
{
    public partial class MyCalc : Form
    {
        public MyCalc()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, EventArgs e)
        {
            bool decimalFlag = false;
            bool totalFlag = false;

            Button b = (Button)sender;
            string inputTxt = b.Text;
            output.Text = inputTxt;

            // if a total has been calculated, refresh the display
            if (totalFlag == true)
            {
                output.Text = "0";
                totalFlag = false;
            }

            // if 0 in output and number typed, clear for number typed
            // but not if an operator's been typed
            if (output.Text == "0" 
                && !inputTxt.Contains("*") 
                && !inputTxt.Contains("/") 
                && !inputTxt.Contains("+") 
                && !inputTxt.Contains("-"))
            {
                output.Text = "";
            }

        }

    }
}
