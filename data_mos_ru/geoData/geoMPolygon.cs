using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_mos_ru
{
    public class geoMPolygon:List<geoPolygon>,IGeoData
    {
        public geoMPolygon() : base() { }
        public geoMPolygon(JArray jArray)
        {
            foreach (JArray jArrayPolygon in jArray)
            {
                this.Add(new geoPolygon(jArrayPolygon));
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
