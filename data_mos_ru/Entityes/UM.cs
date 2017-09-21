using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace data_mos_ru.Entityes
{
    [Table("UM", Schema = "data_mos_ru")]
    public class UM
    {
        [Key]
        public int id { get; set; }
        public int global_id { get; set; }
        [MaxLength(4000)]
        public string UM_CODE { get; set; }
        [MaxLength(4000)]
        public string system_object_id { get; set; }
        [MaxLength(4000)]
        public string UM_NAMEF { get; set; }
        [MaxLength(4000)]
        public string UM_NAMES { get; set; }
        [MaxLength(4000)]
        public string UM_TRANS { get; set; }
        [MaxLength(4000)]
        public string UM_TYPE { get; set; }
        [MaxLength(4000)]
        public string UM_TM { get; set; }
        [MaxLength(4000)]
        public string UM_TE { get; set; }
        [MaxLength(4000)]
        public string UM_KLADR { get; set; }
        [MaxLength(4000)]
        public string geoData { get; set; }
    }
}