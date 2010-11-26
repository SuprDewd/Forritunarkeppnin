using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK_Alfa_2010
{
    class Verk1
    {
        static void Main(string[] args)
        {
            Console.Write("Hver er talan? ");
            int tala = Int32.Parse(Console.ReadLine());

            int hundrud = tala / 100;
            int afg = tala % 100;
            int tug = afg / 10;
            int ein = afg % 10;

            string h = "hundruð";

            if (hundrud == 1)
            {
                h = "hundrað";
            }

            if (hundrud == 0)
            {
                Console.WriteLine(MinnaEnHundrad(afg, false));
            }
            else
            {
                string milli = " ";
                if ((tug == 0 && ein != 0) || (tug != 0 && ein == 0))
                {
                    milli = " og ";
                }

                if (ein > 0 || tug > 0)
                {
                    Console.WriteLine(MinnaEnHundrad(hundrud, true) + " " + h + milli + MinnaEnHundrad(afg, false));
                }
                else
                {
                    Console.WriteLine(MinnaEnHundrad(hundrud, true) + " " + h);
                }
            }

            Console.ReadLine();
        }

        static string MinnaEnHundrad(int tala, bool h)
        {
            string[] tolurh = new string[] { "", "eitt", "tvö", "þrjú", "fjögur", "fimm", "sex", "sjö", "átta", "níu" };
            if (h && tala <= 9)
            {
                return tolurh[tala];
            }

            string[] tolur = new string[] { "núll", "einn", "tveir", "þrír", "fjórir", "fimm", "sex", "sjö", "átta", "níu", "tíu", "ellefu", "tólf", "þrettán", "fjórtán", "fimmtán", "sextán", "sautján", "átján", "nítján" };
            string[] tugir = new string[] { "", "tíu", "tuttugu", "þrjátíu", "fjörtíu", "fimmtíu", "sextíu", "sjötíu", "áttatíu", "nítíu" };
            if (tala < 20)
            {
                return tolur[tala];
            }

            int ttugir = tala / 10;
            int einingar = tala % 10;

            if (einingar == 0)
            {
                return tugir[ttugir];
            }
            else
            {
                return tugir[ttugir]+" og "+tolur[einingar];
            }
        }
    }
}
