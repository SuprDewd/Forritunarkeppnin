using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK_Delta_2010
{
    class Verk7
    {
        static void Main(string[] args)
        {
            Console.Write("Hvaða klukkustund er: ");
            int klst = Int32.Parse(Console.ReadLine());
            Console.Write("Hvaða mínúta er: ");
            int min = Int32.Parse(Console.ReadLine());
            bool pm = false;

            if (klst >= 12)
            {
                pm = true;
                if (klst > 12)
                {
                    klst -= 12;
                }
            }
            else if (klst == 0)
            {
                klst = 12;
            }

            string sMin = min < 10 ? "0" + min : min.ToString();
            string app = pm ? "PM" : "AM";

            Console.WriteLine(klst+":"+sMin+" "+app);
            Console.ReadLine();
        }
    }
}
