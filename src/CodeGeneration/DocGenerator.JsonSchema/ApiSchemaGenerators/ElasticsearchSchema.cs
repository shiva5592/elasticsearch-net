using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using Nest;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DocGenerator.JsonSchema
{
	public class ElasticsearchSchema : IDisposable
	{
		private readonly string _endpoint;
		private readonly static string _outputFolder = @"..\..\Output\";


		public ElasticsearchSchema(string endpoint)
		{
			_endpoint = endpoint;
		}

		public void Request<T>() where T : IRequest { For<T>("request"); }
		public void Response<T>() where T : IResponse { For<T>("response"); }
		public void Domain<T>(string subFolder = null)
		{
			For<T>((string.IsNullOrEmpty(subFolder) ? "" : subFolder + @"\") + typeof(T).Name.ToLowerInvariant());
		}

		public static bool ValidateAll()
		{
			var re = new Regex("^(.+)_example(.+)$");
			var schemas = Directory.GetFiles(_outputFolder, "*.*", SearchOption.AllDirectories)
				.Where(f => re.IsMatch(f))
				.Select(f => new { schema = LocalFullPath(re.Replace(f, "$1$2")), example = LocalFullPath(f) })
				.Select(v => Validate(v.schema, v.example))
				.ToList()
				;

			return schemas.All(errors => errors.Count == 0);
		}

		private static IList<string> Validate(string file, string exampleFile)
		{
			var schemaJson = ReadJsonFromFile(file);
			var exampleJson = ReadJsonFromFile(exampleFile);
			var schemaResolver = new JsonSchemaResolver { ResolveExternals = true };
			var schema = Newtonsoft.Json.Schema.JsonSchema.Parse(schemaJson, schemaResolver);

			var example = JObject.Parse(exampleJson);

			IList<string> errors = new List<string>();
			var valid = example.IsValid(schema, out errors);
			return errors;
		}

		private static string ReadJsonFromFile(string file)
		{
			using (StreamReader reader = new StreamReader(file))
			{
				return reader.ReadToEnd();
			}
		}

		private void For<T>(string fileName)
		{
			var type = typeof(T);
			var jsonSchemaGenerator = new JsonSchemaGenerator();
			jsonSchemaGenerator.UndefinedSchemaIdHandling = UndefinedSchemaIdHandling.UseTypeName;
			var schema = jsonSchemaGenerator.Generate(type);
			schema.Title = type.Name;
			var file = LocalUri(string.Format("{0}.json", fileName));
			using (var writer = new StreamWriter(file))
			using (var jsonTextWriter = new JsonTextWriter(writer) { Formatting = Formatting.Indented })
				schema.WriteTo(jsonTextWriter);
		}

		private string LocalUri(string file)
		{
			var folder = string.Format(@"{0}\{1}\{2}", _outputFolder, _endpoint, file);
			return LocalFullPath(folder);
		}

		private static string LocalFullPath(string folder)
		{
			var basePath = Path.Combine(Assembly.GetEntryAssembly().Location, @"..\" + folder);
			var assemblyPath = Path.GetFullPath((new Uri(basePath)).LocalPath);
			var dir = Path.GetDirectoryName(assemblyPath);
			Directory.CreateDirectory(dir);
			return assemblyPath;
		}

		public void Dispose()
		{
		}
	}
}