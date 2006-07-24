using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace MyPocketCal2003
{
    class StatsAdvance
    {
        ArrayList x;
        ArrayList y;
        public StatsAdvance(ArrayList x, ArrayList y)
        {
            this.x = x;
            this.y = y;
        }
        public String linearFit()
        {
            double b = ssxy() / ssxx();
            Math.Round(b, 4);
            
            StatsBasic statBasic = new StatsBasic(this.x);
            String xMean = statBasic.getAM();
            
            statBasic = new StatsBasic(this.y);
            String yMean = statBasic.getAM();

            double a = Double.Parse(yMean) - ((b)*(Double.Parse(xMean)));
            Math.Round(a, 4);

            if(b<0)
                return "y = " + a + "" + b + "x";
            
            return "y = " + a + "+" + b + "x";
        }
        public double ssxy()
        {
            double sumXY = 0.0; //to store sum of summation xy
            double sumX = 0.0; //to store sum of summation x
            double sumY = 0.0; //to store sum of summation y
            for (int i = 0; i < x.Count; ++i)
            {
                double xValue = Convert.ToDouble(x[i]);
                double yValue = Convert.ToDouble(y[i]);
                sumXY += (xValue * yValue ); //Exy
                sumX += xValue; //Ex
                sumY += yValue; //Ey
            }

            return (sumXY - ((sumX * sumY) / x.Count)); //Exy - (Ex)(Ey)/n
        }
        public double ssxx()
        {
            double sumX = 0.0; //to store sum of summation x
            double sumXSquare = 0.0; //to store sum of summation x square

            for (int i = 0; i < x.Count; ++i)
            {
                double xValue = Convert.ToDouble(x[i]);
                sumX += xValue; //Ex
                sumXSquare += (xValue*xValue); //Ex^2
            }

            return (sumXSquare - ((sumX) * (sumX)) / x.Count); 
        }
        public double ssyy()
        {
            double sumX = 0.0; //to store sum of summation x
            double sumXSquare = 0.0; //to store sum of summation x square

            for (int i = 0; i < y.Count; ++i)
            {
                double yValue = Convert.ToDouble(y[i]);
                sumX += yValue; //Ex
                sumXSquare += (yValue * yValue); //Ex^2
            }

            return (sumXSquare - ((sumX) * (sumX)) / y.Count); 
        }
        public String correlationCoeff()
        {
            double ssxxssyy = ssxx() * ssyy();
            return Convert.ToString(Math.Round(ssxy() / (Math.Pow(ssxxssyy, 0.5)),2));
        }
        public String coeffDetermination()
        {
            double correlation = Double.Parse(correlationCoeff());
            return Convert.ToString(correlation * correlation);
        }
    }
}
