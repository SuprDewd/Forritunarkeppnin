using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK_Delta_2010
{
    class Verk6B
    {
        static void Main(string[] args)
        {
            Console.Write("Heiti vöru: ");
            string nafn = Console.ReadLine();
            Console.Write("Heiti einingar: ");
            string eining = Console.ReadLine();
            double magn = -1;
            double verd = -1;
            double minnst = -1;
            Dictionary<double, double> mv = new Dictionary<double, double>();
            do
            {
                Console.Write("Magn (sláið inn - tölu til að hætta) ");
                magn = Double.Parse(Console.ReadLine());
                if (magn >= 0)
                {
                    Console.Write("Verð í krónum: ");
                    verd = Double.Parse(Console.ReadLine());
                    mv.Add(magn, verd);
                }
            }while(magn >= 0);

            foreach (KeyValuePair<double, double> h in mv)
            {
                if (h.Value / h.Key < minnst || minnst == -1)
                {
                    minnst = h.Value / h.Key;
                    magn = h.Key;
                    verd = h.Value;
                }
            }

            Console.WriteLine(nafn+", hagkvæmasta verð er "+verd+" fyrir "+magn+" "+eining);
            Console.ReadLine();
        }
    }
}
