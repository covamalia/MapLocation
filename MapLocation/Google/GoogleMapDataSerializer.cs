namespace MapLocation.Google
{
    using Newtonsoft.Json;

    internal static class GoogleMapDataSerializer
    {
        internal static string ToJson(this GoogleMapData self) => JsonConvert.SerializeObject(self, GoogleConverter.Settings);
    }
}

