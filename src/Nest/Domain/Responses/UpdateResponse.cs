using Newtonsoft.Json;

namespace Nest
{
	[JsonObject]
	public interface IUpdateResponse : IResponse
	{
		[JsonProperty(PropertyName = "_shards")]
		ShardsMetaData ShardsHit { get; }
		[JsonProperty(PropertyName = "_index")]
		string Index { get; }
		[JsonProperty(PropertyName = "_type")]
		string Type { get; }
		[JsonProperty(PropertyName = "_id")]
		string Id { get; }
		[JsonProperty(PropertyName = "_version")]
		string Version { get; }
	}

	public class UpdateResponse : BaseResponse, IUpdateResponse
	{
		public ShardsMetaData ShardsHit { get; private set; }

		public string Index { get; private set; }
		public string Type { get; private set; }
		public string Id { get; private set; }
		public string Version { get; private set; }
	}
}
