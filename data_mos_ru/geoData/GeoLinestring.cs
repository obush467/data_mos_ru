using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data.Entity.Spatial;

namespace data_mos_ru
{
    public class GeoLinestring : List<GeoPoint>,IGeoData
    {
        public GeoLinestring(JArray jArray)
        {
            foreach (JArray jArrayPoint in jArray)
            {
                Add(new GeoPoint(jArrayPoint));
            }
        }
        public DbGeography ToDbGeography(int epsg)
        {
            return DbGeography.LineFromText(ToWKT(), epsg);
        }

        public DbGeometry ToDbGeometry(int epsg)
        {
            return DbGeometry.LineFromText(ToWKT(), epsg);
        }

        public string ToWKT()
        {
            string WKT = ToString();
            if (string.IsNullOrEmpty(WKT))
            { return string.Join(" ", "LINESTRING", "EMPTY"); }
            else
            { return string.Join(" ", "LINESTRING", ToString()); }
        }
        public override string ToString()
        {
            return "("+string.Join(", ",this)+")";
        }
    }
}