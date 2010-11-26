using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FK_Beta_2010
{
    class Verk3b
    {
        static char[] serhljodar = new char[] { 'a', 'á', 'e', 'é', 'y', 'ý', 'u', 'ú', 'i', 'í', 'o', 'ó', 'æ', 'ö' };
        static List<string> ljod = new List<string>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("ljod.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                line = line.ToLower().Trim();
                if (new char[] { ',', '.' }.Contains(line[line.Length - 1]))
                {
                    line = line.Substring(0, line.Length-1);
                }
                Rim(line);
            }
            sr.Close();

            if (Samrim())
            {
                Console.WriteLine("Samrím.");
            }
            else if (Runurim())
            {
                Console.WriteLine("Runurím.");
            }
            else if (Vixlrim())
            {
                Console.WriteLine("Víxlrím.");
            }
            else
            {
                Console.WriteLine("Ekkert passar við rímið.");
            }

            Console.ReadLine();
        }

        static void Rim(string line)
        {
            string r = line;
            foreach (char s in serhljodar)
            {
                if (r.LastIndexOf(s) >= 0)
                {
                    r = r.Substring(r.LastIndexOf(s));
                }
            }
            ljod.Add(r);
        }

        static bool Samrim()
        {
            string f = ljod[0];
            foreach (string l in ljod)
            {
                if (l != f)
                {
                    return false;
                }
            }
            return true;
        }

        static bool Runurim()
        {
            if (ljod.Count % 4 != 0) return false;

            for (int i = 1; i < ljod.Count; i+=2)
            {
                string f = ljod[i - 1];
                string s = ljod[i];

                if (f != s)
                {
                    return false;
                }
            }

            return true;
        }

        static bool Vixlrim()
        {
            if (ljod.Count % 4 != 0) return false;

            for (int i = 3; i < ljod.Count; i += 4)
            {
                string a = ljod[i - 3];
                string b = ljod[i - 2];
                string c = ljod[i - 1];
                string d = ljod[i];

                if (!(a == c && b == d))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
