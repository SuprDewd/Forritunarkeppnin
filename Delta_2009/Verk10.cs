using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta_2009
{
    class Verk10
    {
        static void Main(string[] args)
        {
            double[] einkunnir = new double[10];

            for (int i = 0; i < einkunnir.Length; i++)
            {
                Console.Write("Einkunn "+(i+1)+": ");
                einkunnir[i] = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine("\nSpónninn er "+(einkunnir.Max() - einkunnir.Min()));
            Console.ReadLine();
        }
    }
}
