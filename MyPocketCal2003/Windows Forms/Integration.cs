using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyPocketCal2003
{
    public partial class Integration : BaseFormLibrary.FunctionsForm
    {
        private TextBox activeBox; //the TextBox which has the focus

        public Integration()
        {
            InitializeComponent();
            activeBox = new TextBox();
        }
        //a function which sets the activebox TextBox to the TextBox which has the focus
        private void setActiveInputBox()
        {
            if (this.inputBox.Focused == true) //if inputBox textbox has the focus
            {
                this.activeBox = inputBox;
            }
            else if (this.aBox.Focused == true) //if the a value textbox has the focus
            {
                this.activeBox = aBox;
            }
            else if (this.bBox.Focused == true) //if the b value textbox has the focus
            {
                this.activeBox = bBox;
            }
        }
        //zero pressed on the calculator
        private void zeroButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.ZERO;
        }
        //1 pressed on the calculator
        private void oneButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.ONE;
        }
        //2 pressed on the calculator
        private void twoButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.TWO;
        }
        //3 pressed on the calculator
        private void threeButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.THREE;
        }
        //4 pressed on the calculator
        private void fourButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.FOUR;
        }
        //5 pressed on the calculator
        private void fiveButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.FIVE;
        }
        //6 pressed on the calculator
        private void sixButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.SIX;
        }
        //7 pressed on the calculator
        private void sevenButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.SEVEN;
        }
        //8 pressed on the calculator
        private void eightButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.EIGHT;
        }
        //9 pressed on the calculator
        private void nineButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.NINE;
        }
        //, pressed on the calculator
        private void commaButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.COMMA;
        }
        //+ pressed on the calculator
        private void plusButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.PLUS;
        }
        //- pressed on the calculator
        private void minusButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.MINUS;
        }
        //x pressed on the calculator
        private void multiplyButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.MULTIPLY;
        }
        //division pressed on the calculator
        private void divideButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.DIVIDE;
        }
        //. pressed on the calculator
        private void decimalButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.DECIMAL;
        }
        //( pressed on the calculator
        private void leftBracketButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.RIGHT_BRACKET;
        }
        //) pressed on the calculator
        private void rightBracketButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.LEFT_BRACKET;
        }
        //sin pressed on the calculator
        private void sinButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.SIN;
        }
        //arcsin pressed on the calculator
        private void arcsinButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.ARCSIN;
        }
        //sinh pressed on the calculator
        private void sinhButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.SINH;
        }
        //cos pressed on the calculator
        private void cosButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.COS;
        }
        //arccos pressed on the calculator
        private void arccosButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.ARCCOS;
        }
        //cosh pressed on the calculator
        private void coshButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.COSH;
        }
        //tan pressed on the calculator
        private void tanButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.TAN;
        }
        //arctan pressed on the calculator
        private void arctanButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.ARCTAN;
        }
        //tanh pressed on the calculator
        private void tanhButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.TANH;
        }
        //sec pressed on the calculator
        private void secButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.SEC;
        }
        //arcsec pressed on the calculator
        private void arcsecButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.ARCSEC;
        }
        //sech pressed on the calculator
        private void sechButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.SECH;
        }
        //csc pressed on the calculator
        private void cscButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.CSC;
        }
        //arccsc pressed on the calculator
        private void arccscButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.ARCCSC;
        }
        //csch pressed on the calculator
        private void cschButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.CSCH;
        }
        //cot pressed on the calculator
        private void cotButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.COT;
        }
        //arccot pressed on the calculator
        private void arccotButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.ARCCOT;
        }
        //coth pressed on the calculator
        private void cothButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.COTH;
        }
        //e power x pressed on the calculator
        private void exButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.EX;
        }
        //ln pressed on the calculator
        private void lnButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.LN;
        }
        //factorial pressed on the calculator
        private void xfactorialButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.X_FACTORIAL;
        }
        //10 power x pressed on the calculator
        private void tenXButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.TEN_X;
        }
        //log pressed on the calculator
        private void logButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.LOG;
        }
        //x inverse pressed on the calculator
        private void xInverseButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.X_INVERSE;
        }
        //x power y pressed on the calculator
        private void xyButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.X_POWER_Y;
        }
        //x power 3 pressed on the calculator
        private void x3Button_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.X_POWER_3;
        }
        //x power 2 pressed on the calculator
        private void x2Button_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.X_POWER_2;
        }
        //x underroot y pressed on the calculator
        private void xUnderrootYButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.X_UNDERROOT_Y;
        }
        //x underroot 3 pressed on the calculator
        private void xUnderoot3Button_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.X_UNDERROOT_3;
        }
        //x underroot 2 pressed on the calculator
        private void xUnderrootButton_Click(object sender, EventArgs e)
        {
            this.setActiveInputBox();
            this.activeBox.Text += Constants.X_UNDERROOT_2;
        }
    }
}