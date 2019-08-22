using System.Collections.Generic;

namespace data_mos_ru.Entities
{

    public class data_Organization_v1_Base
    {
        /// <summary>
        /// 
        /// </summary>
        public int global_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Category { get; set; }
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
        public string CommonName { get; set; }
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
        public List<ChiefPhoneItem> ChiefPhone { get; set; }
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
        public List<WorkingHoursItem> WorkingHours { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public GeoData geoData { get; set; }
    }
}
