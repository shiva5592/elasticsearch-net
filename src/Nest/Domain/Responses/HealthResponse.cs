using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject]
	public interface IHealthResponse : IResponse
	{
		[JsonProperty(PropertyName = "cluster_name")]
		string ClusterName { get; }
		
		[JsonProperty(PropertyName = "status")]
		string Status { get; }
		
		[JsonProperty(PropertyName = "timed_out")]
		bool TimedOut { get; }
		
		[JsonProperty(PropertyName = "number_of_nodes")]
		int NumberOfNodes { get; }
		
		[JsonProperty(PropertyName = "number_of_data_nodes")]
		int NumberOfDataNodes { get; }
		
		[JsonProperty(PropertyName = "active_primary_shards")]
		int ActivePrimaryShards { get; }
		
		[JsonProperty(PropertyName = "active_shards")]
		int ActiveShards { get; }
		
		[JsonProperty(PropertyName = "relocating_shards")]
		int RelocatingShards { get; }
		
		[JsonProperty(PropertyName = "initializing_shards")]
		int InitializingShards { get; }
		
		[JsonProperty(PropertyName = "unassigned_shards")]
		int UnassignedShards { get; }
		
		[JsonProperty(PropertyName = "indices")]
		[JsonConverter(typeof(DictionaryKeysAreNotPropertyNamesJsonConverter))]
		Dictionary<string, IndexHealthStats> Indices { get; }
	}

	public class HealthResponse : BaseResponse, IHealthResponse
	{
		public HealthResponse()
		{
			this.IsValid = true;
		}

		public string ClusterName { get; internal set; }
		
		public string Status { get; internal set; }
		
		public bool TimedOut { get; internal set; }

		public int NumberOfNodes { get; internal set; }
		
		public int NumberOfDataNodes { get; internal set; }

		public int ActivePrimaryShards { get; internal set; }
		
		public int ActiveShards { get; internal set; }
		
		public int RelocatingShards { get; internal set; }
		
		public int InitializingShards { get; internal set; }
		
		public int UnassignedShards { get; internal set; }

		public Dictionary<string, IndexHealthStats> Indices { get; set; }
	}
}
