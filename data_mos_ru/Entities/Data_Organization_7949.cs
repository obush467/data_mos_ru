using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_mos_ru.Entities
{
    public class Data_Organization_7949
    {
        /// <summary>
        /// 
        /// </summary>
        public int global_id { get; set; }
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
        public string LegalAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<PublicPhoneItem> ContactPhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WebSite { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public GeoData geoData { get; set; }
    }
}
