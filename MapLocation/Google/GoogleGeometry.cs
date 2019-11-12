namespace MapLocation.Google
{
    using Newtonsoft.Json;

    internal partial class GoogleGeometry
    {
        [JsonProperty("location")]
        internal GoogleLocation Location { get; set; }

        [JsonProperty("location_type")]
        internal GoogleLocationSearchType LocationSearchType { get; set; }

        [JsonProperty("viewport")]
        internal GoogleBounds Viewport { get; set; }

        [JsonProperty("bounds", NullValueHandling = NullValueHandling.Ignore)]
        internal GoogleBounds Bounds { get; set; }
    }
}

