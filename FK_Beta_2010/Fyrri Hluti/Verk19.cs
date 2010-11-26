using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FK_Beta_2010
{
    class Verk19
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("tidni.txt");
            string txt = sr.ReadToEnd();
            sr.Close();
            Dictionary<char, int> takn = new Dictionary<char, int>();

            for (int i = 0; i < txt.Length; i++)
            {
                char s = Char.Parse(txt[i].ToString().ToLower());
                if (Char.IsLetterOrDigit(s) || new string[] { "á", "í", "ú", "ý", "ó", "é", "þ", "ð", "æ", "ö" }.Contains(s.ToString().ToLower()))
                {
                    if (takn.ContainsKey(s))
                    {
                        takn[s]++;
                    }
                    else
                    {
                        takn.Add(s, 1);
                    }
                }
            }

            var sortedDict = (from entry in takn orderby entry.Value descending select entry);

            foreach (KeyValuePair<char, int> t in sortedDict)
            {
                Console.WriteLine(t.Key + " " + t.Value);
            }
            Console.ReadLine();
        }
    }
}
