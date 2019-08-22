using AutoMapper;
using data_mos_ru.Comparers;
using System.Collections.Generic;
using System.Linq;
using UNS.Models.Entities;

namespace data_mos_ru.Mappers
{
    public class Organization_Organization_MapProfile : Profile
    {
        public Organization_Organization_MapProfile()
        {
            CreateMap<Organization, Organization>()
                .ForMember(s => s.Id, d => d.Ignore())
                .ForMember(s => s.PhoneItems, options =>
                {
                    options.PreCondition(member => member.PhoneItems != null);
                    options.MapFrom((source, destination, member) =>
                    {
                        var t = destination.PhoneItems
                            .ToList()
                            .Concat(source.PhoneItems.Except(destination.PhoneItems.ToList(), new PhoneItemComparer()).ToList());
                        return t;
                    });
                })
                .ForMember(s => s.FaxItems, options =>
                {
                    options.PreCondition(member => member.FaxItems != null);
                    options.MapFrom((source, destination, member) =>
                    {
                        var d = destination.FaxItems.ToList();
                        var s = source.FaxItems.ToList();
                        return (d.Any()) ?
                            d.Concat(s.Except(d, new FaxItemComparer()).ToList())
                            : source.FaxItems.ToList();
                    });
                })
                .ForMember(s => s.EmailItems, options =>
                {
                    options.PreCondition((source, destination, member) => source.EmailItems != null);
                    options.MapFrom((source, destination, member) =>
                    {
                        var d = destination.EmailItems.ToList();
                        var s = source.EmailItems.ToList();
                        return (d.Any()) ?
                            d.Concat(s.Except(d, new EmailItemComparer()).ToList())
                            : source.EmailItems.ToList();
                    });
                })
                .ForMember(s => s.OwnerRawAddresses, options =>
                {
                    options.PreCondition(member => member.OwnerRawAddresses != null && member.OwnerRawAddresses.Count > 0);
                    options.MapFrom((source, destination, member) =>
                    {
                        var d = destination.OwnerRawAddresses.ToList();
                        var s = source.OwnerRawAddresses.ToList();
                        return (d.Any()) ?
                            d.Concat(s.Except(d, new OwnerRawAddressComparer())).ToList()
                            : source.OwnerRawAddresses.ToList();
                    });
                })
                .ForMember(s => s.PersonPositions, options =>
                {//TODO доделать 
                    options.PreCondition(member => member.PersonPositions != null && member.PersonPositions.Count > 0);
                    options.MapFrom((source, destination, member) =>
                    {
                        var d = destination.PersonPositions;
                        var s = source.PersonPositions;
                        if (d.Any() && s.Any())
                        {
                            var intersected = (from dintersected in d
                                               from sintersected in s
                                               where
                            dintersected.Person.Family.ToLower() == sintersected.Person.Family.ToLower()
                            && dintersected.Person.Name.ToLower() == sintersected.Person.Name.ToLower()
                            && dintersected.Person.Patronymic.ToLower() == sintersected.Person.Patronymic.ToLower()
                            &&
                            (dintersected.PositionType == sintersected.PositionType
                                               && dintersected.PositionType != null
                                               && sintersected.PositionType != null)
                                               || (dintersected.PositionType == null && sintersected.PositionType != null)
                                               || (dintersected.PositionType != null && sintersected.PositionType == null)
                                               select new { destItem = dintersected, sourseItem = sintersected }).ToList();

                            foreach (var intersectedItem in intersected)
                            {
                                if (intersectedItem.sourseItem.Emails != null && intersectedItem.destItem.Emails != null)
                                {
                                    var demail = intersectedItem.destItem.Emails;
                                    var semail = intersectedItem.sourseItem.Emails;
                                    demail = (demail.Any())
                                        ? (ICollection<UNS.Models.Entities.EmailItem>)demail.Concat(semail.Except(demail, new EmailItemComparer())).ToList()
                                        : (ICollection<UNS.Models.Entities.EmailItem>)semail.ToList();
                                }
                                if (intersectedItem.sourseItem.Phones != null && intersectedItem.destItem.Phones != null)
                                {
                                    var dphone = intersectedItem.destItem.Phones;
                                    var sphone = intersectedItem.sourseItem.Phones;
                                    dphone = (dphone.Any())
                                    ? (ICollection<UNS.Models.Entities.PhoneItem>)dphone.Concat(sphone.Except(dphone, new PhoneItemComparer())).ToList()
                                    : (ICollection<UNS.Models.Entities.PhoneItem>)sphone.ToList();
                                }
                                if (intersectedItem.sourseItem.Faxes != null && intersectedItem.destItem.Faxes != null)
                                {
                                    var dphone = intersectedItem.destItem.Faxes;
                                    var sphone = intersectedItem.sourseItem.Faxes;
                                    dphone = (dphone.Any())
                                    ? (ICollection<UNS.Models.Entities.FaxItem>)dphone.Concat(sphone.Except(dphone, new FaxItemComparer())).ToList()
                                    : (ICollection<UNS.Models.Entities.FaxItem>)sphone.ToList();
                                }

                            }
                            var yy = d.Concat(s.Except(d, new PersonPositionComparer())).ToList();
                            return yy;
                        }
                        else return d.Concat(s.Except(d, new PersonPositionComparer()).ToList());
                    });
                })
                .ForAllOtherMembers(options => options.PreCondition((source, destination, member) => member != null))
                ;
        }
    }
}
