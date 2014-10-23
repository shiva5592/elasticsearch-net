using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elasticsearch.Net.Connection;
using StatsdClient;

namespace Elasticsearch.Net.Statsd
{
	public static class ConnectionSettingsExtensions
	{
		/// <summary>
		/// Configure the client to output request metrics to statsd
		/// </summary>
		/// <param name="settings">the object we are extending</param>
		/// <param name="statsdEndpoint">the statsd uri we want to write to</param>
		/// <param name="prefix">The global prefix we want to give the statsd metrics</param>
		public static ConnectionConfiguration<T> OutputMetricsToStatsD<T>(
			this ConnectionConfiguration<T> settings,
			Uri statsdEndpoint, string prefix = null
			)
 			where T : ConnectionConfiguration<T>
		{
			settings.EnableMetrics();
			settings.AddResponseHandler(new StatsdResponseHandler(statsdEndpoint, prefix));
		}
	}


	class StatsdResponseHandler : IResponseHandler
	{
		private static string _metricsNamespace = "ElasticsearchNetClient";
		private readonly StatsdClient.Statsd _statsd;

		internal StatsdResponseHandler(Uri statsdEndpoint, string prefix = null)
		{
			_statsd = new StatsdClient.Statsd(statsdEndpoint.Host, statsdEndpoint.Port, prefix);
		}

		public void Handle(IElasticsearchResponse response) 
		{
			var responseSettings = response.Settings;

			if (!responseSettings.MetricsEnabled) return;

			var callMetrics = response.Metrics;
			_statsd.LogTiming(_metricsNamespace + ".Duration.Deserialization.", (int)callMetrics.DeserializationTime);
			_statsd.LogTiming(_metricsNamespace + ".Duration.Serialization", (int)callMetrics.SerializationTime);
			_statsd.LogTiming(_metricsNamespace + ".Duration.Total", (callMetrics.CompletedOn - callMetrics.StartedOn).Milliseconds);
			_statsd.LogCount(_metricsNamespace + ".Request.NumberOfRetries", response.NumberOfRetries);

			var connectionPool = responseSettings.ConnectionPool;
			var endpointStates = connectionPool.EndpointStates;

			var deadNodes = endpointStates.Values.Count(v => !v.IsAlive);
			var aliveNodes = endpointStates.Values.Count(v => v.IsAlive);

			_statsd.LogGauge(_metricsNamespace + ".ConnectionPool.Dead", aliveNodes);
			_statsd.LogGauge(_metricsNamespace + ".ConnectionPool.Alive", deadNodes);
		}
	}
}
