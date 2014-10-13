using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Nest
{
	[JsonObject]
	public interface IValidateResponse : IResponse
	{
		[JsonProperty(PropertyName = "valid")]
		bool Valid { get; }

		[JsonProperty(PropertyName = "_shards")]
		ShardsMetaData Shards { get; }

		[JsonProperty(PropertyName = "explanations")]
		IList<ValidationExplanation> Explanations { get; set; }
	}

	public class ValidateResponse : BaseResponse, IValidateResponse
	{
		public ValidateResponse()
		{
			this.IsValid = true;
		}

		public bool Valid { get; internal set; }

		public ShardsMetaData Shards { get; internal set; }

		/// <summary>
		/// Gets the explanations if Explain() was set.
		/// </summary>
		public IList<ValidationExplanation> Explanations { get; set;}
	}
}