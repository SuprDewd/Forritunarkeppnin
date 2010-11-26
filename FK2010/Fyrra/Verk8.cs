using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK
{
    class Verk8
    {
        static void Main(string[] args)
        {
            string[] manudur = new string[] { "gormánuður", "ýlir", "mörsugur", "þorri", "góa", "einmánuður",
            "harpa", "skerpla", "sólmánuður", "heyannir", "tvímánuður", "haustmánuður"};

            Console.Write("Heiti mánaðar? ");
            string m = Console.ReadLine().ToLower();

            int nm = 0;
            bool til = false;
            for (int i = 0; i < manudur.Length; i++)
            {
                if (m == manudur[i])
                {
                    til = true;
                    nm = i;
                }
            }

            if (til)
            {
                int b = (nm - 1 < 0) ? manudur.Length - 1 : nm - 1;
                int f = (nm + 1 > manudur.Length - 1) ? 0 : nm + 1;
                Console.WriteLine("Á undan þessum mánuði kemur " + manudur[b] + " en á eftir honum kemur " + manudur[f] + ".");
            }
            else
            {
                Console.WriteLine("Þessi mánuður er ekki til skv. norrænu tímabili");
            }
            Console.ReadLine();
        }
    }
}
