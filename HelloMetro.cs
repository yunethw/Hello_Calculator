using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hello_Metro
{
    public partial class HelloMetro : MetroFramework.Forms.MetroForm
    {
        protected double num1= 0;
        protected double nummult = 1;
        protected double num2, final;
        protected bool first = true;
        protected string signmap;

        public Dictionary<string, int> Operation = new Dictionary<string, int>
        {
            {"÷", 1},
            {"x", 2},
            {"+", 3},
            {"-", 4}
        };

        private void Operator(string sign)
        {
            textbox_top.Text = textbox_top.Text + textbox_calc.Text + " " + sign + " ";

            switch (Operation[sign]) //need to fix this
            {
            case 1:
                if(first)
                {
                    num1 = Convert.ToDouble(textbox_calc.Text);
                    first = false;
                }
                else
                {
                    num1 /= Convert.ToDouble(textbox_calc.Text);
                }
                break;

            case 2:
                nummult *= Convert.ToDouble(textbox_calc.Text);
                break;

            case 3:
                num1 += Convert.ToDouble(textbox_calc.Text);
                break;

            case 4:
                if (first)
                {
                    num1 = Convert.ToDouble(textbox_calc.Text);
                    first = false;
                }
                else
                {
                    num1 -= Convert.ToDouble(textbox_calc.Text);
                }
                break;
            }

            signmap = sign;
            textbox_calc.Clear();
        }

        private void CalcBox(string num)
        {
            textbox_calc.Text = textbox_calc.Text + num;
        }

        public HelloMetro()
        {
            InitializeComponent();
        }

        private void HelloMetro_Load(object sender, EventArgs e)
        {
            textbox_calc.Clear();
            textbox_calc.Select();
            textbox_calc.Focus();
        }

        #region //numericalbuttonclicks
        private void button_1_Click(object sender, EventArgs e)
        {
            CalcBox("1");
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            CalcBox("2");
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            CalcBox("3");
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            CalcBox("4");
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            CalcBox("5");
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            CalcBox("6");
        }

        private void button_7_Click(object sender, EventArgs e)
        {
            CalcBox("7");
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            CalcBox("8");
        }

        private void button_9_Click(object sender, EventArgs e)
        {
            CalcBox("9");
        }

        private void button0_Click(object sender, EventArgs e)
        {
            CalcBox("0");
        }
        #endregion

        private void buttonPoint_Click(object sender, EventArgs e)
        {
            CalcBox(".");
        }

        //clear button
        private void buttonC_Click(object sender, EventArgs e) 
        {
            textbox_top.Clear();
            textbox_calc.Clear();
            num1 = 0;
            num2 = 0;
            nummult = 1;
            final = 0;
            first = true;
        }

        #region //operator buttons
        private void buttonSub_Click(object sender, EventArgs e)
        {
            Operator("-");
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            Operator("x");
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            Operator("÷");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Operator("+");
        }
        #endregion

        private void buttonEq_Click(object sender, EventArgs e)
        {
            num2 = Convert.ToDouble(textbox_calc.Text);
            textbox_top.Text = textbox_top.Text + textbox_calc.Text + " ="; 
            switch(Operation[signmap])
            {
                case 1:
                    final = num1 / num2;
                    break;

                case 2:
                    final = nummult * num2;
                    break;

                case 3:
                    final = num1 + num2;
                    break;

                case 4:
                    final = num1 - num2;
                    break;
            }

            textbox_calc.Text = final.ToString();
        }


    }
}
