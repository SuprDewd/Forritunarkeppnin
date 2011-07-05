using System;
using System.Collections.Generic;
using System.Linq;

namespace DistanceBetween
{
    class Program
    {
        static List<char> chars = new List<char>();

        static IEnumerable<WordOp> AllRemove(WordOp s, int i)
        {
            if (i == 0)
            {
                yield return s;
                yield break;
            }

            for (int j = 0; j < s.Word.Length; j++)
            {
                string b = s.Word.Substring(0, j);
                string a = s.Word.Substring(j + 1);
                int nj = j;

                foreach (WordOp x in AllRemove(new WordOp { Word = b + a, Ops = s.Ops + 1, Do = p =>
                {
                    if (!Reversed)
                    {
                        s.Do(p);
                        Console.WriteLine("Remove {0} at index {1}", s.Word[nj], (nj + p));
                    }
                    else
                    {
                        Console.WriteLine("Add {0} at index {1}", s.Word[nj], (nj + p));
                        s.Do(p);
                    }
                } }, i - 1)) yield return x;
            }
        }

        static IEnumerable<WordOp> AllReplace(WordOp s, int i, List<int> alreadyReplaced)
        {
            yield return s;
            if (i == 0) yield break;

            for (int j = 0; j < s.Word.Length; j++)
            {
                if (alreadyReplaced.Contains(j)) continue;

                for (int c = 0; c < chars.Count; c++)
                {
                    string b = s.Word.Substring(0, j);
                    string a = s.Word.Substring(j + 1);
                    int nj = j, nc = c;

                    if (chars[c] == s.Word[j]) continue;
                    List<int> nAlreadyReplace = new List<int>(alreadyReplaced);
                    nAlreadyReplace.Add(j);
                    foreach (WordOp x in AllReplace(new WordOp { Word = b + chars[c] + a, Ops = s.Ops + 1, Do = p =>
                    {
                        if (!Reversed)
                        {
                            s.Do(p);
                            Console.WriteLine("Replace {0} at index {1} with {2}", s.Word[nj], (nj + p), chars[nc]);
                        }
                        else
                        {
                            Console.WriteLine("Replace {0} at index {1} with {2}", chars[nc], (nj + p), s.Word[nj]);
                            s.Do(p);
                        }
                    } }, i - 1, nAlreadyReplace)) yield return x;
                }
            }
        }

        struct WordOp
        {
            public string Word;
            public Action<int> Do;
            public int Ops;

            public WordOp(string word)
            {
                Word = word;
                Do = i => { };
                Ops = 0;
            }
        }

        static int LevenshteinDistance(string s, string t)
        {
            int n = s.Length, m = t.Length;
            int?[,] d = new int?[n + 1, m + 1];
            Func<char, char, int> r = (a, b) => a == b ? 0 : 1;

            for (int i = 0; i <= n; i++) d[i, 0] = i;
            for (int j = 0; j <= m; j++) d[0, j] = j;

            Func<int, int, int> dRec = null;
            dRec = (i, j) =>
            {
                if (d[i, j].HasValue) return d[i, j].Value;
                int x = Math.Min(dRec(i - 1, j) + 1, Math.Min(dRec(i, j - 1) + 1, dRec(i - 1, j - 1) + r(s[i - 1], t[j - 1])));
                d[i, j] = x;
                return x;
            };

            return dRec(n, m);
        }

        static bool Reversed = false;

        static void Main(string[] args)
        {
            Console.Write("From: ");
            string l = Console.ReadLine();
            Console.Write("To: ");
            string r = Console.ReadLine();

            if (l.Length < r.Length)
            {
                string t = l;
                l = r;
                r = t;
                Reversed = true;
            }

            string lm = l, rm = r;

            int f = 0;
            for (int i = 0; i < Math.Min(lm.Length, rm.Length); i++)
            {
                if (lm[0] != rm[0]) break;

                lm = lm.Substring(1);
                rm = rm.Substring(1);
                f++;
            }

            int li = lm.Length - 1, ri = rm.Length - 1;

            if (li >= 0 && ri >= 0) while (lm[li] == rm[ri])
            {
                lm = lm.Substring(0, lm.Length - 1);
                rm = rm.Substring(0, rm.Length - 1);

                li--;
                ri--;

                if (li == 0 || ri == 0) break;
            }

            foreach (char c in r.ToCharArray()) if (!chars.Contains(c)) chars.Add(c);

            int diff = r.Length - l.Length;
            IEnumerable<WordOp> correctLength;

            if (diff < 0) correctLength = AllRemove(new WordOp(lm), Math.Abs(diff));
            else correctLength = new[] { new WordOp(lm) };

            List<int> emptyList = new List<int>();
            var q = from c in correctLength.AsParallel()
                    from s in AllReplace(c, c.Word.Length, emptyList)
                    select s;

            /*int? lowest = null;
            foreach (WordOp i in q.Where(i => i.Word == rm))
            {
                if (lowest != null && lowest <= i.Ops) continue;
                lowest = i.Ops;

                i.Do(f);
                Console.WriteLine();
            }*/

            int lDistance = LevenshteinDistance(l, r);
            WordOp o = q.First(i => i.Word == rm && i.Ops == lDistance);
            o.Do(f);

            // Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}