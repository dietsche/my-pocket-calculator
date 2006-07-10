using System.Windows.Forms;
using System.Xml;
using System;

namespace MyPocketCal2003
{
    public partial class AddQuantity : BaseFormLibrary.AlphaNumeric
    {
        XmlDocument docXMLFile; //the XmlDocument object which reads all the Quantities and their respective units from an xml file
        public String baseUnit;

        public AddQuantity(XmlDocument docXmlFile)
        {
            this.docXMLFile = docXMLFile;
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Every Quantity is assigned a base unit with respect to which you would need to provide conversion ratio of other units");
        }

        private void registerBaseButton_Click(object sender, System.EventArgs e)
        {
            baseUnit = baseUnitTextBox.Text; //store the base unit 
        }

        private void addUnitButton_Click(object sender, System.EventArgs e)
        {
            unitsListBox.Items.Add(unitTextBox.Text);
        }

        private void button1_Click_1(object sender, System.EventArgs e)
        {
            String selectedItem = unitsListBox.SelectedItem.ToString();
        }

        private void label5_ParentChanged(object sender, EventArgs e)
        {

        }
    }
}