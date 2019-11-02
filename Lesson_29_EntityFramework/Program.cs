using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_29_EntityFramework
{
	public class File
	{
        [Key]
		public int FileIdentifire { get; set; }
		public string Name { get; set; }
		public byte[] Data { get; set; }
		public long Size { get; set; }
		public List<Folder> Parent { get; set; }
	}

    public class Folder
    {
        public List<File> Files { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullPath { get; set; }
    }

    class Person
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public string SName { get; set; }
    }

    class Student : Person
    {
        public string InstituteName { get; set; }
    }

	class Program
	{
		static void Main(string[] args)
		{
			using (var context = new ApplicationContext())
			{
                context.Database.Initialize(true);
                //context.Files.Add(new File { Name = "1.txt", Size = 15 });
                context.People.Add(new Student { Age = 19, InstituteName = "TTTT", Name = "SName" });

                context.SaveChanges();
			}
		}
	}
}
