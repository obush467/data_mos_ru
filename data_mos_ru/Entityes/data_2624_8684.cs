using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Data.Entity.Spatial;
using NetTopologySuite.Geometries;

namespace data_mos_ru.Entityes
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
    public class data_2624_8684_1 //Религиозные объекты Русской православной церкви
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
        public geoData geoData { get; set; }
        public double? Longitude_WGS84 { get; set; }
        public double? Latitude_WGS84 { get; set; }

    }
}
