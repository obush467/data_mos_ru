using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace data_mos_ru.Entities
{
    public class Data_7612 //Религиозные объекты Русской православной церкви
    {
        [DataMember]
        public int? ID { get; set; }
        [DataMember]
        public int? global_id { get; set; }
        [DataMember]
        [MaxLength(1000)]
        public string ObjectName { get; set; }//Наименование  объекта
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
        public string MetroStation { get; set; }//Станция метро,
        [DataMember]
        [MaxLength(1000)]
        public string MetroLine { get; set; }//Линия метро,
                                             // [InverseProperty("ParentID")]
        public string PublicPhone { get; set; }//Контактный телефон,
        [DataMember]
        [MaxLength(1000)]
        public string WebSite { get; set; }//Сайт,
        public GeoData geoData { get; set; }
        public double? Longitude_WGS84 { get; set; }
        public double? Latitude_WGS84 { get; set; }

    }
}
