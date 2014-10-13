using Newtonsoft.Json;

namespace Nest
{
	[JsonObject]
	public interface IRootInfoResponse : IResponse
	{
		[JsonProperty(PropertyName = "status")]
		int Status { get; }

		[JsonProperty(PropertyName = "name")]
		string Name { get; }

		[JsonProperty(PropertyName = "tagline")]
		string Tagline { get;  }

		[JsonProperty(PropertyName = "version")]
		ElasticsearchVersionInfo Version { get;  }
	}

	public class RootInfoResponse : BaseResponse, IRootInfoResponse
	{
		public RootInfoResponse()
		{
			this.IsValid = true;
		}

		public int Status { get; internal set; }

		public string Name { get; internal set; }

		public string Tagline { get; internal set; }
		
		public ElasticsearchVersionInfo Version { get; internal set; }

	}
}