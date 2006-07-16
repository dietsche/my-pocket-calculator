using System.Windows.Forms;
using System.Xml;
using System;

namespace MyPocketCal2003
{
    public partial class AddDeleteQuantity : BaseFormLibrary.AlphaNumeric
    {
        private XmlDocument docXMLFile; //the XmlDocument object which reads all the Quantities and their respective units from an xml file
        private QuantityNode quantityNode;

        //getting the XmlDocument object and quantities names through the constructor
        public AddDeleteQuantity(XmlDocument docXmlFile, ListBox.ObjectCollection items)
        {
            InitializeComponent();
            this.docXMLFile = docXmlFile;
            this.quantityNode = new QuantityNode(); //initialize a QuantityNode
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Every Quantity is assigned a base unit with respect to which you would need to provide conversion ratio of other units. Once a the base unit is registered you will not be able to change it.");
        }

        private void registerBaseButton_Click(object sender, System.EventArgs e)
        {
            if (quantityNameTextBox.Text.ToString().Length == 0) //if empty quantity name textbox
            {
                MessageBox.Show("Please Enter Quantity Name");
                return;
            }
            if (baseUnitTextBox.Text.ToString().Length == 0) //if empty baseunit textbox
            {
                MessageBox.Show("Please Enter Base Unit Name");
                return;
            }
            quantityNode.name = quantityNameTextBox.Text; //store the quantity name
            quantityNode.baseUnit = baseUnitTextBox.Text; //store the base unit

            //making the unvisible components visible
            unitsListBox.Visible = true;
            oneLabel.Visible = true;
            baseUnitLabel.Visible = true;
            ratioLabel.Visible = true;
            unitLabel.Visible = true;
            unitRatioTextBox.Visible = true;
            unitTextBox.Visible = true;
            deleteUnitButton.Visible = true;
            addUnitButton.Visible = true;
            saveQuantityButton.Visible = true;

            //changing base unit label text
            baseUnitLabel.Text = quantityNode.baseUnit + " ="; 
            baseUnitTextBox.ReadOnly = true; //changing base unit text to read only
        }
        private void addUnitButton_Click(object sender, System.EventArgs e)
        {
            unitsListBox.Items.Add(unitTextBox.Text); //adding to the list box
            quantityNode.conversionRatios.Add(unitTextBox.Text, unitRatioTextBox.Text); //add unit name & conversion ratio to the hashtable
            unitTextBox.Text = "";
            unitRatioTextBox.Text = "";
        }
        private void deleteUnitButton_Click(object sender, EventArgs e)
        {
            //removing from listbox
            quantityNode.conversionRatios.Remove(unitsListBox.SelectedItem);
            //removing from hashtable
            unitsListBox.Items.Remove(unitsListBox.SelectedItem); 
        }

        private void saveQuantityButton_Click(object sender, EventArgs e)
        {
            //add the quantity node to the XmlDocument object
            this.quantityNode.addTo(this.docXMLFile);
        }
    }
}