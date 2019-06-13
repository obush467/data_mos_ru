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
    [Table("AO_60562", Schema = "data_mos_ru")]
    [DataContract(Name = "AO_60562")]
    public class AO_60562
    {
        [Key]
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public Nullable<int> Global_ID { get; set; }
        [DataMember]
        [MaxLength(1000)]
        public string Adm_Area { get; set; }
        [DataMember]
        public Nullable<int> UNOM { get; set; }
        [DataMember]
        [MaxLength(1000)]
        public string VID { get; set; }
        [DataMember]
        [MaxLength(1000)]
        public string TDOC { get; set; }
        [DataMember]
        [MaxLength(1000)]
        public string NDOC { get; set; }
        [DataMember]
        public Nullable<DateTime> DDOC { get; set; }
        [DataMember]
        public Nullable<int> NREG { get; set; }
        [DataMember]
        public Nullable<DateTime> DREG { get; set; }
        [DataMember]
        [MaxLength(1000)]
        public string ADDRESS { get; set; }
        [DataMember]
        [MaxLength(200)]
        public string P1 { get; set; }
        [DataMember]
        [MaxLength(200)]
        public string P2 { get; set; }
        [DataMember]
        [MaxLength(200)]
        public string P3 { get; set; }
        [DataMember]
        [MaxLength(200)]
        public string P4 { get; set; }
        [DataMember]
        [MaxLength(200)]
        public string P5 { get; set; }
        [DataMember]
        [MaxLength(200)]
        public string P6 { get; set; }
        [DataMember]
        [MaxLength(200)]
        public string P7 { get; set; }
        [DataMember]
        [MaxLength(200)]
        public string P90 { get; set; }
        [DataMember]
        [MaxLength(200)]
        public string P91 { get; set; }
        [DataMember]
        [MaxLength(200)]
        public string L1_TYPE { get; set; }
        [DataMember]
        [MaxLength(200)]
        public string L1_VALUE { get; set; }
        [DataMember]
        [MaxLength(200)]
        public string L2_TYPE { get; set; }
        [DataMember]
        [MaxLength(200)]
        public string L2_VALUE { get; set; }
        [DataMember]
        [MaxLength(200)]
        public string L3_TYPE { get; set; }
        [DataMember]
        [MaxLength(200)]
        public string L3_VALUE { get; set; }
        [DataMember]
        [MaxLength(200)]
        public string L4_TYPE { get; set; }
        [DataMember]
        [MaxLength(200)]
        public string L4_VALUE { get; set; }
        [DataMember]
        [MaxLength(200)]
        public string L5_TYPE { get; set; }
        [DataMember]
        [MaxLength(200)]
        public string L5_VALUE { get; set; }
        [DataMember]
        [MaxLength(200)]
        public string DISTRICT { get; set; }
        [DataMember]
        public Nullable<Guid> N_FIAS { get; set; }
        [DataMember]
        public Nullable<DateTime> D_FIAS { get; set; }
        [DataMember]
        [MaxLength(30)]
        public string KLADR { get; set; }
        [DataMember]
        [MaxLength(4000)]
        public string ADR_TYPE { get; set; }
        [DataMember] 
        public geoData GeoData { get; set; }
    }

}