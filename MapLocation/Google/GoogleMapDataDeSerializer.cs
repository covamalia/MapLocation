namespace MapLocation.Google
{
    using Newtonsoft.Json;

    internal partial class GoogleMapData
    {
        internal static GoogleMapData FromJson(string json) => JsonConvert.DeserializeObject<GoogleMapData>(json, GoogleConverter.Settings);
    }
}


