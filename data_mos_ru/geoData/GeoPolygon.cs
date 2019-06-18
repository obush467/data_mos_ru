using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data.Entity.Spatial;

namespace data_mos_ru
{
    public class GeoPolygon : List<GeoLinestring>
    {
        public void Init(JArray jArray)
        {
            foreach (JArray jArrayLinestring in jArray)
            {
                Add(new GeoLinestring(jArrayLinestring));
            }
        }
        public GeoPolygon() : base() { }

        internal DbGeography ToDbGeography(int epsg)
        {
            return DbGeography.PolygonFromText(ToWKT(), epsg);
        }

        public GeoPolygon(JArray jArray)
        {
            Init(jArray);
        }
        public override string ToString()
        {
            return "(" + string.Join<GeoLinestring>(",", this) + ")";
        }
        public string ToWKT()
        {string r = "POLYGON " + ToString();
            return r;
        }

    }
}
    

