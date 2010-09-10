using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta_2009
{
    class Verk12
    {
        static void Main(string[] args)
        {
            Console.Write("Klukkustundir: ");
            int klst = Convert.ToInt32(Console.ReadLine());
            string klsts = klst.ToString();
            Console.Write("Mínútur: ");
            int min = Convert.ToInt32(Console.ReadLine());
            string mins = (min < 10) ? "0" + min.ToString() : min.ToString();
            Console.Write("Sekúndur: ");
            int sek = Convert.ToInt32(Console.ReadLine());
            string seks = (sek < 10) ? "0" + sek.ToString() : sek.ToString();
            Console.WriteLine("Tíminn er: "+klsts+":"+mins+":"+seks);
            Console.ReadLine();
        }
    }
}
