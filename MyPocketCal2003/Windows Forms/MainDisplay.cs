using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace MyPocketCal2003
{
    public partial class MainDisplay : BaseFormLibrary.FunctionsForm
    {
        string funtionSelected;
        
        //a string which will be passed to the rpn algo as string and will contain all the input in numeric 
        //form e.g. if user inputs sin(2) this string will hold the value of sin(2)
        string inputExpression;
        //the ArrayList which will hold the inputbox text
        MyArrayList inputBoxText;

        public MainDisplay()
        {
            InitializeComponent();
            inputBoxText = new MyArrayList();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Form oldWindow = Program.activeWindow; // the old window
            oldWindow.Hide(); // hide the window

            Program.activeWindow = new MatrixForm(); // make the form
            Program.activeWindow.Show(); // show the form
            //oldWindow.Dispose();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form oldWindow = Program.activeWindow; // the old window
            oldWindow.Hide(); // hide the window

            Program.activeWindow = new Statistic(); // make the form
            Program.activeWindow.Show(); // show the form
           //oldWindow.Dispose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form oldWindow = Program.activeWindow; // the old window
            oldWindow.Hide(); // hide the window

            Program.activeWindow = new Unit(); // make the form
            Program.activeWindow.Show(); // show the form
            //oldWindow.Dispose();
        }
        private void pictureBox115_Click(object sender, EventArgs e)
        {
            MatrixForm m = new MatrixForm();
            m.Show();
        }

        private void pictureBox116_Click(object sender, EventArgs e)
        {
            Statistic s = new Statistic();
            s.Show();
        }

        private void pictureBox113_Click(object sender, EventArgs e)
        {
            Unit c = new Unit();
            c.Show();
        }

        private void pictureBox120_Click(object sender, EventArgs e)
        {
            Plot p = new Plot();
            p.Show();
        }

        private void pictureBox118_Click(object sender, EventArgs e)
        {
            Differentiation d = new Differentiation();
            d.Show();
        }

        private void pictureBox119_Click(object sender, EventArgs e)
        {
            Integration i = new Integration();
            i.Show();
        }

        private void pictureBox117_Click(object sender, EventArgs e)
        {
            Vector v = new Vector();
            v.Show();
        }

        private void pictureBox139_Click(object sender, EventArgs e)
        {
            Equations ee = new Equations();
            ee.Show();
        }


        //zero pressed on the calculator
        private void zeroButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.ZERO);
        }
        //clear pressed on the calculator
        private void clearButton_Click(object sender, EventArgs e)
        {
            this.inputBox.Text = "";
            this.inputBoxText.Clear();
        }
        //1 pressed on the calculator
        private void oneButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.ONE);
        }
        //2 pressed on the calculator
        private void twoButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.TWO);
        }
        //3 pressed on the calculator
        private void threeButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.THREE);
        }
        //4 pressed on the calculator
        private void fourButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.FOUR);
        }
        //5 pressed on the calculator
        private void fiveButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.FIVE);
        }
        //6 pressed on the calculator
        private void sixButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.SIX);
        }
        //7 pressed on the calculator
        private void sevenButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.SEVEN);
        }
        //8 pressed on the calculator
        private void eightButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.EIGHT);
        }
        //9 pressed on the calculator
        private void nineButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.NINE);
        }
        //, pressed on the calculator
        private void commaButton_Click(object sender, EventArgs e)
        {
            //this.inputBox.Text += Constants.COMMA;
        }
        //+ pressed on the calculator
        private void plusButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.PLUS);
        }
        //- pressed on the calculator
        private void minusButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.MINUS);
        }
        //x pressed on the calculator
        private void multiplyButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.MULTIPLY);
        }
        //division pressed on the calculator
        private void divideButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.DIVIDE);
        }
        //. pressed on the calculator
        private void decimalButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.DECIMAL);
        }
        //( pressed on the calculator
        private void leftBracketButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.RIGHT_BRACKET);
        }
        //) pressed on the calculator
        private void rightBracketButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.LEFT_BRACKET);
        }
        //sin pressed on the calculator
        private void sinButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler(Constants.SIN + "(x), x =");
            this.funtionSelected = Constants.SIN;
        }
        //arcsin pressed on the calculator
        private void arcsinButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler(Constants.ARCSIN + "(x), x =");
            this.funtionSelected = Constants.ARCSIN;
        }
        //sinh pressed on the calculator
        private void sinhButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler(Constants.SINH + "(x), x ="); 
            this.funtionSelected = Constants.SINH;
        }
        //cos pressed on the calculator
        private void cosButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler(Constants.COS + "(x), x =");
            this.funtionSelected = Constants.COS;
        }
        //arccos pressed on the calculator
        private void arccosButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler(Constants.ARCCOS + "(x), x =");
            this.funtionSelected = Constants.ARCCOS;
        }
        //cosh pressed on the calculator
        private void coshButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler(Constants.COSH + "(x), x =");
            this.funtionSelected = Constants.COSH;
        }
        //tan pressed on the calculator
        private void tanButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler(Constants.TAN + "(x), x =");
            this.funtionSelected = Constants.TAN;
        }
        //arctan pressed on the calculator
        private void arctanButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler(Constants.ARCTAN + "(x), x =");
            this.funtionSelected = Constants.ARCTAN;
        }
        //tanh pressed on the calculator
        private void tanhButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler(Constants.TANH + "(x), x =");
            this.funtionSelected = Constants.TANH;
        }
        //sec pressed on the calculator
        private void secButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler(Constants.SEC + "(x), x =");
            this.funtionSelected = Constants.SEC;
        }
        //arcsec pressed on the calculator
        private void arcsecButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler(Constants.ARCSEC + "(x), x =");
            this.funtionSelected = Constants.ARCSEC;
        }
        //sech pressed on the calculator
        private void sechButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler(Constants.SECH + "(x), x =");
            this.funtionSelected = Constants.SECH;
        }
        //csc pressed on the calculator
        private void cscButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler(Constants.CSC + "(x), x =");
            this.funtionSelected = Constants.CSC;
        }
        //arccsc pressed on the calculator
        private void arccscButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler(Constants.ARCCSC + "(x), x =");
            this.funtionSelected = Constants.ARCCSC;
        }
        //csch pressed on the calculator
        private void cschButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler(Constants.CSCH + "(x), x =");
            this.funtionSelected = Constants.CSCH;
        }
        //cot pressed on the calculator
        private void cotButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler(Constants.COT + "(x), x =");
            this.funtionSelected = Constants.COT;
        }
        //arccot pressed on the calculator
        private void arccotButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler(Constants.ARCCOT + "(x), x =");
            this.funtionSelected = Constants.ARCCOT;
        }
        //coth pressed on the calculator
        private void cothButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler(Constants.COTH + "(x), x =");
            this.funtionSelected = Constants.COTH;
        }
        //e power x pressed on the calculator
        private void exButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler(Constants.EX + "x, x =");
            this.funtionSelected = Constants.EX;
        }
        //ln pressed on the calculator
        private void lnButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler(Constants.LN + "(x), x =");
            this.funtionSelected = Constants.LN;
        }
        //factorial pressed on the calculator
        private void xfactorialButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler(Constants.X_FACTORIAL + "!, x =");
            this.funtionSelected = Constants.X_FACTORIAL;
        }
        //10 power x pressed on the calculator
        private void tenXButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler(Constants.TEN_X + "x, x =");
            this.funtionSelected = Constants.TEN_X;
        }
        //log pressed on the calculator
        private void logButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler(Constants.LOG + "(x), x =");
            this.funtionSelected = Constants.LOG;
        }
        //x inverse pressed on the calculator
        private void xInverseButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler(Constants.X_INVERSE + "x, x =");
            this.funtionSelected = Constants.X_INVERSE;
        }
        //x power y pressed on the calculator
        private void xyButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler("x^y, x =, y=");
            this.funtionSelected = Constants.X_POWER_Y;
        }
        //x power 3 pressed on the calculator
        private void x3Button_Click(object sender, EventArgs e)
        {
            this.functionClickHandler("x^3), x =");
            this.funtionSelected = Constants.X_POWER_3;
        }
        //x power 2 pressed on the calculator
        private void x2Button_Click(object sender, EventArgs e)
        {
            this.functionClickHandler("x^2), x =");
            this.funtionSelected = Constants.X_POWER_2;
        }
        //x underroot y pressed on the calculator
        private void xUnderrootYButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler("x^(1/y)), x =, y =");
            this.funtionSelected = Constants.X_UNDERROOT_Y;
        }
        //x underroot 3 pressed on the calculator
        private void xUnderoot3Button_Click(object sender, EventArgs e)
        {
            this.functionClickHandler( "x^(1/3)), x =");
            this.funtionSelected = Constants.X_UNDERROOT_3;
        }
        //x underroot 2 pressed on the calculator
        private void xUnderrootButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler("x^(1/2)), x =");
            this.funtionSelected = Constants.X_UNDERROOT_2;
        }
        //nPr pressed on the calculator
        private void nPrButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler("nPr n =, r =");
            this.funtionSelected = Constants.NPR;
        }
        //nCr pressed on the calculator
        private void nCrButton_Click(object sender, EventArgs e)
        {
            this.functionClickHandler("nCr n =, r =");
            this.funtionSelected = Constants.NCR;
        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            BasicPostFix postFix = new BasicPostFix();
            String rpn = postFix.Convert(inputExpression);
            this.txtOutput.Text = postFix.Solve(rpn);
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            //throughout the following code inside each if condition the following steps are performed:
            //1. calculating sin value and adding it to the internal string
            //2. add the token to Arraylist
            //3. set the ArrayList to inputboxtext 
            if(this.funtionSelected.Equals(Constants.SIN))
            {
                this.inputExpression += ""+(Math.Sin(Double.Parse(txtFunctionInput.Text)));
                inputBoxText.Add(Constants.SIN + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.COS))
            {
                this.inputExpression += "" + (Math.Cos(Double.Parse(txtFunctionInput.Text)));
                inputBoxText.Add(Constants.COS + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.TAN))
            {
                this.inputExpression += "" + (Math.Tan(Double.Parse(txtFunctionInput.Text)));
                inputBoxText.Add(Constants.TAN + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.CSC))
            {
                this.inputExpression += "" + 1/(Math.Sin(Double.Parse(txtFunctionInput.Text)));
                inputBoxText.Add(Constants.TAN + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.SEC))
            {
                this.inputExpression += "" + 1/(Math.Cos(Double.Parse(txtFunctionInput.Text)));
                inputBoxText.Add(Constants.COS + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.COT))
            {
                this.inputExpression += "" + 1/(Math.Tan(Double.Parse(txtFunctionInput.Text)));
                inputBoxText.Add(Constants.TAN + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.ARCSIN))
            {
                this.inputExpression += "" + (Math.Asin(Double.Parse(txtFunctionInput.Text)));
                inputBoxText.Add(Constants.ARCSIN + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.ARCCOS))
            {
                this.inputExpression += "" + (Math.Acos(Double.Parse(txtFunctionInput.Text)));
                inputBoxText.Add(Constants.ARCCOS + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.ARCTAN))
            {
                this.inputExpression += "" + (Math.Atan(Double.Parse(txtFunctionInput.Text)));
                inputBoxText.Add(Constants.ARCTAN + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.ARCCSC))
            {
                this.inputExpression += "" + (Math.Asin(1/Double.Parse(txtFunctionInput.Text)));
                inputBoxText.Add(Constants.ARCCSC + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.ARCSEC))
            {
                this.inputExpression += "" + (Math.Acos(1/Double.Parse(txtFunctionInput.Text)));
                inputBoxText.Add(Constants.ARCSEC + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.ARCCOT))
            {
                this.inputExpression += "" + (1.570796327-Math.Atan(Double.Parse(txtFunctionInput.Text)));
                inputBoxText.Add(Constants.ARCCOT + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.SINH))
            {
                this.inputExpression += "" + (Math.Sinh(Double.Parse(txtFunctionInput.Text)));
                inputBoxText.Add(Constants.SINH + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.COSH))
            {
                this.inputExpression += "" + (Math.Cosh(Double.Parse(txtFunctionInput.Text)));
                inputBoxText.Add(Constants.COSH + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.TANH))
            {
                this.inputExpression += "" + (Math.Tanh(Double.Parse(txtFunctionInput.Text)));
                inputBoxText.Add(Constants.TANH + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.CSCH))
            {
                this.inputExpression += "" + 1/(Math.Sinh(Double.Parse(txtFunctionInput.Text)));
                inputBoxText.Add(Constants.CSCH + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.SECH))
            {
                this.inputExpression += "" + 1/(Math.Cosh(Double.Parse(txtFunctionInput.Text)));
                inputBoxText.Add(Constants.SECH + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.COTH))
            {
                this.inputExpression += "" + 1/(Math.Tanh(Double.Parse(txtFunctionInput.Text)));
                inputBoxText.Add(Constants.TANH + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.EX))
            {
                this.inputExpression += "" + Math.Pow((Math.E),Double.Parse(txtFunctionInput.Text));
                inputBoxText.Add(Constants.EX + "^" + txtFunctionInput.Text);
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.LN))
            {
                this.inputExpression += "" + Math.Log(Double.Parse(txtFunctionInput.Text));
                inputBoxText.Add(Constants.LN + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.X_FACTORIAL))
            {
                //this.inputExpression += "" + 

            }
            else if (this.funtionSelected.Equals(Constants.TEN_X))
            {
                this.inputExpression += "" + Math.Pow(10.0, Double.Parse(txtFunctionInput.Text));
                inputBoxText.Add(Constants.TEN_X + "^" + txtFunctionInput.Text);
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.LOG))
            {
                this.inputExpression += "" + Math.Log10(Double.Parse(txtFunctionInput.Text));
                inputBoxText.Add(Constants.LOG + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.X_INVERSE))
            {
                this.inputExpression += "" + 1.0/Double.Parse(txtFunctionInput.Text);
                inputBoxText.Add(Constants.X_INVERSE + txtFunctionInput.Text);
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.X_POWER_Y))
            {
                double x = 0.0;
                double y = 0.0;
                this.inputExpression += "" + Math.Pow(x, y);
                inputBoxText.Add(x+Constants.X_POWER_Y+y);
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.X_POWER_3))
            {
                this.inputExpression += "" + Math.Pow(Double.Parse(txtFunctionInput.Text),3);
                inputBoxText.Add(txtFunctionInput.Text + Constants.X_POWER_3);
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.X_POWER_2))
            {
                this.inputExpression += "" + Math.Pow(Double.Parse(txtFunctionInput.Text), 2);
                inputBoxText.Add(txtFunctionInput.Text + Constants.X_POWER_2);
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.X_UNDERROOT_Y))
            {

            }
            else if (this.funtionSelected.Equals(Constants.X_UNDERROOT_3))
            {
                this.inputExpression += "" + Math.Pow(Double.Parse(txtFunctionInput.Text), (1/3));
                inputBoxText.Add(txtFunctionInput.Text + Constants.X_UNDERROOT_3);
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.X_UNDERROOT_2))
            {
                this.inputExpression += "" + Math.Pow(Double.Parse(txtFunctionInput.Text), (1 / 2));
                inputBoxText.Add(txtFunctionInput.Text + Constants.X_UNDERROOT_2);
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.NPR))
            {
                
            }
            else if (this.funtionSelected.Equals(Constants.NCR))
            {


            }

            setFunctionControl(false);
            MessageBox.Show(inputExpression); //88888
            inputExpression = ""; //88888888
        }
        //a function which sets the visibility of 3 controls to false or true
        private void setFunctionControl(bool value)
        {
            txtFunctionInput.Visible = value;
            btnOK.Visible = value;
            labelFunction.Visible = value;
        }
        //to add the passed string to input data structures
        private void addAsInput(String input)
        {
            this.inputBoxText.Add(input);
            this.inputBox.Text = this.inputBoxText.ToString();
        }
        //to handle the click on different function buttons
        private void functionClickHandler(string input)
        {
            labelFunction.Text = input;
            setFunctionControl(true); //make the 3 controls visible which are required for input
            txtFunctionInput.Focus();
        }
    }
    public class MyArrayList : ArrayList
    {
        public override String ToString()
        {
            return (String)this[this.Count - 1];
        }
    }
}