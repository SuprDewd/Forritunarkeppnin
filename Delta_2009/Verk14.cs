using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Delta_2009
{
    class Verk14
    {
        static void Main(string[] args)
        {
            /*
             * Grand
             * Spaði
             * Hjarta
             * Tígull
             * Lauf
             * 
             * Hæst 7
             * 
             * */

            string input;
            int tala;
            int seinastaTala = 0;

            while (true)
            {
                Console.Write("Sögn: ");
                input = Console.ReadLine();
                if(RettInput(input))
                {
                    tala = ParseInput(input);
                    if(tala <= seinastaTala)
                    {
                        Console.WriteLine("Sögnin verður að hækka.");
                    }
                    else
                    {
                        seinastaTala = tala;
                    }
                }
                else
                {
                    Console.WriteLine("Þessi sögn er ekki rétt.");
                }
            }
        }

        static int ParseInput(string input)
        {
            int tala = Convert.ToInt32(input.Split(' ')[0]);
            string tegund = input.Split(' ')[1];
            int ut = 0;

            switch (tegund)
            {
                case "l":
                    ut = 1;
                    break;
                case "t":
                    ut = 2;
                    break;
                case "h":
                    ut = 3;
                    break;
                case "s":
                    ut = 4;
                    break;
                case "g":
                    ut = 5;
                    break;
            }

            ut += tala * 10;

            return ut;
        }

        static bool RettInput(string input)
        {
            return Regex.IsMatch(input, "^[0-7] [gshtlGSHTL]$");
        }
    }
}