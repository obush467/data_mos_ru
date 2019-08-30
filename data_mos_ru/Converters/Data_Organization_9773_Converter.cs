using AutoMapper;
using data_mos_ru.Entities;
using data_mos_ru.Mappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNS.Models;
using UNS.Models.Entities;

namespace data_mos_ru.Converters
{
    public class Data_Organization_9773_Converter:IMapConverter<Data_Organization_9773,Organization>
    {
        public Data_Organization_9773_Converter(UNS.Models.UNSModel context) : base()
        {
            Context = context;
        }

        public UNSModel Context { get; private set; }

        public List<Organization> Convert(IEnumerable<Data_Organization_9773> data_Organization_2748s)
        {
            var result = new List<Organization>();
            var id = Guid.Parse("ef9e18e4-1e9e-4d50-9886-085c6ba0eaf6");
            var organization = (from org in Context.Organizations
                               where org.Id==id
                               select org)
                        .Include("PhoneItems")
                        .Include("FaxItems")
                        .Include("EmailItems")
                        .Include("OwnerRawAddresses")
                        .Include("Addresses")
                        .Include("PersonPositions")
                        .FirstOrDefault();
            var mapper = (new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new Data_Organization_9773_OwnerRawAddress_MapProfile (Context));
                })).CreateMapper();
                var addresses = data_Organization_2748s.Select(s => mapper.Map<Data_Organization_9773, OwnerRawAddress>(s)).ToList();
                foreach (var addedAddress in addresses)
                {
                    organization.OwnerRawAddresses.Add(addedAddress);
                }
                result.Add(organization);

            return result;
        }
    }
}
