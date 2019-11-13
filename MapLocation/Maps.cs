using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MapLocation.Exceptions;
using MapLocation.Google;

namespace MapLocation
{
    public class Maps
    {
        public Maps(MapOptions mapOptions)
        {
            if (mapOptions.MapType == null)
            {
                throw new MissingMapOptionException("No Map Type selected");
            }
            if (mapOptions.MapType==MapType.GoogleMaps && mapOptions.ApiKey==null)
            {
                 throw new MissingMapOptionException("Google Maps requires an API key");
            }
            MapType = (MapType)mapOptions.MapType;
            ApiKey = mapOptions.ApiKey;
            MapImageScale = mapOptions.MapImageOptions?.MapImageScale;
            MapImageSize = mapOptions.MapImageOptions?.MapImageSize;
        }
        private string ApiKey { get; set; }
        private MapType MapType { get; set; }
        private MapImageSize? MapImageSize { get; set; }
        private MapImageScale? MapImageScale { get; set; }
        public MapData GetMapData(Coordinates coordinates)
        {
            return GetFullMapData(coordinates.Latitude,coordinates.Longitude);
        }
        public MapData GetFullMapData(double Latitude, double Longitude)
        {
            MapData mapData = GetMapDataFromLatLong(Latitude, Longitude);
            mapData.MapImage = GetMapImageFromLatLong(Latitude, Longitude);
            mapData.MapUrl = GetMapUrlFromLatLong(Latitude, Longitude);
            return mapData;
        }

        private string GetMapUrlFromLatLong(double Latitude, double Longitude)
        {
            string url = "";
            switch (MapType)
            {
                case MapType.GoogleMaps:
                    string coordinate = $"{Latitude},{Longitude}";
                    url = $"https://www.google.com/maps/search/?api=1&query={coordinate}";
                    break;
                case MapType.Here:
                    break;
                default:
                    break;
            }
            return url;
        }

        public byte[] GetMapImageFromLatLong(Coordinates coordinates)
        {
            return GetMapImageFromLatLong(coordinates.Latitude, coordinates.Longitude);
        }
        public byte[] GetMapImageFromLatLong(double Latitude, double Longitude)
        {

            if (MapImageSize == null)
            {
                throw new MissingMapOptionException("Map Image Size option was not set");
            }
            if (MapImageScale == null)
            {
                throw new MissingMapOptionException("Map Image Scale option was not set");
            }
            MapImageSize mapSize = (MapImageSize)MapImageSize;
            MapImageScale mapScale = (MapImageScale)MapImageScale;

            byte[] result = null;
            switch (MapType)
            {
                case MapType.GoogleMaps:
                    string coordinate = $"{Latitude},{Longitude}";
                    string mapSizeString = "";
                    switch (mapSize)
                    {
                        case MapLocation.MapImageSize.Size400x400:
                            mapSizeString = "400x400";
                            break;
                        case MapLocation.MapImageSize.Size300x600:
                            mapSizeString = "300x600";
                            break;
                        case MapLocation.MapImageSize.Size1280x400:
                            mapSizeString = "1280x400";
                            break;
                        case MapLocation.MapImageSize.Size1280x1024:
                            mapSizeString = "1280x1024";
                            break;
                        default:
                            break;
                    }
                    var address = $"https://maps.googleapis.com/maps/api/staticmap?center={coordinate}&zoom={(int)mapScale}&size={mapSizeString}&maptype=roadmap&markers=color:red%7Clabel:%7C{coordinate}&key={ApiKey}";
                    using (WebClient wc = new WebClient())
                    {
                        result = wc.DownloadData(address);
                    }
                    break;
                case MapType.Here:
                    break;
                default:
                    break;
            }
            return result;
        }
        public MapData GetMapDataFromLatLong(Coordinates coordinates)
        {
            return GetMapDataFromLatLong(coordinates.Latitude, coordinates.Longitude);
        }
        
        public MapData GetMapDataFromLatLong(double Latitude, double Longitude)
        {
            var mapData = new MapData();
            mapData.Coordinates.Latitude = Latitude;
            mapData.Coordinates.Longitude= Longitude;

            switch (MapType)
            {
                case MapType.GoogleMaps:
                    string coordinate = $"{Latitude},{Longitude}";

                    var address = $"https://maps.googleapis.com/maps/api/geocode/json?latlng={coordinate}&key={ApiKey}";
                    string jsonString = "";

                    using (WebClient wc = new WebClient())
                    {
                        jsonString = wc.DownloadString(address);
                        var googleMapData = GoogleMapData.FromJson(jsonString);

                        //first look for buildings, then approximations of things nearby, then the actual coordinate data
                        GoogleLocationSearchType[] CustomOrdering = new GoogleLocationSearchType[] { GoogleLocationSearchType.Rooftop, GoogleLocationSearchType.Approximate, GoogleLocationSearchType.GeometricCenter };


                        var results = googleMapData.Results
                                                .Where(o => o.PlusCode != null)
                                                .OrderBy(p => Array.IndexOf(CustomOrdering, p.Geometry.LocationSearchType));
                        
                        //not 100% that these will all be from the same instance, but it should mean we are more likely to get data for all of them
                        mapData.Address = results.Select(f=>f.FormattedAddress).FirstOrDefault()?.Trim();
                        mapData.StreetNumber = results.Select(f => f.AddressComponents.FirstOrDefault(g => g.ComponentType==AddressComponentType.StreetNumber)).FirstOrDefault()?.LongName;
                        mapData.Street = results.Select(f => f.AddressComponents.FirstOrDefault(g => g.ComponentType==AddressComponentType.Street)).FirstOrDefault()?.LongName;
                        mapData.Town = results.Select(f => f.AddressComponents.FirstOrDefault(g => g.ComponentType==AddressComponentType.PostalTown)).FirstOrDefault()?.LongName;
                        mapData.PostCode = results.Select(f => f.AddressComponents.FirstOrDefault(g => g.ComponentType == AddressComponentType.PostalCode)).FirstOrDefault()?.LongName;
                        mapData.Country = results.Select(f => f.AddressComponents.FirstOrDefault(g => g.ComponentType == AddressComponentType.Country)).FirstOrDefault()?.LongName;
                    }
                    break;
                case MapType.Here:
                    break;
                default:
                    break;

            }
            return mapData;
        }
    }
}
