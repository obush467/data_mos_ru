using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_mos_ru.Entities
{
    public class PersonPosition
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public virtual PersonPositionType PositionType { get; set; }
        public virtual Person Human { get; set; }
        public Nullable<DateTime> BeginDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public Guid Organization_Id { get; set; }
        [ForeignKey("Organization_Id")]
        public virtual Organization Organization { get; set; }

    }
}
