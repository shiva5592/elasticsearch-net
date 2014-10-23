using System;
using System.Collections.Generic;
using System.Threading;
using Elasticsearch.Net.Connection;

namespace Elasticsearch.Net.ConnectionPool
{
	public class SingleNodeConnectionPool : IConnectionPool
	{
		private readonly Uri _uri;
		private readonly EndpointState state = new EndpointState();

		public int MaxRetries { get { return 0; } }

		public bool AcceptsUpdates { get { return false; } }

		public IDictionary<Uri, EndpointState> EndpointStates { get; private set; }

		public SingleNodeConnectionPool(Uri uri)
		{
			//this makes sure that paths stay relative i.e if the root uri is:
			//http://my-saas-provider.com/instance
			if (!uri.OriginalString.EndsWith("/"))
				uri = new Uri(uri.OriginalString + "/");
			_uri = uri;
			this.EndpointStates = new Dictionary<Uri, EndpointState> { { uri, state } };
		}


		public Uri GetNext(int? initialSeed, out int seed, out bool shouldPingHint)
		{
			seed = 0;
			shouldPingHint = false;
			Interlocked.Increment(ref state.Used);
			return _uri;
		}

		public void MarkDead(Uri uri, int? deadTimeout = null, int? maxDeadTimeout = null)
		{
			state.IsAlive = false;
		}

		public void MarkAlive(Uri uri)
		{
			state.IsAlive = true;
		}

		public void UpdateNodeList(IList<Uri> newClusterState, Uri sniffNode = null)
		{
		}

	}
}