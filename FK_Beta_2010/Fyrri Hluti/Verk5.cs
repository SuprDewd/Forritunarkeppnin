using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FK_Beta_2010
{
    class Verk5
    {
        static void Main(string[] args)
        {
            Console.Write("Hver er talan? ");
            int tala = Int32.Parse(Console.ReadLine());

            string mal = TalaIMal(tala, false).ToLower().Trim();
            while (mal.Contains("  "))
            {
                mal = mal.Replace("  ", " ");
            }
            Console.WriteLine(mal);
            Console.ReadLine();
        }

        static string[] malEiningar = new string[] { "núll", "einn", "tveir", "þrír", "fjórir", "fimm", "sex", "sjö", "átta", "níu", "tíu", "ellefu", "tólf", "þrettán", "fjórtán", "fimmtán", "sekstán", "sautján", "átján", "nítján" };
        static string[] malTugir = new string[] { "", "tíu", "tuttugu", "þrjátíu", "fjörtíu", "fimmtíu", "sextíu", "sjötíu", "áttatíu", "nítíu", "hundrað" };
        static string[] malHundrud = new string[] { "", "eitt", "tvö", "þrjú", "fjögur", "fimm", "sex", "sjö", "átta", "níu", "hundruð" };

        static string TalaIMal(int tala, bool h)
        {
            int tugir, ein, hundrud, afg;
            if ((tala >= 0 && tala <= 19 && !h) || (tala >= 0 && tala <= 9 && h))
            {
                return h ? malHundrud[tala] : malEiningar[tala];
            }

            if (tala < 100)
            {
                tugir = tala / 10;
                ein = tala - (tugir * 10);

                if (ein == 0)
                {
                    return malTugir[tugir];
                }
                else
                {
                    return malTugir[tugir] + " og " + malEiningar[ein];
                }
            }

            hundrud = tala / 100;
            afg = tala % 100;
            tugir = afg / 10;
            ein = afg % 10;

            string hu = hundrud == 1 ? TalaIMal(hundrud, true) + " hundrað " : TalaIMal(hundrud, true) + " hundruð ";

            if (tugir == 0 && ein == 0)
            {
                return hu;
            }

            if (tugir <= 1)
            {
                return hu + " og " + malEiningar[ein + (tugir * 10)];
            }

            return hu + TalaIMal(ein+(tugir*10), false);
        }
    }
}
