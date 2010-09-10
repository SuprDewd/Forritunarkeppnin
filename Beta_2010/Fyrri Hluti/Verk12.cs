using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FK_Beta_2010
{
    class Verk12
    {
        static void Main(string[] args)
        {
            Console.Write("Línufjöldi: ");
            int linur = Int32.Parse(Console.ReadLine());
            Console.Write("Dálkafjöldi: ");
            int dalkar = Int32.Parse(Console.ReadLine());

            linur++;
            dalkar++;
            List<string> xLina = new List<string>();
            List<string> mLina = new List<string>();

            for (int i = 0; i < dalkar; i++)
            {
                xLina.Add("x");
                mLina.Add("|");
            }

            string sxLina = String.Join("--", xLina);
            string smLina = String.Join("  ", mLina);

            for (int i = 0; i < linur-1; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine(sxLina);
                }
                Console.WriteLine(smLina);
                Console.WriteLine(sxLina);
            }

            Console.ReadLine();
        }
    }
}
