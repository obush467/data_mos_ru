using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_mos_ru.Entities
{
    [Table("AccountantGeneralPositions")]
    public class AccountantGeneralPosition: PersonPosition
    {
        public bool AccountantGeneral { get; set; }
        public Document InstDocument { get; set; }


    }
}
