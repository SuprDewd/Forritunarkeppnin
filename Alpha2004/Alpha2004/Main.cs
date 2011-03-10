using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using SharpBag;
using SharpBag.Strings;
using SharpBag.IO;
using SharpBag.Net;
using SharpBag.Math;
using SharpBag.Combinatorics;
using SharpBag.Database;
using SharpBag.Games;
using SharpBag.FK;
using SharpBag.FK.MVC;
using SharpBag.Time;
using SharpBag.Math.Converters;
using System.Linq;
using System.Globalization;

namespace Alpha2004
{
	public class Alpha2004 : FKController
	{
		public static void Main(string[] args) { new Alpha2004(new string[] {  }).Run(); }
		public Alpha2004(string[] args) : base(new FKModel(), "Alfa 2004", args: args) { }
		public override void PreActionExecute() { Console.Clear(); }
		
		[FKAction("D5")]
		public void D5()
		{
			while (true)
			{
				Console.WriteLine("Strengur: ");
				string s = Console.ReadLine().Replace(" ", "").ToLower();
				bool l = false;
				
				for (int i = 2; i <= s.Length / 2; i++)
				{
					if (s.Split(new string[] { s.Substring(0, i) }, StringSplitOptions.RemoveEmptyEntries).Length == 0)
					{
						Console.WriteLine("Hann er lotubundinn");
						Console.WriteLine("Strengur: " + s.Substring(0, i));
						Console.WriteLine("Oft: " + s.Length / i);
						l = true;
						break;
					}
				}
				
				if (!l) Console.WriteLine("Hann er ekki lotubundinn");
			}
		}
		
		[FKAction("D6")]
		public void D6()
		{
			Console.WriteLine("S: ");
			string s = Console.ReadLine().ToLower();
			List<string> dot = new List<string>();
			
			for (int j = 2; j < s.Length / 2; j++)
			{
				for (int i = 0; i < s.Length - j + 1; i++)
				{
					string x = s.Substring(i, j);
					if (!x.Contains(" "))
					{
						dot.Add(x);
					}
				}	
			}
			
			dot.Reverse();
			foreach (string x in dot)
			{
				if (dot.Count(i => i == x) > 1)
				{
					s = s.Replace(x, x.ToUpper());
				}
			}
			
			Console.WriteLine(s);
		}
		
		[FKAction("D10")]
		public void D10()
		{
			string kt = this.Model.Read("KT");
			int d = Convert.ToInt32(kt.Substring(0, 2));
			int m = Convert.ToInt32(kt.Substring(2, 2));
			int y = Convert.ToInt32(kt.Substring(4, 2));
			
			y += y < 20 ? 2000 : 1900;
			
			try
			{
				DateTime dt = new DateTime(y, m, d);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Ekki lögleg");
				return;
			}
			
			Console.WriteLine("Lögleg");
		}
		
		struct Persona
		{
			public int Aldur;
			public string Nafn;
		}
		
		public int Veldi(int upprTala, int veldi, int tala)
		{
			if (veldi == 1) return tala;
			return Veldi(upprTala, veldi - 1, tala * upprTala);
		}
		
		[FKAction("D4")]
		public void D4()
		{
			int tala = this.Model.Read<int>("Tala");
			int veldi = this.Model.Read<int>("Veldi");
			Console.WriteLine("Talan í veldinu: " + Veldi(tala, veldi, tala));
		}
		
		[FKAction("D11")]
		public void D11()
		{
			List<Persona> kk = new List<Persona>();
			List<Persona> kvk = new List<Persona>();
			
			for (int i = 1; i <= 10; i++)
			{
				string n = this.Model.Read("Nafn stráks " + i);
				int a = this.Model.Read<int>("Aldur stráks " + i);
				kk.Add(new Persona { Aldur = a, Nafn = n });
			}
			
			for (int i = 1; i <= 10; i++)
			{
				string n = this.Model.Read("Nafn stelpu " + i);
				int a = this.Model.Read<int>("Aldur stelpu " + i);
				kvk.Add(new Persona { Aldur = a, Nafn = n });
			}
			
			Console.WriteLine();
			Console.WriteLine();
			
			var kk2 = kk.OrderByDescending(p => p.Aldur).ToArray();
			var kvk2 = kvk.OrderByDescending(p => p.Aldur).ToArray();
			
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine(kk2[i].Nafn + " og " + kvk2[i].Nafn);
			}
		}
		
		private double PD(string s)
		{
			return Convert.ToDouble(s);
		}
		
		private double Calc(string exp)
		{
			exp = exp.Replace(" ", "").Replace(',', '.');
			
			foreach (char c in new[] { '*', '/', '+', '-' })
			{
				while (true)
				{
					Match m = Regex.Match(exp, @"([0-9]+(\.[0-9]+)?\" + c + @"[0-9]+(\.[0-9]+)?)");
					if (!m.Success) break;
					
					double[] d = m.Value.Split(c).Select(i => PD(i)).ToArray();
					double x;
					
					switch (c)
					{
						case '*': x = d[0] * d[1]; break;
						case '/': x = d[0] / d[1]; break;
						case '+': x = d[0] + d[1]; break;
						case '-': x = d[0] - d[1]; break;
					}
					
					exp = exp.Replace(m.Value, x.ToString());
				}
			}
			
			return PD(exp);
		}
		
		[FKAction("D14", Finished = false, Start = true)]
		public void D14()
		{
			while (true) Console.WriteLine("Svar: " + Calc(this.Model.Read("Expr")));
		}
		
