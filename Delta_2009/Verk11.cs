using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta_2009
{
    class Verk11
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> heiti = new Dictionary<string,double>();
            heiti["fárviðri"] = 34.8;
            heiti["ofsaveður"] = 30.5;
            heiti["rok"] = 26.4;
            heiti["stormur"] = 22.6;
            heiti["hvassviðri"] = 18.9;
            heiti["allhvass vindur"] = 15.5;
            heiti["stinningskaldi"] = 12.3;
            heiti["kaldi"] = 9.3;
            heiti["stinningsgola"] = 6.7;
            heiti["gola"] = 4.3;
            heiti["kul"] = 2.4;
            heiti["andvari"] = 1;
            heiti["logn"] = 0;
            

            Console.Write("Vindstyrkur í m/s: ");
            double styrkur = Convert.ToDouble(Console.ReadLine());

            bool afram = true;
            foreach (var hti in heiti)
            {
                if (styrkur >= hti.Value && afram)
                {
                    Console.WriteLine("Þá er "+hti.Key);
                    afram = false;
                }
            }
            Console.ReadLine();
        }
    }
}
