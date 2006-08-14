using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyPocketCal2003
{
    public partial class MatrixForm : BaseFormLibrary.BasicButtonForm
    {
        Hashtable dataMap;
        int columnDim;

        public MatrixForm()
        {
            InitializeComponent();
            dataMap = new Hashtable();
            columnDim = 0;
        }

        //zero pressed on the calculator
        private void zeroButton_Click(object sender, EventArgs e)
        {
            this.addAsInput(Constants.ZERO);
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
        private void addAsInput(string input)
        {
            if (this.txtColumnDim.Focus())
            {
                this.txtColumnDim.Text += input;
            }
            else if (this.txtRowDim.Focus())
            {
                this.txtRowDim.Text += input;
            }
            else
            {
                this.inputBox.Text += input;
            }
        }
        private void btnSaveRow_Click(object sender, EventArgs e)
        {
            //if dimension have not been provided yet
            if (txtColumnDim.Text.Length == 0 || txtRowDim.Text.Length == 0)
            {
                MessageBox.Show("First choose a dimension for the matrix");
                txtRowDim.Focus();
                return;
            }
            
            //if input box empty
            inputBox.Text = inputBox.Text.Trim();
            if (inputBox.Text.Length == 0)
            {
                MessageBox.Show("Write a row to add e.g. 1,2,-3,4");
                inputBox.Focus();
                return;
            }
            
            //tokenize the input and extract numbers
            String[] tokens = inputBox.Text.ToString().Split(new Char [] {' '});

            try
            {
                
                //check if the input is in correct formats
                foreach (String token in tokens)
                {
                    int i = Int32.Parse(token);
                }
            }
            catch (Exception ex) //if the user does not enter input in correct format
            {
                MessageBox.Show(ex.Message);
                inputBox.Focus();
                return;
            }
            //number of entries should be equal to the column dimension otherwise:
            if (tokens.Length != this.columnDim)
            {
                MessageBox.Show("Entries do not match with the column dimension");
                inputBox.Focus();
                return;
            }

            listBoxMatrix.Items.Add(inputBox.Text);
            inputBox.Text = "";
        }

        private void btnNewMatrix_Click(object sender, EventArgs e)
        {
            listBoxMatrix.Items.Clear();
            txtRowDim.Text = "";
            txtRowDim.ReadOnly = false;
            txtColumnDim.Text = "";
            txtColumnDim.ReadOnly = false;
            inputBox.Text = "";
        }

        private void btnSaveMatrix_Click(object sender, EventArgs e)
        {
            if (listBoxMatrix.Items.Count == 0)
            {
                MessageBox.Show("Enter data for Matrix");
                inputBox.Focus(); //set inputbox focus
                return;
            }
            if (Int32.Parse(txtRowDim.Text) != listBoxMatrix.Items.Count)
            {
                MessageBox.Show("The row dimension do not match with the matrix entry.");
                inputBox.Focus();
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
                DialogResult result = MessageBox.Show("This name is already present in the list. Yes to overwrite, No to choose another name", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes) //yes overwrite
                {
                    //create a Matrix with the passed dimension and data
                    Matrix matrixOver = new Matrix(listBoxMatrix.Items, listBoxMatrix.Items.Count, this.columnDim, dataName);
                    dataMap[dataName] = matrixOver; //set the existing key to new value 
                    ////clear matrix list box
                    listBoxMatrix.Items.Clear();
                }
                else if (result == DialogResult.No) //no choose another name
                {
                    comboBoxDataNames.Focus(); //set data name text box focus
                }
                return;
            }

            //create a Matrix with the passed dimension,data,name
            Matrix matrix = new Matrix(listBoxMatrix.Items, listBoxMatrix.Items.Count, this.columnDim, dataName);
            
            dataMap.Add(dataName, matrix); //add dataname & data to hashtable
            listBoxMatrixName.Items.Add(dataName); //add matrix name to listbox

            //clear valueslist box
            listBoxMatrix.Items.Clear();
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            listBoxMatrix.Items.Remove(listBoxMatrix.SelectedItem);
        }

        private void btnStoreDim_Click(object sender, EventArgs e)
        {
            txtRowDim.Text = txtRowDim.Text.Trim();
            txtColumnDim.Text = txtColumnDim.Text.Trim();

            //check for empty boxes
            if (txtRowDim.Text.Length == 0)
            {
                MessageBox.Show("Enter a dimension for row");
                txtRowDim.Focus();
                return;
            }
            if (txtColumnDim.Text.Length == 0)
            {
                MessageBox.Show("Enter a dimension for column");
                txtColumnDim.Focus();
                return;
            }

            try
            {
                this.columnDim = Int32.Parse(txtColumnDim.Text); //store column dimension
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtColumnDim.Focus();
                return;
            }

            try
            {
                int rowDim = Int32.Parse(txtRowDim.Text); //row dimension
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtRowDim.Focus();
                return;
            }

            //set them to readonly once set
            txtRowDim.ReadOnly = true;
            txtColumnDim.ReadOnly = true;
        }

        private void btnDeleteMatrix_Click(object sender, EventArgs e)
        {
            if(listBoxMatrixName.SelectedItem != null)
            {
                dataMap.Remove(listBoxMatrixName.SelectedItem.ToString()); //remove from hashtable
                listBoxMatrixName.Items.Remove(listBoxMatrixName.SelectedItem.ToString()); //remove from listbox
            }
        }

        private void listBoxMatrixName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMatrixName.SelectedItem != null) //if count==0 then there is nothing to display so an exceptiion would occur
            {
                //get matrix against specified data name
                Matrix matrix = (Matrix)dataMap[listBoxMatrixName.SelectedItem.ToString()];
                listBoxMatrix.Items.Clear(); //clear any previous entries
                
                matrix.splitRows(); //prepare the matrix for receiving individual rows

                while(matrix.hasNext()) //get next row untill the matrix end
                {
                    listBoxMatrix.Items.Add(matrix.nextRow()); //add each row to listbox
                }

                txtRowDim.Text = Convert.ToString(matrix.getRows()); //set row dimension
                txtColumnDim.Text = Convert.ToString(matrix.getColumns()); //set column dimension
            }
            else
                listBoxMatrix.Items.Clear();
        }
        private void comboOperationMatrix_GotFocus(object sender, EventArgs e)
        {
            comboOperationMatrix.Items.Clear(); //clear any last entries
            foreach (String item in listBoxMatrixName.Items)
            {
                comboOperationMatrix.Items.Add(item); //add each matrix name
            }
        }
        private void comboOperationMatrix_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOperation.Text += comboOperationMatrix.SelectedItem.ToString();
        }
        private void btnAnswer_Click(object sender, EventArgs e)
        {
            MatrixPostFix postFix = new MatrixPostFix();
            String rpn = postFix.Convert(txtOperation.Text); //convert the expression to RPN Notation
            Matrix result = postFix.Solve(rpn,dataMap); //solve the RPN expression
            if (result != null)
            {
                listBoxAnswers.Items.Clear(); //clear any previous entries
                result.splitRows(); //prepare the matrix for receiving individual rows
                while (result.hasNext()) //get next row untill the matrix end
                {
                    listBoxAnswers.Items.Add(result.nextRow()); //add each row to answer listbox
                }
            }
            else
                MessageBox.Show("Result is null"); //88888888888888888888888888888888888888888888888888888888
            tabControl1.SelectedIndex = 2; //show the answers tabpage
        }

        private void comboMatrix_GotFocus(object sender, EventArgs e)
        {
            comboMatrix.Items.Clear(); //clear any last entries
            foreach (String item in listBoxMatrixName.Items)
            {
                comboMatrix.Items.Add(item); //add each matrix name
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Matrix matrix = (Matrix)dataMap[comboMatrix.SelectedItem.ToString()];
            listBoxAnswers.Items.Clear(); //clear any previous entries

            if (checkBoxDeterminant.Checked) //find determinant
            {
                listBoxAnswers.Items.Add("Determinant: " + Convert.ToString(matrix.determinant()));
            }
            if (checkBoxInverse.Checked) //find inverse
            {
                Matrix result = matrix.inverse();
                if (result != null)
                {
                    result.splitRows(); //prepare the matrix for receiving individual rows
                    listBoxAnswers.Items.Add("Inverse:");
                    while (result.hasNext()) //get next row untill the matrix end
                    {
                        listBoxAnswers.Items.Add(result.nextRow()); //add each row to answer listbox
                    }
                }
            }
            if (checkBoxTranspose.Checked) //find transpose
            {
                Matrix result = matrix.transpose();
                if (result != null)
                {
                    result.splitRows(); //prepare the matrix for receiving individual rows
                    listBoxAnswers.Items.Add("Transpose:");
                    while (result.hasNext()) //get next row untill the matrix end
                    {
                        listBoxAnswers.Items.Add(result.nextRow()); //add each row to answer listbox
                    }
                }
            }
            if (checkBoxAdjoint.Checked) //find adjoint
            {
                Matrix result = matrix.adjoint();
                if (result != null)
                {
                    result.splitRows(); //prepare the matrix for receiving individual rows
                    listBoxAnswers.Items.Add("Adjoint:");
                    while (result.hasNext()) //get next row untill the matrix end
                    {
                        listBoxAnswers.Items.Add(result.nextRow()); //add each row to answer listbox
                    }
                }
            }
            if (checkBoxEigenvalues.Checked) //find eigenvalues
            {

            }
            if (checkBoxEigenvector.Checked) //find eigenvector
            {

            }
            if (checkBoxRoots.Checked) //find roots
            {
                double[] result = matrix.gaussianElimination();
                listBoxAnswers.Items.Add("Roots: ");
                for (int i = 0; i < result.Length; ++i)
                {
                    listBoxAnswers.Items.Add(i + 1 + ". " + result[i]);
                }
            }
            tabControl1.SelectedIndex = 2; //switch to answers tab
        }
    }
}