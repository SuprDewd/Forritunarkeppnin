using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FK_Beta_2010
{
    class Verk1B
    {
        public static string[,] leikbord = new string[3, 3];
        static void Main(string[] args)
        {
            while (true)
            {
                Reset();
                bool a = true;
                do
                {
                    Console.Clear();
                    Teikna();

                    if (a)
                    {
                        bool afram = true;
                        do
                        {
                            if (!afram)
                            {
                                Console.WriteLine("Vitlaus innsláttur.");
                                Console.ReadLine();
                                Console.Clear();
                                Teikna();
                            }
                            Console.Write("Leikmaður A velur: ");
                            afram = aGera(Console.ReadLine());
                        }while(!afram);
                    }
                    else
                    {
                        bool afram = true;
                        do
                        {
                            if (!afram)
                            {
                                Console.WriteLine("Vitlaus innsláttur.");
                                Console.ReadLine();
                                Console.Clear();
                                Teikna();
                            }
                            Console.Write("Leikmaður B velur: ");
                            afram = bGera(Console.ReadLine());
                        } while (!afram);
                    }
                    a = !a;
                } while (!aVann() && !bVann());
                Console.Clear();
                Teikna();
                if (aVann())
                {
                    Console.WriteLine("Leikmaður A vann!");
                }
                else if (bVann())
                {
                    Console.WriteLine("Leikmaður B vann!");
                }
				else
				{
					Console.WriteLine("Jafntefli.");
				}
                Console.WriteLine("Leikurinn er búinn. Ýttu á enter til að byrja uppá nýtt.");
                Console.ReadLine();
            }
        }

        static void Reset()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    leikbord[i, j] = ".";
                }
            }
        }

        static List<string> vinningsleidir = new List<string>() { 
            "00-10-20", 
            "01-11-21",
            "02-12-22",
            "00-01-02", 
            "10-11-12",
            "20-21-22",
            "00-11-22", 
            "02-11-20"
        };

        static bool aGera(string inn)
        {
            inn = inn.ToUpper();
            int x = Int32.Parse(inn[0].ToString())-1;
            int y = ((int)inn[1])-65;
            if (leikbord[x, y] != ".")
            {
                return false;
            }
            else
            {
                leikbord[x, y] = "x";
                return true;
            }
        }

        static bool bGera(string inn)
        {
            inn = inn.ToUpper();
            int x = Int32.Parse(inn[0].ToString()) - 1;
            int y = ((int)inn[1]) - 65;
            if (leikbord[x, y] != ".")
            {
                return false;
            }
            else
            {
                leikbord[x, y] = "o";
                return true;
            }
        }

        static bool aVann()
        {
            bool vann = false;
            foreach (string hnit in vinningsleidir)
            {
                string[] split = hnit.Split('-');
                bool v = true;
                foreach (string h in split)
                {
                    int x = Int32.Parse(h[0].ToString());
                    int y = Int32.Parse(h[1].ToString());

                    if (leikbord[x, y] != "x")
                    {
                        v = false;
                    }
                }

                if (v)
                {
                    vann = true;
                    break;
                }
            }

            return vann;
        }

        static bool bVann()
        {
            bool vann = false;
            foreach (string hnit in vinningsleidir)
            {
                string[] split = hnit.Split('-');
                bool v = true;
                foreach (string h in split)
                {
                    int x = Int32.Parse(h[0].ToString());
                    int y = Int32.Parse(h[1].ToString());

                    if (leikbord[x, y] != "o")
                    {
                        v = false;
                    }
                }

                if (v)
                {
                    vann = true;
                    break;
                }
            }

            return vann;
        }

        static void Teikna()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(leikbord[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
