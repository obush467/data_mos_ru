using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_mos_ru.Entities
{
    [Table("Persons")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Patronymic { get; set; }
        [MaxLength(50)]
        public string Family { get; set; }
    }
}
