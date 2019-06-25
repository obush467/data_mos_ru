using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace data_mos_ru.Entities
{
    [Table("UM", Schema = "data_mos_ru")]
    public class UM
    {
        [Key]
        public int id { get; set; }
        public int global_id { get; set; }
        [MaxLength(2000)]
        public string UM_CODE { get; set; }
        [MaxLength(2000)]
        public string system_object_id { get; set; }
        [MaxLength(2000)]
        public string UM_NAMEF { get; set; }
        [MaxLength(2000)]
        public string UM_NAMES { get; set; }
        [MaxLength(2000)]
        public string UM_TRANS { get; set; }
        [MaxLength(2000)]
        public string UM_TYPE { get; set; }
        [MaxLength(2000)]
        public string UM_TM { get; set; }
        [MaxLength(2000)]
        public string UM_TE { get; set; }
        [MaxLength(2000)]
        public string UM_KLADR { get; set; }
        [MaxLength(2000)]
        public string geoData { get; set; }
    }
}