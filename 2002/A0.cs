using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Keppnin_2002
{
    class A01
    {
        static void Main()
        {
            Console.Write("Fyrri talan? ");
            double tala1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Síðari talan? ");
            double tala2 = Convert.ToDouble(Console.ReadLine());
            double medaltal = (tala1 + tala2) / 2;
            Console.WriteLine("Meðaltal talnanna er: "+medaltal);
            Console.ReadLine();
        }
    }
}
