using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_mos_ru
{
    interface IGeoData
    {
        string ToWKT();
        string ToString();
        DbGeography ToDbGeography(int epsg);
        DbGeometry ToDbGeometry(int epsg);
    }
    public abstract class geoDataBaseAbstract : List<object>, IGeoData
    {
        public abstract DbGeography ToDbGeography(int epsg);
        public abstract DbGeometry ToDbGeometry(int epsg);
        public abstract string ToWKT();        
    }
    public class geoDataBase : geoDataBaseAbstract
    {
        protected string WKTtype { get; set; }
        public override DbGeography ToDbGeography(int epsg)
        {
            return DbGeography.FromText(ToWKT(), epsg);
        }
        public override DbGeometry ToDbGeometry(int epsg)
        {
            return DbGeometry.FromText(ToWKT(), epsg);
        }

        public override string ToWKT()
        {
            string tstr = ToString();
            if (string.IsNullOrEmpty(tstr))
            { return string.Join(" ", WKTtype, "EMPTY"); }
            else
            { return string.Join(" ", WKTtype, "(", ToString(), ")"); }
        }
    }
}
