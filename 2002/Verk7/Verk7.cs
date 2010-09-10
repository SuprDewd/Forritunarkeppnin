using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuprLibrary;

namespace FK_2002
{
    class Verk7
    {
        static void Main(string[] args)
        {
            Console.Write("A: ");
            int a = Int32.Parse(Console.ReadLine());
            Console.Write("B: ");
            int b = Int32.Parse(Console.ReadLine());

            Console.WriteLine(Stæ.StaerstiSameiginlegiDeilir(a, b));
            Console.ReadLine();
        }
    }
}
