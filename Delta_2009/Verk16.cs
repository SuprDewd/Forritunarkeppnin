using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Delta_2009
{
    class Verk16
    {
        static void Main(string[] args)
        {
            double e = 2;

            for (int i = 2; i < 10; i++)
            {
                e += 1 / Upphropun(i);
            }

            Console.WriteLine(e);
            Console.ReadLine();
        }

        static double Upphropun(double t)
        {
            double heild = t;
            for (double i = t-1; i > 0; i--)
            {
                heild *= i;
            }
            return heild;
        }
    }
}