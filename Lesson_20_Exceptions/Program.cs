using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_20_Exceptions
{
	class AuthException : Exception
	{
		public AuthException();
	}

	class User
	{
		public string Login { get; set; }
		public string Password { get; set; }

		internal void Init(string[] args)
		{
			Login = args[0].Split(':')[1];
			Password = args[1].Split(':')[1];
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			User currentUser = new User() { Login = "log", Password = "pwd" };
			User incomeUser = new User();
			incomeUser.Init(args);

			if (currentUser.Password.Equals(incomeUser.Password) && currentUser.Login.Equals(incomeUser.Login))
			{
				Console.WriteLine("Looks good");
			}
			else
			{
				throw new AuthException("wrong login/password");
			}

		//	try
		//	{
		//		Method();
		//		//throw new IndexOutOfRangeException();
		//	}
		//	catch(IndexOutOfRangeException ex)
		//	{
		//		Console.WriteLine(ex.StackTrace);
		//		Console.WriteLine(ex.Message);
		//	}
		//	catch(SystemException se)
		//	{
		//		Console.WriteLine(se.Message);
		//	}
		//	Console.ReadKey();
		//}

		//private static void Method()
		//{
		//	try
		//	{
		//		throw new IndexOutOfRangeException("Exception messege");
		//	}
		//	catch(SystemException se)
		//	{
		//		Console.WriteLine(se.Message);
		//	}
		//	throw new IndexOutOfRangeException();
		//}
		//private static void MethodInner()
		//{
		//	throw new AuthException();
		//}
	}
}
