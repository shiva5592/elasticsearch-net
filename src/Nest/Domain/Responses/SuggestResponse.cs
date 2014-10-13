using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Nest
{
	[JsonObject]
	public interface ISuggestResponse : IResponse
	{
        [JsonProperty("shards")]
		ShardsMetaData Shards { get; }

		[JsonProperty("suggestions")]
		IDictionary<string, Suggest[]> Suggestions { get; set; }
	}

	public class SuggestResponse : BaseResponse, ISuggestResponse
	{
		public SuggestResponse()
		{
			this.IsValid = true;
			this.Suggestions = new Dictionary<string, Suggest[]>();
		}
		
		public ShardsMetaData Shards { get; internal set; }

		public IDictionary<string, Suggest[]> Suggestions { get; set;}
	}
}