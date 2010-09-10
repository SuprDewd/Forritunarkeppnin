using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Keppnin_2002
{
    class A03
    {
        static void Main()
        {
            Console.Write("Tala 1: ");
            double t1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Tala 2: ");
            double t2 = Convert.ToDouble(Console.ReadLine());
            if (t1 == t2)
            {
                Console.WriteLine("Tölurnar eru jafnar: "+t1);
            }
            else if (t1 > t2)
            {
                Console.WriteLine("Lægri talan er: " + t2);
                Console.WriteLine("Hærri talan er: " + t1);
            }
            else if (t1 < t2)
            {
                Console.WriteLine("Lægri talan er: " + t1);
                Console.WriteLine("Hærri talan er: " + t2);
            }
            else
            {
                Console.WriteLine("Villa.");
            }
            Console.ReadLine();
        }
    }
}
