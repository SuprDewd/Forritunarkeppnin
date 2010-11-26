using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FK_Beta_2010
{
    class Verk3
    {
        static void Main(string[] args)
        {
            Console.Write("Tala: ");
            int tala = Int32.Parse(Console.ReadLine());
            int c = tala / 50;
            int afg = tala % 50;
            int x = afg / 10;
            int e = afg % 10;

            for (int i = 0; i < e; i++)
            {
                Console.Write("*");
            }
            for (int i = 0; i < x; i++)
            {
                Console.Write("X");
            }
            for (int i = 0; i < c; i++)
            {
                Console.Write("C");
            }
            Console.ReadLine();
        }
    }
}
