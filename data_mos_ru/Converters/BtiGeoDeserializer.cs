using Newtonsoft.Json.Linq;
using System.Data.Entity.Spatial;

namespace data_mos_ru.Converters
{
    public class BtiGeoDeserializer
    {
        public static DbGeography Polygon(JProperty jproperty)
        {
            return new GeoPolygon((JArray)jproperty.Value).ToDbGeography(4326);
        }
        public static DbGeography MPolygon(JProperty jproperty)
        {
            return (new GeoMPolygon((JArray)jproperty.Value)).ToDbGeography(4326);
        }

        internal static DbGeography Point(JProperty jproperty)
        {
            return new GeoPoint((JArray)jproperty.Value).ToDbGeography(4326);
        }
    }
}
