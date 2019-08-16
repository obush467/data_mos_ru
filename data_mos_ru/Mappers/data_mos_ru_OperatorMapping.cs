using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using data_mos_ru.Comparers;
using data_mos_ru.Entities;
using UNS.Models.Entities;

namespace data_mos_ru.Operators
{
    public partial class Data_mos_ru_Operator
    {
        public IMapper Mapper;
        protected virtual MapperConfiguration mapperConfiguration { get; private set; }
        public void mapConfigure()
        {
            mapperConfiguration=
            new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Organization, Organization>()
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
                    options.PreCondition(member => member.EmailItems != null);
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
                            d.Concat(s.Except(d, new OwnerRawAddressComparer()).ToList())
                            : source.OwnerRawAddresses.ToList();
                    });
                })
                .ForMember(s => s.PersonPositions, options =>
                {
                    options.PreCondition(member => member.PersonPositions != null && member.PersonPositions.Count > 0);
                    options.MapFrom((source, destination, member) =>
                    {
                        var d = destination.PersonPositions.ToList();
                        var s = source.PersonPositions.ToList();
                        return (d.Any()) ?
                            d.Concat(s.Except(d, new PersonPositionComparer()).ToList())
                            : source.PersonPositions.ToList();
                    });
                });
                cfg.CreateMap<data_Organization_v2, Organization>()
                   .ForMember(s => s.GeoData, d => d.MapFrom(s => s.geoData.Coordinates))
                   .ForMember(s => s.FaxItems, d => new List<UNS.Models.Entities.FaxItem>())
                   .ForMember(s => s.EmailItems, d => new UNS.Models.Entities.EmailItem())
                   .ForMember(s => s.UrAddress, d => d.MapFrom(s => s.Address))
                   .ForMember(s => s.Id, d => d.Ignore())
                   .ForMember(d => d.PhoneItems, opt => opt.MapFrom((src, o) =>
                   {
                       List<UNS.Models.Entities.PhoneItem> res = new List<UNS.Models.Entities.PhoneItem>();
                       foreach (var phone in src.Phone)
                       {
                           res.Add(new UNS.Models.Entities.PhoneItem() { Phone = phone.Phone });
                       }
                       return res;
                   }))
                   .ForMember(d => d.OwnerRawAddresses, opt => opt.MapFrom((src, o) =>
                   {
                       List<OwnerRawAddress> res = new List<OwnerRawAddress>();
                       res.Add(new OwnerRawAddress()
                       {
                           Address = src.Address,
                           TypeOwner = "использует",
                           Source = "data_mos_ru"//,
                           //Organization = o
                       });
                       return res;
                   }));
                cfg.CreateMap<Data_7361, Organization>()
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
                                 Source = "data_7361",
                                 Organization = o
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
                         List<DirectorPosition> directorPosition =
                            new List<DirectorPosition>()
                            {
                                new DirectorPosition()
                                {
                                    //Organization = o,
                                    Human = person,
                                    Phones = phones,
                                    Director = true
                                }
                            };
                         return directorPosition;
                     }));
                cfg.CreateMap<Data_7611, Organization>()
                    .ForMember(s => s.GeoData, d => d.MapFrom(s => s.geoData.Coordinates))
                    .ForMember(s => s.FullName, d => d.MapFrom(s => s.NameOfReligiousOrganization))
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
                            Source = "data_7611",
                            Organization = o
                        });
                        return res;
                    }))
                    .ForAllOtherMembers(s => s.Ignore());
                cfg.CreateMap<Data_7612, Organization>()
                .ForMember(s => s.GeoData, d => d.MapFrom(s => s.geoData.Coordinates))
                .ForMember(s => s.FullName, d => d.MapFrom(s => s.ObjectName))
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
                        Source = "data_7612",
                        Organization = o
                    });
                    return res;
                }))
                .ForAllOtherMembers(s => s.Ignore());
                cfg.CreateMap<Data_2624_8684, Organization>()
                .ForMember(d => d.OwnerRawAddresses, opt => opt.MapFrom((src, o) =>
                {
                    List<OwnerRawAddress> res = new List<OwnerRawAddress>();
                    res.Add(new OwnerRawAddress()
                    {
                        Address = src.Address,
                        TypeOwner = "использует",
                        Source = "data_2624_8684",
                        Organization = o
                    });
                    return res;
                }))
                .ForMember(s => s.GeoData, d => d.MapFrom(s => s.geoData.Coordinates))
                .ForMember(s => s.FullName, d => d.MapFrom(s => s.Name))
                .ForMember(d => d.PhoneItems, opt => opt.MapFrom((src, o) =>
                {
                    List<UNS.Models.Entities.PhoneItem> res = new List<UNS.Models.Entities.PhoneItem>();
                    foreach (var n in src.PublicPhone)
                    {
                        res.Add(new UNS.Models.Entities.PhoneItem() { Phone = n.PublicPhone });
                    }
                    return res;
                }));
                cfg.CreateMap<data_Organization_v1, Organization>()
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
                        res.Add(new UNS.Models.Entities.PhoneItem() { Phone = n.PublicPhone });
                    }
                    return res;
                }))
                .ForMember(d => d.EmailItems, opt => opt.MapFrom((src, o) =>
                {
                    List<UNS.Models.Entities.EmailItem> res = new List<UNS.Models.Entities.EmailItem>();
                    foreach (var n in src.Email)
                    {
                        res.Add(new UNS.Models.Entities.EmailItem() { Email = n.Email });
                    }
                    return res;
                }))
                .ForMember(d => d.FaxItems, opt => opt.MapFrom((src, o) =>
                {
                    List<UNS.Models.Entities.FaxItem> res = new List<UNS.Models.Entities.FaxItem>();
                    foreach (var n in src.Fax)
                    {
                        res.Add(new UNS.Models.Entities.FaxItem() { Fax = n });
                    }
                    return res;
                }))
                .ForMember(d => d.OwnerRawAddresses, opt => opt.MapFrom((src, o) =>
                {
                    List<OwnerRawAddress> res = new List<OwnerRawAddress>();
                    res.Add(new OwnerRawAddress()
                    {
                        Address = src.OrgInfo[0].LegalAddress,
                        TypeOwner = "юрадрес",
                        Source = "data_mos_ru",
                        Organization = o
                    });
                    foreach (var oa in src.ObjectAddress)
                    {
                        res.Add(new OwnerRawAddress()
                        {
                            Address = oa.Address,
                            TypeOwner = "использует",
                            Source = "data_mos_ru",
                            Organization = o
                        });

                    }
                    return res;
                }))
                .ForMember(d => d.PersonPositions, opt => opt.MapFrom((src, o) =>
                {
                    List<UNS.Models.Entities.PhoneItem> phones = new List<UNS.Models.Entities.PhoneItem>();
                    foreach (var n in src.OrgInfo[0].ChiefPhone)
                    {
                        phones.Add(new UNS.Models.Entities.PhoneItem() { Phone = n.ChiefPhone });
                    }
                    foreach (var n in src.ChiefPhone)
                    {
                        phones.Add(new UNS.Models.Entities.PhoneItem() { Phone = n.ChiefPhone });
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
                    var pptInBase = ContexUNS.PersonPositionTypes.Where(w => w.PositionType_Nominative == src.ChiefPosition).ToList();
                    PersonPositionType ppt;
                    if (pptInBase.Any())
                    { ppt = pptInBase.FirstOrDefault(); }
                    else
                    {
                        ppt = new PersonPositionType();
                        ppt.PositionType = src.ChiefPosition;
                    };
                    List<DirectorPosition> directorPosition =
                       new List<DirectorPosition>()
                       {
                                new DirectorPosition()
                                {
                                    //Organization = o,
                                    Human = person,
                                    Phones = phones,
                                    Director = true,
                                    PositionType=ppt
                                }
                       };
                    return directorPosition;
                }));
            });
            Mapper = mapperConfiguration.CreateMapper();
            //Mapper.Initialize(mapperConfiguration);
        }
    }
}