using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK_Delta_2010
{
    class Verk9B
    {
        static void Main(string[] args)
        {
            int t = 0;
            bool plus = true;
            int summa = 0;
            do
            {
                Console.Write("Tala (-1 til að hætta): ");
                t = Int32.Parse(Console.ReadLine());
                if (t >= 0)
                {
                    if (!plus)
                    {
                        summa += (t * -1);
                    }
                    else
                    {
                        summa += t;
                    }
                    plus = !plus;
                }

            } while (t >= 0);
            Console.WriteLine("Mismunasumma: " + summa);
            Console.ReadLine();
        }
    }
}
