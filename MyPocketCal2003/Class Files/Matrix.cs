using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace MyPocketCal2003
{
    class Matrix
    {
        String name;
        int rows;
        int columns;
        int[][] matrix;

        //ArrayList to store rows separately as Strings
        ArrayList rowsSplitter;

        public Matrix(ListBox.ObjectCollection items, int rows, int columns, String name)
        {
            this.rows = rows;
            this.columns = columns;
            this.rowsSplitter = new ArrayList();
            this.name = name;
            this.populateMatrix(items);
        }
        public Matrix(int rows, int columns, String name)
        {
            this.name = name;
            this.rows = rows;
            this.columns = columns;
            this.rowsSplitter = new ArrayList();

            //constructing an int 2D array
            this.matrix = new int[rows][];
            for (int rowNo = 0; rowNo < rows; ++rowNo)
            {
                matrix[rowNo] = new int[columns];
            }
        }
        public String getName()
        {
            return this.name;
        }
        public int getRows()
        {
            return this.rows;
        }
        public int getColumns()
        {
            return this.columns;
        }
        public void populateMatrix(ListBox.ObjectCollection items)
        {
            matrix = new int[rows][];
            
            for(int rowNo=0; rowNo < rows; ++rowNo)
            {
                matrix[rowNo] = new int[columns];

                String[] values = ((String)items[rowNo]).Split(new Char[] {' '}); //get individual values out
                for (int colNo = 0; colNo < columns; ++colNo)
                {
                    matrix[rowNo][colNo] = Int32.Parse(values[colNo]); //store the individual value at the correct place
                }
            }
        }
        //separate very row into an ArrayList
        public void splitRows()
        {
            for (int rowNo = 0; rowNo < rows; ++rowNo)
            {
                String row = "";
                for (int colNo = 0; colNo < columns; ++colNo)
                {
                    row += Convert.ToString(matrix[rowNo][colNo]) + " "; //get each value and add it to a string
                }
                rowsSplitter.Add(row); //adding each row string to the arraylist
            }
        }
        public String nextRow()
        {
            String row =  Convert.ToString(this.rowsSplitter[0]);
            this.rowsSplitter.RemoveAt(0);
            return row;
        }
        public bool hasNext()
        {
            if (this.rowsSplitter.Count > 0)
                return true;
            return false;
        }
        public Matrix add(Matrix left, Matrix right)
        {
            Matrix result;
            if(equalDimension(left,right))
            {
                result = new Matrix(left.rows,left.columns, left.name + "+" + right.name);
                for (int rowNo=0; rowNo < left.rows; ++rowNo)
                {
                    for (int colNo = 0; colNo < left.columns; ++colNo)
                    {
                        result.matrix[rowNo][colNo] = left.matrix[rowNo][colNo] + right.matrix[rowNo][colNo];
                    }
                }
            }
            else
            {
                throw new MatrixIncompatibleException("Cannot Add " + left.name + " & " + right.name + " :Incompatible Matrices");
            }
            return result;
        }
        public Matrix subtract(Matrix left, Matrix right)
        {
            Matrix result;
            if (equalDimension(left, right))
            {
                result = new Matrix(left.rows, left.columns, left.name + "+" + right.name);
                for (int rowNo = 0; rowNo < left.rows; ++rowNo)
                {
                    for (int colNo = 0; colNo < left.columns; ++colNo)
                    {
                        result.matrix[rowNo][colNo] = left.matrix[rowNo][colNo] - right.matrix[rowNo][colNo];
                    }
                }
            }
            else
            {
                throw new MatrixIncompatibleException("Cannot Subtract " + left.name + " & " + right.name + " :Incompatible Matrices");
            }
            return result;
        }
        public Matrix multiply(Matrix left, Matrix right)
        {
            Matrix result;
            if(this.canMultiply(left,right))
            {                
                result = new Matrix(left.rows, right.columns, left.name + "*" + right.name);
                for (int rowNo = 0; rowNo < left.rows; rowNo++) //left matrix row traversal
                {
                    for (int colNo = 0; colNo < right.columns; colNo++) //right matrix column traversal
                    {
                        for (int elementNo = 0; elementNo < right.rows; elementNo++) // picking up each element from left & right matrix
                        {
                            result.matrix[rowNo][colNo] += left.matrix[rowNo][elementNo] * right.matrix[elementNo][colNo];
                        }
                    }
                }
                //for (int rowNo = 0; rowNo < left.rows; rowNo++) //left matrix row traversal
                //{
                //    for (int rowNo2 = 0; rowNo2 < right.columns; rowNo2++) //right matrix column traversal
                //    {
                //        for (int colNo = 0; colNo < right.rows; colNo++) // picking up each element from left & right matrix
                //        {
                //            result.matrix[rowNo][rowNo2] += left.matrix[rowNo][colNo] * right.matrix[colNo][rowNo2];
                //        }
                //    }
                //}
            }
            else
            {
                throw new MatrixIncompatibleException("Cannot Multiply " + left.name + " & " + right.name + " :Incompatible Matrices");
            }
            return result;
        }        
        public bool equalDimension(Matrix left, Matrix right)
        {
            if(left.rows == right.rows && left.columns == right.columns)
                return true;
            return false;
        }
        public bool canMultiply(Matrix left, Matrix right)
        {
            if(left.columns == right.rows)
                return true;
            return false;
        }

    }
    public class MatrixIncompatibleException : System.Exception
    {
        public MatrixIncompatibleException(string message): base(message)
        {
        }
    }
}
