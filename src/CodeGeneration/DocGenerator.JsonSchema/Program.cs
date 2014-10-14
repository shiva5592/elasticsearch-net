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
			var schemas = new ApiSchemaGenerator[]
			{
				new EndpointsGenerator(),
				new FilterDslGenerator(), 
				new QueryDslGenerator()
			};

			foreach (var schema in schemas)
				schema.Generate();

			ElasticsearchSchema.ValidateAll();
		}
	}
}
