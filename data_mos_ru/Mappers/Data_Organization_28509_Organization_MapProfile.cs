using AutoMapper;
using data_mos_ru.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using UNS.Models;
using UNS.Models.Entities;

namespace data_mos_ru.Mappers
{
    class Data_Organization_28509_Organization_MapProfile : Profile
    {
        public UNSModel Context { get; private set; }
        public Data_Organization_28509_Organization_MapProfile(UNSModel context) : this()
        { Context = context; }
        public Data_Organization_28509_Organization_MapProfile() : base()
        {
            CreateMap<data_Organization_28509, Organization>()
                .ForMember(s => s.Id, opt => opt.Ignore())
                .ForMember(s => s.GeoData, d => d.MapFrom(s => s.geoData.Coordinates))
                .ForMember(s => s.FullName, d => d.MapFrom(s => s.OperatingCompany))
                .ForMember(s => s.ShortName, d => d.MapFrom(s => s.Name))
                .ForMember(s => s.OwnerRawAddresses, opt => opt.MapFrom((source, destination) =>
                {
                    var ownerRawAddresses = new List<OwnerRawAddress>();
                    ownerRawAddresses.Add(new OwnerRawAddress()
                    {
                        DirtyAddress = source.Address,
                        Address = source.Address,
                        Source = source.GetType().Name,
                        TypeOwner = "использует",
                    });
                    return ownerRawAddresses;
                }))
                .ForMember(s=>s.Comments,d=>d.MapFrom(s=>string.Join("; ","global_id",s.global_id.ToString(), "IsNetObject", s.IsNetObject, "TypeService",s.TypeService, "TypeObject",s.TypeObject)))
                .ForAllMembers(options => options.PreCondition((source, destination, member) => member != null));

        }
    }
}
