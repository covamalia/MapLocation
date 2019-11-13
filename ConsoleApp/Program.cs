using MapLocation;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Xml;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter Latitude");
            double.TryParse(Console.ReadLine(),out double LocationLatitude);
            Console.WriteLine("Enter Longitude");
            double.TryParse(Console.ReadLine(), out double LocationLongitude); 

            var map = new Maps(new MapOptions
                                            {
                                                ApiKey = Environment.GetEnvironmentVariable("GoogleAPIKey",EnvironmentVariableTarget.Machine),
                                                MapType = MapType.GoogleMaps,
                                                MapImageOptions = new MapImageOptions
                                                {
                                                    MapImageScale = MapImageScale.Close,
                                                    MapImageSize = MapImageSize.Size300x600
                                                }
                                            });
            
            var m = map.GetFullMapData(LocationLatitude, LocationLongitude);

            Console.WriteLine("Address: " + m.Address);
            Console.WriteLine("Street number: " + m.StreetNumber);
            Console.WriteLine("Street: " + m.Street);
            Console.WriteLine("Town: " + m.Town);
            Console.WriteLine("Postcode: " + m.PostCode);
            Console.WriteLine("Country: " + m.Country);
            var ba = m.MapImage;
            var ms = new MemoryStream(ba);
            var img = Image.Load(ms);
            img.Save("map.jpg", new JpegEncoder() { Quality = 100 });
            Console.WriteLine(m.MapUrl);
        }
    }
}
