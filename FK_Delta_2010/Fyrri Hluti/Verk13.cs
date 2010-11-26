using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK_Delta_2010
{
    class Verk13
    {
        static void Main()
        {
            Random rand = new Random();
            List<int> t = new List<int>();
            t.Add(rand.Next(1, 7));
            t.Add(rand.Next(1, 7));
            t.Add(rand.Next(1, 7));
            t.Add(rand.Next(1, 7));
            t.Add(rand.Next(1, 7));
            int tala = Tvisvar(t);
            Console.WriteLine("Tölurnar sem komu upp eru "+String.Join(" ", t));
            if (tala != 0)
            {
                Console.WriteLine("Talan "+tala+" kom upp tvisvar");
            }

            Console.ReadLine();
        }

        static int Tvisvar(List<int> t)
        {
            Dictionary<int, int> to = new Dictionary<int, int>();
            foreach (int ta in t)
            {
                if (to.ContainsKey(ta))
                {
                    to[ta]++;
                }
                else
                {
                    to.Add(ta, 1);
                }
            }

            foreach (KeyValuePair<int, int> ti in to)
            {
                if (ti.Value == 2)
                {
                    return ti.Key;
                }
            }

            return 0;
        }
    }
}