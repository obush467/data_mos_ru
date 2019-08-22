using data_mos_ru.Entities;
using data_mos_ru.Loaders;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using UNS.Models.Entities;

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
            foreach (var ttt in ContexUNS.RawAddresses.ToList())
            {
                if (Utility.AddressOperator.Match(ttt.Address, "^\\s*(\\d{6})\\s*,\\s*"))
                {
                    var yyy = Utility.AddressOperator.PostReplace(ttt.Address);
                    ttt.Address = yyy.Address;
                    ttt.PostCode = yyy.PostCode;
                    ContexUNS.SaveChanges();
                }
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

        /*public void Update(List<List<Data_Organization_5988>> input)
        {
            int counter = 0;
            foreach (List<Data_Organization_5988> block in input)
                using (JSONContext context = new JSONContext(ConnectionString))
                {
                    //block.RemoveAll(x => x.global_id == null);
                    counter += block.Count;
                    foreach (Data_Organization_5988 row in block)
                    {
                        // if (row.GeoData == null)
                        // { row.GeoData = new geoData(); }
                    }
                    context.Data_1641_5988s.AddOrUpdate(block.ToArray());
                    Logger.Logger.Info(string.Join(" ", typeof(Data_Organization_5988).Name, "Сохранено", block.Count.ToString(), "всего", counter.ToString()));
                    context.SaveChanges();
                }
        }*/

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
                    var family = itemUpserted.PersonPositions.FirstOrDefault().Person.Family;
                    var name = itemUpserted.PersonPositions.FirstOrDefault().Person.Name;
                    var patronimic = itemUpserted.PersonPositions.FirstOrDefault().Person.Patronymic;
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
                                        //(W.PersonPositions !=null && item.PersonPositions!=null)
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
                            var y = itemsFinded.FirstOrDefault();
                            var t = Mapper.Map<Organization, Organization>(itemUpserted, y);
                            ContexUNS.Organizations.AddOrUpdate(t);
                            ContexUNS.SaveChanges();
                            Logger.Logger.Info(string.Join(" ", typeof(T).Name, "Изменено", block.Count.ToString(), "всего", counter.ToString()));
                            counter++;
                        }
                    }
                    else
                    {
                        ContexUNS.Organizations.Add(itemUpserted);
                        ContexUNS.SaveChanges();
                        Logger.Logger.Info(string.Join(" ", typeof(T).Name, "Добавлено", block.Count.ToString(), "всего", counter.ToString()));
                        counter++;
                    }

                }
                // ContexUNS.SaveChanges();

            }
        }
    }
}

