using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Delta_2009
{
    class Verk15
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int heild = 0;
                Console.Write("Hversu margir litlir teningar eru á hverri rönd stóra teningsins: ");
                int litlirTeningar = Convert.ToInt32(Console.ReadLine());

                heild += ((litlirTeningar * litlirTeningar) * 2) + ((litlirTeningar * (litlirTeningar - 2)) * 2) + (((litlirTeningar - 2) * (litlirTeningar - 2)) * 2);

                Console.WriteLine(heild);
                Console.ReadLine();
            }
        }
    }
}