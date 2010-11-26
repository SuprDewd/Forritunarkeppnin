using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK_2002
{
    class Verk2
    {
        static void Main(string[] args)
        {
            Console.Write("Sentimetrar: ");
            double sm = Double.Parse(Console.ReadLine());

            Console.WriteLine("Tommur: "+(sm/2.54));
            Console.ReadLine();
        }
    }
}
