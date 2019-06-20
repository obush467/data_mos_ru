using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Data.Entity.Spatial;
using System.Globalization;
using data_mos_ru.Entities;
using log4net;
using NetTopologySuite.Features;
using NetTopologySuite.IO;
using System.Data.Entity.Migrations;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using data_mos_ru.Utility;
using data_mos_ru.Loaders;
using Nest;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace data_mos_ru
{
    public class Operator
    {
        public JSONContext ContextMain { get; set; }
        private Data_mos_ru_Loader DataLoader { get; set; }
        private Dom_mos_ru_Loader DomLoader { get; set; }
        string ConnectionString { get; set; }
        public Operator()
        {
            log4net.Config.XmlConfigurator.Configure();
            Logger.InitLogger();
            DataLoader = new Data_mos_ru_Loader("");
            DomLoader = new Dom_mos_ru_Loader();
        }
        public Operator(string сonnectionString):this()
        {
            ConnectionString = сonnectionString;
            ContextMain = new JSONContext(сonnectionString);         
        }
        /// <summary>
        /// 
        /// </summary>
        public void UpdateHouses()
        {
            DomLoader.UpdateHouses(Encoding.UTF8);
        }
        public void LoadDom()
        {
            //var ttt =domLoader.LoadUPR(JS.UPRs.ToList(),Encoding.UTF8);
            DomLoader.LoadUpr(ContextMain.UPRs.ToList(), Encoding.UTF8);
        }
        public async Task LoadBuildingsAsync()
        {
            using (JSONContext context = new JSONContext(ConnectionString))
            {
                var addressList = context.AO_60562s.ToList().Select(s => s.ADDRESS).ToList();
                ///var ttt = await DomLoader.LoadBuildingsAsync(addressList, Encoding.UTF8);
                ///context.UPRs.AddOrUpdate(up=>new {up.Url },ttt.Distinct().ToArray());
                context.SaveChanges();
            }
        }

        public void LoadBuildings()
        {
            using (JSONContext context = new JSONContext(ConnectionString))
            {
                var addressList = context.AO_60562s.OrderBy(o=>o.ADDRESS).Select(s => s.ADDRESS).ToList();
                var ttt = DomLoader.LoadBuildings(addressList, Encoding.UTF8);
                context.UPRs.AddOrUpdate(up => new { up.Url }, ttt.Distinct().ToArray());
                context.SaveChanges();
            }
        }

        public void LoadBuildingsQ()
        {
            using (JSONContext context = new JSONContext(ConnectionString))
            {
                var aol = context.AO_60562s.ToList();
                var addressList1 =(aol.Select(s=>s.ADDRESS).ToList()).ConvertAll(new Converter<string, string>(AddressOperator.CleanToSearch));
                var addressList2 = aol.ConvertAll(new Converter<AO_60562,string>(AddressOperator.AO_60562_ToSearch));
                var addressList = addressList1.Union(addressList2).ToList();
                addressList.Sort();
                BlockingCollection<UPR> result = new BlockingCollection<UPR>();
                Task t1= Task.Run(()=> DomLoader.LoadBuildings(addressList, Encoding.UTF8,result));
                Task t2 = Task.Run(() => {
                        UPR upr = new UPR();
                    foreach (var n in result.GetConsumingEnumerable())
                    { try
                        {
                            context.UPRs.AddOrUpdate(up => new { up.Url }, n);
                            context.SaveChanges();
                            Logger.Log.Info(string.Join(" ", "ВНЕСЕНО", n.Value));
                        }
                        catch(Exception) { }
                    }
                    });
                Task.WaitAll(new Task[]{ /*t1,*/t2});
                
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
                    Logger.Log.Info(string.Join(" ", typeof(AO_60562).Name, "Сохранено", block.Count.ToString(), "всего", counter.ToString()));
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
                    Logger.Log.Info(string.Join(" ", typeof(Data_1181_7382).Name, "Сохранено", block.Count.ToString(), "всего", counter.ToString()));
                    context.SaveChanges();
                }
        }

        public void Update(List<List<UPR>> input)
        {
            int counter = 0;
            foreach (List<UPR> block in input)
                using (JSONContext context = new JSONContext(ConnectionString))
                {
                    //block.RemoveAll(x => x.global_id == null);
                    counter += block.Count;
                    context.UPRs.AddRange(block.ToArray());
                    Logger.Log.Info(string.Join(" ", typeof(Data_54518).Name, "Сохранено", block.Count.ToString(), "всего", counter.ToString()));
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
                    Logger.Log.Info(string.Join(" ", typeof(Data_54518).Name, "Сохранено", block.Count.ToString(), "всего", counter.ToString()));
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
                    Logger.Log.Info(string.Join(" ", typeof(Data_1641_5988).Name, "Сохранено", block.Count.ToString(), "всего", counter.ToString()));
                    context.SaveChanges();
                }
        }

        public void Update(List<List<Data_2624_8684>> input)
         {
             int counter = 0;
             foreach (List<Data_2624_8684> block in input)
                 using (JSONContext context = new JSONContext(ConnectionString))
                 {
                     block.RemoveAll(x => x.global_id == null);
                     foreach (Data_2624_8684 row in block)
                     {
                         if (row.geoData == null)
                         { row.geoData = new GeoData(); }
                     }
                     context.Data_2624_8684.AddOrUpdate(block.ToArray());
                     Logger.Log.Info(string.Join(" ", typeof(Data_2624_8684).Name, "Сохранено", block.Count.ToString(), "всего", counter.ToString()));
                     context.SaveChanges();
                 }
         }
        public delegate void UpdateDelegate<T>(T X);
        public void Update<T>(List<T> input,UpdateDelegate<T> updater)
        {
            foreach(T ao in input)
            { updater(ao); }
        }
        public delegate void UpdateDelegateTwo<T>(T X);
        public delegate object ComparerDelegate<T>(T x);
        public void Update<T>(IEnumerable<IQueryable<T>> input, UpdateDelegateTwo<T> updater, Expression<System.Func<Data_2624_8684,object>> comparer)
        {
            int counter = 0;
            foreach (IEnumerable<T> block in input)
                using (JSONContext context = new JSONContext(ConnectionString))
                {
                    foreach (T row in block)
                    {
                        updater(row);
                    }
                    //context.AddOrUpdate(comparer, block.ToArray());
                    Logger.Log.Info(string.Join(" ", typeof(Data_2624_8684).Name, "Сохранено", block.Count().ToString(), "всего", counter.ToString()));
                    context.SaveChanges();
                }
        }

        public void DeserializeAO_site(Stream stream, Encoding encoding)
        {
            Logger.Log.Info("Запущено преобразование AO");
            JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.Converters.Add(new GeoPolyConverterSite());
            jss.Culture = CultureInfo.CurrentCulture;

            AO_JSON_site[] json_data = JsonConvert.DeserializeObject<AO_JSON_site[]>((new StreamReader(stream, encoding)).ReadToEnd(), jss);
            Logger.Log.Info("Преобразовано AO");
            ContextMain.AOs.Create<AO>();
            List<AO> data = new List<AO>();
            foreach (AO_JSON_site jitem in json_data)
            {
                AO ditem = new AO
                {
                    ADRES = jitem.Cells.ADRES
                };
                if (jitem.Cells.DDOC != null) { ditem.DDOC = DateTime.Parse(jitem.Cells.DDOC, CultureInfo.CurrentCulture); }
                ditem.DMT = jitem.Cells.DMT;
                if (jitem.Cells.DREG != null) { ditem.DREG = DateTime.Parse(jitem.Cells.DREG, CultureInfo.CurrentCulture); }
                if (jitem.Cells.geoData != null)
                {
                    try
                    {
                        ditem.geoData = DbGeography.FromText(jitem.Cells.geoData.AsText(), 4326);
                    }
                    catch { ditem.geoData = DbGeography.FromText(jitem.Cells.geoData.Reverse().AsText(), 4326); }

                }
                else ditem.geoData = null;
                ditem.global_id = jitem.Cells.global_id;
                ditem.KAD_KV = jitem.Cells.KAD_KV;
                ditem.KAD_RN = jitem.Cells.KAD_RN;
                ditem.KAD_ZU = jitem.Cells.KAD_ZU;
                ditem.NDOC = jitem.Cells.NDOC;
                ditem.NREG = jitem.Cells.NREG;
                ditem.SOOR = jitem.Cells.SOOR;
                ditem.STRT = jitem.Cells.STRT;
                //ditem.system_object_id = jitem.Cells.system_object_id;
                ditem.TDOC = jitem.Cells.TDOC;
                ditem.UNOM = jitem.Cells.UNOM;
                ditem.VLD = jitem.Cells.VLD;
                ditem.VYVAD = jitem.Cells.VYVAD;
                ditem.KRT = jitem.Cells.KRT;
                data.Add(ditem);
            }
            ContextMain.AOs.AddRange(data);
            ContextMain.SaveChanges();
            Logger.Log.Info("Сохранено AO");
        }
        public void DeserializeAO(Encoding encoding)
        {
            DataLoader.Dataset = "1927";
            DataLoader.Load(encoding);
            // foreach (string S in Loader.Result)
            while (DataLoader.Result.TryDequeue(out string S))
            {
                MemoryStream ms = new MemoryStream(encoding.GetBytes(S));
                DeserializeAO_site(ms, encoding);
            }
        }
        public void LoadGeoJSON_AO(Stream stream, Encoding encoding)
        {
            // = "E:\\Filetable1\\ao.geojson";

            var s = new StreamReader(stream, encoding).ReadToEnd();

            var reader = new GeoJsonReader();
            var fc = reader.Read<FeatureCollection>(s);
            List<AO_geojson> flist = new List<AO_geojson>();
            foreach (Feature f in fc.Features)
            {

                var geo = f.Geometry.AsText();
                AO_geojson AO = new AO_geojson
                {
                    NAME = (string)f.Attributes["NAME"],
                    OKATO = (string)f.Attributes["OKATO"],
                    ABBREV = (string)f.Attributes["ABBREV"]
                };
                try
                {
                    AO.geometry = DbGeography.FromText(f.Geometry.AsText(), 4326);
                }
                catch
                {
                    try
                    {
                        AO.geometry = DbGeography.FromText(f.Geometry.Reverse().AsText(), 4326);
                    }
                    catch
                    {
                        AO.geometry = null;

                    }

                }
                flist.Add(AO);
            }
            ContextMain.Configuration.AutoDetectChangesEnabled = false;
            ContextMain.AO_geojsons.AddRange(flist);
            ContextMain.SaveChanges();
            ContextMain.Configuration.AutoDetectChangesEnabled = true;
        }

        public string FirstVal<T>(IEnumerable<T> list)
        {
            if (list.Any())
            {
                return list.FirstOrDefault().ToString().Replace("&#171;", "\"").Replace("&#187;", "\"");
            }
            else
                return null;
        }
        public OrganizationType FirstVal<T>(IEnumerable<T> list, string FullTypeName) where T : OrganizationType
        {
            if (list.Any())
            {
                return list.FirstOrDefault();
            }
            else
                return new OrganizationType() { FullTypeName = FullTypeName };
        }
        public void UpdateOrganizationsByDomMosRu()
        {
            JSONContext context = new JSONContext();
            Regex reHref = new Regex("&#\\d+;");
            List<UPRsite> inserted = (from upr in context.UPRsites
                                      select upr).ToList();
            foreach (UPRsite uprsite in inserted)
            {
                uprsite.InfTableRows.ToList();
                var ogrn = FirstVal(uprsite.InfTableRows.Where(p => p.Name.Trim() == "Основной государственный регистрационный номер (ОГРН):" ? true : false).Select(p => p.Value));
                var inn = FirstVal(uprsite.InfTableRows.Where(p => p.Name != null && p.Name.Trim() == "Идентификационный номер налогоплательщика(ИНН):" ? true : false).Select(p => p.Value));
                var shname = FirstVal(uprsite.InfTableRows.Where(p => p.Name != null && p.Name.Trim() == "Сокращенное наименование" ? true : false).Select(p => p.Value));
                var uaddress = FirstVal(uprsite.InfTableRows.Where(p => p.Name != null && p.Name.Trim() == "Место государственной регистрации юридического лица(место нахождения юридического лица):" ? true : false).Select(p => p.Value));
                var form = FirstVal(uprsite.InfTableRows.Where(p => p.Name != null && p.Name.Trim() == "Организационно-правовая форма" ? true : false).Select(p => p.Value));
                var orgType = FirstVal(context.OrganizationTypes.ToList().Where(ot => ot.FullTypeName.Trim() == form ? true : false).ToList(), form);
                var fio = FirstVal(uprsite.InfTableRows.Where(p => p.Name.Trim() == "ФИО руководителя (председателя)" ? true : false).Select(p => p.Value));
                Organization organization = new Organization()
                {
                    Id = uprsite.ID,
                    FullName = uprsite.Name,
                    OGRN = ogrn,
                    INN = inn,
                    ShortName = shname,
                    UrAddress = uaddress,
                    OrganizationType = orgType
                };

                //organization.DirectorPosition.Add(dirpos);
                if (organization.OGRN != null)
                {
                    context.Organizations.AddOrUpdate(p => new { p.OGRN }, organization);
                }
                else
                {
                    context.Organizations.AddOrUpdate(p => new { p.Id }, organization);
                }
                context.SaveChanges();
                if (fio.Any())
                {
                    var dirpos = (new AccountantGeneralPosition()
                    {
                        PositionType = new PersonPositionType() { PositionType = "" },
                        Human = new Person() { Family = fio, Id = Guid.NewGuid() },
                        InstDocument = new Document() { DocumentName = "" },
                        Organization_Id = organization.Id
                    });
                    context.AccountantGeneralPositions.AddOrUpdate(p => p.Organization_Id, dirpos);
                    context.SaveChanges();
                }
            }
        }

        public void LoadGeoJSON_MO(Stream stream, Encoding encoding)
        {
            // = "E:\\Filetable1\\ao.geojson";

            var s = new StreamReader(stream, encoding).ReadToEnd();

            var reader = new GeoJsonReader();
            var fc = reader.Read<FeatureCollection>(s);
            List<MO_geojson> flist = new List<MO_geojson>();
            foreach (Feature f in fc.Features)
            {

                var geo = f.Geometry.AsText();
                MO_geojson MO = new MO_geojson
                {
                    NAME = (string)f.Attributes["NAME"],
                    OKATO = (string)f.Attributes["OKATO"],
                    ABBREV_AO = (string)f.Attributes["ABBREV_AO"],
                    OKTMO = (string)f.Attributes["OKTMO"],
                    NAME_AO = (string)f.Attributes["NAME_AO"],
                    OKATO_AO = (string)f.Attributes["OKATO_AO"],
                    TYPE_MO = (string)f.Attributes["TYPE_MO"]
                };
                try
                {
                    MO.geometry = DbGeography.FromText(f.Geometry.AsText(), 4326);
                }
                catch
                {
                    try
                    {
                        MO.geometry = DbGeography.FromText(f.Geometry.Reverse().AsText(), 4326);
                    }
                    catch
                    {
                        MO.geometry = null;

                    }

                }
                flist.Add(MO);
            }
            ContextMain.Configuration.AutoDetectChangesEnabled = false;
            ContextMain.MO_geojsons.AddRange(flist);
            ContextMain.SaveChanges();
            ContextMain.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}

