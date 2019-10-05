using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork_3
{
	class Book
	{
		public string Name;
		public int Year;
		public string Author;
	}
	class Program
	{
		static void Main(string[] args)
		{
			//***Task_1***
			var data = new List<Book>()
			{
				new Book() { Name = "Guards! Guards! LINQ!", Year = 2008 },
				new Book() { Name = "Finders Keepers", Year = 1999},
				new Book() { Name = "The Departed", Year = 2012},
				new Book() { Name = "Good LINQ Hunting", Year = 2015}
			};

			Console.WriteLine(string.Join(", ", data.Where(book => book.Name.Contains("LINQ") && DateTime.IsLeapYear(book.Year)).Select(book => book.Name)));

			//***Task_2***
			var text = new List<string>()
			{
			"aaa;abb;ccc;dap",
			"aaa;xabbx;abb;ccc;dap",
			"aaa;xabbx;abb;ccc;dap;zh",
			"baaa;aabb;xabbx;abb;ccc;dap;zh"
			};
			//Console.WriteLine(text.SelectMany(str => str).Distinct().Count());
			Console.WriteLine(string.Join(", ", text.SelectMany(str => str).Where(a => a != ';').Distinct().Count()));

			//***Task_3***
			int[] array = { 14, 12, 23, 20, 32, 33 };
			Console.WriteLine(string.Join(", ", array.OrderBy(arrnum => arrnum / 10).ThenByDescending(arrnum => arrnum % 10)));

			//***Task_4***
			var Books = new List<Book>()
			{
				new Book() { Author = "Terry Pratchett" },
				new Book() { Author = "Martin Scorsese" },
				new Book() { Author = "Stephen King" },
				new Book() { Author = "Stephen King" },
			};
			Console.WriteLine(string.Join(", ", Books.GroupBy(book => book.Author).Select(b => $"{b.Key}: {b.Count()}")));

			Console.ReadKey();
		}
	}
}
