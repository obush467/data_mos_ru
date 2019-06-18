using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace data_mos_ru.Entities
{
    [Table("TM_Type", Schema = "data_mos_ru")]
    public class TM_Type
    {
        [Key]
        public int id { get; set; }
        public int global_id { get; set; }
        /*[MaxLength(4000)]
        public string system_object_id { get; set; }
        [MaxLength(4000)]*/
        public string TM_TYPEC { get; set; }
        [MaxLength(4000)]
        public string TM_TYPEN { get; set; }
    }
}