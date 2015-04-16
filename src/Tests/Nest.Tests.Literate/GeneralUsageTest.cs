using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest.Tests.Literate
{
	public abstract class GeneralUsageTest<TInterface, TDescriptor, TInitializer>
		: SerializationTest
		where TDescriptor : TInterface, new() 
		where TInitializer : TInterface
	{
		protected TInterface InstanceInitializer { get; private set; }
		protected TInterface InstanceFluent { get; private set; }

		protected abstract TInitializer Initializer(IElasticClient client);
		protected abstract Func<TDescriptor, TInterface> Fluent(IElasticClient client);

		public GeneralUsageTest()
		{
			var client = this.Client();
			this.InstanceInitializer = this.Initializer(client);
			var func = this.Fluent(client);
			this.InstanceFluent = func(new TDescriptor());
		}

		protected virtual ConnectionSettings ConnectionSettings(ConnectionSettings settings) => settings; 
		protected virtual IElasticClient Client() => TestConfiguration.GetClient(ConnectionSettings); 

		protected virtual void Setup(IElasticClient client) { }
		protected virtual void Teardown(IElasticClient client) { }


		[Fact] private void SerializesInitializer() => this.AssertSerializes(this.InstanceInitializer);

		[Fact] private void SerializesFluent() => this.AssertSerializes(this.InstanceFluent);
	}
}
