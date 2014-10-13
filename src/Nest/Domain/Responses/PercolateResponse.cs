using System.Collections.Generic;
using Elasticsearch.Net;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject]
	public interface IPercolateCountResponse : IResponse
	{
		[JsonProperty(PropertyName = "took")]
		int Took { get; }

		[JsonProperty(PropertyName = "total")]
		long Total { get; }
	}


	public interface IPercolateResponse : IPercolateCountResponse
	{
		IEnumerable<PercolatorMatch> Matches { get; }
	}

	public class PercolateCountResponse : BaseResponse, IPercolateCountResponse
	{
		public PercolateCountResponse()
		{
			this.IsValid = true;
		}

		public int Took { get; internal set; }

		public long Total { get; internal set; }
		
		/// <summary>
		/// The individual error for separate requests on the _mpercolate API
		/// </summary>
		[JsonProperty(PropertyName = "error")]
		internal string Error { get; set; }

		public override ElasticsearchServerError ServerError
		{
			get
			{
				if (this.Error.IsNullOrEmpty()) return base.ServerError;
				return new ElasticsearchServerError
				{
					Error = this.Error,
					Status = 500
				};
			}
		}
	}

	[JsonObject]
	public class PercolateResponse : PercolateCountResponse, IPercolateResponse
	{
		[JsonProperty(PropertyName = "matches")]
		public IEnumerable<PercolatorMatch> Matches { get; internal set; }
	}

	public class PercolatorMatch
	{
		[JsonProperty(PropertyName = "_index")]
		public string Index { get; set; }
		[JsonProperty(PropertyName = "_id")]
		public string Id { get; set; }
	}
}