using System.Security.Cryptography.X509Certificates;
using Nest.Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Nest
{
	[JsonObject]
	public interface IExplainResponse<T> : IResponse
		where T : class
	{
		[JsonProperty(PropertyName = "matched")]
		bool Matched { get; }

		[JsonProperty(PropertyName = "explanation")]
		ExplanationDetail Explanation { get; }

		[JsonProperty(PropertyName = "get")]
		ExplainGet<T> Get { get; }

		T Source { get; }

		FieldSelection<T> Fields { get; }
	}

	public class ExplainResponse<T> : BaseResponse, IExplainResponse<T>
		where T : class
	{
		public ExplainResponse()
		{
			this.IsValid = true;
		}

		public bool Matched { get; internal set; }

		public ExplanationDetail Explanation { get; internal set;}

		public ExplainGet<T> Get { get; internal set;}

		public T Source
		{
			get
			{
				if (this.Get == null) return null;
				return this.Get.Source;
			}
		}

		public FieldSelection<T> Fields
		{
			get
			{
				if (this.Get == null) return null;
				return new FieldSelection<T>(this.Settings, this.Get._fields);
			}
		}
	}
}