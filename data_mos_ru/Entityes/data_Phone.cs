using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace data_mos_ru.Entityes
{
    public class data_Phone
    {
        [Key]
        [DataMember]
        public Guid ID { get; set; }
    }
}