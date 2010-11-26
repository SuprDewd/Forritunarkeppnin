using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FK_Beta_2010
{
    class Verk15
    {
        static void Main(string[] args)
        {
            Console.Write("Strengur sem leita á í: ");
            string s = Console.ReadLine();
            Console.Write("Strengur sem leita á að: ");
            string l = Console.ReadLine();

            if (s.Contains(l))
            {
                Console.WriteLine("Textinn " + l + " er í strengnum " + s);
            }
            else
            {
                Console.WriteLine("Textinn " + l + " er ekki í strengnum " + s);
            }
            Console.ReadLine();
        }
    }
}
