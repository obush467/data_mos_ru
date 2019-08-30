using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_mos_ru.Entities
{
    public class Data_Organization_2748
    {
        /// <summary>
        /// 
        /// </summary>
        public int global_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BalanceHolderName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
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
        public string Location { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LocationClarification { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CloseFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<WorkingHoursItem> WorkingHours { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PaidService { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DisabilityFriendly { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UNOM { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EntryState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public List<string> EntryModifyReason { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public List<string> ParentEntries { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public List<string> ChildEntries { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<AvailabilityItem> Availability { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public GeoData geoData { get; set; }
    }
}
