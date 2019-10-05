using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_18_Linq
{
	class Director
	{
		public string Name { get; set; }
		public DateTime Birthdate { get; set; }
		public string Country { get; set; } 
	}

	class Actor
	{
		public string Name { get; set; }
		public DateTime Birthdate { get; set; }
	}

	abstract class ArtObject
	{

		public string Author { get; set; }
		public string Name { get; set; }
		public int Year { get; set; }
	}
	class Film : ArtObject
	{

		public int Length { get; set; }
		public IEnumerable<Actor> Actors { get; set; }

	}
	class Book : ArtObject
	{

		public int Pages { get; set; }
	}


	class Program
	{
		static void Main(string[] args)
		{
			var data = new List<object>() {
						"Hello",
						new Book() { Author = "Terry Pratchett", Name = "Guards! Guards!", Pages = 810 },
						new List<int>() {4, 6, 8, 2},
						new string[] {"Hello inside array"},
						new Film() { Author = "Martin Scorsese", Name= "The Departed", Actors = new List<Actor>() {
							new Actor() { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22)},
							new Actor() { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
							new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
						}},
						new Film() { Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>() {
							new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
							new Actor() { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
						}},
						new Book() { Author = "Stephen King", Name="Finders Keepers", Pages = 200},
						"Leonardo DiCaprio"
					};

			// ***Level***
			Console.WriteLine(string.Join(", ", Enumerable.Range(10, 41)));
			Console.WriteLine(string.Join(", ", Enumerable.Range(10, 41).Where((i) => i % 3 == 0)));
			Console.WriteLine(string.Concat(Enumerable.Repeat("LINQ", 10)));
			Console.WriteLine(string.Join(", ", "aaa;abb;ccc;dap".Split(';').Where(str => str.Contains('a'))));
			Console.WriteLine(string.Join(", ", "aaa;abb;ccc;dap".Split(';').Where(str => str.Contains('a')).Select(str => str.Count(letter => letter == 'a'))));
			Console.WriteLine(string.Join(", ", "aaa;xabbx;abb;ccc;dap".Split(';').Select(str => str.Contains("abb"))));
			Console.WriteLine(string.Join(", ", "aaa;xabbx;abb;ccc;dap".Split(';').First(str => str.Length == "aaa;xabbx;abb;ccc;dap".Split(';').Max(s => s.Length))));
			Console.WriteLine(string.Join(", ", "aaa;xabbx;abb;ccc;dap".Split(';').Average(str => str.Length)));
			Console.WriteLine(string.Join(", ", "aaa;xabbx;abb;ccc;dap;zh".Split(';').First(str => str.Length == "aaa;xabbx;abb;ccc;dap;zh".Split(';').Min(s => s.Length)).Reverse()));
			Console.WriteLine(string.Join(", ", "baaa;aabb;xabbx;abb;ccc;dap;zh".Split(';').First(str => str.StartsWith("aa")).All(ch => ch == 'a')));
			Console.WriteLine(string.Join(", ", "baaa;aabb;xabbx;abb;ccc;dap;zh".Split(';').Last(str => str.EndsWith("bb"))));

			//***Level2***
			Console.WriteLine(data.Except(data.OfType<ArtObject>()));
			Console.WriteLine(string.Join(", ", data.OfType<Film>().SelectMany(f => f.Actors).Select(a => a.Name)));
			Console.WriteLine(string.Join(", ", data.OfType<Film>().SelectMany(f => f.Actors, (f, a) => a.Birthdate.Month == 8).Distinct().Count()));
			Console.WriteLine(string.Join(", ", data.OfType<Film>().SelectMany(f => f.Actors).OrderBy(f => f.Birthdate).Select(n => n.Name).Take(2)));
			Console.WriteLine(string.Join(", ", data.OfType<Book>().GroupBy(a => a.Author).Select(gr => $"{gr.Key}: {gr.Count()}")));
			Console.WriteLine(string.Join(", ", data.OfType<Book>().GroupBy(a => a.Author).Select(gr => $"{gr.Key}: {gr.Count()}").Concat(data.OfType<Film>().GroupBy(f => f.Actors).Select(gr => $"{gr.Key}: {gr.Count()}"))));
			Console.WriteLine(string.Join(",", data.OfType<Film>().SelectMany(f => f.Actors, (f, a) => a.Name).SelectMany(n => n).Where(c => c != ' ').Distinct().Count()));
			Console.WriteLine(string.Join(",", data.OfType<Book>().OrderBy(n => n.Author).ThenBy(b => b.Name).Select(gr => $"{gr.Name}")));
			Console.WriteLine(string.Join("\n", data.OfType<Film>().SelectMany(f => f.Actors).GroupBy(a => a.Name, actor => data.OfType<Film>().Where(film => film.Actors.Contains(actor)).Select(f => f.Name))));
			Console.WriteLine(string.Join(",", data.OfType<Book>().Sum(Book => Book.Pages) + data.OfType<IEnumerable<int>>().Sum(a => a.Sum())));
			Console.WriteLine(string.Join(",", data.OfType<Book>().GroupBy(a => a.Author).Select(gr => $"{gr.Key}").Concat(data.OfType<Book>().ToLookup(b => b.Name).Select(gr => $"{gr.Key}"))));
			Console.WriteLine(string.Join(",", data.OfType<Film>().Where(a => a.Actors.Any(n => n.Name == "Matt Damon") && a.Actors.All(act => !data.OfType<string>().Contains(act.Name))).Select(a => a.Name)));

			//List<Film> films = new List<Film>()
			//{
			//	new Film{Name = "", Director = "Jonathan Demme"},
			//	new Film{Name = "", Diretor = ""},

			//	new Film{Name = "", Director = ""},
			//};
			//List<Director> directors = new List<Director>()
			//{
			//	new Director {Name = "Jonathan Demme", Country = "USA"},
			//	new Director {Name = "Roger Donaldson", Country = "New Zeland"},
			//};

			//var result = from film in films
			//			 join dir in directors
			//			 on film.Director equals dir.Name into dirr
			//			 from dd in dirr
			//			 let tmp = dd.Country
			//			 where dd.Name == "Rogar Donaldson" && tmp == dd.Country
			//			 select new { dd.Name, dd.Country, FName = film.Name };

			Console.ReadKey();
		}
	}
}
