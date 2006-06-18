using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;

namespace MyPocketCal2003
{
    public partial class Unit : BaseFormLibrary.BasicButtonForm
    {

        XmlDocument docXMLFile; //the XmlDocument object which reads all the Quantities and their respective units from an xml file
        public Unit()
        {
            InitializeComponent();
            loadQuantities(); 
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
            convertToComboBox.Items.Clear(); //clear the combo box from any previous entries
            ArrayList units = getUnits(quantityName); //get the corresponding units for the quantity selected
            for (int i = 0; i < units.Count; ++i) //populate the unit listbox with the corresponding units for the quantity selected
            {
                String unit = (String)units[i];
                unitListbox.Items.Add(unit); //add unit to listbox
                convertToComboBox.Items.Add(unit); //add unit to combo box
            }
        }
        //loads the Quantity Names & Units XML file into an XmlDocument object
        private void loadQuantities()
        {
            this.docXMLFile = new XmlDocument();
            //String path = Environment.GetFolderPath(Environment.SpecialFolder.Programs) + "\\MyPocketCal2003\\QuantitiesUnits.xml";
            String path = "E:\\SOC\\MyPocketCal2003\\MyPocketCal2003\\QuantitiesUnits.xml";
            this.docXMLFile.Load(path);
            this.populateQuantities(); //load quantities name in the listbox
        }
        //get the units of a Quantity=quantityName and returns them in an ArrayList
        private ArrayList getUnits(String quantityName)
        {
            XmlNode quantityNode; //the XmlNode to hold the returned Quantity Node
            ArrayList unitsList = new ArrayList(); //the ArrayList to hold the quantity units name
            
            //get the Quantity node which has its Name = quantityName in the XmlDocument object
            quantityNode = docXMLFile.SelectSingleNode("/Quantities/Quantity[Name='" + quantityName + "']");
            
            foreach (XmlNode unit in quantityNode.LastChild) //retreiving each unit name
            {
                unitsList.Add(unit.InnerText);
            }
            return unitsList; 
        }
        //populate the Quantities Listbox will all the quantities name
        private void populateQuantities()
        {
            XmlNodeList nodeList;

            //get the Name of all the quantities
            nodeList = docXMLFile.SelectNodes("/Quantities/descendant::Name");
            foreach (XmlNode node in nodeList)
            {
                this.quantitiesListBox.Items.Add(node.InnerText); //adding quantity name of the listbox
            }
        }
    }
}