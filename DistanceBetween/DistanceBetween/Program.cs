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

                foreach (WordOp x in AllRemove(new WordOp { Word = b + a, Ops = s.Ops + 1, Do = p => { s.Do(p); Console.WriteLine("Remove " + s.Word[nj] + " at index " + (nj + p)); } }, i - 1)) yield return x;
            }
        }

        static IEnumerable<WordOp> AllAdd(WordOp s, int i)
        {
            if (i == 0)
            {
                yield return s;
                yield break;
            }

            for (int j = 0; j <= s.Word.Length; j++)
            {
                for (int c = 0; c < chars.Count; c++)
                {
                    string b = s.Word.Substring(0, j);
                    string a = s.Word.Substring(j);
                    int nj = j, nc = c;

                    foreach (WordOp x in AllAdd(new WordOp { Word = b + chars[c] + a, Ops = s.Ops + 1, Do = p => { s.Do(p); Console.WriteLine("Add " + chars[nc] + " at index " + (nj + p)); } }, i - 1)) yield return x;
                }
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
                    List<int> alreadyRep = new List<int>(alreadyReplaced);
                    alreadyRep.Add(j);
                    foreach (WordOp x in AllReplace(new WordOp { Word = b + chars[c] + a, Ops = s.Ops + 1, Do = p => { s.Do(p); Console.WriteLine("Replace " + s.Word[nj] + " at index " + (nj + p) + " with " + chars[nc]); } }, i - 1, alreadyRep)) yield return x;
                }
            }
        }

        struct WordOp
        {
            public string Word;
            public Action<int> Do;
            public int Ops;
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

        static void Main(string[] args)
        {
            string l = "bjarki", r = "jónas", lm = l, rm = r;

            int f = 0;
            for (int i = 0; i < Math.Min(lm.Length, rm.Length); i++)
            {
                if (lm[i] != rm[i]) break;

                lm = lm.Substring(1);
                rm = rm.Substring(1);
                f++;
            }

            int li = lm.Length - 1, ri = rm.Length - 1;

            while (lm[li] == rm[ri])
            {
                lm = lm.Substring(0, lm.Length - 1);
                rm = rm.Substring(0, rm.Length - 1);

                li--;
                ri--;

                if (li == 0 || ri == 0) break;
            }

            foreach (char c in l.ToCharArray().Concat(r.ToCharArray())) if (!chars.Contains(c)) chars.Add(c);

            int diff = r.Length - l.Length;
            IEnumerable<WordOp> correctLength;

            if (diff < 0) correctLength = AllRemove(new WordOp { Word = lm, Do = i => { }, Ops = 0 }, Math.Abs(diff));
            else if (diff > 0) correctLength = AllAdd(new WordOp { Word = lm, Do = i => { }, Ops = 0 }, diff);
            else correctLength = new[] { new WordOp { Word = lm, Do = i => { }, Ops = 0 } };

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