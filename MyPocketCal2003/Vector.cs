using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyPocketCal2003
{
    public partial class Vector : BaseFormLibrary.BasicButtonForm
    {
        private TextBox activeBox;
        public Vector()
        {
            InitializeComponent();
            activeBox = new TextBox();
        }
        private void setActiveInputBox()
        {
            if (this.vectorBox.Focused == true) //if vector box has focus
            {
                this.activeBox = vectorBox;
            }
            else if (this.operationBox.Focused == true) //if operation box has focus
            {
                this.activeBox = operationBox;
            }
        }
        //zero pressed on the calculator
        private void zeroButton_Click(object sender, EventArgs e)
        {
            setActiveInputBox();
            this.activeBox.Text += Constants.ZERO;
        }
        //1 pressed on the calculator
        private void oneButton_Click(object sender, EventArgs e)
        {
            setActiveInputBox();
            this.activeBox.Text += Constants.ONE;
        }
        //2 pressed on the calculator
        private void twoButton_Click(object sender, EventArgs e)
        {
            setActiveInputBox();
            this.activeBox.Text += Constants.TWO;
        }
        //3 pressed on the calculator
        private void threeButton_Click(object sender, EventArgs e)
        {
            setActiveInputBox();
            this.activeBox.Text += Constants.THREE;
        }
        //4 pressed on the calculator
        private void fourButton_Click(object sender, EventArgs e)
        {
            setActiveInputBox();
            this.activeBox.Text += Constants.FOUR;
        }
        //5 pressed on the calculator
        private void fiveButton_Click(object sender, EventArgs e)
        {
            setActiveInputBox();
            this.activeBox.Text += Constants.FIVE;
        }
        //6 pressed on the calculator
        private void sixButton_Click(object sender, EventArgs e)
        {
            setActiveInputBox();
            this.activeBox.Text += Constants.SIX;
        }
        //7 pressed on the calculator
        private void sevenButton_Click(object sender, EventArgs e)
        {
            setActiveInputBox();
            this.activeBox.Text += Constants.SEVEN;
        }
        //8 pressed on the calculator
        private void eightButton_Click(object sender, EventArgs e)
        {
            setActiveInputBox();
            this.activeBox.Text += Constants.EIGHT;
        }
        //9 pressed on the calculator
        private void nineButton_Click(object sender, EventArgs e)
        {
            setActiveInputBox();
            this.activeBox.Text += Constants.NINE;
        }
        //, pressed on the calculator
        private void commaButton_Click(object sender, EventArgs e)
        {
            setActiveInputBox();
            this.activeBox.Text += Constants.COMMA;
        }
        //+ pressed on the calculator
        private void plusButton_Click(object sender, EventArgs e)
        {
            setActiveInputBox();
            this.activeBox.Text += Constants.PLUS;
        }
        //- pressed on the calculator
        private void minusButton_Click(object sender, EventArgs e)
        {
            setActiveInputBox();
            this.activeBox.Text += Constants.MINUS;
        }
        //x pressed on the calculator
        private void multiplyButton_Click(object sender, EventArgs e)
        {
            setActiveInputBox();
            this.activeBox.Text += Constants.MULTIPLY;
        }
        //division pressed on the calculator
        private void divideButton_Click(object sender, EventArgs e)
        {
            setActiveInputBox();
            this.activeBox.Text += Constants.DIVIDE;
        }
        //. pressed on the calculator
        private void decimalButton_Click(object sender, EventArgs e)
        {
            setActiveInputBox();
            this.activeBox.Text += Constants.DECIMAL;
        }
        //( pressed on the calculator
        private void leftBracketButton_Click(object sender, EventArgs e)
        {
            setActiveInputBox();
            this.activeBox.Text += Constants.RIGHT_BRACKET;
        }
        //) pressed on the calculator
        private void rightBracketButton_Click(object sender, EventArgs e)
        {
            setActiveInputBox();
            this.activeBox.Text += Constants.LEFT_BRACKET;
        }
    }
}