namespace MapLocation.Google
{
    using System;
    using Newtonsoft.Json;

    internal class GoogleLocationTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(GoogleLocationSearchType) || t == typeof(GoogleLocationSearchType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "APPROXIMATE":
                    return GoogleLocationSearchType.Approximate;
                case "GEOMETRIC_CENTER":
                    return GoogleLocationSearchType.GeometricCenter;
                case "ROOFTOP":
                    return GoogleLocationSearchType.Rooftop;
            }
            throw new Exception("Cannot unmarshal type LocationSearchType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (GoogleLocationSearchType)untypedValue;
            switch (value)
            {
                case GoogleLocationSearchType.Approximate:
                    serializer.Serialize(writer, "APPROXIMATE");
                    return;
                case GoogleLocationSearchType.GeometricCenter:
                    serializer.Serialize(writer, "GEOMETRIC_CENTER");
                    return;
                case GoogleLocationSearchType.Rooftop:
                    serializer.Serialize(writer, "ROOFTOP");
                    return;
            }
            throw new Exception("Cannot marshal type LocationSearchType");
        }

        public static readonly GoogleLocationTypeConverter Singleton = new GoogleLocationTypeConverter();
    }
}

