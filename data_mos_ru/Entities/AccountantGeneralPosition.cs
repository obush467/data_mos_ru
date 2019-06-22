using System.ComponentModel.DataAnnotations.Schema;

namespace data_mos_ru.Entities
{
    [Table("AccountantGeneralPositions")]
    public class AccountantGeneralPosition: PersonPosition
    {
        public bool AccountantGeneral { get; set; }
        public Document InstDocument { get; set; }


    }
}
