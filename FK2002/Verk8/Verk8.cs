using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK_2002
{
    class Verk8
    {
        static void Main(string[] args)
        {
            int[] t = new int[10];
            for (int i = 0; i < t.Length; i++)
            {
                Console.Write("Tala "+(i+1)+": ");
                t[i] = Int32.Parse(Console.ReadLine());
            }

            t = (from n in t
                orderby n ascending
                select n).ToArray();

            foreach (int tala in t)
            {
                Console.WriteLine(tala);
            }
            Console.ReadLine();
        }
    }
}
