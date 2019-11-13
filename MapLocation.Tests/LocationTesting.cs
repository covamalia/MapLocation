using System;
using Xunit;
using MapLocation;

namespace MapLocation.Tests
{
    public class LocationTesting
    {
        [Fact]
        public void MonopolyTest()
        {
            MapImageOptions mapImageOptions = new MapImageOptions
            {
                MapImageScale = MapImageScale.Further,
                MapImageSize = MapImageSize.Size300x600
            };
            MapOptions mapOptions = new MapOptions
            {
                ApiKey = Environment.GetEnvironmentVariable("GoogleAPIKey", EnvironmentVariableTarget.Machine),
                MapType=MapType.GoogleMaps,
                MapImageOptions=mapImageOptions
            };
            Maps maps = new Maps(mapOptions);
            
            MapData mapDataOldKentRoad = maps.GetMapDataFromLatLong(51.492171, -0.08305739);
            Assert.Contains("Old Kent", mapDataOldKentRoad.Street);

            MapData mapDataMayfair = maps.GetMapDataFromLatLong(51.509947, -0.1560481);
            Assert.Contains("Mayfair", mapDataMayfair.Address);
        }
    }
}
