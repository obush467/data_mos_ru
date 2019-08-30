using AutoMapper;
using data_mos_ru.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNS.Models;
using UNS.Models.Entities;

namespace data_mos_ru.Mappers
{
    public class Data_Organization_9773_OwnerRawAddress_MapProfile : Profile
    {
        public UNSModel Context { get; private set; }
        public Data_Organization_9773_OwnerRawAddress_MapProfile(UNSModel context) : this()
        { Context = context; }
        public Data_Organization_9773_OwnerRawAddress_MapProfile() : base()
        {                    
        CreateMap<Data_Organization_9773,OwnerRawAddress>()
                .ForMember(s => s.ID, opt => opt.Ignore())
                .ForMember(s => s.DirtyAddress, opt => opt.MapFrom((source, destination) => source.Address))
                .ForMember(s => s.Source ,opt => opt.MapFrom((source, destination) =>source.GetType().Name))
                .ForMember(s => s.TypeOwner,opt=>opt.MapFrom((source, destination) => "владеет"))
                //.ForMember(s => s.Organization_Id, opt => opt.MapFrom((source, destination) => Guid.Parse("ef9e18e4-1e9e-4d50-9886-085c6ba0eaf6")))
                .ForAllMembers(options => options.PreCondition((source, destination, member) => member != null));
        }
    }
}
