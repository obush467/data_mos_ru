using data_mos_ru.Converters;
using data_mos_ru.Entities;
using data_mos_ru.Loaders;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using UNS.Models.Entities;
using Utility;
using UNS.Models.Entities.Fias;

namespace data_mos_ru.Operators
{
    public class ttt { public string FullName { get; set; } }
    public partial class Data_mos_ru_Operator : Operator
    {
        public Data_mos_ru_Loader Loader { get; set; }
        public Data_mos_ru_Operator() : base()
        {
            Loader = new Data_mos_ru_Loader("");
        }
        public Data_mos_ru_Operator(string сonnectionString) : base(сonnectionString)
        {
            Loader = new Data_mos_ru_Loader("");
            mapConfigure();
        }
        public void ReplacePost()
        {
            foreach (var rawAddress in ContexUNS.RawAddresses.Where(w => w.Address != null).AsEnumerable().Where(w=>AddressOperator.Match(w.Address, "^\\s*(\\d{6})\\s*,\\s*")).ToList())
            {
                    var addressItem = Utility.AddressOperator.PostReplace(rawAddress.Address);
                    rawAddress.Address = addressItem.Address;
                    rawAddress.PostCode = addressItem.PostCode;
                    ContexUNS.SaveChanges();
            }
        }


        public void Update(List<List<data_Organization_v1List>> input)
        {
            int counter = 0;
            foreach (List<data_Organization_v1List> block in input)
                using (UNS.Models.UNSModel context = new UNS.Models.UNSModel())
                {
                    block.RemoveAll(x => x.global_id == null);
                    counter += block.Count;
                    foreach (var row in block)
                    {
                        if (row.geoData == null)
                        { row.geoData = new GeoData(); }
                    }
                    var orgs = block.Select(s => Mapper.Map<data_Organization_v1List, Organization>(s)).ToList();
                    ///TODO реализовать проверку на совпадение имен библиотек, так как есть филиалы
                    context.Organizations.AddOrUpdate(u => new { u.OGRN, u.INN, u.FullName }, orgs.ToArray());
                    Logger.Logger.Info(string.Join(" ", typeof(data_Organization_v1List).Name, "Сохранено", block.Count.ToString(), "всего", counter.ToString()));
                    context.SaveChanges();
                }
        }

        public void Update(List<List<AO_60562>> input)
        {
            int counter = 0;
            foreach (List<AO_60562> block in input)
                using (JSONContext context = new JSONContext(ConnectionString))
                {
                    block.RemoveAll(x => x.Global_ID == null);
                    counter += block.Count;
                    foreach (AO_60562 row in block)
                    {
                        if (row.GeoData == null)
                        { row.GeoData = new GeoData(); }
                    }
                    context.AO_60562s.AddOrUpdate(block.ToArray());
                    Logger.Logger.Info(string.Join(" ", typeof(AO_60562).Name, "Сохранено", block.Count.ToString(), "всего", counter.ToString()));
                    context.SaveChanges();
                }
        }


        public void Update(List<List<OMK002_2013_1>> input)
        {
            int counter = 0;
            foreach (List<OMK002_2013_1> block in input)
                using (JSONContext context = new JSONContext(ConnectionString))
                {
                    block.RemoveAll(x => x.global_id == null);
                    counter += block.Count;
                    context.OMK002_2013_1s.AddOrUpdate(block.ToArray());
                    Logger.Logger.Info(string.Join(" ", typeof(OMK002_2013_1).Name, "Сохранено", block.Count.ToString(), "всего", counter.ToString()));
                    context.SaveChanges();
                }
        }

        public void Update(List<List<SearchAutoCompleteResult>> input)
        {
            int counter = 0;
            foreach (List<SearchAutoCompleteResult> block in input)
                using (JSONContext context = new JSONContext(ConnectionString))
                {
                    //block.RemoveAll(x => x.global_id == null);
                    counter += block.Count;
                    context.UPRs.AddRange(block.ToArray());
                    Logger.Logger.Info(string.Join(" ", typeof(Data_54518).Name, "Сохранено", block.Count.ToString(), "всего", counter.ToString()));
                    context.SaveChanges();
                }
        }

