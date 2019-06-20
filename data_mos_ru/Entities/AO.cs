using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace data_mos_ru.Entities
{
    [Table("AO", Schema = "data_mos_ru")]
    [DataContract(Name = "AO")]
    public class AO
    {
        [Key]
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public int global_id { get; set; }
        [DataMember]
        [MaxLength(4000)]
        public string AdmArea { get; set; }
        [DataMember]
        [MaxLength(4000)]
        public string system_object_id { get; set; }
        [DataMember]
        public int? UNOM { get; set; }
        [DataMember]
        public int? KAD_RN { get; set; }
        [DataMember]
        public int? KAD_KV { get; set; }
        [DataMember]
        public int? KAD_ZU { get; set; }
        [DataMember]
        [MaxLength(4000)]
        public string DMT { get; set; }
        [DataMember]
        [MaxLength(4000)]
        public string KRT { get; set; }
        [DataMember]
        [MaxLength(4000)]
        public string VLD { get; set; }
        [DataMember]
        [MaxLength(4000)]
        public string STRT { get; set; }
        [DataMember]
        [MaxLength(4000)]
        public string SOOR { get; set; }
        [DataMember]
        [MaxLength(4000)]
        public string TDOC { get; set; }
        [DataMember]
        [MaxLength(4000)]
        public string NDOC { get; set; }
        [DataMember]
        public DateTime? DDOC { get; set; }
        [DataMember]
        public int? NREG { get; set; }
        [DataMember]
        public DateTime? DREG { get; set; }
        [DataMember]
        [MaxLength(4000)]
        public string VYVAD { get; set; }
        [DataMember]
        [MaxLength(4000)]
        public string ADRES { get; set; }
        public DbGeography geoData { get; set; }
    }

}