namespace MapLocation.Google
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    internal partial class GoogleAddressComponent
    {
        [JsonProperty("long_name")]
        internal string LongName { get; set; }

        [JsonProperty("short_name")]
        internal string ShortName { get; set; }

        [JsonProperty("types")]
        internal List<string> Types { get; set; }
        internal AddressComponentType ComponentType {
            get {
                AddressComponentType c = AddressComponentType.Unknown;
                foreach (var t in Types)
                {
                    switch (t)
                    {
                        case "postal_town":
                            c = AddressComponentType.PostalTown;
                            break;
                        case "postal_code":
                            c = AddressComponentType.PostalCode;
                            break;
                        case "country":
                            c = AddressComponentType.Country;
                            break;
                        case "street_number":
                            c = AddressComponentType.StreetNumber;
                            break;
                        case "route":
                            c = AddressComponentType.Street;
                            break;
                        default:
                            break;
                    }
                }
                return c;
            } 
        }
    }
}

