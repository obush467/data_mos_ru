using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
