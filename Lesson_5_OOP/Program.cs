using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5_OOP
{
	class Human
	{

	}

	class Cat
	{
		public string Name;
		private int _age;
		public Cat Father;
		public Cat Mother;
		public Human Owner;

		public int Age
		{
			get { return _age; }
			set { if (value >= 0) Age = value; }
		}
		

		public void Voice()
		{
			Console.WriteLine($"Meou! My name is {Name}");
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Cat catBob = new Cat();
			catBob.Name = "Bob";
			Cat catJohn = new Cat();
			catJohn.Name = "John";
			catJohn.Age = 1;
			catBob.Voice();
			catJohn.Voice();

			Console.ReadKey();
		}
	}
}
