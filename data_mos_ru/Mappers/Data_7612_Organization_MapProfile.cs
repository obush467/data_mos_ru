using AutoMapper;
using data_mos_ru.Entities;
using System.Collections.Generic;
using UNS.Models.Entities;

namespace data_mos_ru.Mappers
{
    class Data_7612_Organization_MapProfile : Profile
    {
        public Data_7612_Organization_MapProfile()
        {
            CreateMap<Data_7612, Organization>()
                .ForMember(s => s.GeoData, d => d.MapFrom(s => s.geoData.Coordinates))               
                .ForMember(d => d.PhoneItems, opt => opt.MapFrom((src, o) =>
                {
                    List<UNS.Models.Entities.PhoneItem> res = new List<UNS.Models.Entities.PhoneItem>();
                    res.Add(new UNS.Models.Entities.PhoneItem() { Phone = src.PublicPhone });
                    return res;
                }))
                .ForMember(d => d.OwnerRawAddresses, opt => opt.MapFrom((src, o) =>
                {
                    List<OwnerRawAddress> res = new List<OwnerRawAddress>();
                    res.Add(new OwnerRawAddress()
                    {
                        Address = src.Address,
                        TypeOwner = "использует",
                        Source = "data_7612"//,
                        //Organization = o
                    });
                    return res;
                }))
                .ForAllOtherMembers(s => s.Ignore());

        }
    }
}
