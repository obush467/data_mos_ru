using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace data_mos_ru.Entities
{

    public class data_5870
    {
        /// <summary>
        /// 
        /// </summary>
        public int global_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AmbulanceStationPhone { get; set; }
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
        public string ClarificationWorkingHours { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public GeoData geoData { get; set; }

       
    }
}
