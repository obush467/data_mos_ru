using AutoMapper;
using data_mos_ru.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNS.Models.Entities;

namespace data_mos_ru.Mappers
{
    public class Data_Organization_7949_Organization_MapProfile:Profile
    {
        public Data_Organization_7949_Organization_MapProfile() : base()
        {
            CreateMap<Data_Organization_7949, Organization>()
                .ForMember(s => s.Id, d => d.Ignore())
                .ForMember(s => s.GeoData, d => d.MapFrom(s => s.geoData.Coordinates))
                .ForMember(s => s.OwnerRawAddresses, options =>
                {
                    options.PreCondition((source, destination, member) => source.LegalAddress != null || source.Address != null);
                    options.MapFrom((source, destination, member) =>
                    {
                        var ownerRawAddresses = new List<OwnerRawAddress>();
                        var addressItem = Utility.AddressOperator.PostReplace(source.LegalAddress);
                        ownerRawAddresses.Add(new OwnerRawAddress()
                        {
                                                
                            PostCode = addressItem.PostCode,
                            Address = addressItem.Address,
                            DirtyAddress= source.LegalAddress,
                            Source = source.GetType().Name,
                            TypeOwner = "юрадрес"
                        });
                        addressItem = Utility.AddressOperator.PostReplace(source.Address);
                        ownerRawAddresses.Add(new OwnerRawAddress()
                        {
                            PostCode = addressItem.PostCode,
                            Address = addressItem.Address,
                            DirtyAddress = source.Address,
                            Source = source.GetType().Name,
                            TypeOwner = "использует"
                        });
                        return ownerRawAddresses;
                    });
                })
                .ForMember(d => d.PhoneItems, opt =>
                {
                    opt.PreCondition(member => member.ContactPhone != null);
                    opt.MapFrom((src, o) =>
                    {
                        List<UNS.Models.Entities.PhoneItem> res = new List<UNS.Models.Entities.PhoneItem>();
                        foreach (var n in src.ContactPhone)
                        {
                            res.Add(new UNS.Models.Entities.PhoneItem() { Phone = n.PublicPhone });
                        }
                        return res;
                    });
                })
                 .ForAllOtherMembers(options => options.Condition((source, destination, svalue, destvalue, rr) => svalue != null && destvalue == null));
        }
    }
}
