using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson_21_IO
{
	class Program
	{
		static string basePath = @"C:\Users\Student\source\repos\ItCloudAcademy\Lesson_21_IO\";
		static void Main(string[] args)
		{
			//	byte[] _bytes = Encoding.ASCII.GetBytes("new Test string");

			//	MemoryStream ms = new MemoryStream(30);
			//	{
			//		StreamWriter sw = new StreamWriter(ms);
			//		{
			//			sw.Write("new Test string");
			//			sw.Flush();
			//		}
			//		ms.Position = 0;

			//		StreamReader sr = new StreamReader(ms);
			//		{

			//			Console.WriteLine(sr.ReadLine());
			//		}
			//	}

			//	FileStream fileStream = new FileStream(@"C:\Users\Student\source\repos\ItCloudAcademy\Lesson_21_IO\testFileStream.txt", FileMode.Create);
			//	fileStream.Write(_bytes, 0, _bytes.Length);
			//	//fileStream.Flush();

			//using (MemoryStream memoryStream = new MemoryStream(@"C:\Users\Student\source\repos\ItCloudAcademy\Lesson_21_IO\testFileStream.txt", FileMode.Create))
			//	fileStream.Write(_bytes, 0, _bytes.Length);
			////fileStream.Flush();

			var folderView = new FolderView();
			do
			{
				folderView.Show();


			}

			Console.ReadKey();
		}
	}

	class FolderView
	{
		string _basePath;
		public FolderView(string path = @"C:\Users\Student\source\repos\ItCloudAcademy\Lesson_21_IO\")
		{
			_basePath = path;
		}

		public void Show()
		{
			var dirs = Directory.GetDirectories(_basePath).Select(s => new DirectoryInfo(s)).Cast<FileSystemInfo>();
			dirs = dirs.Concat(Directory.GetFiles(_basePath).Select(s => new FileInfo(s)).Cast<FileSystemInfo>());
			foreach (var item in dirs)
			{
				Console.WriteLine(item.Name);
			}

		}

		public void InFolder(string folder)
		{
			_basePath = Path.Combine(_basePath, folder);
			_basePath = new DirectoryInfo(_basePath).FullName;
		}
	}
}
