using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MyPocketCal2003
{
    class ComplexNumber
    {
        double real;
        double imaginary;

        //constructors
        public ComplexNumber()
        { }
        public ComplexNumber(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }
        public ComplexNumber(String input)
        {
            //validates & converts to my own representation of complex number in String format
            input = ComplexNumber.convertToComplex(input); 
            if(input != null)
                this.toComplex(input); //to store the real & imaginary part
        }
        
        //the following function validated & converts an input to my own complex number representation
        //my own complex number representation is basically the + replaced by a and - replabed by b
        //returns a the string representation is validation & conversion was succesfull otherwise returns a null
        public static string convertToComplex(string input)
        {
            //+ replaced by a
            input = Regex.Replace(input, @"\+", "a");
            //- replaced by b
            input = Regex.Replace(input, @"\-", "b");
            try
            {
                //a valid complex number e.g. 2+2i 2.2-2i etc
                string goodWord = @"^[b]?\d+(\.\d+)?([E][ab]\d+)?[a-b]{1}\d+(\.\d+)?([E][ab]\d+)?[i]$"; 
                if (!Regex.IsMatch(input, goodWord))
                {
                    //a valid complex number but something as 2+i or 2-i
                    goodWord = @"^[b]?\d+(\.\d+)?([E][ab]\d+)?[a-b]{1}\d*[i]$";
                    if (Regex.IsMatch(input, goodWord))
                    {
                        input = input.Remove(input.Length - 1, 1); //remove the i at the end
                        input += "1i"; //add a 1i at the end
                    }
                    else
                    {
                        //a valid complex number whose real part is 0
                        goodWord = @"^b?\d*(\.\d+)?([E][ab]\d+)?i$";
                        if (Regex.IsMatch(input, goodWord))
                        {
                            //if negative imaginary number then append a "0" at the start
                            if ((input[0] + "").Equals("b"))
                                input = "0" + input;
                            else //otherwise append a "0a" at the start which means addin a "0+" 
                                input = "0a" + input;
                        }
                        else
                        {
                            //a complex number whose imaginary part is 0 i.e. 20.2 or 20
                            goodWord = @"^b?\d+(\.\d+)?([E][ab]\d+)?$";
                            if (Regex.IsMatch(input, goodWord))
                            {
                                input += "a0i"; //add an imaginary 0
                            }
                            else
                            {
                                goodWord = @"^NaN[ab]NaNi?$"; //check for NaN +- NaNi
                                if (!Regex.IsMatch(input, goodWord))
                                {
                                    throw new FormatException("Invalid input. Enter a complex number");
                                }
                            }
                        }
                    }
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message);
                return null;
            }
            return input;
        }

        //the following functions extracts the imaginary & real part out of a complex number represented as a string
        private void toComplex(string input)
        {

            string goodWord = @"^NaN[ab]NaNi?$"; //check for NaN +- NaNi
            if (Regex.IsMatch(input, goodWord))
            {
                this.real = Double.NaN;
                this.imaginary = Double.NaN;
                return;
            }
            //a represents +
            //b represents -
            //i represents i
            string operators = "abi";

            //to avoid splitting of a number like 1.2E+16

            input = input.Replace("Ea", "c"); //replacing Ea with c so that it does not splits the string 
            input = input.Replace("Eb", "d"); //replacing Eb with d so that it does not splits the string 

            for (int i = 0; i < operators.Length; ++i)
            {
                input = input.Replace(""+operators[i], " " + operators[i] + " ");
            }
            input = input.Trim(); //remove spaces from start & end

            input = input.Replace("c", "E+");
            input = input.Replace("d", "E-");

            string[] tokens = input.Split(' ');

            if (tokens.Length == 4)//positive real part
            {                
                this.real = Double.Parse(tokens[0]);
                if(tokens[1].Equals("b")) //negative imaginary part
                    this.imaginary = -1.0*double.Parse(tokens[2]);
                else //positive imaginary part
                    this.imaginary = double.Parse(tokens[2]);
            }
            else if (tokens.Length == 5) //negative real part
            {
                this.real = -1.0*Double.Parse(tokens[1]);
                if (tokens[2].Equals("b")) //negative imaginary part
                    this.imaginary = -1.0 * double.Parse(tokens[3]);
                else //positive imaginary part
                    this.imaginary = double.Parse(tokens[3]);
            }
        }

        //+ overloaded
        public static ComplexNumber operator +(ComplexNumber left, ComplexNumber right)
        {
            return new ComplexNumber(left.real + right.real, left.imaginary + right.imaginary);
        }
        //- overloaded
        public static ComplexNumber operator -(ComplexNumber left, ComplexNumber right)
        {
            return new ComplexNumber(left.real - right.real, left.imaginary - right.imaginary);
        }
        //* overloaded
        public static ComplexNumber operator *(ComplexNumber left, ComplexNumber right)
        {
            ComplexNumber result = new ComplexNumber();
            result.real = left.real * right.real - left.imaginary * right.imaginary;
            result.imaginary =left.real*right.imaginary + left.imaginary*right.real; 

            return result;
        }
        // / overloaded
        public static ComplexNumber operator /(ComplexNumber left, ComplexNumber right)
        {
            ComplexNumber conjugate = new ComplexNumber(right.real, -1.0*right.imaginary);

            ComplexNumber numerator = left * conjugate;
            ComplexNumber denominator = right* conjugate;

            return new ComplexNumber(Math.Round(numerator.real/denominator.real,4),Math.Round(numerator.imaginary/denominator.real,4));
        }
        //converting a complex number to my own representation of a complex number in string
        public override string ToString()
        {
            String complexStr = "";
            if (this.imaginary < 0) //negative imaginary
                complexStr = this.real + "" + this.imaginary + "i";
            else                    //positive imaginary
                complexStr = this.real + "+" + this.imaginary + "i";

            complexStr = complexStr.Replace("+", "a"); //replace + with a
            complexStr = complexStr.Replace("-", "b"); //replace - with b
            return complexStr;
        }
        //converting to a normal complex number returned as string object
        public String toMathString()
        {
            String complexStr = "";
            if (this.imaginary < 0)         //negative imaginary
                complexStr = this.real + "" + this.imaginary + "i";
            else if (this.imaginary == 0)   //zero imaginary
                complexStr = this.real + "";
            else                            //positive imaginary
            {
                if(this.real == 0) //if real part is 0
                    complexStr = this.imaginary + "i";
                else //otherwise if real part is not 0 neither is imaginary part 0
                    complexStr = this.real + "+" + this.imaginary + "i";
            }
            return complexStr;
        }
    }
}
