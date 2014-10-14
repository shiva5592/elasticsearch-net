using Newtonsoft.Json;

namespace Nest
{
	[JsonObject]
	public interface ICountResponse : IResponse
	{
		[JsonProperty(PropertyName = "count")]
		long Count { get; }

		[JsonProperty(PropertyName = "_shards")]
		ShardsMetaData Shards { get; }
	}

	public class CountResponse : BaseResponse, ICountResponse
	{
		public CountResponse()
		{
			this.IsValid = true;
		}

		public long Count { get; internal set; }

		public ShardsMetaData Shards { get; internal set; }
	}
}