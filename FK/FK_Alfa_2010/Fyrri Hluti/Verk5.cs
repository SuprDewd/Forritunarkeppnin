using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK_Akfa_2010
{
    class Verk7
    {
        static void Main(string[] args)
        {
            Console.Write("Strengur sem leira á í: ");
            string txt = Console.ReadLine();
            Console.Write("Strengur sem leita á að: ");
            string txt2 = Console.ReadLine();

            if (Finna(txt2, txt, 0))
            {
                Console.WriteLine("Textinn " + txt2 + " er í strengnum " + txt);
            }
            else
            {
                Console.WriteLine("Textinn " + txt2 + " er ekki í strengnum " + txt);
            }

            Console.ReadLine();
        }

        static bool Finna(string txt, string txt2, int i)
        {
            if (txt == "") return true;

            if (txt.Length <= i || txt2.Substring(i).Length < txt.Length) return false;

            if (txt2.Substring(i, i + txt.Length) == txt) return true;

            return Finna(txt, txt2, i++);
        }
    }
}
