using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK
{
    class Verk10B
    {
        static void Main(string[] args)
        {
            Console.Write("Tala: ");
            int t = Int32.Parse(Console.ReadLine());

            int fimmtiu = t / 50;
            int afg = t % 50;

            int tiu = afg / 10;
            afg = afg % 10;

            int einn = afg;

            Console.WriteLine();
            for (int i = 0; i < einn; i++)
            {
                Console.Write("*");
            }

            for (int i = 0; i < tiu; i++)
            {
                Console.Write("X");
            }

            for (int i = 0; i < fimmtiu; i++)
            {
                Console.Write("C");
            }

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
