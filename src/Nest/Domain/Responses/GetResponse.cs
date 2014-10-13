using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Nest.Domain;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject(MemberSerialization.OptIn)]
	public interface IGetResponse<T> : IResponse where T : class
	{
		[JsonProperty(PropertyName = "found")]
		bool Found { get; }
		[JsonProperty(PropertyName = "_index")]
		string Index { get; }
		[JsonProperty(PropertyName = "_type")]
		string Type { get; }
		[JsonProperty(PropertyName = "_id")]
		string Id { get; }
		[JsonProperty(PropertyName = "_version")]
		string Version { get; }
		[JsonProperty(PropertyName = "_source")]
		T Source { get; }
		
		FieldSelection<T> Fields { get; }
	}

	public class GetResponse<T> : BaseResponse, IGetResponse<T> where T : class
	{
		private IDictionary<string, object> _fieldValues;

		public string Index { get; private set; }

		public string Type { get; private set; }

		public string Id { get; private set; }

		public string Version { get; private set; }

		public bool Found { get; private set; }

		public T Source { get; private set; }

		[JsonConverter(typeof(DictionaryKeysAreNotPropertyNamesJsonConverter))]
		[JsonProperty(PropertyName = "fields")]
		internal IDictionary<string, object> FieldValues
		{
			get { return _fieldValues; }
			set { _fieldValues = value; }
		}

		private FieldSelection<T> _fields = null; 
		public FieldSelection<T> Fields
		{
			get
			{
				if (_fields != null)
					return _fields;

				if (this.ConnectionStatus == null)
					return null;
				var realSettings = this.ConnectionStatus.Settings as IConnectionSettingsValues;

				_fields = new FieldSelection<T>(realSettings, FieldValues);
				return _fields;
			}
		}

		public K[] FieldValue<TBindTo, K>(Expression<Func<TBindTo, object>> objectPath)
			where TBindTo : class
		{
			if (this.Fields == null) return default(K[]);
			return this.Fields.FieldValues<TBindTo,K>(objectPath);
		}

		public K FieldValue<K>(string path)
		{
			if (this.Fields == null) return default(K);
			return this.Fields.FieldValues<K>(path);
		}

	}
}
