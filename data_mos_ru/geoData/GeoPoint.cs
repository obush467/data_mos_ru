using Newtonsoft.Json.Linq;
using System;
using System.Data.Entity.Spatial;
using System.Globalization;

namespace data_mos_ru
{
    public class GeoPoint: IGeoData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Nullable<double> Z { get; set; } = null;
        public Nullable<double> M { get; set; } = null;
        public GeoPoint(double x, double y, double? z=null, double? m = null)
        { Init(x,y,z,m);}
        public void Init(double x, double y, double? z = null, double? m = null)
        { X = x; Y = y; Z = z; M = m; }

        public GeoPoint(JArray jArray)
        {
            //JArray jArray1 = jArray[0].Value<JArray>();
            {
                switch (jArray.Count)
                {
                    case 2:
                        Init(double.Parse(jArray[0].ToString()), double.Parse(jArray[1].ToString()));
                        break;
                    case 3:
                        Init(double.Parse(jArray[0].ToString()), double.Parse(jArray[1].ToString()), double.Parse(jArray[2].ToString()));
                        break;
                    case 4:
                        Init(double.Parse(jArray[0].ToString()), double.Parse(jArray[1].ToString()), double.Parse(jArray[2].ToString()), double.Parse(jArray[3].ToString()));
                        break;
                }
            }
        }
        public string ToWKT()
        {
            if (X == null & Y == null)
            { return string.Join(" ", "POINT", "EMPTY"); }
            else
            { return string.Join(" ", "POINT", "(", ToString(), ")"); }
        }
        public override string ToString()
        {
            return string.Join(" ", X.ToString(CultureInfo.InvariantCulture), Y.ToString(CultureInfo.InvariantCulture));
        }

        public DbGeography ToDbGeography(int epsg)
        {
            return DbGeography.FromText(ToWKT(), epsg);
        }

        public DbGeometry ToDbGeometry(int epsg)
        {
            return DbGeometry.FromText(ToWKT(), epsg);
        }
    }
}
