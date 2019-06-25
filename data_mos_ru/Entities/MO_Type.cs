using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace data_mos_ru.Entities
{
    [DataContract]
    [Table("MO_Type", Schema = "data_mos_ru")]
    public class MO_Type
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [DataMember]
        public int? Number { get; set; }

        [DataMember]
        public int global_id { get; set; }
        [MaxLength(40)]
        [DataMember]
        public string MO_Type_C { get; set; }
        [MaxLength(40)]
        [DataMember]
        public string MO_Type_N { get; set; }

        /* [DataMember]
         public MO_Type_Cell Cells { get; set; }*/
    }
    public class MO_Type_Cell
    {
        [DataMember]
        public int global_id { get; set; }
        [MaxLength(40)]
        [DataMember]
        public string MO_Type_C { get; set; }
        [MaxLength(40)]
        [DataMember]
        public string MO_Type_N { get; set; }
    }
}

