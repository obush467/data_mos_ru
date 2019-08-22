using System.Runtime.Serialization;

namespace data_mos_ru.Entities
{
    [DataContract(Name = "BankingDetailsItem")]
    public class BankingDetailsItem
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string SettlementAccount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string BIK { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string NameBank { get; set; }
    }
}