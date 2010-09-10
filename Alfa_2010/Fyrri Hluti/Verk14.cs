using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FK_Alfa_2010
{
    class Verk14
    {
        static void Main(string[] args)
        {
            // http://www.ccs.neu.edu/home/sbratus/com1101/lab4.html

            while (true)
            {
                Console.Clear();
                Console.Write("Svigar: ");
                string sv = Console.ReadLine();

                if (ErRett(sv))
                {
                    Console.WriteLine("Rett");
                }
                else
                {
                    Console.WriteLine("Rangt");
                }

                Console.ReadLine();
            }
        }

        static bool ErRett(string sv)
        {
            Stack<string> S = new Stack<string>();

            for (int i = 0; i < sv.Length; i++)
            {
                if (new string[] { "(", "[" }.Contains(sv[i].ToString()))
                {
                    S.Push(sv[i].ToString());
                }
                else if (new string[] { ")", "]" }.Contains(sv[i].ToString()))
                {
                    if (S.Count == 0)
                    {
                        return false;
                    }
                    if (S.Pop() != OpinnS(sv[i].ToString()))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        static string OpinnS(string s)
        {
            return s == ")" ? "(" : "[";
        }
    }
}