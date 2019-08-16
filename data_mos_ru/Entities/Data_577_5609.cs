using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace data_mos_ru.Entities
{
    public class Data_577_5609_ChiefPhoneItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ChiefPhone { get; set; }
    }

    public class Data_577_5609_OrgInfoItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OGRN { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ChiefPosition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ChiefName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        // public List<ChiefPhoneItem> ChiefPhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string INN { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string KPP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LegalAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ChiefGender { get; set; }
    }

    public class Data_577_5609_AvailabilityItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string available_z { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string available_o { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string available_s { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> available_element { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string available_k { get; set; }
    }

    public class Data_577_5609_ObjectAddressItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AdmArea { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string District { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
       // public List<Data_577_5609_AvailabilityItem> Availability { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Extrainfo { get; set; }
    }
    [DataContract(Name = "PublicPhoneItem")]
    public class Data_577_5609_PublicPhoneItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<string> PublicPhone { get; set; }
    }

    public class Data_577_5609_FaxItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Fax { get; set; }
    }

    public class Data_577_5609_EmailItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
    }

    public class Data_577_5609_WorkingHoursItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WorkHours { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DayWeek { get; set; }
    }

    public class Data_577_5609
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int global_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public string AmbulanceStationPhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> DoctorsSpecialtiesListForSelfRecording { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ChiefName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ChiefPosition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ChiefGender { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CloseFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BedSpace { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PaidServiceInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Specialization { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Data_577_5609_OrgInfoItem> OrgInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Data_577_5609_ObjectAddressItem> ObjectAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public List<Data_577_5609_ChiefPhoneItem> ChiefPhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Data_577_5609_PublicPhoneItem> PublicPhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Data_577_5609_FaxItem> Fax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Data_577_5609_EmailItem> Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Data_577_5609_WorkingHoursItem> WorkingHours { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public GeoData geoData { get; set; }
    }

}