        public void Update(List<List<Data_54518>> input)
        {
            int counter = 0;
            foreach (List<Data_54518> block in input)
                using (JSONContext context = new JSONContext(ConnectionString))
                {
                    //block.RemoveAll(x => x.Global_id == null);
                    counter += block.Count;
                    foreach (Data_54518 row in block)
                    {
                        if (row.GeoData == null)
                        { row.GeoData = new GeoData(); }
                    }
                    context.Data_54518s.AddRange(block.ToArray());
                    Logger.Logger.Info(string.Join(" ", typeof(Data_54518).Name, "Сохранено", block.Count.ToString(), "всего", counter.ToString()));
                    context.SaveChanges();
                }
        }

        public void Room()
        {
            using (var context = new UNS.Models.UNSModel())
            {
                int counter = 0;
                int counterLength = 100;
                context.Configuration.AutoDetectChangesEnabled = false;
                ((IObjectContextAdapter)context).ObjectContext.CommandTimeout = 10000;
                Logger.Logger.Info(string.Join(" ", "Удаляются старые данные"));
                context.AddressAOs.RemoveRange(context.AddressAOs);
                Logger.Logger.Info(string.Join(" ", "Начато сохранение"));
                context.SaveChanges();
                Logger.Logger.Info(string.Join(" ", "Сохранение завершено"));
                Logger.Logger.Info(string.Join(" ", "Поиск AddressObjects"));
                var mappedblock = context.AddressObjects.Where(w => w.REGIONCODE == "77").AsEnumerable().Select(s => Mapper.Map<AddressObject, UNS.Models.Entities.Fias.AddressAO>(s)).ToList();
                context.Set<UNS.Models.Entities.Fias.AddressAO>().AddRange(mappedblock);
                context.SaveChanges();
                var steads = (from
                  stead in context.Stead
                              join ao in context.AddressObjects
                              on stead.PARENTGUID equals ao.AOGUID
                              where ao.REGIONCODE=="77"
                              select stead).AsEnumerable().Distinct().Select(stead=> Mapper.Map<UNS.Models.Entities.Stead, UNS.Models.Entities.Fias.AddressStead>(stead)).GroupBy(_ => counter++ / counterLength).ToList();
                foreach (var stead in steads)
                {
                    context.Set<AddressStead>().AddRange(stead);
                    context.SaveChanges();
                    Logger.Logger.Info(string.Join(" ", typeof(Data_Organization_5988).Name, "Сохранено"));
                }
                /*var houses = (from
                                  house in context.Houses
                                  join ao in context.AddressObjects
                                  on house.AOGUID equals ao.AOGUID
                                  select Mapper.Map<UNS.Models.Entities.House, UNS.Models.Entities.>(house)).ToList();
                context.Set<UNS.Models.Entities.Fias.AO>().AddRange(houses);*/
                    
                
            }
        }

