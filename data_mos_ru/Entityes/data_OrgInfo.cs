using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_mos_ru.Entityes
{
    class data_OrgInfo
    {
        public string FullName { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string OGRN { get; set; }
        public string LegalAddress { get; set; }
        public string ChiefName { get; set; }
        public string ChiefPosition { get; set; }
        public List<data_Phone> ChiefPhone { get; set; }
        public List<data_ObjectAddress> ObjectAddress { get; set; }
        //public string ChiefName { get; set; }
    }
}
