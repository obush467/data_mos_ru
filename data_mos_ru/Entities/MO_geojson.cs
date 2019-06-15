using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;

namespace data_mos_ru.Entities
{
    [Table("MO_geojson", Schema = "data_mos_ru")]
    [DataContract(Name = "MO_geojson")]
    public class MO_geojson
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(150)]
        public string NAME { get; set; }
        [MaxLength(150)]
        public string OKATO { get; set; }
        [MaxLength(150)]
        public string OKTMO { get; set; }

        [MaxLength(150)]
        public string NAME_AO { get; set; }

        [MaxLength(150)]
        public string OKATO_AO { get; set; }

        [MaxLength(150)]
        public string TYPE_MO { get; set; }


        [MaxLength(150)]
        public string ABBREV_AO { get; set; }
        public DbGeography geometry { get; set; }
    }
}
