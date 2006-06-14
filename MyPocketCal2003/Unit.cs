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
    public partial class Unit : BaseFormLibrary.BasicButtonForm
    {
        Hashtable quantitiesUnits;

        public Unit()
        {
            InitializeComponent();
            populateHashTable();
        }
        //zero pressed on the calculator
        private void zeroButton_Click(object sender, EventArgs e)
        {
            this.inputBox.Text += Constants.ZERO;
        }
        //1 pressed on the calculator
        private void oneButton_Click(object sender, EventArgs e)
        {
            this.inputBox.Text += Constants.ONE;
        }
        //2 pressed on the calculator
        private void twoButton_Click(object sender, EventArgs e)
        {
            this.inputBox.Text += Constants.TWO;
        }
        //3 pressed on the calculator
        private void threeButton_Click(object sender, EventArgs e)
        {
            this.inputBox.Text += Constants.THREE;
        }
        //4 pressed on the calculator
        private void fourButton_Click(object sender, EventArgs e)
        {
            this.inputBox.Text += Constants.FOUR;
        }
        //5 pressed on the calculator
        private void fiveButton_Click(object sender, EventArgs e)
        {
            this.inputBox.Text += Constants.FIVE;
        }
        //6 pressed on the calculator
        private void sixButton_Click(object sender, EventArgs e)
        {
            this.inputBox.Text += Constants.SIX;
        }
        //7 pressed on the calculator
        private void sevenButton_Click(object sender, EventArgs e)
        {
            this.inputBox.Text += Constants.SEVEN;
        }
        //8 pressed on the calculator
        private void eightButton_Click(object sender, EventArgs e)
        {
            this.inputBox.Text += Constants.EIGHT;
        }
        //9 pressed on the calculator
        private void nineButton_Click(object sender, EventArgs e)
        {
            this.inputBox.Text += Constants.NINE;
        }
        //, pressed on the calculator
        private void commaButton_Click(object sender, EventArgs e)
        {
            this.inputBox.Text += Constants.COMMA;
        }
        //+ pressed on the calculator
        private void plusButton_Click(object sender, EventArgs e)
        {
            this.inputBox.Text += Constants.PLUS;
        }
        //- pressed on the calculator
        private void minusButton_Click(object sender, EventArgs e)
        {
            this.inputBox.Text += Constants.MINUS;
        }
        //x pressed on the calculator
        private void multiplyButton_Click(object sender, EventArgs e)
        {
            this.inputBox.Text += Constants.MULTIPLY;
        }
        //division pressed on the calculator
        private void divideButton_Click(object sender, EventArgs e)
        {
            this.inputBox.Text += Constants.DIVIDE;
        }
        //. pressed on the calculator
        private void decimalButton_Click(object sender, EventArgs e)
        {
            this.inputBox.Text += Constants.DECIMAL;
        }
        //( pressed on the calculator
        private void leftBracketButton_Click(object sender, EventArgs e)
        {
            this.inputBox.Text += Constants.RIGHT_BRACKET;
        }
        //) pressed on the calculator
        private void rightBracketButton_Click(object sender, EventArgs e)
        {
            this.inputBox.Text += Constants.LEFT_BRACKET;
        }

        //event handler for the quantity listbox called whenever a user select an item in the listbox
        private void quantitiesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String quantityName = quantitiesListBox.SelectedItem.ToString(); //get the selected item into a String
            unitListbox.Items.Clear(); //clear the unit listbox from any previous entries
            ArrayList units = getUnits(quantityName); //get the corresponding units for the quantity selected
            for (int i = 0; i < units.Count; ++i) //populate the unit listbox with the corresponding units for the quantity selected
            {
                String unit = (String)units[i];
                unitListbox.Items.Add(unit); //add unit to listbox    
            }
        }
        //populating hashtable for corresponding quantities and their units
        private void populateHashTable()
        {
            quantitiesUnits = new Hashtable(); //a new hashtable
            ArrayList unitsList = new ArrayList(); //a new arraylist
            unitsList.Add("ft/s2");
            unitsList.Add("in/s2");
            unitsList.Add("m/s2");
            quantitiesUnits.Add("Acceleration", unitsList);
            unitsList.Clear();



        }
        private ArrayList getUnits(String quantityName)
        {
            return new ArrayList();
        }
    }
}