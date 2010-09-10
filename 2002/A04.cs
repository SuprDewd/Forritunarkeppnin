using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Keppnin_2002
{
    class A05
    {
        static void Main()
        {
            int[] tolur = new int[10];
            for (int i = 1; i <= 10; i++)
            {
                Console.Write("Tala "+i+": ");
                tolur[i - 1] = Convert.ToInt32(Console.ReadLine());
            }

            int haest = tolur[0];
            for (int i = 1; i < 10; i++)
            {
                if (tolur[i] > haest)
                {
                    haest = tolur[i];
                }
            }

            int laegst = tolur[0];
            for (int i = 1; i < 10; i++)
            {
                if (tolur[i] < laegst)
                {
                    laegst = tolur[i];
                }
            }

            Console.WriteLine("Hæsta talan er: "+haest);
            Console.WriteLine("Lægsta talan er: "+laegst);
            Console.ReadLine();
        }
    }
}
