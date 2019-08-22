using System.Collections.Generic;
using System.Runtime.Serialization;

namespace data_mos_ru.Entities
{
    public class EmailItemList
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<string> Email { get; set; }
    }
}