        public void Update<T>(List<List<T>> input)
        {
            int counter = 0;
            foreach (List<T> block in input)
            {
                var mappedblock = block.Select(s => Mapper.Map<T, Organization>(s)).ToList();
                foreach (var itemUpserted in mappedblock)
                {
                    if (itemUpserted.PersonPositions == null) itemUpserted.PersonPositions = new List<PersonPosition>();
                    if (itemUpserted.PhoneItems == null) itemUpserted.PhoneItems = new List<UNS.Models.Entities.PhoneItem>();
                    if (itemUpserted.EmailItems == null) itemUpserted.EmailItems = new List<UNS.Models.Entities.EmailItem>();
                    if (itemUpserted.FaxItems == null) itemUpserted.FaxItems = new List<UNS.Models.Entities.FaxItem>();
                    var family = itemUpserted.PersonPositions.Any() ? itemUpserted.PersonPositions.FirstOrDefault().Person.Family : null;
                    var name = itemUpserted.PersonPositions.Any() ? itemUpserted.PersonPositions.FirstOrDefault().Person.Name : null;
                    var patronimic = itemUpserted.PersonPositions.Any() ? itemUpserted.PersonPositions.FirstOrDefault().Person.Patronymic : null;

                    var itemsFinded = ContexUNS.Organizations
                        .Include("PhoneItems")
                        .Include("FaxItems")
                        .Include("EmailItems")
                        .Include("OwnerRawAddresses")
                        .Include("PersonPositions")
                        .Where(W => W.FullName.ToLower().Trim() == itemUpserted.FullName.ToLower().Trim() &&
                            (
                                (W.OGRN == itemUpserted.OGRN && W.OGRN != null && itemUpserted.OGRN != null)
                                ||
                                (W.INN != null && itemUpserted.INN != null && W.INN == itemUpserted.INN)
                                ||
                                (
                                    ((W.OGRN == null && itemUpserted.OGRN != null) || (W.OGRN != null && itemUpserted.OGRN == null) || (W.OGRN == null && itemUpserted.OGRN == null))
                                    &&
                                    ((W.INN == null && itemUpserted.INN != null) || (W.INN != null && itemUpserted.INN == null) || (W.INN == null && itemUpserted.INN == null))
                                    &&
                                    (
                                        // (family !=null || name != null || patronimic !=null)
                                        //&& 
                                        W.PersonPositions.FirstOrDefault().Person.Family.ToLower() == family.ToLower()
                                        &&
                                        W.PersonPositions.FirstOrDefault().Person.Name.ToLower() == name.ToLower()
                                        &&
                                        W.PersonPositions.FirstOrDefault().Person.Patronymic.ToLower() == patronimic.ToLower()
                                    )
                                 )
                            )).ToList();
                    if (itemsFinded.Any())
                    {
                        if (itemsFinded.Count() == 1)
                        {

                            try
                            {
                                var y = itemsFinded.FirstOrDefault();
                                var t = Mapper.Map<Organization, Organization>(itemUpserted, y);
                                ContexUNS.Organizations.AddOrUpdate(t);
                                ContexUNS.SaveChanges();
                            }
                            catch (Exception e)
                            {
                                Logger.Logger.Error(e.Message);
                                var changedEntries = ContexUNS.ChangeTracker.Entries()
                                    .Where(x => x.State != EntityState.Unchanged).ToList();

                                foreach (var entry in changedEntries)
                                {
                                    switch (entry.State)
                                    {
                                        case EntityState.Modified:
                                            entry.CurrentValues.SetValues(entry.OriginalValues);
                                            entry.State = EntityState.Unchanged;
                                            break;
                                        case EntityState.Added:
                                            entry.State = EntityState.Detached;
                                            break;
                                        case EntityState.Deleted:
                                            entry.State = EntityState.Unchanged;
                                            break;
                                    }
                                }
                            }
                            Logger.Logger.Info(string.Join(" ", typeof(T).Name, "Изменено", block.Count.ToString(), "всего", counter.ToString()));
                            counter++;
                        }
                    }
                    else
                    {
                        ContexUNS.Organizations.Add(itemUpserted);
                        try
                        {
                            ContexUNS.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            Logger.Logger.Error(e.Message);
                            var changedEntries = ContexUNS.ChangeTracker.Entries()
                                .Where(x => x.State != EntityState.Unchanged).ToList();

                            foreach (var entry in changedEntries)
                            {
                                switch (entry.State)
                                {
                                    case EntityState.Modified:
                                        entry.CurrentValues.SetValues(entry.OriginalValues);
                                        entry.State = EntityState.Unchanged;
                                        break;
                                    case EntityState.Added:
                                        entry.State = EntityState.Detached;
                                        break;
                                    case EntityState.Deleted:
                                        entry.State = EntityState.Unchanged;
                                        break;
                                }
                            }
                        }
                        Logger.Logger.Info(string.Join(" ", typeof(T).Name, "Добавлено", block.Count.ToString(), "всего", counter.ToString()));
                        counter++;
                    }

                }
                // ContexUNS.SaveChanges();

            }
        }



