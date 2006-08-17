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
            if (input.Length == 0)
                return "";
            if(inputUnit.Equals(outputUnit)) //if same unit conversion
                return Convert.ToString(input) + " " + outputUnit;

            //get the respective quantity node
            XmlNode quantityNode = docXmlFile.SelectSingleNode("/Quantities/Quantity[Name='" + quantityName + "']");
   
            //select the baseUnit node
            XmlNode node = quantityNode.SelectSingleNode("BaseUnit");
            //the name of the baseUnit
            String baseUnit = node.InnerText;
            
            //inputUnit -> baseUnit -> outputUnit:

            //converting from inputUnit to baseUnit....baseUnit act as intermediary
            XmlNode conversionNode;
            double inputToBaseRatio = 1.0;

            //there is no ratio available for going from A unit to A unit i.e. inputUnit=baseUnit otherwise:
            if (!inputUnit.Equals(baseUnit)) 
            {
                //finding the ratio of baseUnit-->inputUnit then getting its inverse to form inputUnit-->baseUnit
                conversionNode = quantityNode.SelectSingleNode("Conversion[ToUnit='" + inputUnit + "']");   
                inputToBaseRatio = 1.0/Convert.ToDouble(conversionNode.LastChild.InnerText); //inputUnit to baseUnit conversion ratio
            }
            
            double baseToOutputRatio = 1.0;

            //there is no ratio available for going from A unit to A unit i.e. baseUnit=outputUnit otherwise:
            if (!outputUnit.Equals(baseUnit)) 
            {
                //converting from baseUnit (intermediary) to outputUnit
                conversionNode = quantityNode.SelectSingleNode("Conversion[ToUnit='" + outputUnit + "']");
                baseToOutputRatio = Convert.ToDouble(conversionNode.LastChild.InnerText); //baseUnit to outputUnit conversion ratio
            }

            //converting input to base unit then converting base unit to output unit
            return Convert.ToString((Convert.ToDouble(input)*inputToBaseRatio)*baseToOutputRatio) + " " + outputUnit;
        }
    }
}

/*public String convert(String input, String quantityName, String inputUnit, String outputUnit, XmlDocument docXmlFile)
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

            //there is no ratio available for going from A unit to A unit i.e. inputUnit=baseUnit
            if (!inputUnit.Equals(baseUnit)) 
            {
                //finding the ratio of baseUnit-->inputUnit then getting its inverse to form inputUnit-->baseUnit
                conversionNode = quantityNode.SelectSingleNode("Conversion[FromUnit='" + baseUnit + "' and ToUnit='" + inputUnit + "']");   
                inputToBaseRatio = 1.0/Convert.ToDouble(conversionNode.LastChild.InnerText); //inputUnit to baseUnit conversion ratio
            }
            
            double baseToOutputRatio = 1.0;

            //there is no ratio available for going from A unit to A unit i.e. baseUnit=outputUnit
            if (!outputUnit.Equals(baseUnit)) 
            {
                //converting from baseUnit (intermediary) to outputUnit
                conversionNode = quantityNode.SelectSingleNode("Conversion[FromUnit='" + baseUnit + "' and ToUnit='" + outputUnit + "']");
                baseToOutputRatio = Convert.ToDouble(conversionNode.LastChild.InnerText); //baseUnit to outputUnit conversion ratio
            }

            //converting input to base unit then converting base unit to output unit
            return Convert.ToString((Convert.ToDouble(input)*inputToBaseRatio)*baseToOutputRatio);
        }
   */