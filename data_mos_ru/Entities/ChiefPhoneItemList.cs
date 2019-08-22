using System.Collections.Generic;
using System.Runtime.Serialization;

namespace data_mos_ru.Entities
{
    public class ChiefPhoneItemList
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<string> ChiefPhone { get; set; }
    }
}
