using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections;

namespace MyPocketCal2003
{
    public partial class MainDisplay : BaseFormLibrary.FunctionsForm
    {
        string funtionSelected;
        
        //a string which will be passed to the rpn algo as string and will contain all the input in numeric 
        //form e.g. if user inputs sin(2) this string will hold the value of sin(2)
        MyArrayList inputExpression;
        //the ArrayList which will hold the inputbox text
        MyArrayList inputBoxText;


        public MainDisplay()
        {
            InitializeComponent();
            inputBoxText = new MyArrayList();
            inputExpression = new MyArrayList();
            checkBoxDeg.Enabled = false;
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
            Complex c = new Complex();
            c.Show();
        }

        private void pictureBox119_Click(object sender, EventArgs e)
        {
            this.functionClickHandler(Constants.COMPLEX);
            this.funtionSelected = Constants.COMPLEX;
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
            this.clearRegisters();
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
            this.addAsInput(Constants.COMMA);
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
            this.functionClickHandler(Constants.X_FACTORIAL + "x =");
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
            if (checkBoxRPN.Checked)
            {
                BasicPostFix postFix = new BasicPostFix();
                //solve the rpn input
                this.txtOutput.Text = postFix.solveRPN(inputExpression.toCompleteString());
            }
            else
            {
                BasicPostFix postFix = new BasicPostFix();
                //convert to rpn
                String rpn = postFix.Convert(inputExpression.toCompleteString());
                //solve the rpn
                this.txtOutput.Text = postFix.Solve(rpn);
            }
            this.clearRegisters(); //clear the input registers
        }
        private void clearRegisters()
        {
            this.inputBox.Text = "";
            this.inputBoxText.Clear();
            this.inputExpression.Clear();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {

            //if the last entry is a numeral from 0-9 or ) then that means the user wants to multiply
            //the selected function with the last entry so we do:
            string input = inputBox.Text.ToString();
            if(input.Length != 0)
                if (Regex.IsMatch(input[input.Length-1]+"", @"[\d)]"))
                {
                    this.inputExpression.Add("x");
                    inputBoxText.Add("x");
                    inputBox.Text += inputBoxText.ToString();
                }

            //throughout the following code inside each if condition the following steps are performed:
            //1. calculating sin value and adding it to the internal string
            //2. add the token to Arraylist
            //3. set the ArrayList to inputboxtext 
            if(this.funtionSelected.Equals(Constants.SIN))
            {
                if (checkBoxDeg.Checked)
                    this.inputExpression.Add("" + (Math.Sin(Double.Parse(txtFunctionInput.Text) * (Math.PI / 180))));
                else
                    this.inputExpression.Add("" + (Math.Sin(Double.Parse(txtFunctionInput.Text))));
                inputBoxText.Add(Constants.SIN + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.COMPLEX))
            {
                //if its a complex number the function is gonna return my own created representation of a complex number
                string returnValue = ComplexNumber.convertToComplex(txtFunctionInput.Text.ToString());
                if(returnValue != null)
                {
                    inputBoxText.Add("(" + txtFunctionInput.Text.ToString() + ")");
                    inputBox.Text += inputBoxText.ToString();
                    this.inputExpression.Add(returnValue);
                }
            }
            else if (this.funtionSelected.Equals(Constants.COS))
            {
                if (checkBoxDeg.Checked)
                    this.inputExpression.Add("" + (Math.Cos(Double.Parse(txtFunctionInput.Text) * (Math.PI / 180))));
                else
                    this.inputExpression.Add("" + (Math.Cos(Double.Parse(txtFunctionInput.Text))));
                inputBoxText.Add(Constants.COS + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.TAN))
            {
                if (checkBoxDeg.Checked)
                    this.inputExpression.Add("" + (Math.Tan(Double.Parse(txtFunctionInput.Text) * (Math.PI / 180))));
                else
                    this.inputExpression.Add("" + (Math.Tan(Double.Parse(txtFunctionInput.Text))));
                inputBoxText.Add(Constants.TAN + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.CSC))
            {
                if (checkBoxDeg.Checked)
                    this.inputExpression.Add("" + 1 / (Math.Sin(Double.Parse(txtFunctionInput.Text) * (Math.PI / 180))));
                else
                    this.inputExpression.Add("" + 1 / (Math.Sin(Double.Parse(txtFunctionInput.Text))));
                inputBoxText.Add(Constants.CSC + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.SEC))
            {
                if (checkBoxDeg.Checked)
                    this.inputExpression.Add("" + (1 / (Math.Cos(Double.Parse(txtFunctionInput.Text) * (Math.PI / 180)))));
                else
                    this.inputExpression.Add("" + 1 / (Math.Cos(Double.Parse(txtFunctionInput.Text))));
                inputBoxText.Add(Constants.SEC + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.COT))
            {
                if (checkBoxDeg.Checked)
                    this.inputExpression.Add("" + (1 / (Math.Tan(Double.Parse(txtFunctionInput.Text) * (Math.PI / 180)))));
                else
                    this.inputExpression.Add("" + 1 / (Math.Tan(Double.Parse(txtFunctionInput.Text))));
                inputBoxText.Add(Constants.COT + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.ARCSIN))
            {
                if (checkBoxDeg.Checked)
                    this.inputExpression.Add("" + (Math.Asin(Double.Parse(txtFunctionInput.Text)) * (180 / Math.PI)));
                else
                    this.inputExpression.Add("" + (Math.Asin(Double.Parse(txtFunctionInput.Text))));
                inputBoxText.Add(Constants.ARCSIN + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.ARCCOS))
            {
                if (checkBoxDeg.Checked)
                    this.inputExpression.Add("" + (Math.Acos(Double.Parse(txtFunctionInput.Text)) * (180 / Math.PI)));
                else
                    this.inputExpression.Add("" + (Math.Acos(Double.Parse(txtFunctionInput.Text))));
                inputBoxText.Add(Constants.ARCCOS + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.ARCTAN))
            {
                if (checkBoxDeg.Checked)
                    this.inputExpression.Add("" + (Math.Atan(Double.Parse(txtFunctionInput.Text)) * (180 / Math.PI)));
                else
                    this.inputExpression.Add("" + (Math.Atan(Double.Parse(txtFunctionInput.Text))));
                inputBoxText.Add(Constants.ARCTAN + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.ARCCSC))
            {
                if (checkBoxDeg.Checked)
                    this.inputExpression.Add("" + (Math.Asin(1 / Double.Parse(txtFunctionInput.Text)) * (180 / Math.PI)));
                else
                    this.inputExpression.Add("" + (Math.Asin(1 / Double.Parse(txtFunctionInput.Text))));
                inputBoxText.Add(Constants.ARCCSC + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.ARCSEC))
            {
                if (checkBoxDeg.Checked)
                    this.inputExpression.Add("" + (Math.Acos(1 / Double.Parse(txtFunctionInput.Text)) * (180 / Math.PI)));
                else
                    this.inputExpression.Add("" + (Math.Acos(1 / Double.Parse(txtFunctionInput.Text))));
                inputBoxText.Add(Constants.ARCSEC + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.ARCCOT))
            {
                if (checkBoxDeg.Checked)
                    this.inputExpression.Add("" + (1.570796327 - Math.Atan(Double.Parse(txtFunctionInput.Text))) * (180 / Math.PI));
                else
                    this.inputExpression.Add("" + (1.570796327 - Math.Atan(Double.Parse(txtFunctionInput.Text))));
                inputBoxText.Add(Constants.ARCCOT + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.SINH))
            {
                this.inputExpression.Add("" + (Math.Sinh(Double.Parse(txtFunctionInput.Text))));
                inputBoxText.Add(Constants.SINH + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.COSH))
            {
                this.inputExpression.Add("" + (Math.Cosh(Double.Parse(txtFunctionInput.Text))));
                inputBoxText.Add(Constants.COSH + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.TANH))
            {
                this.inputExpression.Add("" + (Math.Tanh(Double.Parse(txtFunctionInput.Text))));
                inputBoxText.Add(Constants.TANH + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.CSCH))
            {
                this.inputExpression.Add("" + 1 / (Math.Sinh(Double.Parse(txtFunctionInput.Text))));
                inputBoxText.Add(Constants.CSCH + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.SECH))
            {
                this.inputExpression.Add("" + 1 / (Math.Cosh(Double.Parse(txtFunctionInput.Text))));
                inputBoxText.Add(Constants.SECH + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.COTH))
            {
                this.inputExpression.Add("" + 1 / (Math.Tanh(Double.Parse(txtFunctionInput.Text))));
                inputBoxText.Add(Constants.TANH + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.EX))
            {
                this.inputExpression.Add("" + Math.Pow((Math.E), Double.Parse(txtFunctionInput.Text)));
                inputBoxText.Add(Constants.EX + "^" + txtFunctionInput.Text);
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.LN))
            {
                this.inputExpression.Add("" + Math.Log(Double.Parse(txtFunctionInput.Text)));
                inputBoxText.Add(Constants.LN + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.X_FACTORIAL))
            {
                try
                {
                    if (int.Parse(txtFunctionInput.Text) > 0)
                    {
                        this.inputExpression.Add("" + factorial(int.Parse(txtFunctionInput.Text)));
                        inputBoxText.Add(txtFunctionInput.Text + Constants.X_FACTORIAL);
                        inputBox.Text += inputBoxText.ToString();
                    }
                    else
                        throw new MyFormatException("Negative number is not allowed");
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message);
                    //if a x was appended to the input then the following condition would be true
                    if (Regex.IsMatch(inputBox.Text.ToString(), @"[\d)]"))
                    {
                        //we need to remove the x appended at the end of the input data structures
                        this.undo();
                    }
                    txtFunctionInput.Focus();
                    return;
                }
            }
            else if (this.funtionSelected.Equals(Constants.TEN_X))
            {
                this.inputExpression.Add("" + Math.Pow(10.0, Double.Parse(txtFunctionInput.Text)));
                inputBoxText.Add(Constants.TEN_X + "^" + txtFunctionInput.Text);
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.LOG))
            {
                this.inputExpression.Add("" + Math.Log10(Double.Parse(txtFunctionInput.Text)));
                inputBoxText.Add(Constants.LOG + "(" + txtFunctionInput.Text + ")");
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.X_INVERSE))
            {
                this.inputExpression.Add("" + 1.0 / Double.Parse(txtFunctionInput.Text));
                inputBoxText.Add(Constants.X_INVERSE + txtFunctionInput.Text);
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.X_POWER_Y))
            {
                //split at , to get x & y out of x,y
                String[] xy = txtFunctionInput.Text.ToString().Split(',');
                try
                {
                    if (xy.Length == 2)
                    {
                        double x = Double.Parse(xy[0]); //store x
                        double y = Double.Parse(xy[1]); //store y
                        //solve
                        this.inputExpression.Add("" + Math.Pow(x, y));
                        inputBoxText.Add(x + Constants.X_POWER_Y + y);
                        inputBox.Text += inputBoxText.ToString();
                    }
                    else
                        throw new MyFormatException("There is a syntax error, the correct format is x,y");
                }
                catch (FormatException fe)
                {
                    MessageBox.Show(fe.Message);
                    //if a x was appended to the input then the following condition would be true
                    if (Regex.IsMatch(inputBox.Text.ToString(), @"[\d)]"))
                    {
                        //we need to remove the x appended at the end of the input data structures
                        this.undo();
                    }
                    txtFunctionInput.Focus();
                    return;
                }
            }
            else if (this.funtionSelected.Equals(Constants.X_POWER_3))
            {
                this.inputExpression.Add("" + Math.Pow(Double.Parse(txtFunctionInput.Text), 3.0));
                inputBoxText.Add(txtFunctionInput.Text + Constants.X_POWER_3);
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.X_POWER_2))
            {
                this.inputExpression.Add("" + Math.Pow(Double.Parse(txtFunctionInput.Text), 2.0));
                inputBoxText.Add(txtFunctionInput.Text + Constants.X_POWER_2);
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.X_UNDERROOT_Y))
            {
                //split at , to get x & y out of x,y
                String[] xy = txtFunctionInput.Text.ToString().Split(',');

                try
                {
                    if (xy.Length == 2)
                    {
                        double x = Double.Parse(xy[0]); //store x
                        double y = Double.Parse(xy[1]); //store y
                        //solve
                        this.inputExpression.Add("" + Math.Pow(x, (1.0 / y)));
                        inputBoxText.Add(x + Constants.X_POWER_Y + y);
                        inputBox.Text += inputBoxText.ToString();
                    }
                    else
                        throw new MyFormatException("There is a syntax error, the correct format is x,y");
                }
                catch (FormatException fe)
                {
                    MessageBox.Show(fe.Message);
                    //if a x was appended to the input then the following condition would be true
                    if (Regex.IsMatch(inputBox.Text.ToString(), @"[\d)]"))
                    {
                        //we need to remove the x appended at the end of the input data structures
                        this.undo();
                    }
                    txtFunctionInput.Focus();
                    return;
                }

            }
            else if (this.funtionSelected.Equals(Constants.X_UNDERROOT_3))
            {
                this.inputExpression.Add("" + Math.Pow(Double.Parse(txtFunctionInput.Text), (1.0 / 3.0)));
                inputBoxText.Add(txtFunctionInput.Text + Constants.X_UNDERROOT_3);
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.X_UNDERROOT_2))
            {
                this.inputExpression.Add("" + Math.Pow(Double.Parse(txtFunctionInput.Text), (1.0 / 2.0)));
                inputBoxText.Add(txtFunctionInput.Text + Constants.X_UNDERROOT_2);
                inputBox.Text += inputBoxText.ToString();
            }
            else if (this.funtionSelected.Equals(Constants.NPR))
            {
                //split at , to get n & r out of n,r
                String[] nr = txtFunctionInput.Text.ToString().Split(',');
                try
                {
                    if (nr.Length == 2)
                    {
                        int n = int.Parse(nr[0]); //store n
                        int r = int.Parse(nr[1]); //store r
                        if (n < r) throw new MyFormatException("n cannot be less then r");
                        //solve
                        this.inputExpression.Add("" + factorial(n) / factorial(n - r));
                        inputBoxText.Add(n + Constants.NPR + r);
                        inputBox.Text += inputBoxText.ToString();
                    }
                    else
                        throw new MyFormatException("There is a syntax error, the correct format is n,r");
                }
                catch (FormatException fe)
                {
                    MessageBox.Show(fe.Message);
                    //if a x was appended to the input then the following condition would be true
                    if (Regex.IsMatch(inputBox.Text.ToString(), @"[\d)]"))
                    {
                        //we need to remove the x appended at the end of the input data structures
                        this.undo();
                    }
                    txtFunctionInput.Focus();
                    return;
                }
            }
            else if (this.funtionSelected.Equals(Constants.NCR))
            {
                //split at , to get n & r out of n,r
                String[] nr = txtFunctionInput.Text.ToString().Split(',');
                try
                {
                    if (nr.Length == 2)
                    {
                        int n = int.Parse(nr[0]); //store n
                        int r = int.Parse(nr[1]); //store r
                        if (n < r) throw new MyFormatException("n cannot be less then r");
                        //solve
                        this.inputExpression.Add("" + factorial(n) / (factorial(r) * factorial(n - r)));
                        inputBoxText.Add(n + Constants.NCR + r);
                        inputBox.Text += inputBoxText.ToString();
                    }
                    else
                        throw new MyFormatException("There is a syntax error, the correct format is n,r");
                }
                catch (FormatException fe)
                {
                    MessageBox.Show(fe.Message);
                    //if a x was appended to the input then the following condition would be true
                    if (Regex.IsMatch(inputBox.Text.ToString(), @"[\d)]"))
                    {
                        //we need to remove the x appended at the end of the input data structures
                        this.undo();
                    }
                    txtFunctionInput.Focus();
                    return;
                }
            }

            setFunctionControl(false);
        }
        //remove the x sign from the end of  3 data structures used in input
        private void undo()
        {
            //if the function input box is focused do undo there
            if (txtFunctionInput.Focused == true)
            {
                if (this.txtFunctionInput.Text.ToString().Length > 0)
                    this.txtFunctionInput.Text = this.txtFunctionInput.Text.ToString().Remove(this.txtFunctionInput.Text.ToString().Length - 1, 1);
            }
            else //this id the default case of unod
            {
                if (inputBoxText.Count > 0) //so that array out of bound exception does not occur
                {
                    String lastElement = (String)this.inputBoxText[inputBoxText.Count - 1]; //get the last input 
                    this.inputBoxText.RemoveAt(inputBoxText.Count - 1); //remove the last input from the MyArrayList                    
                    this.inputExpression.RemoveAt(inputExpression.Count - 1); //remove the last entry from the input expression builder
                    
                    //from which index to start deleting the inputbox text
                    int startIndex = this.inputBox.Text.Length-lastElement.Length;
                    //the count of the characters to be deleted
                    int count = lastElement.Length;
                    this.inputBox.Text = this.inputBox.Text.ToString().Remove(startIndex,count); //remove x from the text being displayed to the user
                }
            }
        }
        //a function which sets the visibility of 3 controls to false or true
        private void setFunctionControl(bool value)
        {
            txtFunctionInput.Text = "";
            txtFunctionInput.Visible = value;
            btnOK.Visible = value;
            labelFunction.Visible = value;
            
            //enable/disable the Degree checkbox
            if (value == true)
                checkBoxDeg.Enabled = true;
            else if (value == false)
                checkBoxDeg.Enabled = false;
        }
        //to add the passed string to input data structures
        private void addAsInput(String input)
        {
            if (txtFunctionInput.Visible == true && txtFunctionInput.Focused == true)
            {
                this.txtFunctionInput.Text += input;
            }
            else
            {
                this.inputBoxText.Add(input);
                this.inputBox.Text += this.inputBoxText.ToString();
                this.inputExpression.Add(input);
            }
        }
        //to handle the click on different function buttons
        private void functionClickHandler(string input)
        {
            labelFunction.Text = input;
            setFunctionControl(true); //make the 3 controls visible which are required for input
            txtFunctionInput.Focus();
        }
        public static int factorial(int number)
        {
            if (number == 0)
                return 1;
            else
                return number * factorial(number - 1);
        }
        private void undoButton_Click(object sender, EventArgs e)
        {
            this.undo();
        }
    }
    public class MyArrayList : ArrayList
    {
        //returns the last element
        public override String ToString()
        {
            return (String)this[this.Count - 1];            
        }
        //returns all the elements as one concatendated string
        public String toCompleteString()
        {
            String str = "";
            foreach (String s in this)
                str += s;
            return str;
        }
    }
    public class MyFormatException : FormatException
    {
        public MyFormatException()
        {}
        public MyFormatException(string message)
            : base(message)
        { }
    }
}