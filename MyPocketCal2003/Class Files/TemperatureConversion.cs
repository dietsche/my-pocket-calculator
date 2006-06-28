using System;
using System.Collections.Generic;
using System.Text;

namespace MyPocketCal2003
{
    class TemperatureConversion
    {
        public String convert(String input, String from, String to)
        {
            if (from.Equals(to))
                return input;

            Decimal nine = 9.0M;
            Decimal five = 5.0M;

            if(from.Equals("F"))
            {
                return Convert.ToString((five / nine) * (Convert.ToDecimal(input) - 32));
            }
            else if (from.Equals("C"))
            {
                return Convert.ToString((nine / five) * Convert.ToDecimal(input) + 32);
            }
            return "--";
        }
    }
}
