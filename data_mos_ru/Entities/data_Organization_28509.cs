using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_mos_ru.Entities
{
public class data_Organization_28509
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
        public string ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OperatingCompany { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string IsNetObject { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TypeService { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TypeObject { get; set; }
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
        public List<PublicPhoneItem> PublicPhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public GeoData geoData { get; set; }
    }
}
