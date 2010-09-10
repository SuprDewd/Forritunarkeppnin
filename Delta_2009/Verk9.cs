using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta_2009
{
    class Verk9
    {
        static void Main(string[] args)
        {
            double[] th1 = new double[2];
            double[] th2 = new double[2];
            Console.WriteLine("Sláðu inn fyrra talnahnappið:");
            Console.Write("Tala 1: ");
            th1[0] = Convert.ToDouble(Console.ReadLine());
            Console.Write("Tala 2: ");
            th1[1] = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nSláðu inn seinna talnahnappið:");
            Console.Write("Tala 1: ");
            th2[0] = Convert.ToDouble(Console.ReadLine());
            Console.Write("Tala 2: ");
            th2[1] = Convert.ToDouble(Console.ReadLine());

            bool afram = true;
            for (int i = 0; i < 2; i++)
            {
                if (!th2.Contains(th1[i]))
                {
                    afram = false;
                }
            }

            Console.WriteLine();

            if (afram)
            {
                Console.WriteLine("Talnapörin innihalda sömu tölur.");
            }
            else
            {
                Console.WriteLine("Talnapörin innihalda ekki sömu tölur.");
            }
            Console.ReadLine();
        }
    }
}
