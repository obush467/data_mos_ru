using AutoMapper;
using data_mos_ru.Entities;
using System.Collections.Generic;
using UNS.Models.Entities;

namespace data_mos_ru.Mappers
{
    class Organization_v3_Organization_MapProfile : Profile
    {
        public Organization_v3_Organization_MapProfile()
        {
            CreateMap<data_Organization_v3, Organization>()
               .ForMember(s => s.GeoData, d => d.MapFrom(s => s.geoData.Coordinates))
               .ForMember(s => s.UrAddress, d => d.MapFrom(s => s.Address))
               .ForMember(s => s.Id, d => d.Ignore())
               .ForMember(d => d.PhoneItems, opt => opt.MapFrom((src, o) =>
               {
                   List<UNS.Models.Entities.PhoneItem> res = new List<UNS.Models.Entities.PhoneItem>();
                   foreach (var phone in src.PublicPhone)
                   {
                       res.Add(new UNS.Models.Entities.PhoneItem() { Phone = phone.PublicPhone });
                   }
                   return res;
               }))
               .ForMember(d => d.OwnerRawAddresses, opt => opt.MapFrom((src, o) =>
               {
                   List<OwnerRawAddress> res = new List<OwnerRawAddress>();
                   res.Add(new OwnerRawAddress()
                   {
                       Address = src.Address,
                       TypeOwner = "юрадрес",
                       Source = "data_mos_ru"//,
                                             //Organization = o
                   });
                   return res;
               }))
               .ForAllOtherMembers(options => options.PreCondition((source, destination, member) => member != null));
        }
    }
}
