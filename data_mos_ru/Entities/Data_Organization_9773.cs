using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_mos_ru.Entities
{
    public class Data_Organization_9773
    {
        /// <summary>
        /// 
        /// </summary>
        public int global_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ObjectType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AISID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ObjectNameOnDoc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> AdmArea { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> District { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SecurityStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public GeoData geoData { get; set; }
    }
}
