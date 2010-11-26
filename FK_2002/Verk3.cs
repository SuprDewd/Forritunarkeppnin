using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK_2002
{
    class Verk3
    {
        static void Main(string[] args)
        {
            Console.Write("Fyrri talan? ");
            double ft = Double.Parse(Console.ReadLine());
            Console.Write("Seinni talan? ");
            double st = Double.Parse(Console.ReadLine());

            if (ft < st)
            {
                Console.WriteLine("Lægri talan: " + ft);
                Console.WriteLine("Hærri talan: " + st);
            }
            else if (st < ft)
            {
                Console.WriteLine("Lægri talan: " + st);
                Console.WriteLine("Hærri talan: " + ft);
            }
            else
            {
                Console.WriteLine("Tölurnar eru jafnar: "+ft);
            }

            Console.ReadLine();
        }
    }
}
