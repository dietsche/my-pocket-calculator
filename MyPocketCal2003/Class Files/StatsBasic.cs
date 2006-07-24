using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace MyPocketCal2003
{
    class StatsBasic
    {
        private ArrayList data;
        public StatsBasic(ArrayList data)
        {
            this.data = data;
            this.sort(); //sort the data
        }
        //return minimum value
        public String getMin() 
        {
            return (String)data[0]; //minimum element
        }
        public String getMax()
        {
            return (String)data[data.Count-1]; //maximum element
        }
        //return median
        public String getMedian() 
        {
            if (data.Count % 2 == 0) //even number of values
            {
                int midPoint = (data.Count / 2)-1;
                //calculating median & returning
                return Convert.ToString((Convert.ToDouble(data[midPoint]) + Convert.ToDouble(data[midPoint + 1])) / 2.0);
            }
            else if (data.Count % 2 != 0) //odd number of values
            {
                int midPoint = (data.Count / 2);
                //calculating median & returning
                return Convert.ToString(data[midPoint]);
            }
            return "";
        }
        //return range
        public String getRange()
        {
            //calculating range & returning
            return Convert.ToString(Convert.ToDouble(data[data.Count - 1]) - Convert.ToDouble(data[0]));
        }
        //return mode
        public String getMode()
        {
            // to store the # of occurences of a value
            Hashtable countTable = new Hashtable();

            for (int i = 0; i < data.Count; ++i)
            {
                String value = Convert.ToString(data[i]);
                // if value alread increment the count
                if (countTable.ContainsKey(value)) 
                {
                    countTable[value] = (int)countTable[value] + 1; //increment occurence by 1
                }
                else //otherwise start the count as 1
                {
                    countTable[value] = 1;
                }
            }

            String[] keys = new String[countTable.Count]; //to store keys
            int[] values = new int[countTable.Count]; //to store corresponding values

            int k = 0;
            foreach(String key in countTable.Keys) //populating array with keys (numbers)
            {
                keys[k] = key;
                ++k;
            }
            k = 0;
            foreach (int value in countTable.Values) //populating an array with values (# of occurence)
            {
                values[k] = value;
                ++k;
            }

            //we need to sort the keys based on the # of occurence i.e. stored in their values:
            Array.Sort(values, keys);

            String mode = "";
            //the greatest number of occurence of any number is 1
            if (values[countTable.Count-1] == 1) 
            {
                return "No Mode Found";
            }

            bool sameOccurence = true;
            //if all numbers occurence is the same
            for (k = 0; k < countTable.Count-1; ++k) 
            {
                if (values[k] == values[k+1])
                {
                    sameOccurence = true;
                }
                else
                {
                    sameOccurence = false;
                    break;
                }
            }

            if (sameOccurence == true)
                return "No Mode Found";

            //Atleast 1 mode exist
            
            for (k = countTable.Count-1; k > 0; --k)
            {
                mode += keys[k];
                if (values[k] == values[k - 1]) //if more mode exist then continue the loop and add the mode
                {
                    mode += ", ";
                    continue;
                }
                else
                    break;
            }
            
            return mode;
        }
        //return AM
        public String getAM() 
        {
            double sum = 0.0;
            for(int i=0; i<data.Count; ++i)
            {
                double num = Convert.ToDouble(data[i]); 
                sum += num; //summing up values
            }
            return Convert.ToString(sum/Convert.ToDouble(data.Count)); //calculating mean & returning
        }
        //return Variance
        public String getVar()
        {
            //sqauring SD & returning
            return Convert.ToString(Math.Pow(Double.Parse(getSD()), 2));
        }
        //return SD
        public String getSD()
        {
            double mean = Double.Parse(getAM());
            double devSum = 0.0;
            for (int i = 0; i < data.Count; ++i)
            {
                double num = Convert.ToDouble(data[i]);
                devSum += Math.Pow((num - mean),2); //summing up squared deviation
            }
            //calculating SD
            devSum = Math.Pow((devSum / Convert.ToDouble(data.Count - 1)),0.5);
            //returning SD
            return Convert.ToString(devSum);
        }
        //return GM
        public String getGM() 
        {
            double product = 1.0;
            for (int i = 0; i < data.Count; ++i)
            {
                double num = Convert.ToDouble(data[i]);
                product *= num; //product of value
            }
            return Convert.ToString(Math.Pow(product,(1.0/data.Count))); //calculating GM & returning
        }
        //return HM
        public String getHM()
        {
            double reciSum = 0.0; //for storing values reciprocal sum
            for (int i = 0; i < data.Count; ++i)
            {
                double num = Convert.ToDouble(data[i]);
                reciSum += (1.0/num); //summing up values reciprocal
            }
            return Convert.ToString(Convert.ToDouble(data.Count)/reciSum) ; //calculating mean & returning
        }
        public void sort()
        {
            NumberComparison numComp = new NumberComparison();
            data.Sort(numComp);
        }
        
        //an interface implemented for the ArrayList sort function
        public class NumberComparison : IComparer
        {
            public int Compare(Object x, Object y)
            {
                if(Double.Parse(x.ToString()) < Double.Parse(y.ToString())) //x < y
                    return -1;
                else if(Double.Parse(x.ToString()) > Double.Parse(y.ToString())) //x > y
                    return 1;

                return 0; //x == y
            }
        }
    }
}
