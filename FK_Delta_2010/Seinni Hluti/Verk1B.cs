using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FK_Delta_2010
{
    class Verk1B
    {
        static void Main()
        {
            Console.Write("Nafn fyrri einstaklings: ");
            string fn = Console.ReadLine();
            Console.Write("Hæð fyrri einstaklings í sentimetrum: ");
            int fh = Int32.Parse(Console.ReadLine());
            Console.Write("Nafn seinni einstaklings: ");
            string sn = Console.ReadLine();
            Console.Write("Hæð seinni einstaklings í sentimetrum: ");
            int sh = Int32.Parse(Console.ReadLine());

            if (sh == fh)
            {
                Console.WriteLine("Báðir einstaklingar eru jafn háir.");
            }
            else if (fh > sh)
            {
                Console.WriteLine(fn+" er hærri.");
            }
            else if (fh < sh)
            {
                Console.WriteLine(sn+" er hærri.");
            }
            Console.ReadLine();
        }
    }
}