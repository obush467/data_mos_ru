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
        public Nullable<int> UNOM { get; set; }
        [DataMember]
        public Nullable<int> KAD_RN { get; set; }
        [DataMember]
        public Nullable<int> KAD_KV { get; set; }
        [DataMember]
        public Nullable<int> KAD_ZU { get; set; }
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
        public Nullable<DateTime> DDOC { get; set; }
        [DataMember]
        public Nullable<int> NREG { get; set; }
        [DataMember]
        public Nullable<DateTime> DREG { get; set; }
        [DataMember]
        [MaxLength(4000)]
        public string VYVAD { get; set; }
        [DataMember]
        [MaxLength(4000)]
        public string ADRES { get; set; }
        public DbGeography geoData { get; set; }
    }

}