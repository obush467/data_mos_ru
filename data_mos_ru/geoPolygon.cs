using System;
using System.Collections.Generic;
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
        public override string ToString()
        {
            return "("+string.Join(",", this) + ")";
        }
    }
    public class geoMPolygon:List<geoPolygon>
    {
        public override string ToString()
        {
            return "(" + string.Join(",", this) + ")";
        }
    }
}
