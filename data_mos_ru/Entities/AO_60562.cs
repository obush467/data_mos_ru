using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace data_mos_ru.Entities
{
    [Table("AO_60562", Schema = "data_mos_ru")]
    [DataContract(Name = "AO_60562")]
    public class AO_60562
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public int? Global_ID { get; set; }
        [DataMember]
        [MaxLength(1000)]
        public string Adm_Area { get; set; }
        [DataMember]
        public int? UNOM { get; set; }
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
        public DateTime? DDOC { get; set; }
        [DataMember]
        public int? NREG { get; set; }
        [DataMember]
        public DateTime? DREG { get; set; }
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
        public Guid? N_FIAS { get; set; }
        [DataMember]
        public DateTime? D_FIAS { get; set; }
        [DataMember]
        [MaxLength(30)]
        public string KLADR { get; set; }
        [DataMember]
        [MaxLength(40)]
        public string ADR_TYPE { get; set; }
        [DataMember]
        public GeoData GeoData { get; set; }
        //[NotMapped]
        //public string AddressClean { get { return (new AddressOperator()).CleanToSearch(ADDRESS); } }
        //[NotMapped]
        //public string AddressToSearch { get { return (new AddressOperator()).AO_60562_ToSearch(this); } }
    }

}