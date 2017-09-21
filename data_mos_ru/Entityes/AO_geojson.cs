using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace data_mos_ru.Entityes
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
