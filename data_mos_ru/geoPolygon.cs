using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_mos_ru
{
    public class geoPolygonBase: List<geoPointBase>
    {
        public override string ToString()
        {
             return "("+string.Join(",", this)+")";
        }
    }


    public class geoPolygon : List<geoPolygonBase>
    {
        public void Set(JArray jArray)
        {
            foreach (var jo in jArray)
            {
                geoPolygonBase p = new geoPolygonBase();
                foreach (var pp in jo)
                {
                    p.Add(new geoPointBase(pp[1].Value<double>(), pp[0].Value<double>()));
                }
                this.Add(p);
            }
        }
        public geoPolygon() : base() { }
        public geoPolygon(JArray jArray)
        {
            Set(jArray);
        }
        public override string ToString()
        {
            return "("+string.Join(",", this) + ")";
        }
        public string ToWKT()
        {
            return "POLYGON (" + string.Join(",", this) + ")";
        }
        public DbGeography dbGeography(int EPSG)
        {
            try
            {
                return DbGeography.PolygonFromText(ToWKT(), EPSG);
            }
            catch (Exception e)
            {
                foreach (geoPolygonBase l in this)
                {
                    l.Reverse();
                }
                return DbGeography.PolygonFromText(ToWKT(), EPSG);
            }
        }
    }
    public class geoMPolygon:List<geoPolygon>
    {
        public geoMPolygon() : base() { }
        public geoMPolygon(JArray jArray)
        {
            foreach (var jo in jArray)
            {
                this.Add(new geoPolygon((JArray)jo));
            }
        }
        public override string ToString()
        {
            return "(" + string.Join(",", this) + ")";
        }
        public string ToWKT()
        {
            return "MULTIPOLYGON (" + string.Join(",", this) + ")";
        }

        public DbGeography dbGeography(int EPSG)
        {
            try
            {
                return DbGeography.PolygonFromText(ToWKT(), EPSG);
            }
            catch (Exception e)
            {
                foreach (geoPolygon l in this)
                {
                    l.Reverse();
                }
                return DbGeography.MultiPolygonFromText(ToWKT(), EPSG);
            }
        }
    }
}
