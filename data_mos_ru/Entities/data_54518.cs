using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace data_mos_ru.Entities
{
    [DataContract(Name = "LicensingAndAccreditationItem")]
    public class Data_54518_LicensingAndAccreditationItem
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string LicenseSeries { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string LicenseNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string LicenseExpires { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string AccreditationAvailability { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string LicenseAvailability { get; set; }
    }

    [DataContract(Name = "InstitutionsAddressesItem")]
    public class Data_54518_InstitutionsAddressesItem
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [MaxLength(150)]
        public string ChiefName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [MaxLength(100)]
        public string ChiefPosition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [MaxLength(1000)]
        public string FullName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [MaxLength(100)]
        public string District { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [MaxLength(1000)]
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
        public List<PublicPhoneItem> PublicPhone { get; set; }
        /// <summary>
        /// 
        /// </summar
        /// y>
        [DataMember]
        [MaxLength(100)]
        public string WebSite { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [MaxLength(100)]
        public string AdmArea { get; set; }
    }
    [DataContract(Name = "data_54518")]
    public class Data_54518
    {

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int Global_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[DataMember]
        ////public List<string> EntranceExaminationsAndUniforms { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string KPP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[DataMember]
        [DataMember]
        public List<Data_54518_LicensingAndAccreditationItem> LicensingAndAccreditation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string OGRN { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string LegalOrganization { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Subordination { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ChiefName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string LegalAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[DataMember]
        [DataMember]
        public List<PublicPhoneItem> PublicPhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<EmailItem> Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string WebSite { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string EducationPrograms { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public List<string> EducationalServices { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ReorganizationStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int IDEKIS { get; set; }
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
        public List<Data_54518_InstitutionsAddressesItem> InstitutionsAddresses { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string INN { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public GeoData GeoData { get; set; }
    }
}

