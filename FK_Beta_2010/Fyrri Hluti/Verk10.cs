using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FK_Beta_2010
{
    class Verk10
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                string skra = "";
                bool afram = false;
                do
                {
                    Console.Write("Skrá sem inniheldur texta: ");
                    skra = Console.ReadLine();
                    if(skra == "$")
                    {
                        afram = true;
                    }
                    else if (!File.Exists(skra))
                    {
                        Console.WriteLine("Skráin "+skra+" er ekki til, sláðu inn nafn á skrá sem er til.");
                    }
                    else
                    {
                        afram = true;
                    }
                } while (!afram);

                if (skra != "$")
                {
                    StreamReader sr = new StreamReader(skra, Encoding.UTF8);
                    string innihald = sr.ReadToEnd().Replace("\r\n", " ").Replace("\n", " ");
                    sr.Close();

                    while (innihald.Contains("  "))
                    {
                        innihald = innihald.Replace("  ", " ");
                    }

                    string[] ord = innihald.Split(' ');
                    int morgord = 0;

                    foreach (string o in ord)
                    {
                        bool erOrd = false;
                        for (int i = 0; i < o.Length; i++)
                        {
                            if (Char.IsLetterOrDigit(o[i]) || new string[]{"á", "í", "ó", "ú", "ý", "é", "ð", "ö", "æ", "þ"}.Contains(o[i].ToString().ToLower()))
                            {
                                erOrd = true;
                            }
                        }

                        if (erOrd)
                        {
                            morgord++;
                        }
                    }

                    Console.WriteLine("Skráin inniheldur "+morgord+" orð.");
                    Console.ReadLine();
                }
            }
        }
    }
}
