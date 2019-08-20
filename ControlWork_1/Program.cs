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

			//string[] result = str.Split(';');
			City[] cities = new City[result.Length];

			NewMethod(result, cities);
			for (int i = 0; i < result.Length; i++)
			{

			}

			//int.Parse("1431000");



			Console.ReadKey();
		}

		private static void NewMethod(string[] result, City[] cities)
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
