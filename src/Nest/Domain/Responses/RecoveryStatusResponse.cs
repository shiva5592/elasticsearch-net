using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject]
	public interface IRecoveryStatusResponse : IResponse
	{
		[JsonConverter(typeof(DictionaryKeysAreNotPropertyNamesJsonConverter))]
		Dictionary<string, RecoveryStatus> Indices { get; set; }
	}

	public class RecoveryStatusResponse : BaseResponse, IRecoveryStatusResponse
	{

		public Dictionary<string, RecoveryStatus> Indices { get; set; } 
	}
}