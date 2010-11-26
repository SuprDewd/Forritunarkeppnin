using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Keppnin_2002
{
    class A04
    {
        static void Main()
        {
            Console.Write("Tala: ");
            int tala = Convert.ToInt32(Console.ReadLine());
            Console.Write("Veldi: ");
            int veldi = Convert.ToInt32(Console.ReadLine());
            int TalaIVeldi = SetjaToluIVeldi(tala, veldi);
            Console.WriteLine(tala + " í " + veldi + " veldi er " + TalaIVeldi);
            Console.ReadLine();
        }

        static int SetjaToluIVeldi(int tala, int veldi)
        {
            int talaiveldi;
            if (veldi == 0)
            {
                talaiveldi = 0;
            }
            else
            {
                talaiveldi = 1;
                for (int i = 0; i < veldi; i++)
                {
                    talaiveldi *= tala;
                }
            }

            return talaiveldi;
        }
    }
}
