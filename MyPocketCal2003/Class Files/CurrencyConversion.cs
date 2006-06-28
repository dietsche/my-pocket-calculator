using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MyPocketCal2003
{
    class CurrencyConversion
    {
        public String convertCurrency(String input, String fromCurrency, String toCurrency)
        {
            //parsing the fromCurrency string to enum object
            CurrencyWebService.Currency from = (CurrencyWebService.Currency)Enum.Parse(typeof(CurrencyWebService.Currency), fromCurrency, false);
            
            //parsing the toCurrency string to enum object
            CurrencyWebService.Currency to = (CurrencyWebService.Currency)Enum.Parse(typeof(CurrencyWebService.Currency), toCurrency, false);

            //create the webservice object
            CurrencyWebService.CurrencyConvertor currencyService = new CurrencyWebService.CurrencyConvertor();

            Decimal rate = 0.0M;

            try
            {
                //get the conversion ratio
                rate = (Decimal)currencyService.ConversionRate(from, to);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message); //connection problem with the network
            }
            return Convert.ToString(Convert.ToDecimal(input)*rate);
        }
    }
}
