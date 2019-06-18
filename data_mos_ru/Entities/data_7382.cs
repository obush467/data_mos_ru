
using System.Collections.Generic;


namespace data_mos_ru.Entities
{

    public class WorkingHoursItem
    {

        /// <summary>
        /// 
        /// </summary>
        public string WorkHours { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DayWeek { get; set; }
    }

    public class ChiefPhoneItem
    {

        /// <summary>
        /// 
        /// </summary>
        public string ChiefPhone { get; set; }
    }

    public class OrgInfoItem
    {

        /// <summary>
        /// 
        /// </summary>
        public string OGRN { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ChiefName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ChiefPhoneItem> ChiefPhone { get; set; }
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
        public string ChiefPosition { get; set; }
    }

    /*public class Available_elementItem
    {

        /// <summary>
        /// 
        /// </summary>
        public string available_index { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Area_mgn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Element_mgn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string available_degree { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Group_mgn { get; set; }
    }*/

   /* public class AvailabilityItem
    {

        /// <summary>
        /// 
        /// </summary>
        public List<Available_elementItem> available_element { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string available_o { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string available_z { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string available_s { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string available_k { get; set; }
    }*/

    public class ObjectAddressItem
    {

        /// <summary>
        /// 
        /// </summary>
        public string PostalCode { get; set; }
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
        public List<AvailabilityItem> Availability { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AdmArea { get; set; }
    }

    public class PublicPhoneItem
    {

        /// <summary>
        /// 
        /// </summary>
        public List<string> PublicPhone { get; set; }
    }

    public class FaxItem
    {

        /// <summary>
        /// 
        /// </summary>
        public List<string> Fax { get; set; }
    }

   /* public class EmailItem
    {

        /// <summary>
        /// 
        /// </summary>
        public List<string> Email { get; set; }
    }*/

    /*public class GeoData
    {

        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<List<double>> coordinates { get; set; }
    }*/

    public class data_7382
    {
    
    /// <summary>
    /// 
    /// </summary>
    public int global_id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<WorkingHoursItem> WorkingHours { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string WebSite { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Category { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string CommonName { get; set; }
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
    public List<OrgInfoItem> OrgInfo { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<ObjectAddressItem> ObjectAddress { get; set; }
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
    public List<PublicPhoneItem> PublicPhone { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<FaxItem> Fax { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<EmailItem> Email { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public GeoData geoData { get; set; }
}
}
