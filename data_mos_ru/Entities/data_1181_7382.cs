using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace data_mos_ru.Entities
{
    public class WorkingHoursItem
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

    public class ChiefPhoneItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ChiefPhone { get; set; }
    }

    public class OrgInfoItem
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
        //[DataMember]
        //public List<ChiefPhoneItem> ChiefPhone { get; set; } = new List<ChiefPhoneItem>();
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

    /*public class Available_elementItem
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
    }*/
    /*
    public class AvailabilityItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<Available_elementItem> available_element { get; set; }
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
    }*/

    public class ObjectAddressItem
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
        public List<AvailabilityItem> Availability { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string AdmArea { get; set; }
    }

    public class PublicPhoneItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<string> PublicPhone { get; set; }
    }

    public class FaxItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<string> Fax { get; set; }
    }

    /* public class EmailItem
     {
         [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public Guid Id { get; set; }
         /// <summary>
         /// 
         /// </summary>
         [DataMember]
         public List<string> Email { get; set; }
     }*/

    /*public class GeoData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<List<double>> coordinates { get; set; }
    }*/

    public class Data_1181_7382
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int Global_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<WorkingHoursItem> WorkingHours { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string WebSite { get; set; }
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
        public List<OrgInfoItem> OrgInfo { get; set; }
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
        public List<PublicPhoneItem> PublicPhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<FaxItem> Fax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[DataMember]
        //public List<EmailItem> Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public GeoData GeoData { get; set; }
    }
}
