using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_29_EntityFramework
{
	class File
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public byte[] Data { get; set; }
		public long Size { get; set; }
		public int ParentId { get; set; }
	}

	class Program
	{
		static void Main(string[] args)
		{
			using (var context = new ApplicationContext())
			{
				context.Database.Initialize(true);
			}
		}
	}
}
