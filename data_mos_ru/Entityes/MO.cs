using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace data_mos_ru.Entityes
{
    [Table("MO", Schema = "data_mos_ru")]
    public class MO
    {
        [Key]
        public int id { get; set; }
        public int global_id { get; set; }
        public string system_object_id { get; set; }
        [MaxLength(4000)]
        public string MO_Code { get; set; }
        [MaxLength(4000)]
        public string MO_Name { get; set; }
        [MaxLength(4000)]
        public string MO_Trans { get; set; }
        [MaxLength(4000)]
        public string MO_Type { get; set; }
        [MaxLength(4000)]
        public string MO_TE { get; set; }
        [MaxLength(4000)]
        public string MO_OKTMO { get; set; }
        [MaxLength(4000)]
        public string geoData { get; set; }

}
}
