using System;
using System.Collections.Generic;
using System.Text;

//code adopted from http://www.codeproject.com/csharp/balamurali_balaji.asp

namespace MyPocketCal2003
{
    class NumberConversion
    {
        const int base10 = 10;
        char[] cHexa = new char[] { 'A', 'B', 'C', 'D', 'E', 'F' };
        int[] iHexaNumeric = new int[] { 10, 11, 12, 13, 14, 15 };
        int[] iHexaIndices = new int[] { 0, 1, 2, 3, 4, 5 };
        const int asciiDiff = 48;

        public String convert(String number, String from, String to)
        {
            if (to.Equals(from))
                return number;

            if (from.Equals("Dec")) //from decimal
            {
                if (to.Equals("Bin")) //to binary
                {
                    return this.DecimalToBase(Int32.Parse(number), 2);
                }
                else if (to.Equals("Oct")) //to octal
                {
                    return this.DecimalToBase(Int32.Parse(number), 8);
                }
                else if (to.Equals("Hex")) //to hexadecimal
                {
                    return this.DecimalToBase(Int32.Parse(number), 16);
                }
            }
            else if(from.Equals("Bin")) //from Binary
            {
                if (to.Equals("Dec")) //to decimal
                {
                    return Convert.ToString(this.BaseToDecimal(number, 2));
                }
                else if (to.Equals("Oct")) //to octal
                {
                    String binToDec = Convert.ToString(this.BaseToDecimal(number, 2));
                    return this.DecimalToBase(Int32.Parse(binToDec), 8);
                }
                else if (to.Equals("Hex")) //to hexadecimal
                {
                    String binToDec = Convert.ToString(this.BaseToDecimal(number, 2));
                    return this.DecimalToBase(Int32.Parse(binToDec), 16);
                }
            }
            else if(from.Equals("Oct")) //from octal
            {
                if (to.Equals("Dec")) //to decimal
                {
                    return Convert.ToString(this.BaseToDecimal(number, 8));
                }
                else if (to.Equals("Bin")) //to binary
                {
                    String octToDec = Convert.ToString(this.BaseToDecimal(number, 8));
                    return this.DecimalToBase(Int32.Parse(octToDec), 2);
                }
                else if (to.Equals("Hex")) //to hexadecimal
                {
                    String octToDec = Convert.ToString(this.BaseToDecimal(number, 8));
                    return this.DecimalToBase(Int32.Parse(octToDec), 16);
                }
            }
            else if(from.Equals("Hex")) //from hexadecimal
            {
                if (to.Equals("Dec")) //to decimal
                {
                    return Convert.ToString(this.BaseToDecimal(number, 16));
                }
                else if (to.Equals("Bin")) //to binary
                {
                    String hexToDec = Convert.ToString(this.BaseToDecimal(number, 16));
                    return this.DecimalToBase(Int32.Parse(hexToDec), 2);
                }
                else if (to.Equals("Oct")) //to octal
                {
                    String hexToDec = Convert.ToString(this.BaseToDecimal(number, 16));
                    return this.DecimalToBase(Int32.Parse(hexToDec), 8);
                }
            }
            return "--";
        }
        
        //This function takes two arguments; the decimal value to be converted 
        //and the base value (2, 8, or 16) to which the number is converted to:
        string DecimalToBase(int iDec, int numbase)
        {
            string strBin = "";
            int[] result = new int[32];
            int MaxBit = 32;
            for (; iDec > 0; iDec /= numbase)
            {
                int rem = iDec % numbase;
                result[--MaxBit] = rem;
            }
            for (int i = 0; i < result.Length; i++)
                if ((int)result.GetValue(i) >= base10)
                    strBin += cHexa[(int)result.GetValue(i) % base10];
                else
                    strBin += result.GetValue(i);
            strBin = strBin.TrimStart(new char[] { '0' });
            return strBin;
        }
        
        //This function takes two arguments; a string value representing the binary, octal, or hexadecimal value 
        //and the corresponding integer base value respective to the first argument
        int BaseToDecimal(string sBase, int numbase)
        {
            int dec = 0;
            int b;
            int iProduct = 1;
            string sHexa = "";
            if (numbase > base10)
                for (int i = 0; i < cHexa.Length; i++)
                    sHexa += cHexa.GetValue(i).ToString();
            for (int i = sBase.Length - 1; i >= 0; i--, iProduct *= numbase)
            {
                string sValue = sBase[i].ToString();
                if (sValue.IndexOfAny(cHexa) >= 0)
                    b = iHexaNumeric[sHexa.IndexOf(sBase[i])];
                else
                    b = (int)sBase[i] - asciiDiff;
                dec += (b * iProduct);
            }
            return dec;
        }
    }
}
