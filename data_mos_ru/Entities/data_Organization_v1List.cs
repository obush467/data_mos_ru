using System.Collections.Generic;
using System.Runtime.Serialization;

namespace data_mos_ru.Entities
{
    // [DataContract(Name = "ChiefPhone")]



    //[DataContract(Name = "FaxItem")]

    //[DataContract(Name = "EmailItem")]


    public class data_Organization_v1List
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int global_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Category { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string CommonName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string FullName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ShortName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ChiefOrg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<OrgInfoItemList> OrgInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<ObjectAddressItem> ObjectAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ChiefName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ChiefPosition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<PublicPhoneItemList> PublicPhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<FaxItemList> Fax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<EmailItemList> Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<WorkingHoursItem> WorkingHours { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ClarificationOfWorkingHours { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string WebSite { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public float NumOfSeats { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public GeoData geoData { get; set; }
    }
}
