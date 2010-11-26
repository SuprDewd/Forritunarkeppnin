using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK_2002
{
    class Verk6
    {
        static void Main(string[] args)
        {
            int odd = -1;
            int oddS = 0;
            for (int i = 0; i < 15; i++)
            {
                int d1 = i + 1;
                int d2 = odd + 2;
                odd = d2;
                oddS += odd;
                int d3 = oddS;

                Console.WriteLine(d1 + "\t" + d2 + "\t" + d3);
            }
            Console.ReadLine();
        }
    }
}
