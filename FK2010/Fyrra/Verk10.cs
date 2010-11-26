using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK
{
    class Verk10
    {
        static void Main(string[] args)
        {
            Console.Write("Fyrsta tala? ");
            int f = Int32.Parse(Console.ReadLine());
            Console.Write("Síðasta tala? ");
            int s = Int32.Parse(Console.ReadLine());
            Console.Write("Veldi ");
            int v = Int32.Parse(Console.ReadLine());

            double heild = 0;
            for (int i = f; i <= s; i++)
            {
                heild += Math.Pow(i, v);
            }
            Console.WriteLine("Niðurstaða: " + heild);
            Console.ReadLine();
        }
    }
}
