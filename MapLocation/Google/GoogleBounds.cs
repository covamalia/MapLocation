namespace MapLocation.Google
{
    using Newtonsoft.Json;

    internal partial class GoogleBounds
    {
        [JsonProperty("northeast")]
        internal GoogleLocation Northeast { get; set; }

        [JsonProperty("southwest")]
        internal GoogleLocation Southwest { get; set; }
    }
}

