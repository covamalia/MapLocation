namespace MapLocation.Google
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    internal partial class GoogleResult
    {
        [JsonProperty("address_components")]
        internal List<GoogleAddressComponent> AddressComponents { get; set; }

        [JsonProperty("formatted_address")]
        internal string FormattedAddress { get; set; }

        [JsonProperty("geometry")]
        internal GoogleGeometry Geometry { get; set; }

        [JsonProperty("place_id")]
        internal string PlaceId { get; set; }

        [JsonProperty("plus_code", NullValueHandling = NullValueHandling.Ignore)]
        internal GooglePlusCode PlusCode { get; set; }

        [JsonProperty("types")]
        internal List<string> Types { get; set; }
    }
}

