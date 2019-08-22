using System.Runtime.Serialization;

namespace data_mos_ru.Entities
{
    [DataContract(Name = "PersonalAccountsItem")]
    public class PersonalAccountsItem
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Account { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string OpenDate { get; set; }
    }
}