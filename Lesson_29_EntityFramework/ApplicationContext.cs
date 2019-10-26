using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_29_EntityFramework
{
	class ApplicationContext : DbContext
	{
		public ApplicationContext() : base("EntityTest")
		{
			Database.Log += Console.WriteLine;
		}
		public DbSet<File> Files { get; set; }
	}
}
