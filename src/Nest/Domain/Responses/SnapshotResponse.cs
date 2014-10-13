using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject]
	public interface ISnapshotResponse : IResponse
	{
		[JsonProperty("accepted")]
		bool Accepted { get; }

		[JsonProperty("snapshot")]
		Snapshot Snapshot { get; set; }
	}

	public class SnapshotResponse : BaseResponse, ISnapshotResponse
	{
		private bool _accepted = false;
		
		public bool Accepted
		{
			get
			{
				return  _accepted ? _accepted : this.Snapshot != null;
			}
			internal set { _accepted = value; }
		}

		public Snapshot Snapshot { get; set; }

	}
}
