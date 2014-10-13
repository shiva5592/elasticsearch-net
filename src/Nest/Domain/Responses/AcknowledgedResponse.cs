using Newtonsoft.Json;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public interface IAcknowledgedResponse : IResponse
	{
		[JsonProperty(PropertyName = "acknowledged")]
		bool Acknowledged { get; }
	}

	public class AcknowledgedResponse : BaseResponse, IAcknowledgedResponse
	{
		public bool Acknowledged { get; internal set; }
	}
}