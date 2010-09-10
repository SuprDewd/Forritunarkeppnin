using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuprLibrary;

namespace FK_Alfa_2010
{
    class Verk19
    {
        static List<string> takn     = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        static List<string> ntakn    = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        static List<string> lykilord = new List<string>();

        static void Main(string[] args)
        {
            Console.Write("Lykilorð: ");
            Lykilord(Console.ReadLine());

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Dulkóða.");
                Console.WriteLine("2. Afkóða.");
                Console.Write("Val: ");
                string val = Console.ReadLine();
                string str = "";

                Console.Clear();
                switch (val)
                {
                    case "1":
                        Console.Write("Strengur: ");
                        str = Console.ReadLine();
                        Console.WriteLine(str+" -> "+Dulkoda(str));
                        break;
                    case "2":
                        Console.Write("Strengur: ");
                        str = Console.ReadLine();
                        Console.WriteLine(Afkoda(str) + " <- " + str);
                        break;
                    default:
                        Console.WriteLine("Sláðu inn 1 eða 2.");
                        break;
                }
                Console.ReadLine();
            }
        }

        static string Dulkoda(string s)
        {
            string ut = "";
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < takn.Count; j++)
                {
                    if (takn[j] == s[i].ToString())
                    {
                        ut += lykilord[j];
                    }
                }
            }

            return ut;
        }

        static string Afkoda(string s)
        {
            string ut = "";
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < lykilord.Count; j++)
                {
                    if (lykilord[j] == s[i].ToString())
                    {
                        ut += takn[j];
                    }
                }
            }

            return ut;
        }

        static void Lykilord(string lkl)
        {
            lkl = lkl.ToLower().Trim();
            int se = 0;
            for (int i = 0; i < lkl.Length; i++)
            {
                if(ntakn.Contains(lkl[i].ToString()))
                {
                    for (int j = 0; j < ntakn.Count; j++)
                    {
                        if (lkl[i].ToString() == ntakn[j])
                        {
                            se = j;
                            ntakn[j] = "-1";
                        }
                    }
                    lykilord.Add(lkl[i].ToString());
                }
            }

            int ut = se;
            do
            {
                if (se == ntakn.Count)
                {
                    se = 0;
                }
                if (ntakn[se] != "-1")
                {
                    lykilord.Add(ntakn[se]);
                }
                se++;
            }while(ut != se);
        }
    }
}
