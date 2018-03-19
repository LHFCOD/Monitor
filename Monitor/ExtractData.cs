
using Accord.Statistics.Distributions.Univariate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Monitor
{
    class ExtractData
    {
     public   double GetData(double a,double b)
        {
            //double c = (a + b) / 2;
            //var Uniform = new NormalDistribution(c, 1);
            //double result=Uniform.Generate();
            double c = (a + b) / 2;
            double d = (a - b) / 2;
            double result = (rand.NextDouble() - 0.5) *2*d+c;
            return result;
        }
       public double GetData(DateTime date)
        {
            double result = (rand.NextDouble() - 0.5) * 10;
            return result;
        }
        Random rand = new Random((int)DateTime.Now.Ticks);
       
    }
}
