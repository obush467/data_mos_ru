using AutoMapper;
using data_mos_ru.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using UNS.Models.Entities;

namespace data_mos_ru.Mappers
{
    public class Organization_v1List_Organization_MapProfile : Profile
    {
        public Organization_v1List_Organization_MapProfile(UNS.Models.UNSModel context) : this()
        {
            ContexUNS = context;
        }
        public Organization_v1List_Organization_MapProfile()
        {

            CreateMap<data_Organization_v1List, Organization>()
                    .ForMember(s => s.GeoData, d => d.MapFrom(s => s.geoData.Coordinates))
                    .ForMember(s => s.OGRN, d => d.MapFrom(s => s.OrgInfo[0].OGRN))
                    .ForMember(s => s.INN, d => d.MapFrom(s => s.OrgInfo[0].INN))
                    .ForMember(s => s.KPP, d => d.MapFrom(s => s.OrgInfo[0].KPP))
                    .ForMember(s => s.UrAddress, d => d.MapFrom(s => s.OrgInfo[0].LegalAddress))
                    .ForMember(d => d.PhoneItems, opt => opt.MapFrom((src, o) =>
                    {
                        List<UNS.Models.Entities.PhoneItem> res = new List<UNS.Models.Entities.PhoneItem>();
                        foreach (var n in src.PublicPhone)
                        {
                            foreach (var pp in n.PublicPhone)
                            {
                                res.Add(new UNS.Models.Entities.PhoneItem() { Phone = pp });
                            }
                        }
                        return res;
                    }))
                     .ForMember(d => d.EmailItems, opt => opt.MapFrom((src, o) =>
                     {
                         List<data_mos_ru.Entities.EmailItem> res = new List<data_mos_ru.Entities.EmailItem>();
                         foreach (var n in src.Email)
                         {
                             foreach (var e in n.Email)
                             {
                                 res.Add(new data_mos_ru.Entities.EmailItem() { Email = e });
                             }
                         }
                         return res;
                     }))
                     .ForMember(d => d.FaxItems, opt => opt.MapFrom((src, o) =>
                     {
                         List<UNS.Models.Entities.FaxItem> res = new List<UNS.Models.Entities.FaxItem>();
                         foreach (var n in src.Fax)
                         {
                             foreach (var pp in n.Fax)
                             {
                                 res.Add(new UNS.Models.Entities.FaxItem() { Fax = pp });
                             }
                         }
                         return res;
                     }))
                                                      .ForMember(d => d.FaxItems, opt => opt.MapFrom((src, o) =>
                                                      {
                                                          List<UNS.Models.Entities.FaxItem> res = new List<UNS.Models.Entities.FaxItem>();
                                                          foreach (var n in src.Fax)
                                                          {
                                                              foreach (var pp in n.Fax)
                                                              {
                                                                  res.Add(new UNS.Models.Entities.FaxItem() { Fax = pp });
                                                              }
                                                          }
                                                          return res;
                                                      }))
                     .ForMember(d => d.OwnerRawAddresses, opt => opt.MapFrom((src, o) =>
                     {
                         List<OwnerRawAddress> res = new List<OwnerRawAddress>();
                         foreach (var n in src.ObjectAddress)
                         {
                             res.Add(new OwnerRawAddress()
                             {
                                 Address = n.Address,
                                 PostCode = n.PostalCode,
                                 TypeOwner = "использует",
                                 Source = "data_7361"
                                 //Organization = o
                             });
                         }
                         return res;
                     }))
                     .ForMember(d => d.PersonPositions, opt => opt.MapFrom((src, o) =>
                     {
                         List<UNS.Models.Entities.PhoneItem> phones = new List<UNS.Models.Entities.PhoneItem>();
                         foreach (var n in src.OrgInfo[0].ChiefPhone)
                         {
                             foreach (var pp in n.ChiefPhone)
                             {
                                 phones.Add(new UNS.Models.Entities.PhoneItem() { Phone = pp });
                             }
                         }
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
                         var positionType = (from pt in ContexUNS.PersonPositionTypes
                                             where pt.PositionType.ToLower() == src.ChiefPosition.ToLower()
                                             select pt).Single();
                         if (positionType != null)
                         {
                             positionType = new PersonPositionType() { PositionType = src.ChiefPosition };
                             ContexUNS.PersonPositionTypes.Add(positionType);
                         }
                         List<DirectorPosition> directorPosition =
                            new List<DirectorPosition>()
                            {
                                new DirectorPosition()
                                {
                                    //Organization = o,
                                    Person = person,
                                    Phones = phones,
                                    Director = true,
                                    PositionType=positionType
                                }
                            };
                         return directorPosition;
                     }));
        }
        public UNS.Models.UNSModel ContexUNS { get; set; }
    }
}