using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace MyPocketCal2003
{
    class UnitConversion
    {
        public String convert(String input, String quantityName, String inputUnit, String outputUnit, XmlDocument docXmlFile)
        {
            if(inputUnit.Equals(outputUnit)) //if same unit conversion
                return Convert.ToString(input);

            //get the respective quantity node
            XmlNode quantityNode = docXmlFile.SelectSingleNode("/Quantities/Quantity[Name='" + quantityName + "']");
   
            //get the first conversion node in the quantity
            XmlNode node = quantityNode.SelectSingleNode("Conversion[1]");

            //the first conversion node always hold the base unit to which we can convert from 
            //any other unit because the XML file has been designed such
            String baseUnit = node.FirstChild.InnerText;
            
            //inputUnit -> baseUnit -> outputUnit:

            //converting from inputUnit to baseUnit....baseUnit act as intermediary
            XmlNode conversionNode;
            double inputToBaseRatio = 1.0;

            if (!inputUnit.Equals(baseUnit)) //there is no ratio available for going from A unit to A unit i.e. inputUnit=baseUnit
            {
                conversionNode = quantityNode.SelectSingleNode("Conversion[FromUnit='" + inputUnit + "' and ToUnit='" + baseUnit + "']");
                inputToBaseRatio = Convert.ToDouble(conversionNode.LastChild.InnerText); //inputUnit to baseUnit conversion ratio
            }

            double baseToOutputRatio = 1.0;

            if (!outputUnit.Equals(baseUnit)) //there is no ratio available for going from A unit to A unit i.e. baseUnit=outputUnit
            {
                //converting from baseUnit (intermediary) to outputUnit
                conversionNode = quantityNode.SelectSingleNode("Conversion[FromUnit='" + baseUnit + "' and ToUnit='" + outputUnit + "']");
                baseToOutputRatio = Convert.ToDouble(conversionNode.LastChild.InnerText); //baseUnit to outputUnit conversion ratio
            }

            //converting input to base unit then converting base unit to output unit
            return Convert.ToString((Convert.ToDouble(input)*inputToBaseRatio)*baseToOutputRatio);
        }
    }
}
