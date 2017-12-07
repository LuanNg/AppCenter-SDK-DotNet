using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.AppCenter.EnhancedTransmission
{
    internal class EnhancedTransmissionConfiguration
    {
        [JsonProperty("n")]
        internal int TestCount { get; set; }

        [JsonProperty("e")]
        internal IList<TestEndpoint> TestEndpoints { get; set; }

        [JsonProperty("r")]
        internal IList<string> ReportEndpoints { get; set; }
    }
}
