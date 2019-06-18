using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_mos_ru.Entities
{
    [Table("DirectorPositions")]
    public class DirectorPosition: PersonPosition
    {
        public bool Director { get; set; }
        public virtual Document InstDocument { get; set; }
    }
}
