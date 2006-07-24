using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace MyPocketCal2003
{
    //class to hold a Quantity name,base unit, conversion ratios
    class QuantityNode
    {
        String _name; //quantity name
        String _baseUnit; //quantity baseunit
        Hashtable _conversionRatios; //conversion ratios key=unitname value=ratio
        
        public QuantityNode()
        {
            _conversionRatios = new Hashtable();
        }
        public void addTo(XmlDocument doc)
        {
            XmlElement quantityElement = doc.CreateElement("Quantity");
            
            //Quantity Name
            XmlElement element = doc.CreateElement("Name");
            element.InnerText = _name;
            quantityElement.AppendChild(element);
            
            //BaseUnit
            element = doc.CreateElement("BaseUnit");
            element.InnerText = _baseUnit;
            quantityElement.AppendChild(element);

            //Units Element
            XmlElement unitsElement = doc.CreateElement("Units");

            //Conversion Ratios Nodes
            foreach (String unit in _conversionRatios.Keys) //for each unit value stored as key
            {
                //get the ratio=value against each unit=key
                String ratio = (String)_conversionRatios[unit];
                
                //conversion
                XmlElement conversionElement = doc.CreateElement("Conversion");
                
                //tounit
                element = doc.CreateElement("ToUnit");
                element.InnerText = unit;
                conversionElement.AppendChild(element); //append to conversion element

                //ratio
                element = doc.CreateElement("Ratio");
                element.InnerText = ratio;
                conversionElement.AppendChild(element); //append to conversion element

                //append conversion to quantity
                quantityElement.AppendChild(conversionElement);

                //append each unit element to units element which is append to the
                //quantity node after the loop
                element = doc.CreateElement("Unit");
                element.InnerText = unit;
                unitsElement.AppendChild(element);
            }
            
            //Appending Units to quantity node
            quantityElement.AppendChild(unitsElement);

            XmlNode root = doc.DocumentElement;
            root.AppendChild(quantityElement);
            Assembly thisAssembly = Assembly.GetExecutingAssembly();
            doc.Save(thisAssembly.GetManifestResourceStream("MyPocketCal2003.QuantitiesUnits.xml"));
            //XmlTextWriter xmlWriter = new XmlTextWriter(thisAssembly.GetManifestResourceStream("MyPocketCal2003.QuantitiesUnits.xml"),null);
            //doc.Save(xmlWriter);
            
        }
        //getter & setter for _name
        public String name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        //getter & setter for _baseUnit
        public String baseUnit
        {
            get
            {
                return _baseUnit;
            }
            set
            {
                _baseUnit = value;
            }
        }
        public Hashtable conversionRatios
        {
            get
            {
                return _conversionRatios;
            }
            set
            {
                _conversionRatios = value;
            }
        }
    }
}
