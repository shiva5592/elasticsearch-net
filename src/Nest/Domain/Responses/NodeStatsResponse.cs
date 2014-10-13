using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Nest
{
    [JsonObject]
    public interface INodeStatsResponse : IResponse
    {
        [JsonProperty(PropertyName = "cluster_name")]
        string ClusterName { get; }

        [JsonProperty(PropertyName = "nodes")]
		[JsonConverter(typeof(DictionaryKeysAreNotPropertyNamesJsonConverter))]
        Dictionary<string, NodeStats> Nodes { get; }
    }

    public class NodeStatsResponse : BaseResponse, INodeStatsResponse
    {
        public NodeStatsResponse()
        {
            this.IsValid = true;
        }

        public string ClusterName { get; internal set; }

		public Dictionary<string, NodeStats> Nodes { get; set; }
    }
}
