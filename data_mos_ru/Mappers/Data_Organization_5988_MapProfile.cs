using AutoMapper;
using data_mos_ru.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using UNS.Models;
using UNS.Models.Entities;

namespace data_mos_ru.Mappers
{
    class Data_Organization_5988_MapProfile : Profile
    {
        public UNSModel Context { get; private set; }
        public Data_Organization_5988_MapProfile(UNSModel context) : this()
        { Context = context; }
        public Data_Organization_5988_MapProfile() : base()
        {
            CreateMap<Data_Organization_5988, Organization>()
                .ForMember(s => s.Id, opt => opt.Ignore())
                .ForMember(s => s.UrAddress, opt =>
                {
                    opt.PreCondition((source, destination, member) => destination.UrAddress == null);
                    opt.MapFrom((source, destination) => source.LegalAddressEGRUL != null ? source.LegalAddressEGRUL : source.LegalAddressMGK);
                })
                .ForMember(s => s.OrganizationType, opt => opt.MapFrom((source, destination) =>
                   {
                       var findOrgType = Context.OrganizationTypes.Where(w =>
                       w.FullTypeName.ToLower().Trim() == source.OrgType.ToLower().Trim()
                       ||
                       w.ShortTypeName.ToLower().Trim() == source.OrgType.ToLower().Trim()
                       ).ToList();
                       if (findOrgType.Any())
                       { return findOrgType.FirstOrDefault(); }
                       else
                       { return Context.OrganizationTypes.Add(new OrganizationType() { FullTypeName = source.OrgType }); }
                   }))
                .ForMember(s => s.PersonPositions, opt =>
                      opt.MapFrom((source, destination) =>
                      {
                          var personPositions = new List<PersonPosition>();
                          foreach (var responsiblePerson in source.ResponsiblePersons)
                          {
                              var person = new Person();
                              var splitters = new List<string>();
                              splitters.Add(" ");
                              var words = responsiblePerson.FIO.Split(splitters.ToArray(), StringSplitOptions.None);
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
                                  default:
                                      person.Name = responsiblePerson.FIO;
                                      break;
                              }
                              var pptInBase = Context.PersonPositionTypes.Where(w => w.PositionType_Nominative.ToLower() == responsiblePerson.NamePosition.ToLower()).ToList();
                              PersonPositionType ppt;
                              if (pptInBase.Any())
                              { ppt = pptInBase.FirstOrDefault(); }
                              else
                              {
                                  ppt = new PersonPositionType() { PositionType = responsiblePerson.NamePosition };
                                  Context.PersonPositionTypes.Add(ppt);
                              }
                              personPositions.Add(new PersonPosition() { Person = person, PositionType = ppt });
                          }
                          return personPositions;
                      }))
                .ForMember(s => s.OwnerRawAddresses, opt => opt.MapFrom((source, destination) =>
                {
                    var ownerRawAddresses = new List<OwnerRawAddress>();
                    ownerRawAddresses.Add(new OwnerRawAddress()
                    {
                        DirtyAddress = source.LegalAddressEGRUL != null ? source.LegalAddressEGRUL : source.LegalAddressMGK,
                        Address = source.LegalAddressEGRUL != null ? source.LegalAddressEGRUL : source.LegalAddressMGK,
                        Source = source.GetType().Name,
                        TypeOwner = "юрадрес"
                    });
                    foreach (var address in source.FactAddress)
                    {
                        ownerRawAddresses.Add(new OwnerRawAddress()
                        {
                            DirtyAddress = address.FactAddress,
                            Address = address.FactAddress,
                            Source = source.GetType().Name,
                            TypeOwner = "использует"
                        });
                    }
                    return ownerRawAddresses;
                }))
                .ForAllMembers(options => options.PreCondition((source, destination, member) => member != null));

        }
    }
}
