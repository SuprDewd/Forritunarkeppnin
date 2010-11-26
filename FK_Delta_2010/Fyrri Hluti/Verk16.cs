using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FK_Delta_2010
{
    class Verk16
    {
        static void Main()
        {
            Dictionary<int, int> tolur = new Dictionary<int, int>();
            int tala = 0;
            Console.WriteLine("Sláðu inn talnaröð -1 til að hætta:");
            do
            {
                Console.Write("Tala: ");
                tala = Int32.Parse(Console.ReadLine());
                if (tala != -1)
                {
                    if (tolur.ContainsKey(tala))
                    {
                        tolur[tala]++;
                    }
                    else
                    {
                        tolur.Add(tala, 1);
                    }
                }
            } while (tala != -1);

            int lengst = 0;
            foreach (KeyValuePair<int, int> t in tolur)
            {
                if (t.Value > lengst)
                {
                    lengst = t.Value;
                }
            }
            Console.WriteLine("Lengsta endurtekning: " + lengst);
            Console.ReadLine();
        }
    }
}