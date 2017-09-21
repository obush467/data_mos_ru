using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace data_mos_ru.Entityes
{
    [Table("UM_Type", Schema = "data_mos_ru")]
    public class UM_Type
    {
        [Key]
        public int id { get; set; }
        public int global_id { get; set; }
        [MaxLength(4000)]
        public string system_object_id { get; set; }
        [MaxLength(4000)]
        public string UM_STAT { get; set; }
        [MaxLength(4000)]
        public string UM_TYPEC { get; set; }
        [MaxLength(4000)]
        public string UM_TYPEN { get; set; }
    }
}