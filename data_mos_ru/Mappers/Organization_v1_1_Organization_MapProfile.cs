using AutoMapper;
using data_mos_ru.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using UNS.Models;
using UNS.Models.Entities;

namespace data_mos_ru.Mappers
{
    internal class Organization_v1_1_Organization_MapProfile : Profile
    {
        public UNSModel ContexUNS { get; private set; }

        public Organization_v1_1_Organization_MapProfile(UNS.Models.UNSModel context) : this()
        {
            ContexUNS = context;
        }
        public Organization_v1_1_Organization_MapProfile()
        {
            CreateMap<data_Organization_v1_1, Organization>()
                .ForMember(s => s.GeoData, d => d.MapFrom(s => s.geoData.Coordinates))
                .ForMember(s => s.OGRN, d => d.MapFrom(s => s.OrgInfo[0].OGRN))
                .ForMember(s => s.INN, d => d.MapFrom(s => s.OrgInfo[0].INN))
                .ForMember(s => s.KPP, d => d.MapFrom(s => s.OrgInfo[0].KPP))
                .ForMember(s => s.UrAddress, d => d.MapFrom(s => s.OrgInfo[0].LegalAddress))
                .ForMember(d => d.PhoneItems, opt =>
                {
                    opt.PreCondition(member => member.PublicPhone != null);
                    opt.MapFrom((src, o) =>
                    {
                        List<UNS.Models.Entities.PhoneItem> res = new List<UNS.Models.Entities.PhoneItem>();
                        foreach (var n in src.PublicPhone)
                        {
                            res.Add(new UNS.Models.Entities.PhoneItem() { Phone = n.PublicPhone });
                        }
                        return res;
                    });
                })
                .ForMember(d => d.EmailItems, opt =>
                {
                    opt.PreCondition(member => member.Email != null);
                    opt.MapFrom((src, o) =>
                    {
                        List<UNS.Models.Entities.EmailItem> res = new List<UNS.Models.Entities.EmailItem>();
                        foreach (var n in src.Email)
                        {
                            res.Add(new UNS.Models.Entities.EmailItem() { Email = n.Email });
                        }
                        return res;
                    });
                })
                .ForMember(d => d.FaxItems, opt =>
                {
                    opt.PreCondition(member => member.Fax != null);
                    opt.MapFrom((src, o) =>
                    {
                        List<UNS.Models.Entities.FaxItem> res = new List<UNS.Models.Entities.FaxItem>();
                        foreach (var n in src.Fax)
                        {
                            res.Add(new UNS.Models.Entities.FaxItem() { Fax = n.Fax });
                        }
                        return res;
                    });
                })
                .ForMember(d => d.OwnerRawAddresses, opt => opt.MapFrom((src, o) =>
                {
                    List<OwnerRawAddress> res = new List<OwnerRawAddress>();
                    res.Add(new OwnerRawAddress()
                    {
                        Address = src.OrgInfo[0].LegalAddress,
                        TypeOwner = "юрадрес",
                        Source = "data_mos_ru"//,
                        //Organization = o
                    });
                    foreach (var oa in src.ObjectAddress)
                    {
                        res.Add(new OwnerRawAddress()
                        {
                            Address = oa.Address,
                            TypeOwner = "использует",
                            Source = "data_mos_ru"//,
                            //Organization = o
                        });

                    }
                    return res;
                }))
                .ForMember(d => d.PersonPositions, opt => opt.MapFrom((src, o) =>
                {
                    List<UNS.Models.Entities.PhoneItem> phones = new List<UNS.Models.Entities.PhoneItem>();
                    try
                    {
                        foreach (var n in src.OrgInfo[0].ChiefPhone)
                        {
                            phones.Add(new UNS.Models.Entities.PhoneItem() { Phone = n.ChiefPhone });
                        }
                    }
                    catch (NullReferenceException)
                    { }
                    try
                    {
                        foreach (var n in src.ChiefPhone)
                        {
                            phones.Add(new UNS.Models.Entities.PhoneItem() { Phone = n.ChiefPhone });
                        }
                    }
                    catch (NullReferenceException)
                    { }
                    var person = new Person();
                    var splitters = new List<string>();
                    splitters.Add(" ");
                    var words = src.ChiefName.Split(splitters.ToArray(), StringSplitOptions.None);
                    switch (words.Length)
                    {
                        case 1:
                            person.Family = words[0];
                            break;
                        case 2:
                            person.Name = words[1];
                            person.Family = words[0];
                            break;
                        case 3:
                            person.Name = words[1];
                            person.Family = words[0];
                            person.Patronymic = words[2];
                            break;
                    }
                    var pptInBase = ContexUNS.PersonPositionTypes.Where(w => w.PositionType_Nominative.ToLower() == src.ChiefPosition.ToLower()).ToList();
                    PersonPositionType ppt;
                    if (pptInBase.Any())
                    { ppt = pptInBase.FirstOrDefault(); }
                    else
                    {
                        ppt = new PersonPositionType() { PositionType = src.ChiefPosition };
                        ContexUNS.PersonPositionTypes.Add(ppt);
                    };

                    List<PersonPosition> directorPosition =
                       new List<PersonPosition>()
                       {
                                new PersonPosition()
                                {
                                    //Organization = o,
                                    Person = person,
                                    Phones = phones,
                                    //Director = true,
                                    PositionType=ppt
                                }
                       };
                    return directorPosition;
                }))
            .ForAllOtherMembers(options => options.PreCondition((source, destination, member) => member != null));
        }
    }
}