using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;

namespace data_mos_ru.Entities
{
    [Table("AO_geojson", Schema = "data_mos_ru")]
    [DataContract(Name = "AO_geojson")]
    public class AO_geojson
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(150)]
        public string NAME { get; set; }
        [MaxLength(150)]
        public string OKATO { get; set; }
        [MaxLength(150)]
        public string ABBREV { get; set; }
        public DbGeography geometry { get; set; }
    }
}
