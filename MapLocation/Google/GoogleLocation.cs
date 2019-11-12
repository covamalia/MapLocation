namespace MapLocation.Google
{
    using Newtonsoft.Json;

    internal partial class GoogleLocation
    {
        [JsonProperty("lat")]
        internal double Lat { get; set; }

        [JsonProperty("lng")]
        internal double Lng { get; set; }
    }
}

