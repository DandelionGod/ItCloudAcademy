using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lesson_23_Serialization
{
	[Serializable]
	public class Work
	{
		public string Name { get; set; }
		public string Comoany { get; set; }
	}

	[Serializable]
	public class Customer
	{
		public string Name { get; set; }
		public string LastName { get; set; }
		public int Age { get; set; }
		public int Salary { get; set; }
		[XmlIgnore]
		public TimeSpan WorkingExpiriance { get; set; }
		[XmlElement(DataType = "duration", ElementName = "WorkingExpiriance")]
		public long WorkingExpirianceLong { get => WorkingExpiriance.Ticks; set => WorkingExpiriance = TimeSpan.FromDays(365); }
		public Work CurrentWork;

		public override string ToString()
		{
			return $"{{Name: {Name}, LastName: {LastName}, Age: {Age}, Salary: {Salary}, WorkingExpiriance: {WorkingExpiriance} }}";
		}
	}


	class Program
	{
		static string customSerialization = "customSerialization.txt";

		static void Main(string[] args)
		{
			var customer = new Customer { Name = "Jon", LastName = "Smith", Age = 44, Salary = 5, WorkingExpiriance = TimeSpan.FromDays(365) };
			File.WriteAllText(customSerialization, customer.ToString());

			//Customer customerXml;
			Customer customerBin;

			using (var xmlFile = File.OpenWrite("xmlFormat.xml"))
			{
				var xmlSerializator = new XmlSerializer(typeof(Customer));
				xmlSerializator.Serialize(xmlFile, customer);
				xmlFile.Flush();
			}

			using (var binFile = File.OpenWrite("Binary.bin"))
			{
				var binSerializator = new BinaryFormatter();
				customerBin = (Customer)binSerializator.Deserialize(binFile);
			}
			//var p = Process.Start("Chrome.exe");
			//p.Kill();

			Console.ReadKey();
		}
	}
}
