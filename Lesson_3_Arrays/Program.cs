using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3_Arrays
{
	class Program
	{
		static void Main(string[] args)
		{
			//int[] array = new int[100];

			//int[] array2 = new int[4] { 1, 2, 3, 4 };
			//int[] array3 = new int[] { 1, 2, 3, 4 };
			//int[] array4 =  

			//int[] array = new int[] { 10, 33, 5, 66 };
			//Console.WriteLine(array[0]);
			//Console.WriteLine(array.Length);
			//Console.WriteLine(array[2]);

			//int i = 0;
			//int j = 100;
			//while (i < array.Length)
			//{
			//	array[i] = j;
			//	Console.WriteLine(array[i]);
			//	i++;
			//	j++;
			//}

			//do
			//{
			//	Console.WriteLine(i);
			//	i--;
			//}
			//while (i > 100);

			//for (int i = 0; i < array.Length; i++)
			//{
			//	array[i] = j;
			//	j++;
			//	Console.WriteLine(array[i]);
			//}
			//Console.WriteLine(j);
			//int j = 200;
			//for (int i = array.Length - 1; i >= 0;  i--)
			//{
			//	array[i] = j;
			//	j--;
			//	Console.WriteLine(array[i]);
			//}
			//Console.WriteLine(j);

			//int[] array2 = new int[];
			//for (int i = 0; i < array.Length; i++)
			//{
			//	if (j % 2 == 0)
			//	{
			//		j++;
			//	}
			//}
			//for (int i = 0, n = 0; i < array.Length; i++, n+)
			//{

			//}
			//Console.WriteLine(array[i]);

			//Console.WriteLine("Enter a four digit number: (XXXX)");
			//int a = int.Parse(Console.ReadLine());
			//int a1 = (a - a % 1000) / 1000;
			//Console.WriteLine(a1);
			//int a2 = (a - a % 100) / 100 % 10;
			//Console.WriteLine(a2);
			//int a3 = (a - a % 10) / 10 % 10;
			//Console.WriteLine(a3);
			//int a4 = a % 10;
			//Console.WriteLine(a4);
			//int sum = a1 + a2 + a3 + a4;
			//int mult = a1 * a2 * a3 * a4;
			//Console.WriteLine($"Sum = {sum}, Multiplication = {mult}");
			//Console.ReadKey();

			//Console.WriteLine("Enter a size number: ");
			//int n = int.Parse(Console.ReadLine());
			//Console.WriteLine("Enter a number: ");
			//int a = int.Parse(Console.ReadLine());
			//for (int i = 0; i < n; i++)
			//{
			//	j = a % 10;
			//	a = a / 10;
			//	Console.WriteLine(j);
			//}

			//int[,] array = { { 10, 33, 5, 6 } };

			//Console.WriteLine(array[1, 1]);
			//Console.WriteLine(array.Rank);

			//int[,,] array2 = new int[1, 2, 3]
			//{
			//	{2,3,9 },
			//}

			//int[,] array = { { 1, 2, 3, }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
			//int sum = 0;
			//for (int i = 0; i < array.Length; i++)
			//{
			//	for (int j = 0; j < array.Length; j++)
			//	{
			//		sum = sum + array;
			//	}
			//}

			//foreach(int item in array)
			//{
			//	sum++;
			//}

			//Book warAndPeace = new Book();
			//warAndPeace.Author = "Lev Tolstoy";
			//warAndPeace.Name = "War and Pease";
			//warAndPeace.PageNumbers = 1233;


			Book[] array = new Book [5];
			int count = 0;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Author = "Author";
				array[i].Name = "NameBook";
				array[i].PageNumbers = 200;
				Console.WriteLine($"{array[i].Author}{count}, {array[i].Name}{count}, {array[i].PageNumbers}{count}");
				count++;
			}
			//Console.WriteLine(warAndPeace.Print());
			Console.ReadKey();
		}

		struct Book
		{
			public int PageNumbers;
			public string Name;
			public string Author;

			public string Print()
			{
				return $"{Name}, {Author}, {PageNumbers}";
			}
		}

	}
}
