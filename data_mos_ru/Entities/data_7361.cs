using data_mos_ru.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace data_mos_ru.Entities
{
   // [DataContract(Name = "ChiefPhone")]
    public class Data_7361_ChiefPhoneItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<string> ChiefPhone { get; set; }
    }
   // [DataContract(Name = "OrgInfo")]
    public class Data_7361_OrgInfoItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string OGRN { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ChiefName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<Data_7361_ChiefPhoneItem> ChiefPhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string INN { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string KPP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string LegalAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string FullName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ChiefPosition { get; set; }
    }
    //[DataContract(Name = "Available_elementItem")]
    public class Data_7361_Available_elementItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string available_index { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Area_mgn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Element_mgn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string available_degree { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Group_mgn { get; set; }
    }
   // [DataContract(Name = "AvailabilityItem")]
    public class Data_7361_AvailabilityItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<Data_7361_Available_elementItem> available_element { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string available_o { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string available_z { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string available_s { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string available_k { get; set; }
    }
   // [DataContract(Name = "ObjectAddressItem")]
    public class Data_7361_ObjectAddressItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string PostalCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string District { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<Data_7361_AvailabilityItem> Availability { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string AdmArea { get; set; }
    }
   // [DataContract(Name = "PublicPhoneItem")]
    public class Data_7361_PublicPhoneItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<string> PublicPhone { get; set; }
    }
    //[DataContract(Name = "FaxItem")]
    public class Data_7361_FaxItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<string> Fax { get; set; }
    }
    //[DataContract(Name = "EmailItem")]
    public class Data_7361_EmailItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<string> Email { get; set; }
    }
    //[DataContract(Name = "WorkingHoursItem")]
    public class Data_7361_WorkingHoursItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string WorkHours { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string DayWeek { get; set; }
    }
   // [DataContract(Name = "Data_7361")]
    public class Data_7361
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
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
        public List<Data_7361_OrgInfoItem> OrgInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<Data_7361_ObjectAddressItem> ObjectAddress { get; set; }
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
        public List<Data_7361_PublicPhoneItem> PublicPhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<Data_7361_FaxItem> Fax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<Data_7361_EmailItem> Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<Data_7361_WorkingHoursItem> WorkingHours { get; set; }
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
