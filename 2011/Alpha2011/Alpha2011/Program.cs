using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using SharpBag;
using SharpBag.Combinatorics;
using SharpBag.Games;
using SharpBag.Math;
using SharpBag.Math.Geometry;
using SharpBag.Misc;
using SharpBag.Strings;

namespace Alpha2011
{
	public class Alpha2011Controller : ProblemController
	{
		private static void Main(string[] args)
		{
			new Alpha2011Controller() { Title = "Alpha 2011" }.Run();
		}

		#region Problem D23

		[Problem("D23", Description = "Dæmi 23")]
		public void D23()
		{
			int rows = this.Read<int>("Fjöldi raða"),
				cols = this.Read<int>("Fjöldi dálka");

			Func<int, int, int[,]> read = (r, c) =>
				{
					int[,] matrix = new int[r, c];
					for (int i = 0; i < rows; i++)
					{
						for (int j = 0; j < cols; j++)
						{
							matrix[i, j] = this.Read<int>(String.Format("röð {0}, dálkur {1}", i + 1, j + 1));
						}
					}

					return matrix;
				};

			Console.WriteLine("Sláið inn gildi fyrir fyrri matrixu:");
			int[,] a = read(rows, cols);

			Console.WriteLine();
			Console.WriteLine("Sláið inn gildi fyrir seinni matrixu:");
			int[,] b = read(rows, cols);

			Console.WriteLine();
			Console.WriteLine("Niðurstaða:");
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					Console.WriteLine("röð {0}, dálkur {1}: {2}", i + 1, j + 1, a[i, j] + b[i, j]);
				}
			}
		}

		#endregion Problem D23

		#region Problem D22

		[Problem("D22", Description = "Dæmi 22")]
		public void D22()
		{
			new Thread(() =>
				{
					int c = 20;
					while (true)
					{
						Console.WriteLine(c + " sek");
						c--;
						if (c == -1) c = 20;
						Thread.Sleep(1000);
					}
				}).Start();

			Dice d = new Dice();
			while (true)
			{
				Console.WriteLine(1.To(5).Select(i => d.Throw()).Do(i => Console.Write("fékk ")).Iter(i => Console.Write(i + ", ")).GroupBy(i => i).Any(i => i.Count() > 1) ? "tvær eða fleiri tölur eins" : "engin tala eins");
				Thread.Sleep(1500);
			}
		}

		#endregion Problem D22

		#region Problem D21

		[Problem("D21", Description = "Dæmi 21")]
		public void D21()
		{
			Func<int, string[]> f = k => this.Read("Texti " + k).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(o => o.ToUpper()).OrderBy(i => i).ToArray();
			Console.WriteLine("Innihalda {0}sömu orð", f(1).SequenceEqual(f(2)) ? "" : "ekki ");
		}

		#endregion Problem D21

		#region Problem D20

		public bool ValidBinaryTala(string s)
		{
			if (s.Length == 0) return true;
			if (s[0] != '0' && s[0] != '1') return false;
			return ValidBinaryTala(s.Substring(1));
		}

		[Problem("D20", Description = "Dæmi 20")]
		public void D20()
		{
			string bin = this.Read("Binary tala");
			Console.WriteLine("Talan er {0}binary tala", bin != "" && ValidBinaryTala(bin) ? "" : "ekki ");
		}

		#endregion Problem D20

		#region Problem D19

		public class IcelandicStringComparer : IComparer<string>
		{
			private static string Score = "aábcdðeéfghiíjklmnoópqrstuúvxyzþæö";

			public int Compare(string x, string y)
			{
				x = x.ToLower();
				y = y.ToLower();
				int m = Math.Min(x.Length, y.Length);

				for (int i = 0; i < m; i++)
				{
					if (x[i] == y[i]) continue;
					int xsc = Score.IndexOf(x[i]),
						ysc = Score.IndexOf(y[i]);

					if (xsc == -1) xsc = Score.Length;
					if (ysc == -1) ysc = Score.Length;
					return xsc.CompareTo(ysc);
				}

				return x.Length.CompareTo(y.Length);
			}
		}

		public class IcelandicNameComparer : IComparer<string>
		{
			public int Compare(string x, string y)
			{
				IcelandicStringComparer scmp = new IcelandicStringComparer();

				x = x.ToLower();
				y = y.ToLower();

				string xfornafn = x.Substring(0, x.IndexOf(' ')),
					   yfornafn = y.Substring(0, y.IndexOf(' '));

				int cmp = scmp.Compare(xfornafn.Trim(), yfornafn.Trim());
				if (cmp != 0) return cmp;

				x = x.Substring(xfornafn.Length);
				y = y.Substring(yfornafn.Length);

				string xeftirnafn = x.Substring(x.LastIndexOf(' '));
				string yeftirnafn = y.Substring(y.LastIndexOf(' '));

				cmp = scmp.Compare(xeftirnafn.Trim(), yeftirnafn.Trim());
				if (cmp != 0) return cmp;

				x = x.Substring(0, x.Length - xeftirnafn.Length);
				y = y.Substring(0, y.Length - yeftirnafn.Length);

				return scmp.Compare(x.Trim(), y.Trim());
			}
		}

		[Problem("D19", Description = "Dæmi 19")]
		public void D19()
		{
			File.ReadAllLines("Nofn.txt").OrderBy(i => i, new IcelandicNameComparer()).ForEach(Console.WriteLine);
		}

		#endregion Problem D19

		#region Problem D18

		[Problem("D18", Description = "Dæmi 18")]
		public void D18()
		{
			var q = 1.ToInfinity().Select(i =>
				{
					double v = this.ReadDouble("Verð á vöru");
					string n = v == 0 ? null : this.Read("Nafn verslunar");
					return new { v, n };
				}).TakeWhile(i => i.v != 0).ToArray();

			double min = q.Min(i => i.v);

			Console.WriteLine();
			Console.WriteLine("Lægsta verðið er {0} hjá:", min);
			q.Where(i => i.v == min).OrderBy(i => i.n).ForEach(i => Console.WriteLine(i.n));
		}

		#endregion Problem D18

		#region Problem D17

		[Problem("D17", Description = "Dæmi 17")]
		public void D17()
		{
			double start = this.ReadDouble("Staða í byrjun"),
				   end = this.ReadDouble("Staða í lok");

			int tin = 0, tout = 0;
			while (start != end && (tin + tout) < 100000)
			{
				if (start < end)
				{
					start += start / 100 * 20;
					tin++;
				}
				else
				{
					start -= start / 100 * 10;
					tout++;
				}
			}

			if (start == end)
			{
				Console.WriteLine("Fjöldi innlagninga: " + tin);
				Console.WriteLine("Fjöldi úttekta: " + tout);
			}
			else
			{
				Console.WriteLine("Ekki hægt");
			}
		}

		#endregion Problem D17

		#region Problem D16

		[Problem("D16", Description = "Dæmi 16")]
		public void D16()
		{
			Console.WriteLine("Hringur A");
			double x0 = this.ReadDouble("X hnit"),
				   y0 = this.ReadDouble("Y hnit"),
				   r0 = this.ReadDouble("Radíus");

			Console.WriteLine();
			Console.WriteLine("Hringur B");
			double x1 = this.ReadDouble("X hnit"),
				   y1 = this.ReadDouble("Y hnit"),
				   r1 = this.ReadDouble("Radíus");

			Circle a = new Circle(new Point(x0, y0), r0),
				   b = new Circle(new Point(x1, y1), r1);

			double minx = Math.Min(x0 - r0, x1 - r1),
				   maxx = Math.Max(x0 + r0, x1 + r1),
				   miny = Math.Min(y0 - r0, y1 - r1),
				   maxy = Math.Max(y0 + r0, y1 + r1);

			Random rand = new Random();
			bool hitANotB = false,
				 hitBNotA = false,
				 hitAAndB = false;

			for (int i = 0; i < 100000; i++)
			{
				Point p = new Point(rand.NextDouble(minx - 1, maxx + 1), rand.NextDouble(miny - 1, maxy + 1));
				bool hitA = a.Contains(p),
					 hitB = b.Contains(p);

				if (hitA && hitB) hitAAndB = true;
				else if (hitA && !hitB) hitANotB = true;
				else if (hitB && !hitA) hitBNotA = true;
			}

			Console.WriteLine("Rétt svar er:");
			if (a.Equals(b)) Console.WriteLine("A == B");
			else if (a.Contains(b)) Console.WriteLine("A hylur B");
			else if (b.Contains(a)) Console.WriteLine("B hylur A");
			else if (a.Intersects(b)) Console.WriteLine("A og B skarast");
			else Console.WriteLine("A og B skarast ekki");

			Console.WriteLine();
			Console.WriteLine("Monte Carlo segir:");
			if (hitAAndB && !(hitANotB || hitBNotA)) Console.WriteLine("A == B");
			else if (hitAAndB && hitANotB && !hitBNotA) Console.WriteLine("A hylur B");
			else if (hitAAndB && !hitANotB && hitBNotA) Console.WriteLine("B hylur A");
			else if (!hitAAndB && hitANotB && hitBNotA) Console.WriteLine("A og B skarast ekki");
			else if (hitAAndB && hitANotB && hitBNotA) Console.WriteLine("A og B skarast");
			else Console.WriteLine("Ekkert");
		}

		#endregion Problem D16

		#region Problem D15

		[Problem("D15", Description = "Dæmi 15")]
		public void D15()
		{
			int total = this.Read<int>("Magn bensíns í lítrum");
			int[] bs = 1.To(6).Select(i => this.Read<int>("Brúsi " + i)).ToArray();
			if (bs.Sum() < total)
			{
				Console.WriteLine("Það er ekki mögulegt að hafa svona mikið bensín í þessum brúsum.");
				return;
			}

			var q = from size in 6.To(0)
					from c in bs.Combinations(size, true)
					let sum = c.Sum()
					where sum >= total
					orderby sum - total
					select c;

			var res = q.First();
			Console.WriteLine("Best er að nota");
			res.OrderByDescending(i => i).ForEach(i => Console.WriteLine(i + " lítra brúsa"));
			Console.WriteLine("Magn bensíns verður þá " + res.Sum());
		}

		#endregion Problem D15

		#region Problem D14

		[Problem("D14", Description = "Dæmi 14")]
		public void D14()
		{
			string bin = this.Read("Binary").TrimStart('0');
			int dec = 0;
			StringBuilder hex = new StringBuilder();

			for (int i = 0; i < bin.Length; i++)
			{
				dec = dec * 2 + (bin[i] - '0');
			}

			while (dec > 0)
			{
				int mod = dec % 16;
				hex.Insert(0, mod < 10 ? (char)(mod + '0') : (char)(mod - 10 + 'A'));
				dec /= 16;
			}

			if (hex.Length == 0) hex.Append('0');

			Console.WriteLine("Hexadecimal: " + hex.ToString());
		}

		#endregion Problem D14

		#region Problem D13

		[Problem("D13", Description = "Dæmi 13")]
		public void D13()
		{
			double g = this.ReadDouble("Fjöldi gramma");

			if (g >= 10)
			{
				double[] b = {
								 Math.Pow(10, 0),
								 Math.Pow(10, 1),
								 Math.Pow(10, 2),
								 Math.Pow(10, 3),
								 Math.Pow(10, 6),
								 Math.Pow(10, 9),
								 Math.Pow(10, 12),
								 Math.Pow(10, 15),
								 Math.Pow(10, 18),
								 Math.Pow(10, 21),
								 Math.Pow(10, 24)
							 };

				string[] s = {
								 "gramm",
								"dekagramm",
								"hektógramm",
								"kílógramm",
								"megagramm",
								"gigagramm",
								"teragramm",
								"petagramm",
								"exagramm",
								"zettagramm",
								"yottagramm"
							 };

				var res = b.Select(i => g / i).WithIndex().SkipWhile(i => i.Value >= 10).First();
				Console.WriteLine("Það eru {0} {1}", res.Value, s[res.Index].Replace("gramm", "grömm"));
			}
			else if (g < 1)
			{
				double[] b = {
								 Math.Pow(10, 0),
								 Math.Pow(10, -1),
								 Math.Pow(10, -2),
								 Math.Pow(10, -3),
								 Math.Pow(10, -6),
								 Math.Pow(10, -9),
								 Math.Pow(10, -12),
								 Math.Pow(10, -15),
								 Math.Pow(10, -18),
								 Math.Pow(10, -21),
								 Math.Pow(10, -24)
							 };

				string[] s = {
								 "gramm",
								"desigramm",
								"sentigramm",
								"milligramm",
								"míkrógramm",
								"nanógramm",
								"píkógramm",
								"femtógramm",
								"attógramm",
								"zeptógramm",
								"yoktógramm"
							 };

				var res = b.Select(i => g / i).WithIndex().SkipWhile(i => i.Value < 1).First();
				Console.WriteLine("Það eru {0} {1}", res.Value, s[res.Index].Replace("gramm", "grömm"));
			}
			else
			{
				Console.WriteLine("Það eru {0} grömm", g);
			}
		}

		#endregion Problem D13

		#region Problem D12

		[Problem("D12", Description = "Dæmi 12")]
		public void D12()
		{
			string start = this.Read("Upphafsstaða peðs");
			int count = this.Read<int>("Hversu oft á peðið að hreyfast");
			string dir = this.Read("Stefna").ToLower();

			Console.WriteLine("Peðið fer á eftirfarandi reiti:");

			int deltax = dir.Contains("h") ? 1 : dir.Contains("v") ? -1 : 0,
				deltay = dir.Contains("u") ? 1 : dir.Contains("n") ? -1 : 0,
				x = (int)(start[0] - 'A'),
				y = start.Substring(1).As<int>() - 1;

			List<string> coords = new List<string>();
			for (int i = 0; i < count; i++)
			{
				if ((x == 0 && deltax == -1) || (x == 9 && deltax == 1)) deltax = -deltax;
				if ((y == 0 && deltay == -1) || (y == 9 && deltay == 1)) deltay = -deltay;

				x += deltax;
				y += deltay;

				coords.Add((char)(x + 'A') + (y + 1).ToString());
			}

			Console.WriteLine(coords.ToStringPretty());
		}

		#endregion Problem D12

		#region Problem D11

		[Problem("D11", Description = "Dæmi 11")]
		public void D11()
		{
			Func<int[]> haed = () => 1.ToInfinity().Select(i => this.Read("hæð " + i)).TakeWhile(i => i != "xxx").Select(i => i == "-" ? -1 : i.Count(k => k == 'x')).Reverse().SkipWhile(i => i == -1).Reverse().ToArray();
			Console.WriteLine("Stökkvari 1:\n");
			int[] s1 = haed();
			Console.WriteLine("\nStökkvari 2:\n");
			int[] s2 = haed();

			Console.WriteLine();

			if (s1.Length != s2.Length)
			{
				Console.WriteLine("Stökkvari " + (s1.Length > s2.Length ? "1" : "2") + " vinnur.");
				return;
			}

			for (int i = s1.Length - 1; i >= 0; i--)
			{
				if (s1[i] == s2[i]) continue;
				if (s1[i] == -1 || s2[i] == -1) Console.WriteLine("Stökkvari " + (s2[i] == -1 ? "1" : "2") + " vinnur.");
				else Console.WriteLine("Stökkvari " + (s1[i] < s2[i] ? "1" : "2") + " vinnur.");

				return;
			}

			Console.WriteLine("Jafntefli.");
		}

		#endregion Problem D11

		#region Problem D10

		[Problem("D10", Description = "Dæmi 10")]
		public void D10()
		{
			int[] x0a = this.Read("Fyrsti tímapunktur klukkan").Split(':').Select(i => i.As<int>()).ToArray();
			double x0 = x0a[0] * 60 + x0a[1];
			double y0 = this.Read<int>("Fjarlægð á fyrsta tímapunkti");
			int[] x1a = this.Read("Annar tímapunktur klukkan").Split(':').Select(i => i.As<int>()).ToArray();
			double x1 = x1a[0] * 60 + x1a[1];
			double y1 = this.Read<int>("Fjarlægð á öðrum tímapunkti");
			int[] xa = this.Read("Þriðji tímapunktur klukkan").Split(':').Select(i => i.As<int>()).ToArray();
			double x = xa[0] * 60 + xa[1];

			Console.WriteLine("Fjarlægðin er þá: " + Interpolation.Linear(new[] { new Point(x0, y0), new Point(x1, y1) })(x));
			// Console.WriteLine("Fjarlægðin er þá: " + (y0 + (y1 - y0) / (x1 - x0) * (x - x0)));
		}

		#endregion Problem D10

		#region Problem D9

		[Problem("D9", Description = "Dæmi 9")]
		public void D9()
		{
			int count = this.Read<int>("Hvað er margir einstaklingar í bekknum");
			1.To(count).Select(s => this.Read("Nafn").ToUpper()).GroupBy(s => s).Where(g => g.Count() > 1).ForEach(g => Console.WriteLine("Það eru {0} {1} í bekknum.", g.Count(), g.Key.ToTitleCase()));
		}

		#endregion Problem D9

		#region Problem D8

		[Problem("D8", Description = "Dæmi 8")]
		public void D8()
		{
			Console.WriteLine("Fyrri hornpunktar fyrir ferhyrning A:");
			double x1 = this.ReadDouble("x hnit");
			double y1 = this.ReadDouble("y hnit");
			Console.WriteLine("Seinni hornpunktar fyrir ferhyrning A:");
			double x2 = this.ReadDouble("x hnit");
			double y2 = this.ReadDouble("y hnit");
			Console.WriteLine("Fyrri hornpunktar fyrir ferhyrning B:");
			double x3 = this.ReadDouble("x hnit");
			double y3 = this.ReadDouble("y hnit");
			Console.WriteLine("Seinni hornpunktar fyrir ferhyrning B:");
			double x4 = this.ReadDouble("x hnit");
			double y4 = this.ReadDouble("y hnit");

			SimplePolygon rect1 = GeometryFactory.Rectangle(new Point(x1, y1), new Point(x2, y2)),
						  rect2 = GeometryFactory.Rectangle(new Point(x3, y3), new Point(x4, y4));

			if (rect1.Equals(rect2)) Console.WriteLine("A == B");
			else if (rect1.Contains(rect2)) Console.WriteLine("A hylur B");
			else if (rect2.Contains(rect1)) Console.WriteLine("B hylur A");
			else if (rect1.Intersects(rect2)) Console.WriteLine("A og B skarast");
			else Console.WriteLine("Ekkert");
		}

		#endregion Problem D8

		#region Problem D7

		[Problem("D7", Description = "Dæmi 7")]
		public void D7()
		{
			Func<int> f = () => this.Read<int>("tala");
			var grp = f.Unfold().TakeWhile(i => i != -1).GroupBy(i => i).ToArray();
			int maxcnt = grp.Max(i => i.Count());

			grp.Where(i => i.Count() == maxcnt).ForEach(i => Console.WriteLine("Talan {0} kemur oftast fyrir í talnaröðinni", i.Key));
		}

		#endregion Problem D7

		#region Problem D6

		[Problem("D6", Description = "Dæmi 6")]
		public void D6()
		{
			string[] months = { "janúar", "febrúar", "mars", "apríl", "maí", "júní", "júlí", "ágúst", "september", "október", "nóvember", "desember" };

			1.To(12).Select(i => this.Read<int>("Regn í mánuði " + i, "? ")).Do((i) => Console.WriteLine()).WithIndex().OrderBy(i => i.Value).ForEach(i => Console.WriteLine("Regn í {0} {1}", months[i.Index], i.Value));
		}

		#endregion Problem D6

		#region Problem D5

		[Problem("D5", Description = "Dæmi 5")]
		public void D5()
		{
			int[] correct = this.Read("Réttar tölur", "? ").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => Convert.ToInt32(i)).ToArray();

			string line;
			int maxCount = 0;
			while ((line = this.Read("Röð sem notandi á").Trim()) != "-1")
			{
				int[] cur = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => Convert.ToInt32(i)).ToArray();
				int cnt = 0;

				for (int i = 0; i < cur.Length; i++)
				{
					if (correct.Contains(cur[i])) cnt++;
				}

				if (cnt > maxCount) maxCount = cnt;
			}

			Console.WriteLine("Það eru mest {0} réttar tölur í einni röðinni", maxCount);
		}

		#endregion Problem D5

		#region Problem D4

		[Problem("D4", Description = "Dæmi 4")]
		public void D4()
		{
			int a = this.Read<int>("Fyrri talan"),
				b = this.Read<int>("Seinni talan");

			Console.WriteLine("Stærsti samnefnari er " + BagMath.Gcd(a, b));
		}

		#endregion Problem D4

		#region Problem D3

		[Problem("D3", Description = "Dæmi 3")]
		public void D3()
		{
			Console.SetBufferSize(500, 500);

			double lagmark = this.ReadDouble("lágmarkshæð"),
				   hamark = this.ReadDouble("hámarkshæð"),
				   step = this.ReadDouble("þrepun í cm") / 100.0;

			Console.WriteLine();
			Console.Write("hæð/þyngd\t");

			for (double cur = lagmark; cur <= (hamark + step / 10); cur += step)
			{
				Console.Write(cur + "\t");
			}

			Console.WriteLine();

			for (double h = 60; h <= 125; h += 5)
			{
				Console.Write(h + "\t\t");

				for (double cur = lagmark; cur <= (hamark + step / 10); cur += step)
				{
					Console.Write((h / (cur * cur)).ToString("0.00") + "\t");
				}

				Console.WriteLine();
			}
		}

		#endregion Problem D3

		#region Problem D2

		[Problem("D2", Description = "Dæmi 2")]
		public void D2()
		{
			string s = this.Read("Texti");
			bool buffering = false;
			int cnt = 0;

			for (int i = 0; i < s.Length; i++)
			{
				if (Char.IsLetter(s[i]))
				{
					if (!buffering) cnt++;
					buffering = true;
				}
				else
				{
					buffering = false;
				}
			}

			Console.WriteLine("Það eru {0} orð í þessum texta.", cnt);
		}

		#endregion Problem D2

		#region Problem D1

		[Problem("D1", Description = "Dæmi 1")]
		public void D1()
		{
			while (true)
			{
				this.ClearScreen();
				Console.WriteLine("Hvort viltu");
				Console.WriteLine(" 1. reikna yfirborðsflatarmál");
				Console.WriteLine(" 2. reikna radíus");
				string c = this.Read("Veldu 1 eða 2").Trim();

				if (c == "1")
				{
					double radius = this.ReadDouble("Radíus kúlunnar", "? ");
					Console.WriteLine("Yfirborðsflatarmál kúlunnar er: " + 4 * Math.PI * radius * radius);
				}
				else if (c == "2")
				{
					double flatarmal = this.ReadDouble("Yfirborðsflatarmál kúlunnar er");
					Console.WriteLine("Radíus kúlunnar? " + Math.Sqrt(flatarmal / (4 * Math.PI)));
				}
				else break;

				Console.ReadLine();
			}
		}

		#endregion Problem D1
	}
}