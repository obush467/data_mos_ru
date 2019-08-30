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
    public class Data_Organization_2748_Organization_MapProfile:Profile
    {
        public UNSModel Context { get; private set; }
        public Data_Organization_2748_Organization_MapProfile(UNSModel context) : this()
        { Context = context; }
        public Data_Organization_2748_Organization_MapProfile() : base()
        {
                   
        
        CreateMap<Data_Organization_2748,Organization>()
                .ForMember(s => s.Id, opt => opt.Ignore())
                .ForMember(d=>d.Comments,opt=>opt.MapFrom(m=>m.Name))
                .ForMember(d => d.FullName, opt => opt.MapFrom(m => m.BalanceHolderName))
                .ForMember(s => s.OwnerRawAddresses, opt => opt.MapFrom((source, destination) =>
                {
                    var ownerRawAddresses = new List<OwnerRawAddress>();
                    ownerRawAddresses.Add(new OwnerRawAddress()
                    {
                        DirtyAddress = source.Location,
                        Address = source.Location,
                        Source = source.GetType().Name,
                        TypeOwner = "управляет"
                    });
                    return ownerRawAddresses;
                }))

                .ForMember(s => s.Addresses ,opt => opt.MapFrom((source, destination) =>
                {
                    var addresses = from hbti in Context.HouseFullBTIs
                                    join hf in Context.HouseFulls
                                    on hbti.HouseFull equals hf
                                    where hbti.UNOM.ToString() == source.UNOM
                                    select new { hbti,hf};
                    var houses = new List<Organization_House>();
                    if (addresses.Any())
                    {
                        
                        var address = addresses.FirstOrDefault();
                        houses.Add(new Organization_House()
                        {
                            HouseGUID = address.hf.HOUSEGUID,
                            TypeRelation = "управляет",
                            Source = source.GetType().Name,
                            Comments = source.Name
                        });
                    }
                    return houses;
                }))

                 .ForAllMembers(options => options.PreCondition((source, destination, member) => member != null));


        }

    }
}
