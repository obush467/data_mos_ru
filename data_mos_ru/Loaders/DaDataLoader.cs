using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dadata;
using Dadata.Model;

namespace data_mos_ru.Loaders
{
    public class DaDataLoader:Loader
    {
        static string apikey = "b2ee2ed899d6a3ec57fbe96d6b6034f3c404edbd";
        SuggestClient Api { get; set; } = new SuggestClient(apikey);
        public void Load()
        {
            var s = new SuggestPartyRequest("ПСИХОНЕВРОЛОГИЧЕСКИЙ ИНТЕРНАТ № 10") { count = 2000};
            s.type = PartyType.LEGAL;
            var response = Api.SuggestParty(s);
            var party = response.suggestions[0];
        }
    }
}
