using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_mos_ru.Converters
{
    public class BtiGeoDeserializer
    {
        public static DbGeography Polygon(JProperty jproperty)
        {
            return new geoPolygon((JArray)jproperty.Value).ToDbGeography(4326);
        }
        public static DbGeography MPolygon(JProperty jproperty)
        {
            return (new geoMPolygon((JArray)jproperty.Value)).ToDbGeography(4326);
        }

        internal static DbGeography Point(JProperty jproperty)
        {
            return new geoPoint((JArray)jproperty.Value).ToDbGeography(4326);
        }
    }
}
