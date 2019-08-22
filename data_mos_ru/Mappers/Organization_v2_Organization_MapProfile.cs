using AutoMapper;
using data_mos_ru.Entities;
using System.Collections.Generic;
using UNS.Models.Entities;

namespace data_mos_ru.Mappers
{
    public class Organization_v2_Organization_MapProfile : Profile
    {
        public Organization_v2_Organization_MapProfile()
        {
            CreateMap<data_Organization_v2, Organization>()
                 .ForMember(s => s.GeoData, d => d.MapFrom(s => s.geoData.Coordinates))
                 .ForMember(s => s.FaxItems, d => new List<UNS.Models.Entities.FaxItem>())
                 .ForMember(s => s.EmailItems, d => new UNS.Models.Entities.EmailItem())
                 .ForMember(s => s.UrAddress, d => d.MapFrom(s => s.Address))
                 .ForMember(s => s.Id, d => d.Ignore())
                 .ForMember(d => d.PhoneItems, opt => opt.MapFrom((src, o) =>
                 {
                     List<UNS.Models.Entities.PhoneItem> res = new List<UNS.Models.Entities.PhoneItem>();
                     foreach (var phone in src.Phone)
                     {
                         res.Add(new UNS.Models.Entities.PhoneItem() { Phone = phone.Phone });
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
                 }));

        }
    }
}
