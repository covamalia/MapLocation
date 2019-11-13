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
                default:
                    return GoogleLocationSearchType.Unknown;
            }
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Yeah, we wont want to pass back to the APIs, it's read only :)");
        }

        public static readonly GoogleLocationTypeConverter Singleton = new GoogleLocationTypeConverter();
    }
}

