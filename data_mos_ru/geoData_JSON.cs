using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_mos_ru
{
    public class geoData_JSON
    {
        public string Type { get; set; }
        public object coordinates { get; set; }
        public JArray center { get; set; }
    }
}
