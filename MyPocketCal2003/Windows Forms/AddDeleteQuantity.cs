using System.Windows.Forms;
using System.Xml;
using System;

namespace MyPocketCal2003
{
    public partial class AddDeleteQuantity : BaseFormLibrary.AlphaNumeric
    {
        private XmlDocument docXMLFile; //the XmlDocument object which reads all the Quantities and their respective units from an xml file
        private QuantityNode quantityNode;
        private bool caps;
        //getting the XmlDocument object and quantities names through the constructor
        public AddDeleteQuantity(XmlDocument docXmlFile, ListBox.ObjectCollection items)
        {
            InitializeComponent();
            this.docXMLFile = docXmlFile;
            this.quantityNode = new QuantityNode(docXMLFile); //initialize a QuantityNode
            this.caps = false;
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
            try
            {
                Double.Parse(unitRatioTextBox.Text);
                unitsListBox.Items.Add(unitTextBox.Text); //adding to the list box
                quantityNode.conversionRatios.Add(unitTextBox.Text, unitRatioTextBox.Text); //add unit name & conversion ratio to the hashtable
                unitTextBox.Text = "";
                unitRatioTextBox.Text = "";
            }
            catch
            {
                MessageBox.Show("Ratio can only be a number");
            }
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
            this.quantityNode.add();
        }

        private void deleteQuantityButton_Click(object sender, EventArgs e)
        {
            if (this.deleteQuantityComboBox.SelectedItem != null)
            {
                string quantityName = this.deleteQuantityComboBox.SelectedItem.ToString();
                //get the respective quantity node
                XmlNode quantityNode = docXMLFile.SelectSingleNode("/Quantities/Quantity[Name='" + quantityName + "']");

                XmlNode root = this.docXMLFile.DocumentElement;

                if (quantityNode != null)
                {
                    root.RemoveChild(quantityNode); //deleted the selected node
                    MessageBox.Show(quantityName + " deleted");
                }
            }
        }
        private void deleteQuantityComboBox_GotFocus(object sender, EventArgs e)
        {
            XmlNodeList nodeList;
            //get the Name of all the quantities
            nodeList = docXMLFile.SelectNodes("/Quantities/descendant::Name");
            foreach (XmlNode node in nodeList)
            {
                this.deleteQuantityComboBox.Items.Add(node.InnerText); //adding quantity name of the listbox
            }
        }
        private void AddDeleteQuantity_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.quantityNode.writeToFile();
        }
        private void zeroButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.ZERO);
        }
        private void oneButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.ONE);
        }
        private void twoButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.TWO);
        }
        private void threeButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.THREE);
        }

        private void fourButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.FOUR);
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.FIVE);
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.SIX);
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.SEVEN);
        }

        private void eightButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.EIGHT);
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.NINE);
        }

        private void decimalButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.DECIMAL);
        }
        private void pictureBoxZ_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.Z.ToLower());
            else
                this.addAsInput(Constants.Z);
        }
        private void pictureBoxX_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.X.ToLower());
            else
                this.addAsInput(Constants.X);
        }

        private void pictureBoxC_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.C.ToLower());
            else
                this.addAsInput(Constants.C);
        }

        private void pictureBoxV_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.V.ToLower());
            else
                this.addAsInput(Constants.V);
        }

        private void pictureBoxB_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.B.ToLower());
            else
                this.addAsInput(Constants.B);
        }

        private void pictureBoxN_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.N.ToLower());
            else
                this.addAsInput(Constants.N);
        }

        private void pictureBoxM_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.M.ToLower());
            else
                this.addAsInput(Constants.M);
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            this.undo();
        }

        private void pictureBoxCaps_Click(object sender, EventArgs e)
        {
            caps = !caps;
        }

        private void pictureBoxA_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.A.ToLower());
            else
                this.addAsInput(Constants.A);
        }

        private void pictureBoxS_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.S.ToLower());
            else
                this.addAsInput(Constants.S);
        }

        private void pictureBoxD_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.D.ToLower());
            else
                this.addAsInput(Constants.D);
        }

        private void pictureBoxF_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.F.ToLower());
            else
                this.addAsInput(Constants.F);
        }

        private void pictureBoxG_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.G.ToLower());
            else
                this.addAsInput(Constants.G);
        }

        private void pictureBoxH_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.H.ToLower());
            else
                this.addAsInput(Constants.H);
        }

        private void pictureBoxJ_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.J.ToLower());
            else
                this.addAsInput(Constants.J);
        }

        private void pictureBoxK_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.K.ToLower());
            else
                this.addAsInput(Constants.K);
        }

        private void pictureBoxL_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.L.ToLower());
            else
                this.addAsInput(Constants.L);
        }

        private void pictureBoxQ_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.Q.ToLower());
            else
                this.addAsInput(Constants.Q);
        }

        private void pictureBoxW_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.W.ToLower());
            else
                this.addAsInput(Constants.W);
        }

        private void pictureBoxE_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.E.ToLower());
            else
                this.addAsInput(Constants.E);
        }

        private void pictureBoxR_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.R.ToLower());
            else
                this.addAsInput(Constants.R);
        }

        private void pictureBoxT_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.T.ToLower());
            else
                this.addAsInput(Constants.T);
        }

        private void pictureBoxY_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.Y.ToLower());
            else
                this.addAsInput(Constants.Y);
        }

        private void pictureBoxU_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.U.ToLower());
            else
                this.addAsInput(Constants.U);
        }

        private void pictureBoxI_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.I.ToLower());
            else
                this.addAsInput(Constants.I);
        }

        private void pictureBoxO_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.O.ToLower());
            else
                this.addAsInput(Constants.O);
        }

        private void pictureBoxP_Click(object sender, EventArgs e)
        {
            if (this.caps == false)
                this.addAsInput(Constants.P.ToLower());
            else
                this.addAsInput(Constants.P);
        }
        private void addAsInput(string input)
        {
            if (quantityNameTextBox.Focused)
            {
                quantityNameTextBox.Text += input;
            }
            else if (baseUnitTextBox.Focused)
            {
                baseUnitTextBox.Text += input;
            }
            else if (unitRatioTextBox.Focused)
            {
                unitRatioTextBox.Text += input;
            }
            else if (unitTextBox.Focused)
            {
                unitTextBox.Text += input;
            }
        }
        private void undo()
        {
            if (quantityNameTextBox.Focused)
            {
                if (quantityNameTextBox.Text.Length > 0)
                {
                    string text = quantityNameTextBox.Text.ToString();
                    quantityNameTextBox.Text = text.Remove(text.Length - 1, 1);
                }
            }
            else if (baseUnitTextBox.Focused)
            {
                if (baseUnitTextBox.Text.Length > 0)
                {
                    string text = baseUnitTextBox.Text.ToString();
                    baseUnitTextBox.Text = text.Remove(text.Length - 1, 1);
                }
            }
            else if (unitRatioTextBox.Focused)
            {
                if (unitRatioTextBox.Text.Length > 0)
                {
                    string text = unitRatioTextBox.Text.ToString();
                    unitRatioTextBox.Text = text.Remove(text.Length - 1, 1);
                }
            }
            else if (unitTextBox.Focused)
            {
                if (unitTextBox.Text.Length > 0)
                {
                    string text = unitTextBox.Text.ToString();
                    unitTextBox.Text = text.Remove(text.Length - 1, 1);
                }
            }
        }
    }
}