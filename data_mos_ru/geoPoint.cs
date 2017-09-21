using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_mos_ru
{
    public class geoPointBase
    {
        public double Lat { get; set; }
        public double Long { get; set; }

        public geoPointBase(double vlat, double vlong)
        { Lat = vlat;Long = vlong; }

        public override string ToString() {
            { return Long.ToString(CultureInfo.InvariantCulture) + " " + Lat.ToString(CultureInfo.InvariantCulture); }; }
    }
}
