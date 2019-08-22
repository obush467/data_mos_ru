using System.Collections.Generic;

namespace data_mos_ru.Entities
{
    public class OrgInfoItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string OGRN { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ChiefPosition { get; set; }
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
        public string ChiefName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ChiefPhoneItem> ChiefPhone { get; set; }
    }
}
