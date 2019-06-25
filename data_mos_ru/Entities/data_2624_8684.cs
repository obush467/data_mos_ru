using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
namespace data_mos_ru.Entities
{
    public class publicPhone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [DataMember]
        public Guid ParentID { get; set; }
        [DataMember]
        [MaxLength(50)]
        public string PublicPhone { get; set; }
    }
    public class Data_2624_8684 //Религиозные объекты Русской православной церкви
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
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
        public string MetroStation { get; set; }//Станция метро,
        [DataMember]
        [MaxLength(1000)]
        public string MetroLine { get; set; }//Линия метро,
                                             // [InverseProperty("ParentID")]
        [ForeignKey("ParentID")]
        public virtual ICollection<publicPhone> PublicPhone { get; set; }//Контактный телефон,
        [DataMember]
        [MaxLength(1000)]
        public string WebSite { get; set; }//Сайт,
        public GeoData geoData { get; set; }
        public double? Longitude_WGS84 { get; set; }
        public double? Latitude_WGS84 { get; set; }

    }
}
