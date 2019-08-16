using AutoMapper;
using data_mos_ru.Entities;
using data_mos_ru.Loaders;
using data_mos_ru.Mappers;
using NetTopologySuite.Features;
using NetTopologySuite.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
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

        public void Update(List<List<Data_2624_8684>> input)
        {
            int counter = 0;
            foreach (List<Data_2624_8684> block in input)
                using (UNS.Models.UNSModel context = new UNS.Models.UNSModel("Data Source=BUSHMAKIN;Initial Catalog=UNS;Integrated Security=True;"))
                {
                    block.RemoveAll(x => x.global_id == null);
                    counter += block.Count;
                    foreach (var row in block)
                    {
                        if (row.geoData == null)
                        { row.geoData = new GeoData(); }
                    }
                    context.Organizations.AddOrUpdate(u => u.FullName, block.Select(s => Mapper.Map<Data_2624_8684, Organization>(s)).ToArray());
                    Logger.Logger.Info(string.Join(" ", typeof(Data_2624_8684).Name, "Сохранено", block.Count.ToString(), "всего", counter.ToString()));
                    context.SaveChanges();
                }
        }



        public void Update(List<List<Data_7611>> input)
        {
            int counter = 0;
            foreach (List<Data_7611> block in input)
                using (UNS.Models.UNSModel context = new UNS.Models.UNSModel("Data Source=BUSHMAKIN;Initial Catalog=UNS;Integrated Security=True;"))
                {
                    block.RemoveAll(x => x.global_id == null);
                    counter += block.Count;
                    foreach (var row in block)
                    {
                        if (row.geoData == null)
                        { row.geoData = new GeoData(); }
                    }
                    context.Organizations.AddOrUpdate(u => u.FullName, block.Select(s => Mapper.Map<Data_7611, Organization>(s)).ToArray());
                    Logger.Logger.Info(string.Join(" ", typeof(Data_7611).Name, "Сохранено", block.Count.ToString(), "всего", counter.ToString()));
                    context.SaveChanges();
                }
        }
        public void Update(List<List<Data_7361>> input)
        {
            int counter = 0;
            foreach (List<Data_7361> block in input)
                using (UNS.Models.UNSModel context = new UNS.Models.UNSModel("Data Source=BUSHMAKIN;Initial Catalog=UNS;Integrated Security=True;"))
                {
                    block.RemoveAll(x => x.global_id == null);
                    counter += block.Count;
                    foreach (var row in block)
                    {
                        if (row.geoData == null)
                        { row.geoData = new GeoData(); }
                    }
                    var orgs = block.Select(s => Mapper.Map<Data_7361, Organization>(s)).ToList();
                    ///TODO реализовать проверку на совпадение имен библиотек, так как есть филиалы
                    context.Organizations.AddOrUpdate(u => new { u.OGRN, u.INN, u.FullName }, orgs.ToArray());
                    Logger.Logger.Info(string.Join(" ", typeof(Data_7361).Name, "Сохранено", block.Count.ToString(), "всего", counter.ToString()));
                    context.SaveChanges();
                }
        }
        public void Update(List<List<Data_7612>> input)
        {
            int counter = 0;
            foreach (List<Data_7612> block in input)
                using (UNS.Models.UNSModel context = new UNS.Models.UNSModel("Data Source=BUSHMAKIN;Initial Catalog=UNS;Integrated Security=True;"))
                {
                    block.RemoveAll(x => x.global_id == null);
                    counter += block.Count;
                    foreach (Data_7612 row in block)
                    {
                        if (row.geoData == null)
                        { row.geoData = new GeoData(); }
                    }
                    context.Organizations.AddOrUpdate(u => u.FullName, block.Select(s => Mapper.Map<Data_7612, Organization>(s)).ToArray());
                    Logger.Logger.Info(string.Join(" ", typeof(AO_60562).Name, "Сохранено", block.Count.ToString(), "всего", counter.ToString()));
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

        public void Update(List<List<Data_577_5609>> input)
        {
            int counter = 0;
            foreach (List<Data_577_5609> block in input)
                using (JSONContext context = new JSONContext(ConnectionString))
                {
                    block.RemoveAll(x => x.global_id == null);
                    counter += block.Count;
                    foreach (Data_577_5609 row in block)
                    {
                        if (row.geoData == null)
                        { row.geoData = new GeoData(); }
                    }
                    context.Data_577_5609s.AddOrUpdate(block.ToArray());
                    Logger.Logger.Info(string.Join(" ", typeof(AO_60562).Name, "Сохранено", block.Count.ToString(), "всего", counter.ToString()));
                    context.SaveChanges();
                }
        }

        public void Update(List<List<Data_1181_7382>> input)
        {
            int counter = 0;
            foreach (List<Data_1181_7382> block in input)
                using (JSONContext context = new JSONContext(ConnectionString))
                {
                    //block.RemoveAll(x => x.Global_id == null);
                    counter += block.Count;
                    foreach (Data_1181_7382 row in block)
                    {
                        if (row.GeoData == null)
                        { row.GeoData = new GeoData(); }
                    }
                    context.Data_1181_7382s.AddOrUpdate(block.ToArray());
                    Logger.Logger.Info(string.Join(" ", typeof(Data_1181_7382).Name, "Сохранено", block.Count.ToString(), "всего", counter.ToString()));
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

        public void Update(List<List<Data_1641_5988>> input)
        {
            int counter = 0;
            foreach (List<Data_1641_5988> block in input)
                using (JSONContext context = new JSONContext(ConnectionString))
                {
                    //block.RemoveAll(x => x.global_id == null);
                    counter += block.Count;
                    foreach (Data_1641_5988 row in block)
                    {
                        // if (row.GeoData == null)
                        // { row.GeoData = new geoData(); }
                    }
                    context.Data_1641_5988s.AddOrUpdate(block.ToArray());
                    Logger.Logger.Info(string.Join(" ", typeof(Data_1641_5988).Name, "Сохранено", block.Count.ToString(), "всего", counter.ToString()));
                    context.SaveChanges();
                }
        }


        public void Update(List<List<data_Organization_v1>> input)
        {
            int counter = 0;
            foreach (List<data_Organization_v1> block in input)               
                {
                var mappedblock = block.Select(s => Mapper.Map<data_Organization_v1, Organization>(s)).ToList();
                foreach (var item in mappedblock)
                {
                    ContexUNS.Organizations.AddOrUpdate(u =>new { u.OGRN, u.INN, u.FullName }, item);
                    Logger.Logger.Info(string.Join(" ", typeof(data_Organization_v1).Name, "Сохранено", block.Count.ToString(), "всего", counter.ToString()));
                    ContexUNS.SaveChanges();
                }
                }
        }

        public void Update(List<List<data_Organization_v2>> input)
        {
            int counter = 0;
            foreach (List<data_Organization_v2> block in input)
            {
                var mappedblock = block.Select(s => Mapper.Map<data_Organization_v2, Organization>(s)).ToList();
                foreach (var item in mappedblock)
                {
                    var itemsfinded = ContexUNS.Organizations
                        .Include("PhoneItems")
                        .Include("FaxItems")
                        .Include("EmailItems")
                        .Include("OwnerRawAddresses")
                        .Include("PersonPositions")
                        .Where(W => W.OGRN == item.OGRN);
                    if (itemsfinded.Any())
                    {
                        if (itemsfinded.Count() == 1)
                        {
                            var y = itemsfinded.FirstOrDefault();
                            var t = Mapper.Map<Organization,Organization>(item,y );
                        }
                    }
                    else
                    {
                        ContexUNS.Organizations.Add(item);
                    }
                    Logger.Logger.Info(string.Join(" ", typeof(data_Organization_v2).Name, "Сохранено", block.Count.ToString(), "всего", counter.ToString()));
                    ContexUNS.SaveChanges();
                }
            }
        }

        public void Update<T>(List<List<T>> input)
        {
            int counter = 0;
            foreach (List<T> block in input)               
                {
                    ContexUNS.Organizations.AddOrUpdate(u => u.OGRN, block.Select(s => Mapper.Map<T, Organization>(s)).FirstOrDefault());
                    Logger.Logger.Info(string.Join(" ", typeof(T).Name, "Сохранено", block.Count.ToString(), "всего", counter.ToString()));
                    ContexUNS.SaveChanges();
                }
        }

        public void Update(List<List<data_2346_5883>> input)
        {
            int counter = 0;
            foreach (List<data_2346_5883> block in input)
                using (JSONContext context = new JSONContext(ConnectionString))
                {
                    block.RemoveAll(x => x.global_id == null);
                    foreach (data_2346_5883 row in block)
                    {
                        if (row.geoData == null)
                        { row.geoData = new GeoData(); }
                    }
                    //context.data_2346_5883.AddOrUpdate(block.ToArray());
                    Logger.Logger.Info(string.Join(" ", typeof(Data_2624_8684).Name, "Сохранено", block.Count.ToString(), "всего", counter.ToString()));
                    context.SaveChanges();
                }
        }

       
    }
}

