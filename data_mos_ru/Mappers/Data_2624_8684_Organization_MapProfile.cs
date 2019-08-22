using AutoMapper;
using data_mos_ru.Entities;
using System.Collections.Generic;
using UNS.Models.Entities;

namespace data_mos_ru.Mappers
{
    public class Data_2624_8684_Organization_MapProfile : Profile
    {
        public Data_2624_8684_Organization_MapProfile()
        {
            CreateMap<Data_2624_8684, Organization>()
                .ForMember(d => d.OwnerRawAddresses, opt => opt.MapFrom((src, o) =>
                {
                    List<OwnerRawAddress> res = new List<OwnerRawAddress>();
                    res.Add(new OwnerRawAddress()
                    {
                        Address = src.Address,
                        TypeOwner = "использует",
                        Source = "data_2624_8684",
                        Organization = o
                    });
                    return res;
                }))
                .ForMember(s => s.GeoData, d => d.MapFrom(s => s.geoData.Coordinates))
                .ForMember(s => s.FullName, d => d.MapFrom(s => s.Name))
                .ForMember(d => d.PhoneItems, opt => opt.MapFrom((src, o) =>
                {
                    List<UNS.Models.Entities.PhoneItem> res = new List<UNS.Models.Entities.PhoneItem>();
                    foreach (var n in src.PublicPhone)
                    {
                        res.Add(new UNS.Models.Entities.PhoneItem() { Phone = n.PublicPhone });
                    }
                    return res;
                }));
        }
    }
}
