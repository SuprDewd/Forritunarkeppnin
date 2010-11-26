using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK
{
    class Verk4B
    {
        static void Main(string[] args)
        {

            Console.Write("Hvaða klukkustund er: ");
            int klst = Int32.Parse(Console.ReadLine());
            Console.Write("Hvaða mínúta: ");
            int min = Int32.Parse(Console.ReadLine());
            Console.Write("Hversu marga klukkutíma á að bíða? ");
            klst += Int32.Parse(Console.ReadLine());
            Console.Write("og hversu margar mínútur? ");
            min += Int32.Parse(Console.ReadLine());

            while (min > 59)
            {
                min -= 60;
                klst++;
            }

            while (klst > 23)
            {
                klst -= 24;
            }



            int s = (klst * 100) + min;

            if (s >= 0 && s <= 259)
            {
                Console.WriteLine("Það er miðnætti");
            }
            else if (s >= 300 && s <= 559)
            {
                Console.WriteLine("Það er ótta");
            }
            else if (s >= 600 && s <= 859)
            {
                Console.WriteLine("Það er rismál");
            }
            else if (s >= 900 && s <= 1159)
            {
                Console.WriteLine("Það er dagmál");
            }
            else if (s >= 1200 && s <= 1459)
            {
                Console.WriteLine("Það er hádegi");
            }
            else if (s >= 1500 && s <= 1759)
            {
                Console.WriteLine("Það er nón");
            }
            else if (s >= 1800 && s <= 2059)
            {
                Console.WriteLine("Það er miðaftan");
            }
            else if (s >= 2100 && s <= 2359)
            {
                Console.WriteLine("Það er náttmál");
            }
            Console.ReadLine();
        }
    }
}
