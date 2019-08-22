using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4
{
	class Program
	{
		public static bool IsPolindrome(string value)
		{
			for (int i = 0; i < value.Length / 2; i++)
			{
				if (value[i] != value[value.Length - 1])
				{
					return false;
				}
			}
			return true;
		}

		//private char[] GetRandomArray(int count)
		//{
		//	Random r = new Random();
		//	char[] result = new char;
		//}

		//public char[] Sort(char[] value)
		//{

		//}

		static void Main(string[] args)
		{
			//int[] array = new int[] { 8, 2, 3, 4, 6 };
			char[] array = new char[] { '8', '2', '3', '4', '6' };

			SortCharBubble(array);
			//SortIntBubble(array);
			//Console.WriteLine(IsPolindrome("qwerewq"));
			Console.ReadKey();
		}

		//private static void SortIntBubble(int[] array)
		//{
		//	for (int i = 0; i < array.Length - 1; i++)
		//	{
		//		if (array[i] > array[i + 1])
		//		{
		//			int temp = array[i];
		//			array[i] = array[i + 1];
		//			array[i + 1] = temp;
		//		}
		//	}

		//	foreach (var item in array)
		//	{
		//		Console.WriteLine(item);
		//	}

		private static void SortCharBubble(char[] array)
		{
			for (int i = 0; i < array.Length - 1; i++)
			{
				if (array[i] > array[i + 1])
				{
					char temp = array[i];
					array[i] = array[i + 1];
					array[i + 1] = temp;
				}
			}

			foreach (var item in array)
			{
				Console.WriteLine(item);
			}
		}
	}
}
