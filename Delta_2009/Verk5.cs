using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta_2009
{
    class Verk5
    {
        static void Main(string[] args)
        {
            Console.Write("Breytunafn: ");
            string breyta = Console.ReadLine();
            if (BreytuNafn(breyta))
            {
                Console.WriteLine("Löglegt Breytunafn.");
            }
            else
            {
                Console.WriteLine("Ekki Löglegt Breytunafn.");
            }
            Console.ReadLine();
        }

        static public bool BreytuNafn(string breyta)
        {
            if (breyta[0] >= '0' && breyta[0] <= '9')
            {
                return false;
            }
            else
            {
                bool afram = true;
                for (int i = 0; i < breyta.Length; i++)
                {
                    if (!((breyta[i] >= 'A' && breyta[i] <= 'Z') || (breyta[i] >= 'a' && breyta[i] <= 'z') || breyta[i] == '$' || breyta[i] == '_' || (breyta[i] >= '0' && breyta[i] <= '9')))
                    {
                        afram = false;
                    }
                }
                return afram;
            }
        }
    }
}
