using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK_2002
{
    class Verk1
    {
        static void Main(string[] args)
        {
            Console.Write("Fyrri talan? ");
            double ft = Double.Parse(Console.ReadLine());
            Console.Write("Síðari talan? ");
            double st = Double.Parse(Console.ReadLine());

            Console.WriteLine("Meðaltal talnanna er: "+(ft+st)/2);
            Console.ReadLine();
        }
    }
}
