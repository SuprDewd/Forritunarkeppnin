using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuprLibrary;

namespace FK2002
{
    class Verk4
    {
        static void Main(string[] args)
        {
            Console.Write("Tala: ");
            double N = Double.Parse(Console.ReadLine());
            Console.Write("Veldi: ");
            int v = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Er: "+Stæ.HefjaIVeldi(N, v));
            Console.ReadLine();
        }
    }
}
