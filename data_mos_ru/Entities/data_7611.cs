using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
namespace data_mos_ru.Entities
{
    public class Data_7611 //Религиозные объекты Русской православной церкви
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Data_7611_ID { get; set; }
        [DataMember]
        public int? ID { get; set; }
        [DataMember]
        public int? global_id { get; set; }
        [DataMember]
        [MaxLength(1000)]
        public string NameOfReligiousOrganization { get; set; }//Наименование  объекта
        [DataMember]
        [MaxLength(1000)]
        public string AdmArea { get; set; }// Административный округ,
        [DataMember]
        [MaxLength(1000)]
        public string District { get; set; }// Район,
        [DataMember]
        [MaxLength(1000)]
        public string Address { get; set; }//Адрес (или адресный ориентир),
        public string PublicPhone { get; set; }//Контактный телефон,
        [DataMember]
        [MaxLength(1000)]
        public string WebSite { get; set; }//Сайт,
        public GeoData geoData { get; set; }
    }
}
