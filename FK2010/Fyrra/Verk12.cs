using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FK
{
    class Verk12
    {
        static Dictionary<int, string> tolur = new Dictionary<int, string>();
        static Dictionary<int, string> hTolur = new Dictionary<int, string>();

        static void Main()
        {
            tolur[0] = "Núll";
            tolur[1] = "Einn";
            tolur[2] = "Tveir";
            tolur[3] = "Þrír";
            tolur[4] = "Fjórir";
            tolur[5] = "Fimm";
            tolur[6] = "Sex";
            tolur[7] = "Sjö";
            tolur[8] = "Átta";
            tolur[9] = "Níu";
            tolur[10] = "Tíu";
            tolur[11] = "Ellefu";
            tolur[12] = "Tólf";
            tolur[13] = "Þrettán";
            tolur[14] = "Fjórtán";
            tolur[15] = "Fimmtán";
            tolur[16] = "Sextán";
            tolur[17] = "Sautján";
            tolur[18] = "Átján";
            tolur[19] = "Nítján";
            tolur[20] = "Tuttugu";
            tolur[30] = "Þrjátíu";
            tolur[40] = "Fjörtíu";
            tolur[50] = "Fimmtíu";
            tolur[60] = "Sextíu";
            tolur[70] = "Sjötíu";
            tolur[80] = "Áttatíu";
            tolur[90] = "Nítíu";
            tolur[100] = "Hundrað";

            hTolur[1] = "Eitt";
            hTolur[2] = "Tvö";
            hTolur[3] = "Þrjú";
            hTolur[4] = "Fjögur";
            hTolur[5] = "Fimm";
            hTolur[6] = "Sex";
            hTolur[7] = "Sjö";
            hTolur[8] = "Átta";
            hTolur[9] = "Níu";

            int tala;

            while (true)
            {
                Console.Clear();
                Console.Write("Hver er talan? ");
                tala = Int32.Parse(Console.ReadLine());
                string f = "";
                if (tala < 0)
                {
                    tala = tala * -1;
                    f = "Mínus ";
                }
                string ut = breytaIOrd(tala);
                while (ut.Contains("  "))
                {
                    ut = ut.Replace("  ", " ");
                }
                Console.WriteLine((f + ut).ToLower());
                Console.ReadLine();
            }
        }

        static string breytaIOrd(int tala)
        {
            if (tala == 0) return "Núll";
            if (tala < 100) return minnaEnHundrad(tala, false);

            int hundrud = tala / 100;
            int afg = tala % 100;

            string h = hundrud == 1 ? " hundrað " : " hundruð ";
            if (afg > 0)
            {
                return minnaEnHundrad(hundrud, true) + h + " " + minnaEnHundrad(afg, false);
            }
            else
            {
                return minnaEnHundrad(hundrud, true) + h;
            }
        }

        static string minnaEnHundrad(int tala, bool t)
        {
            if (tala >= 10 && tala <= 19)
            {
                return tolur[tala];
            }
            if (tala < 10 && !t)
            {
                return tolur[tala];
            }
            else if (tala < 10 && t)
            {
                return hTolur[tala];
            }
            else
            {
                int tugur = tala / 10;
                int auka = tala % 10;
                if (auka > 0)
                {
                    return minnaEnHundrad(tugur * 10, false) + " og " + minnaEnHundrad(tala - (tugur * 10), false);
                }
                else
                {
                    return tolur[tugur * 10];
                }
            }
        }
    }
}