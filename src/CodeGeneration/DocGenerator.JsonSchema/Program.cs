using DocGenerator.JsonSchema.ApiSchemaGenerators;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocGenerator.JsonSchema
{
	class Program
	{
		static void Main(string[] args)
		{
			//GenerateSchemas(new EndpointsGenerator(), new FilterDslGenerator(), new QueryDslGenerator());
			Validate();

			Console.ReadLine();
		}

		private static void GenerateSchemas(params ApiSchemaGenerator[] generators)
		{
			foreach (var generator in generators)
				generator.Generate();
		}

		private static void Validate()
		{
			var results = ElasticsearchSchema.ValidateAll();
			var invalid = results.Where(r => r.Value.Count > 0).ToList();
			foreach(var file in invalid)
				foreach(var error in file.Value)
					Console.WriteLine("{0}: {1}", file, error);

			Console.WriteLine("\nValidation complete.");
			Console.WriteLine("Total Files: {0}", results.Count);
			Console.WriteLine("Invalid: {0}", invalid.Count);
			Console.WriteLine("Total Errors: {0}", invalid.SelectMany(f => f.Value).Count());
		}
	}
}
