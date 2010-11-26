using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FK
{
    class Verk15
    {
        static void Main()
        {
            Console.Write("Klukkustund: ");
            int klst = Int32.Parse(Console.ReadLine());
            Console.Write("Mínúta: ");
            int min = Int32.Parse(Console.ReadLine());
            Console.Write("Sekúnta: ");
            int sek = Int32.Parse(Console.ReadLine());

            while (sek > 59)
            {
                sek -= 60;
                min++;
            }

            while (min > 59)
            {
                min -= 60;
                klst++;
            }

            while (klst > 23)
            {
                klst -= 24;
            }

            string sKlst = klst < 10 ? "0"+klst : klst.ToString();
            string sMin = min < 10 ? "0"+min : min.ToString();
            string sSek = sek < 10 ? "0"+sek : sek.ToString();

            Console.WriteLine(sKlst+":"+sMin+":"+sSek);
            Console.ReadLine();
        }
    }
}