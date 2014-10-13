using System.Collections.Generic;
using System.Linq;
using Nest.Resolvers.Converters;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject(MemberSerialization.OptIn)]
	[JsonConverter(typeof(IndexSettingsResponseConverter))]
	public interface IIndexSettingsResponse : IResponse
	{
		[JsonIgnore]
		IndexSettings IndexSettings { get; }

		[JsonIgnore]
		Dictionary<string, IndexSettings> Nodes { get; set; }
	}

	public class IndexSettingsResponse : BaseResponse, IIndexSettingsResponse
	{
		public IndexSettings IndexSettings
		{
			get { return Nodes.HasAny() ? Nodes.First().Value : null; }
		}

		public Dictionary<string, IndexSettings> Nodes { get; set; }

	}
}
