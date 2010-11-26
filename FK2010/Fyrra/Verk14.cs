using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FK
{
    class Verk14
    {
        static void Main()
        {
            Random rand = new Random();
            double oft = 10000000;
            double hus = 0;

            for (int i = 1; i <= (int)oft; i++)
		    {
                int[] t = new int[] { rand.Next(1, 7), rand.Next(1, 7), rand.Next(1, 7), rand.Next(1, 7), rand.Next(1, 7) };
                if(ErHus(t))
                {
                    hus++;
                }
		    }

            double likur = hus / oft;
            Console.WriteLine("Hús: " + hus);
            Console.WriteLine("Líkur: "+likur);
            Console.ReadLine();
        }

        static bool ErHus(int[] t)
        {
            Dictionary<int, int> oft = new Dictionary<int, int>();
            foreach (int tala in t)
            {
                if (oft.ContainsKey(tala))
                {
                    oft[tala]++;
                }
                else
                {
                    oft.Add(tala, 1);
                }
            }

            if (oft.Count > 2) return false;

            bool o2 = false;
            bool o3 = false;
            foreach (KeyValuePair<int, int> ta in oft)
            {
                if (ta.Value == 2)
                {
                    o2 = true;
                }
                else if (ta.Value == 3)
                {
                    o3 = true;
                }
            }

            return (o2 && o3);
        }
    }
}