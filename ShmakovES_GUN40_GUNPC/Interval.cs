using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShmakovES_GUN40_GUNPC
{
    public struct Interval
    {
        public int min;
        public int max;
        public Interval(int minValue, int maxValue)
        {
            if(minValue > maxValue)
            {
                (minValue,maxValue)=(maxValue,minValue);
                Console.WriteLine("Uncorrect value");
            }

            if(maxValue < 0)  
            {
                maxValue = 0;
                Console.WriteLine("Uncorrect value");
            }

            if(minValue < 0)
            {
                minValue = 0;
                Console.WriteLine("Uncorrect value");
            }

            if (maxValue == minValue)
            {
                maxValue += 10;
                Console.WriteLine("Uncorrect value");
            }

        }
        public int Min 
        {
        get
            {
                return min;
            }
        }
        public int Max
        {
            get
            {
                return max;
            }
        }
        public int Get(int Min, int Max)
        {
            var rnd = new Random();
            return rnd.Next(Min,Max);            
        }
    }
}
