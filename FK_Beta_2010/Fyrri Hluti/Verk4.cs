using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FK_Beta_2010
{
    class Verk4
    {
        static void Main(string[] args)
        {
            Console.Write("Fyrsta tala? ");
            int f = Int32.Parse(Console.ReadLine());
            Console.Write("Síðasta tala? ");
            int s = Int32.Parse(Console.ReadLine());
            Console.Write("Veldi? ");
            int v = Int32.Parse(Console.ReadLine());

            int summa = 0;

            for (int i = f; i <= s; i++)
            {
                summa += (int)Math.Pow(i, v);
            }

            Console.WriteLine("Niðurstaða: "+summa);
            Console.ReadLine();
        }
    }
}