		public class LinkedListItem<T>
		{
			public T Value;
			public LinkedListItem<T> Next = null;
		}
		
		public class LinkedList<T>
		{
			public LinkedListItem<T> First = null;
			
			public void Append(T item)
			{
				LinkedListItem<T> last = null;
				LinkedListItem<T> now = First;
				while (now != null) { last = now; now = now.Next; }
				if (last != null) last.Next = new LinkedListItem<T>() { Value = item };
				else First = new LinkedListItem<T>() { Value = item };
			}
			
			/*public IEnumerable<T> IEnumerable<T>.GetEnumerator()
			{
				LinkedListItem<T> now = First;
				while (now != null) { yield return now.Value; now = now.Next; }
			}*/
		}
		
		[FKAction("D15")]
		public void D15()
		{
			int tala;
			LinkedList<int> l = new LinkedList<int>();
			while ((tala = this.Model.Read<int>("Tala")) != -1)
			{
				l.Append(tala);
			}
			
			Console.WriteLine("Tölurnar: ");
			
			LinkedListItem<int> now = l.First;
			while (now != null) { Console.WriteLine(now.Value); now = now.Next; }	
		}
		
		[FKAction("D16", Start = false)]
		public void D16()
		{
			Random rand = new Random();
			int tala1 = rand.Next(0, 10);
			int tala2 = rand.Next(0, 10);
			int summa = tala1 + tala2;
			bool submitted = false;
			
			new Thread(() => {
				int s = 0;
				while (!submitted) { Thread.Sleep(1); s++; }
				Console.WriteLine("Þú varst " + (s) + " millisek.");
			}).Start();
			
			Console.Write("{0} + {1} = ", tala1, tala2);
			string t = Console.ReadLine();
			submitted = true;
			Console.WriteLine("Svarið var " + (t != summa.ToString() ? "ekki " : "") + "rétt.");
		}
		
		[FKAction("D17", Start = false)]
		public void D17()
		{
			bool b100 = false;
			new Thread(() => {
				for (int i = 1; i <= 100; i++)
				{
					Console.WriteLine("A" + i);
					Thread.Sleep(200);
					if (i == 100)
					{
						while (!b100) Thread.Sleep(10);
						b100 = false;
						i = 0;
					}
				}
			}).Start();
			new Thread(() => {
				for (int i = 1; i <= 100; i++)
				{
					Console.WriteLine("B" + i);
					Thread.Sleep(300);
					if (i == 100)
					{
						b100 = true;
						while (b100) Thread.Sleep(10);
						i = 0;
					}
				}
			}).Start();
			
			while (true) Thread.Sleep(1000);
		}
		
		[FKAction("D18")]
		public void D18()
		{
			double x = this.Model.Read<double>("X");
			double d = 1 + x;
			int n = 2;
			
			while (true)
			{
				double next = Math.Pow(x, n) / n.Factorial();
				d += next;
				if (next < 0.001) break;
			}
			
			Console.WriteLine(d);
		}
		
		[FKAction("D22")]
		public void D22()
		{
			int t1 = this.Model.Read<int>("Tala 1");
			int t2 = this.Model.Read<int>("Tala 2");
			
			WebRequest req = (WebRequest)HttpWebRequest.Create("http://netlab.ru.is/misc/add.php?a=" + t1 + "&b=" + t2);
			WebResponse res = req.GetResponse();
			
			Console.WriteLine(new StreamReader(res.GetResponseStream()).ReadToEnd());
		}
		
		[FKAction("D23Bidlari")]
		public void D23Bidlari()
		{
			int t1 = this.Model.Read<int>("Tala 1");
			int t2 = this.Model.Read<int>("Tala 2");
			
			WebRequest req = (WebRequest)HttpWebRequest.Create("http://localhost:123/?a=" + t1 + "&b=" + t2);
			WebResponse res = req.GetResponse();
			
			Console.WriteLine(new StreamReader(res.GetResponseStream()).ReadToEnd());
		}
		
		[FKAction("D23Midlari")]
		public void D23Midlari()
		{
			HttpListener l = new HttpListener();
			l.Prefixes.Add("http://localhost:123/");
			l.Start();
			while (true)
			{
				Console.WriteLine("Waiting.");
				HttpListenerContext ctx = l.GetContext();
				Console.WriteLine("Got stuffz.");
				int sum = Convert.ToInt32(ctx.Request.QueryString["a"]) + Convert.ToInt32(ctx.Request.QueryString["b"]);
				Console.WriteLine(sum);
				new StreamWriter(ctx.Response.OutputStream).Write(sum.ToString());
				Console.WriteLine("Closing.");
				ctx.Response.OutputStream.Close();
			}
		}
		
		public class Stafli<T>
		{
			private List<T> Array = new List<T>();
			
			public void BaetaVid(T item)
			{
				Array.Add(item);
			}
			
			public T TakaUr()
			{
				T item = Array[Array.Count - 1];
				Array.RemoveAt(Array.Count - 1);
				return item;
			}
		}
		
		[FKAction("D25")]
		public void D25()
		{
			Stafli<int> s = new Stafli<int>();
			s.BaetaVid(1);
			s.BaetaVid(2);
			s.BaetaVid(3);
			s.BaetaVid(4);
			
			if (s.TakaUr() != 4) Console.WriteLine("Villa");
			if (s.TakaUr() != 3) Console.WriteLine("Villa");
			if (s.TakaUr() != 2) Console.WriteLine("Villa");
			if (s.TakaUr() != 1) Console.WriteLine("Villa");
		}
	}
}