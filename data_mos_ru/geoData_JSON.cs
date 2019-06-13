using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace data_mos_ru
{
    public class geoData
    {

        [DataMember]
        [MaxLength(30)]
        public string Type { get; set; }
        [DataMember]
        public DbGeography Coordinates { get; set; }
        [DataMember]
        public DbGeography Сenter { get; set; }
        public geoData() : base()
        { Coordinates = DbGeography.FromText("POINT EMPTY"); }
    }
}
