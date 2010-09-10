using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Keppnin_2002
{
    class A02
    {
        static void Main()
        {
            Console.Write("Lengd í sentimetrum: ");
            double cm = Convert.ToInt32(Console.ReadLine());
            double tommur = cm / 2.54;
            Console.WriteLine("Lengd í tommum: "+tommur);
            Console.ReadLine();
        }
    }
}
