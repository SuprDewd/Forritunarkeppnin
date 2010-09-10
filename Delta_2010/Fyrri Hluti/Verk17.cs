using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FK_Delta_2010
{
    class Verk17
    {
        static void Main()
        {
            Console.Write("Línufjöldi: ");
            int l = Int32.Parse(Console.ReadLine()) + 1;
            Console.Write("Dálkafjöldi: ");
            int d = Int32.Parse(Console.ReadLine()) + 1;

            List<string> x = new List<string>();
            List<string> m = new List<string>();
            for (int j = 0; j < d; j++)
            {
                x.Add("x");
                m.Add("|");
            }
            string sX = String.Join("--", x.ToArray());
            string sM = String.Join("  ", m.ToArray());

            for (int i = 0; i < l; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine(sX);
                }
                else
                {
                    Console.WriteLine(sM);
                    Console.WriteLine(sX);
                }
            }
            Console.ReadLine();
        }
    }
}