using System.Runtime.Serialization;

namespace data_mos_ru.Entities
{
    [DataContract(Name = "AdditionalOKVEDItem")]
    public class AdditionalOKVEDItem
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string AdditionalOKVED { get; set; }
    }
}