        public void Update<T>(IEnumerable<IEnumerable<T>> input, IMapConverter<T, Organization> converter = null)
        {
            int counter = 0;
            foreach (var block in input)
            {
                Update<T>(block, converter);
                Logger.Logger.Info(string.Join(" ", typeof(Data_Organization_2748).Name, "Обработан", counter.ToString(), "блок из", input.Count().ToString()));
                counter++;
            }
        }
        public void Update<T>(IEnumerable<T> input, IMapConverter<T, Organization> converter = null)
        {
            int counter = 0;
                IEnumerable<Organization> mappedblock;
                mappedblock = (converter == null)? input.Select(s => Mapper.Map<T, Organization>(s)).ToList(): converter.Convert(input).ToList();
                foreach (var itemUpserted in mappedblock)
                {
                    if (itemUpserted.PersonPositions == null) itemUpserted.PersonPositions = new List<PersonPosition>();
                    if (itemUpserted.PhoneItems == null) itemUpserted.PhoneItems = new List<UNS.Models.Entities.PhoneItem>();
                    if (itemUpserted.EmailItems == null) itemUpserted.EmailItems = new List<UNS.Models.Entities.EmailItem>();
                    if (itemUpserted.FaxItems == null) itemUpserted.FaxItems = new List<UNS.Models.Entities.FaxItem>();
                    var family = itemUpserted.PersonPositions.Any() ? itemUpserted.PersonPositions.FirstOrDefault().Person.Family : null;
                    var name = itemUpserted.PersonPositions.Any() ? itemUpserted.PersonPositions.FirstOrDefault().Person.Name : null;
                    var patronimic = itemUpserted.PersonPositions.Any() ? itemUpserted.PersonPositions.FirstOrDefault().Person.Patronymic : null;

                    var itemsFinded = ContexUNS.Organizations
                        .Include("PhoneItems")
                        .Include("FaxItems")
                        .Include("EmailItems")
                        .Include("OwnerRawAddresses")
                        .Include("PersonPositions")
                        .Where(W => W.FullName.ToLower().Trim() == itemUpserted.FullName.ToLower().Trim()).ToList();
                    if (itemsFinded.Any())
                    {
                        if (itemsFinded.Count() == 1)
                        {
                            try
                            {
                                var y = itemsFinded.FirstOrDefault();
                                var t = Mapper.Map<Organization, Organization>(itemUpserted, y);
                                ContexUNS.Organizations.AddOrUpdate(t);
                                //ContexUNS.SaveChanges();
                            }
                            catch (Exception e)
                            {
                                Logger.Logger.Error(e.Message);
                                /*var changedEntries = ContexUNS.ChangeTracker.Entries()
                                    .Where(x => x.State != EntityState.Unchanged).ToList();

                                foreach (var entry in changedEntries)
                                {
                                    switch (entry.State)
                                    {
                                        case EntityState.Modified:
                                            entry.CurrentValues.SetValues(entry.OriginalValues);
                                            entry.State = EntityState.Unchanged;
                                            break;
                                        case EntityState.Added:
                                            entry.State = EntityState.Detached;
                                            break;
                                        case EntityState.Deleted:
                                            entry.State = EntityState.Unchanged;
                                            break;
                                    }
                                }*/
                            }
                            Logger.Logger.Info(string.Join(" ", typeof(T).Name, "Изменено", input.Count().ToString(), "всего", counter.ToString()));
                            counter++;
                        }
                    }
                    else
                    {
                        ContexUNS.Organizations.Add(itemUpserted);
                        try
                        {
                            //ContexUNS.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            Logger.Logger.Error(e.Message);
                            /*var changedEntries = ContexUNS.ChangeTracker.Entries()
                                .Where(x => x.State != EntityState.Unchanged).ToList();

                            foreach (var entry in changedEntries)
                            {
                                switch (entry.State)
                                {
                                    case EntityState.Modified:
                                        entry.CurrentValues.SetValues(entry.OriginalValues);
                                        entry.State = EntityState.Unchanged;
                                        break;
                                    case EntityState.Added:
                                        entry.State = EntityState.Detached;
                                        break;
                                    case EntityState.Deleted:
                                        entry.State = EntityState.Unchanged;
                                        break;
                                }
                            }*/
                        }
                        Logger.Logger.Info(string.Join(" ", typeof(T).Name, "Добавлено", counter.ToString(),"Из",input.Count().ToString()));
                        counter++;
                    }

                }
                ContexUNS.SaveChanges();
            }
        }
    }


