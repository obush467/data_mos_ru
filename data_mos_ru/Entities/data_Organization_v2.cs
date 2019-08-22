using System.Collections.Generic;

namespace data_mos_ru.Entities
{

    public class data_Organization_v2
    {
        /// <summary>
        /// 
        /// </summary>
        public int global_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ClarificationOfWorkingHours { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
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
        public string INN { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string KPP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OGRN { get; set; }
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
        public List<PhoneItem> Phone { get; set; }
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
