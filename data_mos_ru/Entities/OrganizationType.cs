using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace data_mos_ru.Entities
{
    public class OrganizationType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string ShortTypeName { get; set; }
        [MaxLength(300)]
        public string FullTypeName { get; set; }
    }
}
