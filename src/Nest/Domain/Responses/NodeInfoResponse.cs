using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject]
	public interface INodeInfoResponse : IResponse
	{
		[JsonProperty(PropertyName = "cluster_name")]
		string ClusterName { get; }

		[JsonProperty(PropertyName = "nodes")]
		[JsonConverter(typeof(DictionaryKeysAreNotPropertyNamesJsonConverter))]
		Dictionary<string, NodeInfo> Nodes { get; }
	}

	public class NodeInfoResponse : BaseResponse, INodeInfoResponse
	{
		public NodeInfoResponse()
		{
			this.IsValid = true;
		}

		public string ClusterName { get; internal set; }

		public Dictionary<string, NodeInfo> Nodes { get; set; }
	}
}
