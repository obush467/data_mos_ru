using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace data_mos_ru.Entities
{

    public class data_2346_5883_OrgInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string OGRN { get; set; }
        public string ChiefPosition { get; set; }
        public string ChiefName { get; set; }
        public List<data_2346_5883_ChiefPhoneItem> ChiefPhone { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string LegalAddress { get; set; }
        public string FullName { get; set; }
        public string ChiefGender { get; set; }
    }
    public class data_2346_5883_ChiefPhoneItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ChiefPhone { get; set; }
    }
    public class data_2346_5883_Availability
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public List<object> available_element { get; set; }
        public string available_o { get; set; }
        public string available_z { get; set; }
        public string available_s { get; set; }
        public string available_k { get; set; }
    }

    public class data_2346_5883_ObjectAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string PostalCode { get; set; }
        public string AdmArea { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public List<data_2346_5883_Availability> Availability { get; set; }
    }

    public class data_2346_5883_WorkingHour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string WorkHours { get; set; }
        public string DayWeek { get; set; }
    }

    public class data_2346_5883
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int global_id { get; set; }
        public List<object> AmbulanceStationPhone { get; set; }
        public List<data_2346_5883_OrgInfo> OrgInfo { get; set; }
        public List<data_2346_5883_ObjectAddress> ObjectAddress { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public List<object> DoctorsSpecialtiesListForSelfRecording { get; set; }
        public string Category { get; set; }
        public string ChiefName { get; set; }
        public string ChiefPosition { get; set; }
        public string ChiefGender { get; set; }
        //public List<ChiefPhoneItem> ChiefPhone { get; set; }
        public List<data_2346_5883_PublicPhoneItem> PublicPhone { get; set; }
        //public List<FaxItem> Fax { get; set; }
        public List<Data_2346_5883_EmailItem> Email { get; set; }
        public string CloseFlag { get; set; }
        public string PaidServiceInfo { get; set; }
        public List<data_2346_5883_WorkingHour> WorkingHours { get; set; }
        public GeoData geoData { get; set; }
    }
    public class data_2346_5883_PublicPhoneItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [MaxLength(30)]
        public string PublicPhone { get; set; }
    }

    public class Data_2346_5883_EmailItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
    }
}

