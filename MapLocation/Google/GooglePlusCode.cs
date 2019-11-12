namespace MapLocation.Google
{
    using Newtonsoft.Json;

    internal partial class GooglePlusCode
    {
        [JsonProperty("compound_code")]
        internal string CompoundCode { get; set; }

        [JsonProperty("global_code")]
        internal string GlobalCode { get; set; }
    }
}

