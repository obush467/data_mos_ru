using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace data_mos_ru.Entityes
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
        public Nullable<int> UNOM { get; set; }
        [DataMember]
        public Nullable<int> KAD_RN { get; set; }
        [DataMember]
        public Nullable<int> KAD_KV { get; set; }
        [DataMember]
        public Nullable<int> KAD_ZU { get; set; }
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
        public Nullable<int> NREG { get; set; }
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
