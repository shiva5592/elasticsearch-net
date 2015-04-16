using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elasticsearch.Net.Connection;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Ploeh.AutoFixture;
using SearchApis.RequestBody;
using Xunit;

namespace Nest.Tests.Literate
{
	public abstract class EndpointUsageTest<TResponse>
		: SerializationTest
		where TResponse : IResponse
	{
		public abstract int ExpectStatusCode { get; }
		public abstract bool ExpectIsValid { get; }
		public abstract void AssertUrl(string url);

		protected TResponse InstanceInitializer { get; private set; }
		protected TResponse InstanceFluent { get; private set; }

		protected abstract TResponse Initializer(IElasticClient client);
		protected abstract TResponse Fluent(IElasticClient client);

		public EndpointUsageTest()
		{
			var client = this.Client();
			this.InstanceInitializer = this.Initializer(client);
			this.InstanceFluent = this.Fluent(client);
		}

		protected virtual ConnectionSettings ConnectionSettings(ConnectionSettings settings) => settings; 
		protected virtual IElasticClient Client() => TestConfiguration.GetClient(ConnectionSettings); 

		private void Dispatch(Action<TResponse> assert)
		{
			assert(this.InstanceFluent);
			assert(this.InstanceInitializer);
		}

		[Fact] void HandlesStatusCode() =>
			this.Dispatch(r=>r.ConnectionStatus.HttpStatusCode.Should().Be(this.ExpectStatusCode));

		[Fact] private void Serializes() => this.Dispatch(r=> this.AssertSerializes(r));

	}
}
