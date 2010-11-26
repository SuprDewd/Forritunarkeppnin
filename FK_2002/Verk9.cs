using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuprLibrary;

namespace FK_2002
{
    class Verk9
    {
        static void Main(string[] args)
        {
            int[] fylki = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 6, 12, 13, 14, 15 };
            Console.WriteLine("Endurtekning: "+Fravik(fylki));
            Console.ReadLine();
        }

        static int Fravik(int[] a)
        {
            Dictionary<int, int> t = new Dictionary<int, int>();
            foreach (int n in a)
            {
                t.AddIfNotContainsKey(n, 1, 1);
            }

            return (from n in t
                   where n.Value != 1
                   select n).ToArray()[0].Key;
        }
    }
}
