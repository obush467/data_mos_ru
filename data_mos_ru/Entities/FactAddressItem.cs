using System.Runtime.Serialization;

namespace data_mos_ru.Entities
{
    [DataContract(Name = "FactAddressItem")]
    public class FactAddressItem
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string FactAddress { get; set; }
    }
}