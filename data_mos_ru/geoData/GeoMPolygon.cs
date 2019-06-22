using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;


namespace data_mos_ru
{
    public class GeoMPolygon:List<GeoPolygon>,IGeoData
    {
        public GeoMPolygon() : base() { }
        public GeoMPolygon(JArray jArray)
        {
            foreach (JArray jArrayPolygon in jArray)
            {
                this.Add(new GeoPolygon(jArrayPolygon));
            }
        }
        public override string ToString()
        {
            return "(" + string.Join(",", this) + ")";
        }
        public string ToWKT()
        {
            return "MULTIPOLYGON " + ToString();
        }

        public DbGeography ToDbGeography(int EPSG)
        {
            return DbGeography.MultiPolygonFromText(ToWKT(), EPSG);
        }

        public DbGeometry ToDbGeometry(int epsg)
        {
            throw new NotImplementedException();
        }
    }
}
