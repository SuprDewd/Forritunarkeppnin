using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta_2009
{
    class Verk13
    {
        static void Main(string[] args)
        {
            Dictionary<int, List<int>> timar = new Dictionary<int,List<int>>();
            int klst, min;
            do
            {
                Console.Write("Klukkustund: ");
                klst = Convert.ToInt32(Console.ReadLine());
                if (klst != -1)
                {
                    List<int> mins = new List<int>();
                    do
                    {
                        Console.Write("   Mínúta: ");
                        min = Convert.ToInt32(Console.ReadLine());
                        if (min != -1)
                        {
                            mins.Add(min);
                        }
                    } while (min != -1);
                    if (mins.Count > 0)
                    {
                        timar.Add(klst, mins);
                    }
                }
            }while(klst != -1);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Hvað er klukkan núna:");
                Console.Write("Klukkustund: ");
                klst = Convert.ToInt32(Console.ReadLine());
                Console.Write("Mínúta: ");
                min = Convert.ToInt32(Console.ReadLine());

                NaestiStraeto(timar, klst, min);

                Console.ReadLine();
            }
        }

        static void NaestiStraeto(Dictionary<int, List<int>> timar, int nunaKlst, int nunaMin)
        {
            bool fann = false;
            foreach(KeyValuePair<int, List<int>> timi in timar)
            {
                if (timi.Key >= nunaKlst)
                {
                    foreach (int min in timi.Value)
                    {
                        if ((min >= nunaMin || timi.Key > nunaKlst) && !fann)
                        {
                            fann = true;
                            Console.WriteLine("Næsti strætó kemur "+timi.Key+":"+Minuta(min));
                            break;
                        }
                    }
                }
            }

            if (!fann)
            {
                Console.WriteLine("Seinasti strætó er farinn.");
            }
        }

        static string Minuta(int min)
        {
            return (min < 10) ? "0" + min : min.ToString();
        }
    }
}
