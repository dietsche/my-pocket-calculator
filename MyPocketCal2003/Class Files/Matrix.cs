using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace MyPocketCal2003
{
    class Matrix
    {
        int rows;
        int columns;
        int[][] matrix;

        //ArrayList to store rows separately as Strings
        ArrayList rowsSplitter;

        public Matrix(ListBox.ObjectCollection items, int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.populateMatrix(items);
            rowsSplitter = new ArrayList();
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
        public void add(Matrix left, Matrix right)
        {

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
}
