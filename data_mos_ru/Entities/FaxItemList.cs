using System.Collections.Generic;
using System.Runtime.Serialization;

namespace data_mos_ru.Entities
{
    public class FaxItemList
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<string> Fax { get; set; }
    }
}
