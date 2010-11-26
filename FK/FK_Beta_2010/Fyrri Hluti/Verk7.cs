using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FK_Beta_2010
{
    class Verk7
    {
        static void Main(string[] args)
        {
            double oft = 10000000;
            double hus = 0;
            Random rand = new Random();
            for (int i = 0; i < (int)oft; i++)
            {
                List<int> l = new List<int>();
                l.Add(rand.Next(1, 7));
                l.Add(rand.Next(1, 7));
                l.Add(rand.Next(1, 7));
                l.Add(rand.Next(1, 7));
                l.Add(rand.Next(1, 7));
                if (erHus(l))
                {
                    hus++;
                }
            }
            Console.WriteLine("Líkur: "+(hus / oft));
            Console.ReadLine();
        }

        static bool erHus(List<int> l)
        {
            Dictionary<int, int> nums = new Dictionary<int, int>();
            foreach (int n in l)
            {
                if (nums.ContainsKey(n))
                {
                    nums[n]++;
                }
                else
                {
                    nums.Add(n, 1);
                }
            }

            bool tveir = false;
            bool thrir = false;
            foreach (KeyValuePair<int, int> num in nums)
            {
                if (num.Value == 2)
                {
                    tveir = true;
                }
                else if (num.Value == 3)
                {
                    thrir = true;
                }
            }

            return (tveir && thrir);
        }
    }
}
