using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace data_mos_ru.Entities
{
    [Table("UPRs", Schema = "dom_mos_ru")]
    public class SearchAutoCompleteResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ID { get; set; }
        [MaxLength(500)]
        public string Value { get; set; }
        [MaxLength(500)]
        public string Label { get; set; }
        [MaxLength(300)]
        public string Url { get; set; }
        [MaxLength(30)]
        public string Section { get; set; }
    }
}
