using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject]
	public interface IBulkResponse : IResponse
	{
		[JsonProperty("took")]
		int Took { get; }
		
		[JsonProperty("errors")]
		bool Errors { get; }
		
		[JsonProperty("items")]
		IEnumerable<BulkOperationResponseItem> Items { get; }
		
		[JsonIgnore]
		IEnumerable<BulkOperationResponseItem> ItemsWithErrors { get; }
	}
}