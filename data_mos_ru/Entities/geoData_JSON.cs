using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;

namespace data_mos_ru.Entities
{
    public class GeoData
    {

        [DataMember]
        [MaxLength(30)]
        public string Type { get; set; }
        [DataMember]
        public DbGeography Coordinates { get; set; }
        [DataMember]
        public DbGeography Сenter { get; set; }
        public GeoData():base()
        { Coordinates = DbGeography.FromText("POINT EMPTY"); }
    }
}
