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
        double[][] matrix;

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
            this.matrix = new double[rows][];
            for (int rowNo = 0; rowNo < rows; ++rowNo)
            {
                matrix[rowNo] = new double[columns];
            }
        }
        public Matrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.rowsSplitter = new ArrayList();

            //constructing a double 2D array
            this.matrix = new double[rows][];
            for (int rowNo = 0; rowNo < rows; ++rowNo)
            {
                matrix[rowNo] = new double[columns];
            }
        }
        public Matrix(double[][] matrix, int rows, int columns)
        {
            this.matrix = matrix;
            this.rows = rows;
            this.columns = columns;
            this.rowsSplitter = new ArrayList();
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
            matrix = new double[rows][];
            
            for(int rowNo=0; rowNo < rows; ++rowNo)
            {
                matrix[rowNo] = new double[columns];

                String[] values = ((String)items[rowNo]).Split(new Char[] {' '}); //get individual values out
                for (int colNo = 0; colNo < columns; ++colNo)
                {
                    matrix[rowNo][colNo] = Double.Parse(values[colNo]); //store the individual value at the correct place
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
            }
            else
            {
                throw new MatrixIncompatibleException("Cannot Multiply " + left.name + " & " + right.name + " :Incompatible");
            }
            return result;
        }
        public Matrix divide(Matrix left, double value)
        {
            Matrix result;
            if(value != 0)
            {
                result = new Matrix(this.rows, this.columns);

                for (int i = 0; i < this.rows; i++)
                {
                    for (int j = 0; j < this.columns; j++)
                    {
                        result.matrix[i][j] = Math.Round(this.matrix[i][j] / value, 3);
                    }
                }
            }
            else
            {
                throw new MatrixIncompatibleException("Cannot Divide " + left.name + " & " + value + " :Value is 0");
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

        public double determinant()
        {
            if (this.rows != this.columns)
                throw new MatrixIncompatibleException("Non-Square Matrix");

            //a new matrix to copy the current matrix to
            double[][] matrixFactored = new double[this.rows][];
            for (int rowNo = 0; rowNo < rows; ++rowNo)
            {
                matrixFactored[rowNo] = new double[this.columns];
                for (int colNo = 0; colNo < columns; ++colNo)
                {
                    //store the individual value at the correct place
                    matrixFactored[rowNo][colNo] = this.matrix[rowNo][colNo];
                }
            }

            for (int p = 0; p < rows - 1; ++p) //start upper triangularization
            {
                for (int k = p + 1; k < rows; ++k)
                {
                    if (matrixFactored[k][p] > matrixFactored[p][p])
                    {
                        //copy pth row to temp
                        double[] temp = new double[this.columns];
                        matrixFactored[p].CopyTo(temp, 0);

                        //copy kth row to pth row
                        matrixFactored[k].CopyTo(matrixFactored[p], 0);

                        //copy the temp to kth row
                        temp.CopyTo(matrixFactored[k], 0);
                    }
                }
                if (matrixFactored[p][p] == 0)
                    throw new MatrixIncompatibleException("The matrix is singular.");

                for (int k = p + 1; k < rows; ++k) //elementary row operations
                {
                    double m = matrixFactored[k][p] / matrixFactored[p][p];
                    for (int c = p; c < rows; ++c)
                    {
                        matrixFactored[k][c] = matrixFactored[k][c] - m * matrixFactored[p][c];
                    }
                }
            }

            if (matrixFactored[rows - 1][rows - 1] == 0)
            {
                throw new MatrixIncompatibleException("The Matrix is singular");
            }

            double determinant = 1.0;
            for (int d = 0; d < rows; ++d)
                determinant *= matrixFactored[d][d];

            return determinant;
        }
        ////determinant
        //public double determinant()
        //{
        //    double determinent = 0;

        //    if (this.rows != this.columns)
        //        throw new MatrixIncompatibleException("Non-Square Matrix. Cannot Find Determinant");

        //    //get the determinent of a 2x2 matrix
        //    if (this.rows == 2 && this.columns == 2)
        //    {
        //        determinent = (this.matrix[0][0] * this.matrix[1][1]) - (this.matrix[0][1] * this.matrix[1][0]);
        //        return determinent;
        //    }

        //    Matrix tempMtx = new Matrix(this.rows - 1, this.columns - 1);

        //    //find the determinent with respect to the first row
        //    for (int j = 0; j < this.columns; j++)
        //    {
        //        tempMtx = this.minor(0, j);

        //        //recursively add the determinents
        //        determinent += (int)Math.Pow(-1, j) * this.matrix[0][j] * tempMtx.determinant();

        //    }
        //    return determinent;
        //}

        //returns a minor of a matrix with respect to an element
        public Matrix minor(int row, int column)
        {
            if (this.rows < 2 || this.columns < 2)
                throw new MatrixIncompatibleException("Minor not available");

            int i, j = 0;

            Matrix minorMtx = new Matrix(this.rows - 1, this.columns - 1);

            //find the minor with respect to the first element
            for (int k = 0; k < minorMtx.rows; k++)
            {
                if (k >= row)
                    i = k + 1;
                else
                    i = k;

                for (int l = 0; l < minorMtx.columns; l++)
                {
                    if (l >= column)
                        j = l + 1;
                    else
                        j = l;
                    minorMtx.matrix[k][l] = this.matrix[i][j];
                }
            }
            return minorMtx;
        }

        //transpose
        public Matrix transpose()
        {
            Matrix result = new Matrix(this.columns, this.rows);

            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    result.matrix[j][i] = this.matrix[i][j];
                }
            }
            return result;
        }

        //adjoint matrix
        public Matrix adjoint()
        {
            if (this.rows < 2 || this.columns < 2)
                throw new MatrixIncompatibleException("Adjoint matrix not available");

            Matrix tempMtx = new Matrix(this.rows - 1, this.columns - 1);
            Matrix adjMtx = new Matrix(this.columns, this.rows);

            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    tempMtx = this.minor(i, j);

                    //put the determinent of the minor in the transposed position
                    adjMtx.matrix[j][i] = ((int)Math.Pow(-1, i + j)) * tempMtx.determinant();
                }
            }
            return adjMtx;
        }
        
        //inverse
        public Matrix inverse()
        {
            if (this.determinant() == 0)
                throw new MatrixIncompatibleException("Attempt to invert a singular matrix");
            //return null;

            //inverse of a 2x2 matrix
            if (this.rows == 2 && this.columns == 2)
            {
                Matrix tempMtx = new Matrix(2, 2);

                tempMtx.matrix[0][0] = this.matrix[1][1];
                tempMtx.matrix[0][1] = -this.matrix[0][1];
                tempMtx.matrix[1][0] = -this.matrix[1][0];
                tempMtx.matrix[1][1] = this.matrix[0][0];

                return tempMtx.divide(tempMtx, this.determinant());
            }
            Matrix result = adjoint(); //get adjoint
            double det = this.determinant(); //get determinant
            return result.divide(result, det);
        }
        public double[] gaussianElimination()
        {
            if (rows + 1 != columns)
                throw new Exception("Augmented Matrix Required");

            //a new matrix to copy the current matrix to
            double[][] matrixFactored = new double[this.rows][];
            for (int rowNo = 0; rowNo<rows; ++rowNo)
            {
                matrixFactored[rowNo] = new double[this.columns];
                for (int colNo = 0; colNo<columns; ++colNo)
                {
                    //store the individual value at the correct place
                    matrixFactored[rowNo][colNo] = this.matrix[rowNo][colNo];
                }
            }

            for (int p = 0; p < rows-1; ++p) //start upper triangularization
            {
                for (int k = p + 1; k < rows; ++k)
                {
                    if (matrixFactored[k][p] > matrixFactored[p][p])
                    {
                        //copy pth row to temp
                        double[] temp = new double[this.columns];
                        matrixFactored[p].CopyTo(temp, 0);

                        //copy kth row to pth row
                        matrixFactored[k].CopyTo(matrixFactored[p], 0);

                        //copy the temp to kth row
                        temp.CopyTo(matrixFactored[k], 0);
                    }
                }
                if (matrixFactored[p][p] == 0)
                    throw new MatrixIncompatibleException("The matrix is singular.");

                for (int k = p + 1; k < rows; ++k) //elementary row operations
                {
                    double m = matrixFactored[k][p]/matrixFactored[p][p];
                    for (int c = p; c < rows + 1; ++c)
                    {
                        matrixFactored[k][c] = matrixFactored[k][c] - m * matrixFactored[p][c];
                    }
                }
            }

            if (matrixFactored[rows-1][rows-1] == 0)
                throw new MatrixIncompatibleException("The Matrix is singular");


            //back substitution
            double[] solutions = new double[rows];

            solutions[rows - 1] = matrixFactored[rows - 1][rows] / matrixFactored[rows - 1][rows - 1];
            for (int k = rows - 2; k >= 0; --k)
            {
                double sum = 0.0;
                for (int c = k + 1; c < rows; ++c)
                {
                    sum = sum + matrixFactored[k][c] * solutions[c];
                }
                solutions[k] = (matrixFactored[k][rows] - sum) / matrixFactored[k][k];
            }

            //Matrix result = new Matrix(matrixFactored, this.rows, this.columns);
            return solutions;
        }
    }

    public class MatrixIncompatibleException : System.Exception
    {
        public MatrixIncompatibleException(string message): base(message)
        {
        }
    }
}
