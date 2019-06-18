using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace data_mos_ru.Entities
{
    [Table("InfTableRows", Schema = "dom_mos_ru")]
    public class InfTableRow
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [MaxLength(300)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Value { get; set; }
    }
}
