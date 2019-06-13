using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_mos_ru
{
    public class geoPolygon : List<geoLinestring>
    {
        public void Init(JArray jArray)
        {
            foreach (JArray jArrayLinestring in jArray)
            {
                Add(new geoLinestring(jArrayLinestring));
            }
        }
        public geoPolygon() : base() { }

        internal DbGeography ToDbGeography(int epsg)
        {
            return DbGeography.PolygonFromText(ToWKT(), epsg);
        }

        public geoPolygon(JArray jArray)
        {
            Init(jArray);
        }
        public override string ToString()
        {
            return "(" + string.Join<geoLinestring>(",", this) + ")";
        }
        public string ToWKT()
        {string r = "POLYGON " + ToString();
            return r;
        }

    }
}
    

