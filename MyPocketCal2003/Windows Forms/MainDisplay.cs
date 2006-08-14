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
        bool equalButtonPressed; //marked as true when equal button is pressed
        bool imaginaryNumber; //marked as true when a negative under root was encountered

        public MainDisplay()
        {
            InitializeComponent();
            inputBoxText = new MyArrayList();
            inputExpression = new MyArrayList();
            checkBoxDeg.Enabled = false;
            equalButtonPressed = false;
            imaginaryNumber = false;
        }
        private void pictureBox115_Click(object sender, EventArgs e)
        {
            MatrixForm mf = new MatrixForm(); //new matrix form
            mf.ControlBox = true;
            mf.MinimizeBox = false;
            mf.Show(); //show the form
        }

        private void pictureBox116_Click(object sender, EventArgs e)
        {
            Statistic statistic = new Statistic(); //new Statistic form
            statistic.ControlBox = true;
            statistic.MinimizeBox = false;
            statistic.Show(); //show the form
        }

        private void pictureBox113_Click(object sender, EventArgs e)
        {
            Unit c = new Unit();
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
            if (inputBoxText.Count == 0) //user pressing = for fun :) i.e. no input in the inputbox
                return;
            try
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
                    //MessageBox.Show(inputExpression.toCompleteString());
                    String rpn = postFix.Convert(inputExpression.toCompleteString());
                    //MessageBox.Show(rpn);
                    //solve the rpn
                    this.txtOutput.Text = postFix.Solve(rpn);
                }
                this.equalButtonPressed = true;
                //this.clearRegisters(); //clear the input registers
            }
            catch (Exception ex)
            {
                this.txtOutput.Text = ex.Message;
            }
        }
        private void clearRegisters()
        {
            this.inputBox.Text = "";
            this.inputBoxText.Clear();
            this.inputExpression.Clear();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtFunctionInput.Text.Length == 0)
            {
                setFunctionControl(false);
                return;
            }

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
            
            //if the user wants to input a complex number
            if (this.funtionSelected.Equals(Constants.COMPLEX))
            {
                //if its a complex number the function is gonna return my own created representation of a complex number
                string returnValue = ComplexNumber.convertToComplex(txtFunctionInput.Text.ToString());
                if (returnValue != null)
                {
                    inputBoxText.Add("(" + txtFunctionInput.Text.ToString() + ")");
                    inputBox.Text += inputBoxText.ToString();
                    this.inputExpression.Add(returnValue);
                }
            }
            else //otherwise there is a need to evaluate a function
            {
                Double answer = 0.0;
                try
                {
                    answer = this.evaluateFunctionInput(); //round upto 10 digits
                    if ((answer + "").Equals("NaN") || (answer + "").Equals("Infinity"))
                        throw new Exception("Function not defined for this value");
                    //MessageBox.Show(answer+"");
                    if (this.imaginaryNumber == true)
                    {
                        this.inputExpression.Add("0a"+answer + "i");
                        this.imaginaryNumber = false;
                    }
                    else
                        this.inputExpression.Add(answer + "");
                    
                    inputBox.Text += inputBoxText.ToString();
                    setFunctionControl(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //if a x was appended to the input then the following condition would be true
                    input = inputBox.Text.ToString();
                    if (input.Length != 0)
                        if (Regex.IsMatch(input[input.Length - 1] + "", @"[\d)]"))
                        {
                            //we need to remove the x appended at the end of the input data structures
                            this.undo();
                        }
                    txtFunctionInput.Focus();
                    return;
                }
            }
        }
        public Double evaluateFunctionInput()
        {
            //the case statement follows the following sequence:
            // 1. add the expression to the ArrayList which holds user input
            // 2. evaluate the value of the function
            switch (this.funtionSelected)
                {
                    case Constants.SIN:
                        {
                            inputBoxText.Add(Constants.SIN + "(" + txtFunctionInput.Text + ")");
                            if (checkBoxDeg.Checked)
                                return Math.Sin(Double.Parse(txtFunctionInput.Text) * (Math.PI / 180));
                            else
                                return Math.Sin(Double.Parse(txtFunctionInput.Text));
                        }
                    case Constants.COS:
                        {
                            inputBoxText.Add(Constants.COS + "(" + txtFunctionInput.Text + ")");
                            if (checkBoxDeg.Checked)
                                return Math.Cos(Double.Parse(txtFunctionInput.Text) * (Math.PI / 180));
                            else
                                return Math.Cos(Double.Parse(txtFunctionInput.Text));
                        }
                    case Constants.TAN:
                        {
                            inputBoxText.Add(Constants.TAN + "(" + txtFunctionInput.Text + ")");
                            if (checkBoxDeg.Checked)
                                return Math.Tan(Double.Parse(txtFunctionInput.Text) * (Math.PI / 180));
                            else
                                return Math.Tan(Double.Parse(txtFunctionInput.Text));
                        }
                    case Constants.CSC:
                        {
                            inputBoxText.Add(Constants.CSC + "(" + txtFunctionInput.Text + ")");
                            if (checkBoxDeg.Checked)
                                return (1.0 / (Math.Sin(Double.Parse(txtFunctionInput.Text) * (Math.PI / 180.0))));
                            else
                                return (1.0 / (Math.Sin(Double.Parse(txtFunctionInput.Text))));                            
                        }
                    case Constants.SEC:
                        {
                            inputBoxText.Add(Constants.SEC + "(" + txtFunctionInput.Text + ")");
                            if (checkBoxDeg.Checked)
                                return (1.0 / (Math.Cos(Double.Parse(txtFunctionInput.Text) * (Math.PI / 180))));
                            else
                                return (1.0 / (Math.Cos(Double.Parse(txtFunctionInput.Text))));
                        }
                    case Constants.COT:
                        {
                            inputBoxText.Add(Constants.COT + "(" + txtFunctionInput.Text + ")");
                            if (checkBoxDeg.Checked)
                                return (1.0 / (Math.Tan(Double.Parse(txtFunctionInput.Text) * (Math.PI / 180))));
                            else
                                return (1.0 / (Math.Tan(Double.Parse(txtFunctionInput.Text))));
                        }
                    case Constants.ARCSIN:
                        {
                            inputBoxText.Add(Constants.ARCSIN + "(" + txtFunctionInput.Text + ")");
                            if (checkBoxDeg.Checked)
                                return (Math.Asin(Double.Parse(txtFunctionInput.Text)) * (180 / Math.PI));
                            else
                                return (Math.Asin(Double.Parse(txtFunctionInput.Text)));
                        }
                    case Constants.ARCCOS:
                        {
                            inputBoxText.Add(Constants.ARCCOS + "(" + txtFunctionInput.Text + ")");
                            if (checkBoxDeg.Checked)
                                return (Math.Acos(Double.Parse(txtFunctionInput.Text)) * (180 / Math.PI));
                            else
                                return (Math.Acos(Double.Parse(txtFunctionInput.Text)));
                        }
                    case Constants.ARCTAN:
                        {
                            inputBoxText.Add(Constants.ARCTAN + "(" + txtFunctionInput.Text + ")");
                            if (checkBoxDeg.Checked)
                                return (Math.Atan(Double.Parse(txtFunctionInput.Text)) * (180 / Math.PI));
                            else
                                return (Math.Atan(Double.Parse(txtFunctionInput.Text)));
                        }
                    case Constants.ARCCSC:
                        {
                            inputBoxText.Add(Constants.ARCCSC + "(" + txtFunctionInput.Text + ")");
                            if (checkBoxDeg.Checked)
                                return (Math.Asin(1.0 / Double.Parse(txtFunctionInput.Text)) * (180 / Math.PI));
                            else
                                return (Math.Asin(1.0 / Double.Parse(txtFunctionInput.Text)));
                        }
                    case Constants.ARCSEC:
                        {
                            inputBoxText.Add(Constants.ARCSEC + "(" + txtFunctionInput.Text + ")");
                            if (checkBoxDeg.Checked)
                                return (Math.Acos(1.0 / Double.Parse(txtFunctionInput.Text)) * (180 / Math.PI));
                            else
                                return (Math.Acos(1.0 / Double.Parse(txtFunctionInput.Text)));
                        }
                    case Constants.ARCCOT:
                        {
                            inputBoxText.Add(Constants.ARCCOT + "(" + txtFunctionInput.Text + ")");
                            if (checkBoxDeg.Checked)
                                return (1.570796327 - Math.Atan(Double.Parse(txtFunctionInput.Text))) * (180 / Math.PI);
                            else
                                return (1.570796327 - Math.Atan(Double.Parse(txtFunctionInput.Text)));
                        }
                    case Constants.SINH:
                        {
                            inputBoxText.Add(Constants.SINH + "(" + txtFunctionInput.Text + ")");
                            return (Math.Sinh(Double.Parse(txtFunctionInput.Text)));
                        }
                    case Constants.COSH:
                        {
                            inputBoxText.Add(Constants.COSH + "(" + txtFunctionInput.Text + ")");
                            return (Math.Cosh(Double.Parse(txtFunctionInput.Text)));
                        }
                    case Constants.TANH:
                        {
                            inputBoxText.Add(Constants.TANH + "(" + txtFunctionInput.Text + ")");
                            return (Math.Tanh(Double.Parse(txtFunctionInput.Text)));
                        }
                    case Constants.CSCH:
                        {
                            inputBoxText.Add(Constants.CSCH + "(" + txtFunctionInput.Text + ")");
                            return 1.0 / (Math.Sinh(Double.Parse(txtFunctionInput.Text)));
                        }
                    case Constants.SECH:
                        {
                            inputBoxText.Add(Constants.SECH + "(" + txtFunctionInput.Text + ")");
                            return 1.0 / (Math.Cosh(Double.Parse(txtFunctionInput.Text)));
                        }
                    case Constants.COTH:
                        {
                            inputBoxText.Add(Constants.COTH + "(" + txtFunctionInput.Text + ")");
                            return 1.0 / (Math.Tanh(Double.Parse(txtFunctionInput.Text)));
                        }
                    case Constants.EX:
                        {
                            inputBoxText.Add(Constants.EX + "^" + txtFunctionInput.Text);
                            return Math.Pow((Math.E), Double.Parse(txtFunctionInput.Text));
                        }
                    case Constants.LN:
                        {
                            inputBoxText.Add(Constants.LN + "(" + txtFunctionInput.Text + ")");
                            return Math.Log(Double.Parse(txtFunctionInput.Text));
                        }
                    case Constants.X_FACTORIAL:
                        {
                            if (this.intParameter(txtFunctionInput.Text))
                            {
                                Double n = Double.Parse(txtFunctionInput.Text);
                                if (n < 0)
                                    throw new Exception("x cannot be negative");
                                else
                                {
                                    inputBoxText.Add(txtFunctionInput.Text + Constants.X_FACTORIAL);
                                    return factorial(n);
                                }
                            }
                            else
                                throw new MyFormatException("Syntax Error");
                        }
                    case Constants.TEN_X:
                        {
                            inputBoxText.Add(Constants.TEN_X + "^" + txtFunctionInput.Text);
                            return Math.Pow(10.0, Double.Parse(txtFunctionInput.Text));
                        }
                    case Constants.LOG:
                        {
                            inputBoxText.Add(Constants.LOG + "(" + txtFunctionInput.Text + ")");
                            return Math.Log10(Double.Parse(txtFunctionInput.Text));
                        }
                    case Constants.X_INVERSE:
                        {
                            inputBoxText.Add(Constants.X_INVERSE + txtFunctionInput.Text);
                            return 1.0 / Double.Parse(txtFunctionInput.Text);
                        }
                    case Constants.X_POWER_Y:
                        {
                            if(this.twoDoubleParameters(txtFunctionInput.Text))
                            {
                                //split at , to get x & y out of x,y
                                String[] xy = txtFunctionInput.Text.ToString().Split(',');
                                
                                double x = Double.Parse(xy[0]); //store x
                                double y = Double.Parse(xy[1]); //store y

                                //solve
                                inputBoxText.Add(x + Constants.X_POWER_Y + y);
                                return Math.Pow(x, y);   
                            }
                            else
                                throw new Exception("Syntax Error. The correct format is x,y");
                        }
                    case Constants.X_POWER_3:
                        {
                            inputBoxText.Add(txtFunctionInput.Text + Constants.X_POWER_3);
                            return Math.Pow(Double.Parse(txtFunctionInput.Text), 3.0);
                        }
                    case Constants.X_POWER_2:
                        {
                            inputBoxText.Add(txtFunctionInput.Text + Constants.X_POWER_2);
                            return Math.Pow(Double.Parse(txtFunctionInput.Text), 2.0);
                        }
                    case Constants.X_UNDERROOT_Y:
                        {
                            if(this.twoDoubleParameters(txtFunctionInput.Text))
                            {
                                //split at , to get x & y out of x,y
                                String[] xy = txtFunctionInput.Text.ToString().Split(',');

                                double x = Double.Parse(xy[0]); //store x
                                double y = Double.Parse(xy[1]); //store y

                                if (x < 0 && y == 2) //x is negative & y is 2
                                {
                                    inputBoxText.Add(x + Constants.X_UNDERROOT_Y + y);
                                    x = -1.0 * x;
                                    this.imaginaryNumber = true;
                                    return Math.Pow(x, (1.0 / y));
                                }
                                else if (x < 0 && (y % 2 != 0)) //x is negative and y is odd
                                {
                                    inputBoxText.Add(x + Constants.X_UNDERROOT_Y + y);
                                    return -1.0*Math.Pow(-1.0*x, (1.0 / y));
                                }
                                else //x is positive, y is positive
                                {
                                    inputBoxText.Add(x + Constants.X_UNDERROOT_Y + y);
                                    return Math.Pow(x, (1.0 / y));
                                }
                             }
                             else
                                throw new MyFormatException("Syntax error, the correct format is x,y");
                        }
                    case Constants.X_UNDERROOT_3:
                        {
                            Double number = Double.Parse(txtFunctionInput.Text);
                            inputBoxText.Add(txtFunctionInput.Text + Constants.X_UNDERROOT_3);

                            if(number<0)
                                return -1.0*(Math.Pow(-1.0*number, (1.0 / 3.0)));
                            else
                                return (Math.Pow(number, (1.0 / 3.0)));
                        }
                    case Constants.X_UNDERROOT_2:
                        {
                            Double number = Double.Parse(txtFunctionInput.Text);
                            if (number < 0)
                            {
                                number = -1.0 * number;
                                this.imaginaryNumber = true;
                            }   
                            inputBoxText.Add(txtFunctionInput.Text + Constants.X_UNDERROOT_2);
                            return (Math.Pow(number, (1.0 / 2.0)));
                        }
                    case Constants.NPR:
                        {
                            //if input is correct in the form of x,y where x & y are integers
                            if (this.twoIntParameters(txtFunctionInput.Text.ToString()))
                            {
                                //split at , to get n & r out of n,r
                                String[] nr = txtFunctionInput.Text.ToString().Split(',');

                                Int64 n = Int64.Parse(nr[0]); //store n
                                Int64 r = Int64.Parse(nr[1]); //store r
                                if (n < r) throw new MyFormatException("n cannot be less then r");
                                //solve
                                inputBoxText.Add(n + Constants.NPR + r);
                                return (factorial(n) / factorial(n - r));
                            }
                            else
                                throw new MyFormatException("There is a syntax error, the correct format is n,r");
                        }
                    case Constants.NCR:
                        {
                                //if input is correct in the form of x,y where x & y are integers
                                if (this.twoIntParameters(txtFunctionInput.Text.ToString()))
                                {
                                    //split at , to get n & r out of n,r
                                    String[] nr = txtFunctionInput.Text.ToString().Split(',');

                                    Int64 n = Int64.Parse(nr[0]); //store n
                                    Int64 r = Int64.Parse(nr[1]); //store r

                                    //if n < r
                                    if (n < r) throw new MyFormatException("n cannot be less then r");
                                    //solve
                                    inputBoxText.Add(n + Constants.NCR + r);
                                    return (factorial(n) / (factorial(r) * factorial(n - r)));
                                }
                                else
                                    throw new MyFormatException("There is a syntax error, the correct format is n,r");
                        }
                }            
            return -99.9999; //should never come here
        }
        //evaluates when to clear the inputbox or not
        private void handleClearingRegister()
        {
            if (this.equalButtonPressed == true)
            {
                this.clearRegisters();
                equalButtonPressed = false;
            }
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
            this.handleClearingRegister(); //if the inputbox needs to be cleared, clear it
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
            this.handleClearingRegister(); //if the inputbox needs to be cleared, clear it
        }
        public static Double factorial(Double number)
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

        private void iota_Click(object sender, EventArgs e)
        {
            this.addAsInput("i");
        }
        private bool intParameter(string input)
        {
            //an input of the form x where x can be an integer
            if (Regex.IsMatch(input, @"^-?\d+$"))
                return true;
            return false;
        }
        private bool twoIntParameters(string input)
        {
            //an input of the form x,y where x & y can only be integers
            if(Regex.IsMatch(input,@"^-?\d+,-?\d+$")) 
                return true;
            return false;
        }
        private bool twoDoubleParameters(string input)
        {
            //an input of the form x,y where x & y can be integer or double
            if (Regex.IsMatch(input, @"^-?\d*(\.\d+)?([E][+-]\d+)?,-?\d*(\.\d+)?([E][+-]\d+)?$")) 
                return true;
            return false;
        }
        private bool doubleParameter(string input)
        {
            //an input of the form x where x can be a double
            if (Regex.IsMatch(input, @"^-?\d*(\.\d+)?([E][+-]\d+)?$"))
                return true;
            return false;
        }

        private void MainDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Rocker Up
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Rocker Down
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }

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