using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject]
	public interface ISegmentsResponse : IResponse
	{
		[JsonProperty(PropertyName = "_shards")]
		ShardsMetaData Shards { get; }
		[JsonProperty(PropertyName = "indices")]
		[JsonConverter(typeof(DictionaryKeysAreNotPropertyNamesJsonConverter))]
		Dictionary<string, IndexSegment> Indices { get; set; }
	}

	public class SegmentsResponse : BaseResponse, ISegmentsResponse
	{

		public ShardsMetaData Shards { get; internal set; }

		public Dictionary<string, IndexSegment> Indices { get; set; } 

		
	}
}