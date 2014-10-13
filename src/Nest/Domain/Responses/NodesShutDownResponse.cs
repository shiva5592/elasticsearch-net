using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nest
{

	[JsonObject]
	public interface INodesShutdownResponse : IResponse
	{
		[JsonProperty("cluster_name")]
		string ClusterName { get; set; }

		[JsonProperty("nodes")]
		Dictionary<string, Dictionary<string, string>> Nodes { get; set; }
	}

	public class NodesShutdownResponse : BaseResponse, INodesShutdownResponse
	{
		public string ClusterName { get; set; }

		public Dictionary<string, Dictionary<string, string>> Nodes { get; set; }
	}
}
