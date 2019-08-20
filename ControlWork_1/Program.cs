using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork_1
{
	struct City
	{
		public int Pop;
		public string Name;
		public int Den;

		public void Print()
		{
			Console.WriteLine($"Name {Name}, Pop {Pop}, Den {Den}");
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			string text = "Kharkiv=1431000,350;Kiev=2804000,839;Las Vegas=603400,352";
			//string str = Console.ReadLine();
			string[] result = text.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

			City[] cities = new City[result.Length];
			string nameCity = null;
			int maxPop = 0;
			SplitCity(result, cities);

			for (int i = 0; i < result.Length - 1; i++)
			{
				if (cities[i].Pop < cities[i + 1].Pop)
				{
					maxPop = cities[i + 1].Pop;
					nameCity = cities[i + 1].Name;
				}
			}

			Console.WriteLine($"Most populated: {nameCity} ({maxPop}) people");

			for (int i = 0; i < result.Length - 1; i++)
			{
				if (cities[i].Name.Length < cities[i + 1].Name.Length)
				{
					int longest = cities[i + 1].Name.Length;
					Console.WriteLine($"Longest name: {cities[i + 1].Name}({longest} letters)");
				}

			}

			Console.WriteLine("Density: ");
			for (int i = 0; i < result.Length; i++)
			{
				double d1 = Convert.ToDouble(cities[i].Pop);
				double d2 = Convert.ToDouble(cities[i].Den);
				double den = d1 / d2;
				var str = string.Format("{0:0.##}", den);
				Console.WriteLine($"	{cities[i].Name} - {str}");
			}

			Console.ReadKey();
		}

		private static void SplitCity(string[] result, City[] cities)
		{
			for (int i = 0; i < result.Length; i++)
			{
				string[] nameSplit = result[i].Split('=');
				string[] valueSplit = nameSplit[1].Split(',');
				cities[i].Name = nameSplit[0];
				cities[i].Pop = int.Parse(valueSplit[0]);
				cities[i].Den = int.Parse(valueSplit[1]);
			}
		}
	}
}
