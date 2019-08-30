using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
namespace data_mos_ru.Entities
{
    public class Data_Organization_4149 //Штаб народной дружины
    {
        [DataMember]
        public int? ID { get; set; }
        [DataMember]
        public int? global_id { get; set; }
        [DataMember]
        [MaxLength(1000)]
        public string Name { get; set; }//Наименование  объекта
        [DataMember]
        [MaxLength(1000)]
        public string AdmArea { get; set; }// Административный округ,
        [DataMember]
        [MaxLength(1000)]
        public string District { get; set; }// Район,
        [DataMember]
        [MaxLength(1000)]
        public string Address { get; set; }//Адрес (или адресный ориентир),
        [DataMember]
        [MaxLength(1000)]
        public List<PublicPhoneItem> PublicPhone { get; set; }//Контактный телефон,
        [DataMember]
        [MaxLength(1000)]
        public GeoData geoData { get; set; }

    }
}
