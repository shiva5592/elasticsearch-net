using Newtonsoft.Json;
using System.Collections.Generic;

namespace Nest
{
	[JsonObject]
	public interface IWarmerResponse : IResponse
	{
		[JsonConverter(typeof(DictionaryKeysAreNotPropertyNamesJsonConverter))]
		Dictionary<string, Dictionary<string, WarmerMapping>> Indices { get; }
	}

	public class WarmerResponse : BaseResponse, IWarmerResponse
	{
		public Dictionary<string, Dictionary<string, WarmerMapping>> Indices { get; internal set; }

	}
}
