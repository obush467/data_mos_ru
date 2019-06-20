using System.ComponentModel.DataAnnotations.Schema;

namespace data_mos_ru.Entities
{
    [Table("DirectorPositions")]
    public class DirectorPosition: PersonPosition
    {
        public bool Director { get; set; }
        public virtual Document InstDocument { get; set; }
    }
}
