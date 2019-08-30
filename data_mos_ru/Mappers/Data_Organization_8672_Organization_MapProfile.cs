using AutoMapper;
using data_mos_ru.Comparers;
using data_mos_ru.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNS.Models.Entities;

namespace data_mos_ru.Mappers
{
    public class Data_Organization_8672_Organization_MapProfile:Profile
    {
        public Data_Organization_8672_Organization_MapProfile() : base()
        {
            CreateMap<Data_Organization_8672, Organization>()
                .ForMember(s => s.Id, d => d.Ignore())
                .ForMember(s => s.GeoData, d => d.MapFrom(s => s.geoData.Coordinates))
                .ForMember(s => s.OwnerRawAddresses, options =>
                {
                    options.PreCondition((source, destination, member) => source.Address != null);
                    options.MapFrom((source, destination, member) =>
                    {
                        var ownerRawAddresses = new List<OwnerRawAddress>();
                        ownerRawAddresses.Add(new OwnerRawAddress()
                        {
                            DirtyAddress = source.Address,
                            Address = source.Address,
                            Source = source.GetType().Name,
                            TypeOwner = "использует"
                        });
                        return ownerRawAddresses;
                    });
                })
                 .ForAllOtherMembers(options => options.Condition((source, destination, svalue, destvalue, rr) => svalue != null && destvalue == null));

        }
    }
}
