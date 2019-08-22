using System.Runtime.Serialization;

namespace data_mos_ru.Entities
{
    [DataContract(Name = "ResponsiblePersonsItem")]
    public class ResponsiblePersonsItem
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string FIO { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string TypePosition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string NamePosition { get; set; }
    }
}