using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FK_Alfa_2010
{
    class Verk10
    {
        static Dictionary<int, List<string>> saeti = new Dictionary<int, List<string>>();
        static string[] stafir = new string[] { "A", "B", "C", "D", "E", "F" };
        static void Main(string[] args)
        {
            LesaUrSkra();
            Console.WriteLine("Í skránni eru "+saeti.Keys.Count+" raðir með "+saeti[1].Count+" sætum hver.");
            Console.WriteLine("Viltu nota skráina eða velja sjálf/ur raða- og sætafjölda?");
            Console.Write("Sláðu inn 1 til að velja, annars verður skráin notuð: ");

            if (Console.ReadLine() == "1")
            {
                Console.Clear();
                Console.Write("Raðir (1-30): ");
                int r = Int32.Parse(Console.ReadLine());
                Console.Write("Sæti (1-6): ");
                int s = Int32.Parse(Console.ReadLine());

                NySaeti(r, s);
            }

            while (true)
            {
                Console.Clear();
                Teikna();

                Console.Write("Panta sæti: ");

                if (!PantaSaeti(Console.ReadLine()))
                {
                    Console.WriteLine("Vitlaus innsláttur.");
                    Console.ReadLine();
                }
            }
        }

        static bool PantaSaeti(string s)
        {
            if(s.Length < 2) return false;

            string sae = s[s.Length - 1].ToString().ToUpper();
            string rod = s.Substring(0, s.Length - 1);

            if (!stafir.Contains(sae)) return false;

            for (int i = 0; i < rod.Length; i++)
            {
                if (!Char.IsNumber(rod[i]))
                {
                    return false;
                }
            }

            int sa = 10, ro = Int32.Parse(rod); ;
            for (int i = 0; i < stafir.Length; i++)
            {
                if (stafir[i] == sae)
                {
                    sa = i+1;
                }
            }

            if (ro > saeti.Keys.Count) return false;

            if (sa > saeti[1].Count) return false;

            if (saeti[ro][sa - 1] == "X") return false;

            saeti[ro][sa-1] = "X";
            SkrifaISkra();

            return true;
        }

        static void NySaeti(int r, int s)
        {
            saeti = new Dictionary<int, List<string>>();

            for (int i = 1; i <= r; i++)
            {
                List<string> n = new List<string>();
                for (int j = 1; j <= s; j++)
                {
                    n.Add(stafir[j-1]);
                }
                saeti.Add(i, n);
            }
        }

        static void LesaUrSkra()
        {
            StreamReader sr = new StreamReader("saeti.txt");
            string line;
            int i = 1;
            while ((line = sr.ReadLine()) != null)
            {
                saeti.Add(i, line.Split(';').ToList());
                i++;
            }
            sr.Close();
        }

        static void SkrifaISkra()
        {
            StreamWriter sw = new StreamWriter("saeti.txt");
            foreach (KeyValuePair<int, List<string>> s in saeti)
            {
                sw.WriteLine(String.Join(";", s.Value));
            }
            sw.Close();
        }

        static void Teikna()
        {
            Console.WriteLine("Röð\tSæti");
            foreach (KeyValuePair<int, List<string>> s in saeti)
            {
                Console.Write(s.Key+"\t");
                foreach (string v in s.Value)
                {
                    Console.Write(v+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
