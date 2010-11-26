using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuprLibrary;

namespace FK2002
{
    class Verk5
    {
        static void Main(string[] args)
        {
            int min = 0;
            int max = 0;
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Tala "+(i+1)+": ");
                int t = Int32.Parse(Console.ReadLine());
                if (i == 0)
                {
                    min = t;
                    max = t;
                }
                else if (t < min)
                {
                    min = t;
                }
                else if (t > max)
                {
                    max = t;
                }
            }

            Console.WriteLine("Hæst: "+max);
            Console.WriteLine("Lægst: "+min);
            Console.ReadLine();
        }
    }
}