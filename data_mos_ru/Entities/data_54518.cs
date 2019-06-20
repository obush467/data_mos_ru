using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace data_mos_ru.Entities
{
    [Table("LicensingAndAccreditationItem", Schema = "data_mos_ru")]
    [DataContract(Name = "LicensingAndAccreditationItem")]
    public class LicensingAndAccreditationItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
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
    [Table("PublicPhoneItem1", Schema = "data_mos_ru")]
    [DataContract(Name = "PublicPhoneItem1")]
    public class PublicPhoneItem1
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
    [Table("PublicPhoneItem2", Schema = "data_mos_ru")]
    [DataContract(Name = "PublicPhoneItem2")]
    public class PublicPhoneItem2
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
    [Table("EmailItem", Schema = "data_mos_ru")]
    [DataContract(Name = "EmailItem")]
    public class EmailItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [MaxLength(50)]
        public string Email { get; set; }
    }
    [Table("Available_elementItem", Schema = "data_mos_ru")]
    [DataContract(Name = "Available_elementItem")]
    public class Available_elementItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Available_index { get; set; }
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
        public string Available_degree { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Group_mgn { get; set; }
    }
    [Table("AvailabilityItem", Schema = "data_mos_ru")]
    [DataContract(Name = "AvailabilityItem")]
    public class AvailabilityItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<Available_elementItem> Available_element { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Available_o { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Available_z { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Available_s { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Available_k { get; set; }
    }
    [Table("InstitutionsAddressesItem", Schema = "data_mos_ru")]
    [DataContract(Name = "InstitutionsAddressesItem")]
    public class InstitutionsAddressesItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
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
        public List<PublicPhoneItem1> PublicPhone { get; set; }
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
    [Table("data_54518", Schema = "data_mos_ru")]
    [DataContract(Name = "data_54518")]
    public class Data_54518
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

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
        public List<LicensingAndAccreditationItem> LicensingAndAccreditation { get; set; }
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
        public List<PublicPhoneItem2> PublicPhone { get; set; }
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
        public List<InstitutionsAddressesItem> InstitutionsAddresses { get; set; }
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

