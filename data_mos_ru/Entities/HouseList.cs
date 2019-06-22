using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace data_mos_ru.Entities
{
    [Table("HouseLists", Schema = "dom_mos_ru")]
    public class HouseList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public List<House> Houses { get; set; } = new List<House>();
    }
}
