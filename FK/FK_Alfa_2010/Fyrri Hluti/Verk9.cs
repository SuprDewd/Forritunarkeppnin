using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK_Alfa_2010
{
    class Verk9
    {
        static void Main(string[] args)
        {
            Console.Write("Póstnúmer: ");
            string pstn = Console.ReadLine();
            int summa = 0;

            for (int i = 0; i < pstn.Length; i++)
            {
                summa += Int32.Parse(pstn[i].ToString());
            }

            int vartala = 20 - summa;

            Console.WriteLine("Vartalan er " + vartala);
            Console.ReadLine();
        }
    }
}
