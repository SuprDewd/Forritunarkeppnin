using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK_Alfa_2010
{
    class Verk7
    {
        static void Main(string[] args)
        {
            Console.Write("Strengur sem leita á í: ");
            string txt = Console.ReadLine();
            Console.Write("Strengur sem leita á að: ");
            string leita = Console.ReadLine();

            if (Finna(leita, txt, 0))
            {
                Console.WriteLine("Textinn " + leita + " er í strengnum " + txt);
            }
            else
            {
                Console.WriteLine("Textinn " + leita + " er ekki í strengnum " + txt);
            }
            Console.ReadLine();
        }

        static bool Finna(string l, string t, int i)
        {
            if (l == "" || l == t) return true;

            if (i + l.Length > t.Length) return false;

            string nTxt = t.Substring(i, l.Length);

            if (nTxt == l) return true;

            return Finna(l, t, i+1);
        }
    }
}
