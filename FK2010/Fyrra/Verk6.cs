using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK
{
    class Verk6
    {
        static void Main(string[] args)
        {
            Console.Write("Laun á klukkustund? ");
            double laun = Int32.Parse(Console.ReadLine());
            Console.Write("Fyrsti vinnustundafjöldi? ");
            double timar = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Vinnustundir\tLaun\tSkattur");
            for (int i = 1; i <= 5; i++)
            {
                double l = laun * i * timar;
                double s = (l > 30000) ? ((l - 30000) * 0.2) : 0;
                Console.WriteLine(timar * i + "\t\t" + l + "\t" + s);
            }
            Console.ReadLine();
        }
    }
}
