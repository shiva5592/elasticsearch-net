using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject]
	public interface IGetSnapshotResponse : IResponse
	{
		[JsonProperty("snapshots")]
		IEnumerable<Snapshot> Snapshots { get; set; }
	}

	public class GetSnapshotResponse : BaseResponse, IGetSnapshotResponse
	{
		public IEnumerable<Snapshot> Snapshots { get; set; }
	}
}
