using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_29_EntityFramework
{
    class MtInit : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            context.Files.Add(new File());

            base.Seed(context);
        }
    }

	class ApplicationContext : DbContext
	{
		public ApplicationContext() : base("EntityTest")
		{
			Database.Log += Console.WriteLine;
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationContext>());
		}
		public DbSet<File> Files { get; set; }
		public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
