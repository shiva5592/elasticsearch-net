using Newtonsoft.Json;

namespace Nest
{
    [JsonObject]
    public interface IIndicesOperationResponse : IResponse
    {
		[JsonProperty(PropertyName = "acknowledged")]
        bool Acknowledged { get; }
    }

	public class IndicesOperationResponse : BaseResponse, IIndicesOperationResponse
    {
		public IndicesOperationResponse()
		{
			this.IsValid = true;
		}

		public bool Acknowledged { get; internal set; }
	}
}