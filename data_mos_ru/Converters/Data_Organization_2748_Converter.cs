using data_mos_ru.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNS.Models.Entities;

namespace data_mos_ru.Converters
{
    public static class Data_Organization_2748_Converter
    {
        public static List<Organization> Convert(IEnumerable<Data_Organization_2748> data_Organization_2748s, UNS.Models.UNSModel context)
        {
            var result = new List<Organization>();

            var orgNames = from org in data_Organization_2748s
                           group org by org.BalanceHolderName;
            if (orgNames.Any())
                foreach (IGrouping<string, Data_Organization_2748> orgGroup in orgNames)
                {
                    var neworg = new Organization()
                    {
                        Addresses = new List<Organization_House>(),
                        FullName = orgGroup.Key,
                        OwnerRawAddresses = new List<OwnerRawAddress>(),
                        PersonPositions = new List<PersonPosition>(),
                        //EmailItems = new List<UNS.Models.Entities.EmailItem>(),
                        //FaxItems = new List<UNS.Models.Entities.FaxItem>()

                    };
                    foreach (var grouprecord in orgGroup)
                    {
                        var geo = grouprecord.geoData.Coordinates;
                        var addresses = from hbti in context.HouseFullBTIs
                                        join hf in context.HouseFulls
                                        on hbti.HouseFull equals hf
                                        join h in context.Houses
                                        on hf.HOUSEID equals h.HOUSEID
                                        where (hbti.UNOM.ToString() == grouprecord.UNOM
                                        //|| hf.GeoData.Intersects(geo)
                                        )
                                        && DateTime.Now <= h.ENDDATE && DateTime.Now >= h.STARTDATE
                                        select new { hbti, hf, h };
                        if (addresses.Any())
                        {
                            var address = addresses.FirstOrDefault();
                            neworg.Addresses.Add(new Organization_House()
                            {
                                HouseGUID = address.hf.HOUSEGUID,
                                TypeRelation = "управляет",
                                Source = grouprecord.GetType().Name,
                                Comments = grouprecord.Name
                            });
                        }
                        else
                            neworg.OwnerRawAddresses.Add(new OwnerRawAddress()
                            {
                                DirtyAddress = grouprecord.Location,
                                Address = grouprecord.Location,
                                Source = grouprecord.GetType().Name,
                                TypeOwner = "управляет"
                            });
                    }
                    result.Add(neworg);

                }

            return result;
        }
    }
}
