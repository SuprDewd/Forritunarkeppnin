using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FK_Delta_2010
{
    class Verk11B
    {
        static void Main(string[] args)
        {
            int sextiu = 0, thratiu = 0, tuttugu = 0;
            List<string> moguleikar = new List<string>();
            Console.Write("Farþegafjöldi: ");
            int f = Int32.Parse(Console.ReadLine());

            if (f <= 300)
            {

                for (int sext = 0; sext <= 3; sext++)
                {
                    for (int thra = 0; thra <= 2; thra++)
                    {
                        for (int tvo = 0; tvo <= 3; tvo++)
                        {
                            moguleikar.Add(sext + ";" + thra + ";" + tvo + ";" + (sext * 60 + thra * 30 + tvo * 20));
                        }
                    }
                }

                int minnst = -1;

                foreach (string moguleiki in moguleikar)
                {
                    int allt = Int32.Parse(moguleiki.Split(';')[0]) + Int32.Parse(moguleiki.Split(';')[1]) + Int32.Parse(moguleiki.Split(';')[2]);
                    int heild = Int32.Parse(moguleiki.Split(';')[3]);
                    if ((minnst == -1 && heild >= f) || (heild >= f && allt < minnst))
                    {
                        minnst = allt;
                        sextiu = Int32.Parse(moguleiki.Split(';')[0]);
                        thratiu = Int32.Parse(moguleiki.Split(';')[1]);
                        tuttugu = Int32.Parse(moguleiki.Split(';')[2]);
                    }
                }

                if (sextiu > 0)
                {
                    Console.WriteLine(sextiu + " stk 60 manna rúta");
                }
                if (thratiu > 0)
                {
                    Console.WriteLine(thratiu + " stk 30 manna rúta");
                }
                if (tuttugu > 0)
                {
                    Console.WriteLine(tuttugu + " stk 20 manna rúta");
                }
            }
            else
            {
                Console.WriteLine("Það eru ekki til nógu margar rútur.");
            }

            Console.ReadLine();
        }
    }
}
