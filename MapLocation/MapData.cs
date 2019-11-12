using System.Collections.Generic;
using System.Text;

namespace MapLocation
{
    public class MapData
    {
        public MapData()
        {
            Coordinates = new Coordinates();
        }

        public byte[] MapImage { get; set; }
        public string MapUrl { get; set; }
        private MapType MapType { get; set; }
        public Coordinates Coordinates { get; set; }
        public string Address { get; set; }
        public string StreetNumber { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }

    }
}
