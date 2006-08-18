using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using System.Reflection;
using System.IO;

namespace MyPocketCal2003
{
    public partial class Unit : BaseFormLibrary.AlphaNumeric
    {
        //public static string path = @"E:\SOC\MyPocketCal2003\MyPocketCal2003\QuantitiesUnits.xml";
        public static string path = @"\Program Files\MyPocketCal2003\QuantitiesUnits.xml";
        XmlDocument docXMLFile; //the XmlDocument object which reads all the Quantities and their respective units from an xml file
        String inputUnit; //the string to hold the user input unit choice
        String outputUnit;  //the string to hold the user output unit choice
        String quantityName; //the string to hold the user quantity choice
        
        public Unit()
        {
            InitializeComponent();
            //string path;
            //path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            //MessageBox.Show(path);
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
        //. pressed on the calculator
        private void decimalButton_Click(object sender, EventArgs e)
        {
            this.inputBox.Text += Constants.DECIMAL;
        }
        //event handler for the quantity listbox called whenever a user select an item in the listbox
        private void quantitiesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            quantityName = quantitiesListBox.SelectedItem.ToString(); //get the selected item into a String
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
            
            //Assembly thisAssembly = Assembly.GetExecutingAssembly();
            //StreamReader strmReader = new StreamReader(thisAssembly.GetManifestResourceStream("MyPocketCal2003.QuantitiesUnits.xml"));
             
            //String strXML = strmReader.ReadToEnd();
       
            //this.docXMLFile.LoadXml(strXML); //loading the xml file in the XmlDocument object
            this.docXMLFile.Load(Unit.path); //loading the xml file in the XmlDocument object

            //strmReader.Close();

            this.populateQuantities(); //load quantities name in the listbox
        }
        //get the units of a Quantity=quantityName and returns them in an ArrayList
        private ArrayList getUnits(String quantityName)
        {
            XmlNode quantityNode; //the XmlNode to hold the returned Quantity Node
            ArrayList unitsList = new ArrayList(); //the ArrayList to hold the quantity units name
            
            //get the Quantity node which has its Name = quantityName in the XmlDocument object
            quantityNode = docXMLFile.SelectSingleNode("/Quantities/Quantity[Name='" + quantityName + "']");
            
            foreach (XmlNode unit in quantityNode.LastChild) //last child is the <Units> node
            {
                unitsList.Add(unit.InnerText); //retreiving each <unit> inside the <Units> node
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
        //event handler for the units lixtbox called whenever the user selects an item in the unit listbox
        private void unitListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputUnit = unitListbox.SelectedItem.ToString(); //user input unit choice
        } 
        //event handler for the convertTo combobox called whenever the user selects an item out of the combo box
        private void convertToComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            outputUnit = convertToComboBox.SelectedItem.ToString(); //user output unit choice
            if (this.ratioQuantity(quantityName)) //if ratios required for conversion
            {
                UnitConversion unitConvert = new UnitConversion(); //the UnitConversion Class which reads ratios from xml file
                outputBox.Text = unitConvert.convert(inputBox.Text, quantityName, inputUnit, outputUnit, docXMLFile); //set output
            }
            else if (quantityName.Equals("Currency"))
            {
                CurrencyConversion currencyConv = new CurrencyConversion(); //the CurrencyConversion class which connects with the webservice
                outputBox.Text = currencyConv.convertCurrency(inputBox.Text, inputUnit.Substring(0, 3), outputUnit.Substring(0, 3)); //pass the first 3 characters of the String & set output
            }
            else if (quantityName.Equals("Number"))
            {
                NumberConversion numberConvert = new NumberConversion(); //the NumberConversion class which does the number system conversion
                outputBox.Text = numberConvert.convert(inputBox.Text, inputUnit, outputUnit); //set output
            }
            else if (quantityName.Equals("Temperature"))
            {
                TemperatureConversion tempConvert = new TemperatureConversion(); //the TemperatureConversion class which does the temperature conversion
                outputBox.Text = tempConvert.convert(inputBox.Text, inputUnit, outputUnit); //set output
            }
        }
        //function which returns true if a quantity requires ratios for conversions otherwise false
        public bool ratioQuantity(String quantityName)
        {
            //quantity is not (currency or number or temperature)
            if (!(quantityName.Equals("Currency") || quantityName.Equals("Number") || quantityName.Equals("Temperature")) )
                return true;
            return false; //quantity would not need ratios for conversions
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            AddDeleteQuantity addQuantity = new AddDeleteQuantity(this.docXMLFile, this.quantitiesListBox.Items);
            addQuantity.ControlBox = true;
            addQuantity.MinimizeBox = false;
            addQuantity.Show();
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (inputBox.Text.Length > 0)
            {
                inputBox.Text = inputBox.Text.ToString().Remove(inputBox.Text.Length - 1, 1);
            }
        }

        private void Unit_Activated(object sender, EventArgs e)
        {
            this.populateQuantities();
        }
    }
}