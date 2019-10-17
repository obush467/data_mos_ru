using AutoMapper;
using data_mos_ru.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNS.Models.Entities;
using Utility;

namespace data_mos_ru.Mappers
{
    public class Data_Organization_2834_Organization_MapProfile:Profile
    {
        public Data_Organization_2834_Organization_MapProfile()
        {
            CreateMap<Data_Organization_2834, Organization>()
                .ForMember(s => s.Id, opt => opt.Ignore())
                .ForMember(s => s.GeoData, d => d.MapFrom(s => s.geoData.Coordinates))
                .ForMember(d => d.Comments, opt => opt.MapFrom(m => m.Name))
                .ForMember(d => d.FullName, opt => opt.MapFrom(m => m.ManagementCompany))
                .ForMember(s => s.OwnerRawAddresses, opt => opt.MapFrom((source, destination) =>
                {
                    var ownerRawAddresses = new List<OwnerRawAddress>();
                    var address = AddressOperator.PostReplace(source.Address);
                    ownerRawAddresses.Add(new OwnerRawAddress()
                    {
                        PostCode=address.PostCode,
                        DirtyAddress = source.Address,
                        Address = address.Address,
                        Source = source.GetType().Name,
                        TypeOwner = "управляет"
                    }) ;
                    address = AddressOperator.PostReplace(source.LegalAddressOfManagementCompany);
                    ownerRawAddresses.Add(new OwnerRawAddress()
                    {
                        PostCode = address.PostCode,
                        DirtyAddress = source.LegalAddressOfManagementCompany,
                        Address = address.Address,
                        Source = source.GetType().Name,
                        TypeOwner = "юрадрес"
                    });
                    return ownerRawAddresses;
                }))
                .ForAllMembers(options => options.Condition((source, destination, sourcevalue,destvalue) => sourcevalue != null && destvalue==null));
        }
    }
}
