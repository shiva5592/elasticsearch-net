using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{
	[JsonObject]
	public interface IClusterStatsResponse : IResponse
	{
		[JsonProperty("cluster_name")]
		string ClusterName { get; set; }

		[JsonProperty("status")]
		string Status { get; set; }

		[JsonProperty("indices")]
		IndicesStats Indices { get; set; }

		[JsonProperty("nodes")]
		ClusterNodesStats Nodes { get; set; }
	}

	public class ClusterStatsResponse : BaseResponse, IClusterStatsResponse
	{
		public string ClusterName { get; set; }
		public string Status { get; set; }

		public IndicesStats Indices { get; set; }

		public ClusterNodesStats Nodes { get; set; }
	}
}
