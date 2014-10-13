using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Nest
{
    [JsonObject]
    public interface IMultiTermVectorResponse : IResponse
    {
        [JsonProperty("docs")]
        IEnumerable<TermVectorResponse> Documents { get; }
    }

    public class MultiTermVectorResponse : BaseResponse, IMultiTermVectorResponse
    {
        public MultiTermVectorResponse()
        {
            IsValid = true;
            Documents = new List<TermVectorResponse>();
        }

        public IEnumerable<TermVectorResponse> Documents { get; internal set; }
    }
}
