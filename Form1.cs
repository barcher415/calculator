using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace Calculator
{
    public partial class Form1 : Form
    {

        List<float> storedNums = new List<float>();
        List<string> storedOps = new List<string>();
        bool opFlag = false;

        public Form1()
        {
            InitializeComponent();
        }

        //Numbers

        private void btnOne_Click(object sender, EventArgs e)
        {
            addNumber(1);
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            addNumber(2);
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            addNumber(3);
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            addNumber(4);
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            addNumber(5);
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            addNumber(6);
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            addNumber(7);
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            addNumber(8);
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            addNumber(9);
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            addNumber(0);
        }

        private void btnClear_click(object sender, EventArgs e)
        {
            clear();
        }


        //Operators


        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (history.Text.Contains("="))
            {
                clear();
            }
            if (!display.Text.Contains("."))
            {
                display.Text += ".";
            }
            
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            operatorClicked("=");

            //do multiplication and division first for pemdas
            for (int i = 0; i < storedOps.Count; i++) {
                if (storedOps[i].Equals("*"))
                {
                    storedNums[i] = storedNums[i] * storedNums[i + 1];
                    storedNums.Remove(i + 1);
                    storedOps.RemoveAt(i);
                } else if (storedOps[i].Equals("/"))
                {
                    storedNums[i] = storedNums[i] / storedNums[i + 1];
                    storedNums.Remove(i + 1);
                    storedOps.RemoveAt(i);
                }
            }

            for (int i = 0; i < storedOps.Count; i++)
            {
                if (storedOps[i].Equals("+"))
                {
                    storedNums[i] = storedNums[i] + storedNums[i + 1];
                    storedNums.Remove(i + 1);
                    storedOps.RemoveAt(i);
                } else if (storedOps[i].Equals("-"))
                {
                    storedNums[i] = storedNums[i] - storedNums[i + 1];
                    storedNums.Remove(i + 1);
                    storedOps.RemoveAt(i);
                }
            }

            display.Text = storedNums[0].ToString();

        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            operatorClicked("/");
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            operatorClicked("*");
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            operatorClicked("-");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            operatorClicked("+");
        }


        //Methods
        private void addNumber(int num)
        {
            if (history.Text.Contains("="))
            {
                clear();
            }
            display.Text += num.ToString();
            opFlag = true;
        }

        private void operatorClicked(string op)
        {
            if (history.Text.Contains('='))
            {
                string temp = display.Text;
                clear();
                history.Text = "";
                display.Text = temp;
                opFlag = true;
            }
            
            if (opFlag)
            {
                checkDecimal();
                storedNums.Add(float.Parse(display.Text));
                storedOps.Add(op);
                history.Text += display.Text + " " + op + " ";
                display.Text = "";
                opFlag = false;
            }
            
        }

        private void checkDecimal()
        {
            if (display.Text.EndsWith("."))
            {
                display.Text += "0";
            }
        }

        private void clear()
        {
            history.Text = "";
            display.Text = "";
            storedNums.Clear();
            storedOps.Clear();
        }
    }
}