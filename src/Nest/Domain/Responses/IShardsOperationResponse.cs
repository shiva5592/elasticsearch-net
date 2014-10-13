using Newtonsoft.Json;

namespace Nest
{
	[JsonObject]
	public interface IShardsOperationResponse : IResponse
	{
		[JsonProperty("_shards")]
		ShardsMetaData Shards { get; }
	}

	public class ShardsOperationResponse : BaseResponse, IShardsOperationResponse
	{
		public ShardsMetaData Shards { get; internal set; }
	}
}