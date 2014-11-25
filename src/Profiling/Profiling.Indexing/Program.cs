using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Nest;

namespace Profiling.Indexing
{
	class Program
	{
		static IEnumerable<Tester> Testers()
		{
			//yield return new ThriftTester();
			yield return new HttpTester();
			//yield return new HttpClientTester();
		} 

		static void Main(string[] args)
		{
			var defaultTester = new HttpTester();
			var warmup = defaultTester.RunTests(10);

			defaultTester.Client.ClusterSettings(s => s
				.Transient(t=>t
					.Add("index.store.throttle.type", "none")
					.Add("index.refresh_interval", -1)
					//.Add("threadpool.index.size", 100)
				)
			);

			Console.WriteLine("Warmed up caches to start testing, press any key to start tests");
			Console.ReadLine();

			ConsoleKeyInfo key;
			do
			{
				Console.WriteLine("running testers");
				var results = Testers().Select(t => t.RunTests()).ToList();
				Console.WriteLine();
				foreach(var r in results)
					PrintRunResults(r);
				
				Console.WriteLine("\nPress r to index again or any other key to delete indices created by this tool.\n");
				key = Console.ReadKey();
			} while (key.KeyChar == 'r');

			defaultTester.Client.ClusterSettings(s => s
				.Transient(t=>t
					.Add("index.store.throttle.type", "merge")
					.Add("index.refresh_interval", "1s")
				)
			);
			defaultTester.Client.DeleteIndex(d => d.Index(Tester.INDEX_PREFIX + "*"));
		}

		private static void PrintRunResults(RunResults runResult)
		{
			Console.WriteLine("---{0}\t---------------", runResult.TesterName);
			Console.WriteLine("  {0:0,0} msg/s {1} ms {2} docs", 
				runResult.RatePerSecond,
				runResult.ElapsedMillisecond,
				runResult.IndexedDocuments
				);
			var maxEsTime = runResult.EsTimings.Max();
			var meanEsTime = runResult.EsTimings.GetMedian();
			Console.WriteLine("  max es-time:{0} mean es-time:{1}", maxEsTime, meanEsTime);
			Console.WriteLine("  memory before:{0} thread count before:{1}", runResult.Before.MemorySize, runResult.Before.ThreadCount);
			Console.WriteLine("  memory after:{0} thread count after:{1}", runResult.After.MemorySize, runResult.After.ThreadCount);
			Console.WriteLine("  no. batches:{0} batch size:{1}", runResult.NumberOfBatches, runResult.BatchSize);
		}

	}
}
