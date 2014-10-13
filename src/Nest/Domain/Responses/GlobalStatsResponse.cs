using Newtonsoft.Json;
using System.Collections.Generic;

namespace Nest
{
	[JsonObject]
	public interface IGlobalStatsResponse : IResponse
	{
		[JsonProperty(PropertyName = "_shards")]
		ShardsMetaData Shards { get; }
	
		[JsonProperty(PropertyName = "_all")]
		Stats Stats { get; set; }
		
		[JsonProperty(PropertyName = "indices")]
		[JsonConverter(typeof(DictionaryKeysAreNotPropertyNamesJsonConverter))]
		Dictionary<string, Stats> Indices { get; set; }
	}

	public class GlobalStatsResponse : BaseResponse, IGlobalStatsResponse
	{
		public ShardsMetaData Shards { get; internal set; }

		public Stats Stats { get; set; }

		public Dictionary<string, Stats> Indices { get; set; }

	}
}