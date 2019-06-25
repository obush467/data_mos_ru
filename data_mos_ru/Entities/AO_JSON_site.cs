using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace data_mos_ru.Entities
{
    public class AO_JSON_site
    {
        [Key]
        public int id { get; set; }

        public AO_JSON_Cells Cells { get; set; }
    }
    public class AO_JSON_Cells

    {

        [DataMember]
        public int global_id { get; set; }
        [DataMember]
        public JArray AdmArea { get; set; }
        [DataMember]
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
        public string DMT { get; set; }
        [DataMember]
        public string VLD { get; set; }
        [DataMember]
        public string KRT { get; set; }
        [DataMember]
        public string STRT { get; set; }
        [DataMember]
        public string SOOR { get; set; }
        [DataMember]
        public string TDOC { get; set; }
        [DataMember]
        public string NDOC { get; set; }
        [DataMember]
        public string DDOC { get; set; }
        [DataMember]
        public int? NREG { get; set; }
        [DataMember]
        public string DREG { get; set; }
        [DataMember]
        public string VYVAD { get; set; }
        [DataMember]
        public string ADRES { get; set; }
        [DataMember]
        public NetTopologySuite.Geometries.Geometry geoData { get; set; }

    }
}
