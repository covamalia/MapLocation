namespace MapLocation.Google
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    internal partial class GoogleMapData
    {
        [JsonProperty("plus_code")]
        internal GooglePlusCode PlusCode { get; set; }

        [JsonProperty("results")]
        internal List<GoogleResult> Results { get; set; }

        [JsonProperty("status")]
        internal string Status { get; set; }
    }
}

