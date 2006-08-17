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
    public partial class Statistic : BaseFormLibrary.BasicButtonForm
    {
        private Hashtable dataMap; //hashtable to hold data lists
        public Statistic()
        {
            InitializeComponent();
            dataMap = new Hashtable();
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

        private void addValueButton_Click(object sender, EventArgs e)
        {
            inputBox.Text = inputBox.Text.Trim();
            if (inputBox.Text.Length == 0)
            {
                MessageBox.Show("Write a value to add");
                inputBox.Focus();
                return;
            }

            valuesListBox.Items.Add(inputBox.Text);
            inputBox.Text = "";   
            
            //# of values 
            lbNoOfValues.Text = "Count: " + Convert.ToString(valuesListBox.Items.Count);
            inputBox.Focus();
        }

        private void newDataButton_Click(object sender, EventArgs e)
        {
            valuesListBox.Items.Clear(); //clear the values listbox
            //# of values 
            lbNoOfValues.Text = "Count: " + Convert.ToString(valuesListBox.Items.Count);
        }

        private void deleteValueButton_Click(object sender, EventArgs e)
        {
            valuesListBox.Items.Remove(valuesListBox.SelectedItem);
            //# of values 
            lbNoOfValues.Text = "Count: " + Convert.ToString(valuesListBox.Items.Count);
        }

        private void saveDataButton_Click(object sender, EventArgs e)
        {
            if (valuesListBox.Items.Count == 0)
            {
                MessageBox.Show("Enter values to store as Data");
                inputBox.Focus(); //set inputbox focus
                return;
            }

            string dataName = "";
            if (comboBoxDataNames.SelectedItem != null)
                dataName = comboBoxDataNames.SelectedItem.ToString();
            else
                return;

            //if data name already present
            if (dataMap.Contains(dataName))
            {
                //yesno dialog box
                DialogResult result = MessageBox.Show("Yes to overwrite, No to choose another name", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                
                if (result == DialogResult.Yes) //yes overwrite
                {
                    ArrayList dataOver = new ArrayList();
                    dataOver.AddRange(valuesListBox.Items); //convert to ArrayList
                    dataMap[dataName] = dataOver; //set the existing key to new value 
                    //clear valueslist box
                    valuesListBox.Items.Clear();
                }
                else if (result == DialogResult.No) //no choose another name
                {
                    comboBoxDataNames.Focus(); //set data name text box focus
                }
                return;
            }

            ArrayList data = new ArrayList();
            data.AddRange(valuesListBox.Items); //convert to ArrayList

            dataMap.Add(dataName, data); //add dataname & data to hashtable as Arraylist
            dataListBox.Items.Add(dataName); //add dataname to listbox

            //clear valueslist box
            valuesListBox.Items.Clear();
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataListBox.SelectedItem != null)
            {
                dataMap.Remove(dataListBox.SelectedItem.ToString()); //remove from hashtable
                dataListBox.Items.Remove(dataListBox.SelectedItem.ToString()); //remove from listbox
                this.lbNoOfValues.Text = "Count: 0";
            }
        }
        private void independentComboBox_GotFocus_1(object sender, EventArgs e)
        {
            dataComboBox.Items.Clear(); //clear any last entries
            foreach (String item in dataListBox.Items)
            {
                dataComboBox.Items.Add(item); //add each data name
            }
        }
        private void dependentComboBox_GotFocus(object sender, EventArgs e)
        {
            dependentComboBox.Items.Clear(); //clear any last entries
            foreach (String item in dataListBox.Items)
            {
                dependentComboBox.Items.Add(item); //add each data name
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (dataComboBox.SelectedItem == null)
            {
                MessageBox.Show("Choose a data from dropdown box");
                tabControl1.SelectedIndex = 1; //display the basic tabpage
                dataComboBox.Focus();
                return;
            }

            listBoxAnswers.Items.Clear(); //clear any previous entries
            tabControl1.SelectedIndex = 3; //display the answers tabpage

            //get data from hashtable
            ArrayList data = (ArrayList)this.dataMap[dataComboBox.SelectedItem.ToString()];
            
            StatsBasic statsAnswers = new StatsBasic(data); //populate the object with the data

            if (checkBoxMin.Checked) //minimum value
            {
                listBoxAnswers.Items.Add("Min = " + statsAnswers.getMin());
            }
            if (checkBoxMax.Checked) //maximum value
            {
                listBoxAnswers.Items.Add("Max = " + statsAnswers.getMax());
            }
            if (checkBoxMedian.Checked) //Median
            {
                listBoxAnswers.Items.Add("Median = " + statsAnswers.getMedian());
            }
            if (checkBoxRange.Checked) //range
            {
                listBoxAnswers.Items.Add("Range = " + statsAnswers.getRange());
            }
            if (checkBoxMode.Checked) //mode
            {
                listBoxAnswers.Items.Add("Mode = " + statsAnswers.getMode());
            }
            if (checkBoxAMean.Checked) //arithematic mean
            {
                listBoxAnswers.Items.Add("A. Mean = " + statsAnswers.getAM());
            }
            if (checkBoxGMean.Checked) //geometric mean
            {
                listBoxAnswers.Items.Add("G. Mean = " + statsAnswers.getGM());
            }
            if (checkBoxHMean.Checked) //hm
            {
                listBoxAnswers.Items.Add("H. Mean = " + statsAnswers.getHM());
            }
            if (checkBoxSVar.Checked) //sample variance
            {
                listBoxAnswers.Items.Add("S. Variance = " + statsAnswers.getSampleVar());
            }
            if (checkBoxPVar.Checked) //population variance
            {
                listBoxAnswers.Items.Add("P. Variance = " + statsAnswers.getPopulationVar());
            }
            if (checkBoxSSD.Checked) // sample sd
            {
                listBoxAnswers.Items.Add("S. S.D. = " + statsAnswers.getSampleSD());
            }
            if (checkBoxPSD.Checked) //population sd
            {
                listBoxAnswers.Items.Add("P. S.D. = " + statsAnswers.getPopulationSD());
            }
        }
        private void dataListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get values arraylist against specified data name
            if (dataListBox.SelectedItem != null) //when the user deletes a data name the selected item is null
            {
                ArrayList values = (ArrayList)dataMap[dataListBox.SelectedItem.ToString()];
                valuesListBox.Items.Clear(); //clear any previous entries
                foreach (String value in values)
                {
                    valuesListBox.Items.Add(value); //add each value to listbox
                }
            }
            else
                valuesListBox.Items.Clear();
        }

        private void independentComboBox_GotFocus(object sender, EventArgs e)
        {
            independentComboBox.Items.Clear(); //clear any last entries
            foreach (String item in dataListBox.Items)
            {
                independentComboBox.Items.Add(item); //add each data name
            }
        }

        private void dependentComboBox_GotFocus_1(object sender, EventArgs e)
        {
            dependentComboBox.Items.Clear(); //clear any last entries
            foreach (String item in dataListBox.Items)
            {
                dependentComboBox.Items.Add(item); //add each data name
            }
        }

        private void btnCalculateAdvance_Click(object sender, EventArgs e)
        {
            if (independentComboBox.SelectedItem == null) //if no independent data selected
            {
                MessageBox.Show("Choose an independent data");
                tabControl1.SelectedIndex = 2; //display the basic tabpage
                independentComboBox.Focus();
                return;
            }

            listBoxAnswers.Items.Clear(); //clear any previous entries
            tabControl1.SelectedIndex = 3; //display the answers tabpage

            if (dependentComboBox.SelectedItem == null) //if no dependent data selected
            {
                MessageBox.Show("Choose a dependent data");
                tabControl1.SelectedIndex = 2; //display the basic tabpage
                dependentComboBox.Focus();
                return;
            }
            
            //get the independent data from hashtable
            ArrayList independentData = (ArrayList)this.dataMap[independentComboBox.SelectedItem.ToString()];
            
            //get the dependent data from hashtable
            ArrayList dependentData = (ArrayList)this.dataMap[dependentComboBox.SelectedItem.ToString()];

            //both data size should be equal otherwise:
            if (independentData.Count != dependentData.Count)
            {
                MessageBox.Show("Choose equal size data");
                independentComboBox.Focus();
                return;
            }
            StatsAdvance statAdvance = new StatsAdvance(independentData, dependentData);

            if (checkBoxCoefficientDetermination.Checked)
            {
                listBoxAnswers.Items.Add("Coeff. of Deter.: " + statAdvance.coeffDetermination());
            }
            if (checkBoxCorrelationCoefficient.Checked)
            {
                listBoxAnswers.Items.Add("Correlation Coeff: " + statAdvance.correlationCoeff());
            }
            if (checkBoxLinearRegression.Checked)
            {
                listBoxAnswers.Items.Add(statAdvance.linearFit());
            }
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (inputBox.Text.Length != 0)
            {
                string input = inputBox.Text.ToString();
                inputBox.Text = input.Remove(input.Length - 1, 1);
            }
        }
    }
}