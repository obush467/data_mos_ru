using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace data_mos_ru.Entities
{
    public class PublicPhoneItemList
    {

        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<string> PublicPhone { get; set; }
    }
}
