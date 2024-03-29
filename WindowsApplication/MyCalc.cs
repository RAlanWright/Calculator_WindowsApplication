﻿using System;
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
        bool decimalFlag = false;
        bool totalFlag = false;

        Queue<string> Calcs = new Queue<string>();
        string NumString = "";  // Empty value to catch if an operator was used first
        double total = 0;
        public MyCalc()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string inputTxt = b.Text;

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

            switch (inputTxt)
            {
                case "0":
                    output.Text += "0";
                    NumString += "0";
                    break;

                case "1":
                    output.Text += "1";
                    NumString += "1";
                    break;

                case "2":
                    output.Text += "2";
                    NumString += "2";
                    break;

                case "3":
                    output.Text += "3";
                    NumString += "3";
                    break;

                case "4":
                    output.Text += "4";
                    NumString += "4";
                    break;

                case "5":
                    output.Text += "5";
                    NumString += "5";
                    break;

                case "6":
                    output.Text += "6";
                    NumString += "6";
                    break;

                case "7":
                    output.Text += "7";
                    NumString += "7";
                    break;

                case "8":
                    output.Text += "8";
                    NumString += "8";
                    break;

                case "9":
                    output.Text += "9";
                    NumString += "9";
                    break;

                case ".":
                    // Only used once per operation!
                    if (decimalFlag == false)
                    {
                        decimalFlag = true;
                        if (NumString.Length == 0)
                        {
                            output.Text += "0.";
                        }
                        else
                        {
                            output.Text += ".";
                        }
                        NumString += ".";
                    }
                    break;

                case "*":
                    if (NumString.Length > 0)
                    {
                        Calcs.Enqueue(NumString);
                        output.Text += " * ";
                        Calcs.Enqueue("*");
                        NumString = "";
                        decimalFlag = false;
                    }
                    break;

                case "/":
                    if (NumString.Length > 0)
                    {
                        Calcs.Enqueue(NumString);
                        output.Text += " / ";
                        Calcs.Enqueue("/");
                        NumString = "";
                        decimalFlag = false;
                    }
                    break;

                case "+":
                    if (NumString.Length > 0)
                    {
                        Calcs.Enqueue(NumString);
                        output.Text += " + ";
                        Calcs.Enqueue("+");
                        NumString = "";
                        decimalFlag = false;
                    }
                    break;

                case "-":
                    if (NumString.Length > 0)
                    {
                        Calcs.Enqueue(NumString);
                        output.Text += " - ";
                        Calcs.Enqueue("-");
                        NumString = "";
                        decimalFlag = false;
                    }
                    break;

                case "=":
                    // If there's a number in NumString, add it
                    if (NumString != "")
                    {
                        Calcs.Enqueue(NumString);
                    }
                    // If there are at least two entries aand one operator
                    if (Calcs.Count < 3 || NumString == "")
                    {
                        return;
                    }
                    else
                    {
                        NumString = "";
                        decimalFlag = false;
                        output.Text += " = ";
                        computeTotal();
                    }
                    break;

                case "C":
                    decimalFlag = false;
                    totalFlag = true;
                    Calcs.Clear();
                    NumString = "";
                    output.Text = "0";
                    total = 0;
                    break;

                default:
                    return;
            }
        }

        public void computeTotal()
        {
            string[] calcString = new string[Calcs.Count];
            Calcs.CopyTo(calcString, 0);
            double val1 = 0;
            double val2 = 0;

            bool firstOperation = true;

            // Process the string
            for (int i = 0; i < Calcs.Count; i++)
            {
                switch (calcString[i])
                {
                    case "*":
                        val1 = Convert.ToDouble(calcString[i - 1]);
                        val2 = Convert.ToDouble(calcString[i + 1]);
                        if (firstOperation == true)
                        {
                            total = val1 * val2;
                            firstOperation = false;
                        }
                        else
                        {
                            total *= val2;
                        }
                        break;

                    case "/":
                        val1 = Convert.ToDouble(calcString[i - 1]);
                        val2 = Convert.ToDouble(calcString[i + 1]);
                        if (firstOperation == true)
                        {
                            total = val1 / val2;
                            firstOperation = false;
                        }
                        else
                        {
                            total /= val2;
                        }
                        break;

                    case "+":
                        val1 = Convert.ToDouble(calcString[i - 1]);
                        val2 = Convert.ToDouble(calcString[i + 1]);
                        if (firstOperation == true)
                        {
                            total = val1 + val2;
                            firstOperation = false;
                        }
                        else
                        {
                            total += val2;
                        }
                        break;

                    case "-":
                        val1 = Convert.ToDouble(calcString[i - 1]);
                        val2 = Convert.ToDouble(calcString[i + 1]);
                        if (firstOperation == true)
                        {
                            total = val1 - val2;
                            firstOperation = false;
                        }
                        else
                        {
                            total -= val2;
                        }
                        break;

                    default:
                        break;
                }
            }

            output.Text += "" + total;
            totalFlag = true;
            Calcs.Clear();
            Array.Clear(calcString, 0, calcString.Length);
            total = 0;
        }
    }
}
