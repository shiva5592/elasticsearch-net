using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elasticsearch.Net
{
	public interface IResponseHandler
	{
		/// <summary>
		/// Provides a global hook to handle every response received by the client
		/// </summary>
		void Handle(IElasticsearchResponse response);
	}

	public static class ResponseHandler
	{
		internal class LamdbaResponseHandler : IResponseHandler
		{
			private readonly Action<IElasticsearchResponse> _handler;

			internal LamdbaResponseHandler(Action<IElasticsearchResponse> handler)
			{
				_handler = handler;
			}

			public void Handle(IElasticsearchResponse response)
			{
				if (_handler != null) _handler(response);
			}
		}


		public static IResponseHandler From(Action<IElasticsearchResponse> handler)
		{
			return new LamdbaResponseHandler(handler);
		}
	}
}
