using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Nest
{
    [JsonObject]
    public interface ITermVectorResponse : IResponse
    {
        [JsonProperty("found")]
        bool Found { get; }

        [JsonProperty("term_vectors")]
        IDictionary<string, TermVector> TermVectors { get; }
    }

    public class TermVectorResponse : BaseResponse, ITermVectorResponse
    {
        public TermVectorResponse()
        {
            IsValid = true;
            TermVectors = new Dictionary<string, TermVector>();
        }

        public bool Found { get; internal set; }

        public IDictionary<string, TermVector> TermVectors { get; internal set; }
    }
}
