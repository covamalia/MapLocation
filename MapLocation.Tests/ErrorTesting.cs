using MapLocation.Exceptions;
using System;
using Xunit;

namespace MapLocation.Tests
{
    public class ErrorTesting
    {
        [Fact]
        public void GoogleNoAPI()
        {
            MapOptions mapOptions = new MapOptions { MapType = MapType.GoogleMaps };
            Exception? myException = null;
            try
            {
                Maps maps = new Maps(mapOptions);
            }
            catch (MissingMapOptionException ex)
            {
                myException = ex;
            }
            Assert.NotNull(myException);
        }
        [Fact]
        public void GoogleNoImageOptionsRequestImage()
        {
            MapOptions mapOptions = new MapOptions { ApiKey = Environment.GetEnvironmentVariable("GoogleAPIKey", EnvironmentVariableTarget.Machine), MapType = MapType.GoogleMaps };
            Exception? myException = null;
            Maps maps = new Maps(mapOptions);
            try
            {
                maps.GetMapImageFromLatLong(((double)new Random().Next(-900000, 900000)) / (double)10000, ((double)new Random().Next(-900000, 900000)) / (double)10000);
            }
            catch (MissingMapOptionException ex)
            {
                myException = ex;
            }
            Assert.NotNull(myException);
            Assert.Contains("Map Image", myException.Message);
        }
        [Fact]
        public void GoogleNoImageSizeOptionsRequestImage()
        {
            MapImageOptions mapImageOptions = new MapImageOptions { MapImageScale = MapImageScale.Further };
            MapOptions mapOptions = new MapOptions { ApiKey = Environment.GetEnvironmentVariable("GoogleAPIKey", EnvironmentVariableTarget.Machine), MapType = MapType.GoogleMaps, MapImageOptions=mapImageOptions };
            Exception? myException = null;
            Maps maps = new Maps(mapOptions);
            try
            {
                maps.GetMapImageFromLatLong(((double)new Random().Next(-900000, 900000)) / (double)10000, ((double)new Random().Next(-900000, 900000)) / (double)10000);
            }
            catch (MissingMapOptionException ex)
            {
                myException = ex;
            }
            Assert.NotNull(myException);
            Assert.Contains("Map Image Size", myException.Message);
        }
        [Fact]
        public void GoogleNoImageScaleOptionsRequestImage()
        {
            MapImageOptions mapImageOptions = new MapImageOptions { MapImageSize = MapImageSize.Size300x600 };
            MapOptions mapOptions = new MapOptions { ApiKey = Environment.GetEnvironmentVariable("GoogleAPIKey", EnvironmentVariableTarget.Machine), MapType = MapType.GoogleMaps, MapImageOptions = mapImageOptions };
            Exception? myException = null;
            Maps maps = new Maps(mapOptions);
            try
            {
                maps.GetMapImageFromLatLong(((double)new Random().Next(-900000, 900000)) / (double)10000, ((double)new Random().Next(-900000, 900000)) / (double)10000);
            }
            catch (MissingMapOptionException ex)
            {
                myException = ex;
            }
            Assert.NotNull(myException);
            Assert.Contains("Map Image Scale", myException.Message);
        }
        [Fact]
        public void NoMapType()
        {
            MapOptions mapOptions = new MapOptions { ApiKey = Environment.GetEnvironmentVariable("GoogleAPIKey", EnvironmentVariableTarget.Machine) };
            Exception? myException = null;
            try
            {
                Maps maps = new Maps(mapOptions);
            }
            catch (MissingMapOptionException ex)
            {
                myException = ex;
            }
            Assert.NotNull(myException);
            Assert.Contains("No Map Type", myException.Message);
        }
        [Fact]
        public void GoogleMapsWorkingLatLongData()
        {
            MapOptions mapOptions = new MapOptions { ApiKey = Environment.GetEnvironmentVariable("GoogleAPIKey", EnvironmentVariableTarget.Machine), MapType = MapType.GoogleMaps };

            Exception? myException = null;
            try
            {
                Maps maps = new Maps(mapOptions);
                MapData mapData = maps.GetMapDataFromLatLong(((double)new Random().Next(-900000, 900000)) / (double)10000, ((double)new Random().Next(-900000, 900000)) / (double)10000);
            }
            catch (MissingMapOptionException ex)
            {
                myException = ex;
            }
            Assert.Null(myException);
        }
        [Fact]
        public void GoogleMapsWorkingImageData()
        {
            MapImageOptions mapImageOptions = new MapImageOptions { MapImageSize = MapImageSize.Size300x600, MapImageScale=MapImageScale.Further };
            MapOptions mapOptions = new MapOptions { ApiKey = Environment.GetEnvironmentVariable("GoogleAPIKey", EnvironmentVariableTarget.Machine), MapType=MapType.GoogleMaps, MapImageOptions=mapImageOptions };
            byte[] mapImage=new byte[0];
            Exception? myException = null;
            try
            {
                Maps maps = new Maps(mapOptions);
                mapImage = maps.GetMapImageFromLatLong(((double)new Random().Next(-900000, 900000)) / (double)10000, ((double)new Random().Next(-900000, 900000)) / (double)10000);
            }
            catch (MissingMapOptionException ex)
            {
                myException = ex;
            }
            Assert.Null(myException);
            Assert.NotEmpty(mapImage);
        }
    }
}
