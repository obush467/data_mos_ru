using data_mos_ru.Entities;
using data_mos_ru.Loaders;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using UNS.Models;
using UNS.Models.Entities;
using Utility;

namespace data_mos_ru.Operators

{
    public class dom_mos_ru_Operator : Operator
    {
        private Dom_mos_ru_Loader DomLoader { get; set; }
        public dom_mos_ru_Operator() : base()
        {
            DomLoader = new Dom_mos_ru_Loader();
        }

        public dom_mos_ru_Operator(string сonnectionString) : base(сonnectionString)
        { }
        /// <summary>
        /// 
        /// </summary>
        public void UpdateHouses()
        {
            DomLoader.UpdateHouses(Encoding.UTF8);
        }
        /// <summary>
        /// 
        /// </summary>
        public void LoadDom()
        {
            IEnumerable<SearchAutoCompleteResult> fulls = from upr in ContextMain.UPRs
                                                          where
                             upr.Section == "UPR"
                                                          select upr;
            IEnumerable<SearchAutoCompleteResult> lold = from upr in ContextMain.UPRs
                                                         join usite in ContextMain.UPRsites
                                                         on upr.ID equals usite.ID
                                                         select upr;
            var lfull = fulls.ToList().AsEnumerable();
            var excepted = lfull.Except(lold).ToList();
            DomLoader.LoadUpr(excepted, Encoding.UTF8);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task LoadBuildingsAsync()
        {
            using (JSONContext context = new JSONContext(ConnectionString))
            {
                var addressList = context.AO_60562s.ToList().Select(s => s.ADDRESS).ToList();
                await DomLoader.LoadBuildingsAsync(addressList, Encoding.UTF8);
                //context.UPRs.AddOrUpdate(up=>new {up.Url },ttt.Distinct().ToArray());
                context.SaveChanges();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void LoadBuildings()
        {
            using (JSONContext context = new JSONContext(ConnectionString))
            {
                var addressList = context.AO_60562s.OrderBy(o => o.ADDRESS).Select(s => s.ADDRESS).ToList();
                var ttt = DomLoader.LoadBuildings(addressList, Encoding.UTF8);
                context.UPRs.AddOrUpdate(up => new { up.Url }, ttt.Distinct().ToArray());
                context.SaveChanges();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searches"></param>
        /// <param name="context"></param>
        /// <param name="result"></param>
        public void LoadUPRsFromBuildingsBlockingCollection(List<Uri> searches, JSONContext context, BlockingCollection<SearchAutoCompleteResult> result = null)
        {
            if (result == null) result = DomLoader.BlockingCollectionUPRs;
            //context.Configuration.AutoDetectChangesEnabled = false;
            //Загрузка с сайта
            using (CancellationTokenSource ts = new CancellationTokenSource())
            {
                Task t1 = Task.Run(() => DomLoader.UPRsFromHouses(searches, Encoding.UTF8, result));
                //запись найденных
                Task t2 = Task.Run(() =>
                {
                    SearchAutoCompleteResult upr = new SearchAutoCompleteResult();
                    foreach (var n in result.GetConsumingEnumerable())
                    {
                        try
                        {
                            context.UPRs.AddOrUpdate(up => up.Url, n);
                            context.SaveChanges();
                            Logger.Logger.Info(string.Join(" ", "ВНЕСЕНО", n.Value, result.Count));
                        }
                        catch (Exception) { }
                    }
                    context.SaveChanges();
                    ts.Cancel();
                });
                Task.WaitAll(new Task[] { t1, t2 });
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void LoadUPRsFromBuildings()
        {
            using (JSONContext context = new JSONContext(ConnectionString))
            {
                /* IEnumerable<SearchAutoCompleteResult> fulls = from upr in context.UPRs
                                                               where upr.Section == "Buildings"
                                                               select upr;
                 IEnumerable<SearchAutoCompleteResult> lold = from upr in context.UPRs
                                                              join house in context.Houses
                                                              on upr.Url equals house.UriString
                                                              select upr;*/
                IEnumerable<SearchAutoCompleteResult> fulls = from upr in context.UPRs
                                                              where upr.Section == "Buildings"
                                                              join house in context.Houses
                                                              on upr.Url equals house.UriString into inner
                                                              from inneri in inner.DefaultIfEmpty()
                                                              where inneri.ID == null
                                                              select upr;
                var lfull = fulls.ToList().AsEnumerable();
                // var addressList = lfull.Except<SearchAutoCompleteResult>(lold).Select(s=>new Uri(s.Url)).ToList();
                var addressList = lfull.Select(s => (new UriBuilder(s.Url)).Uri).ToList();
                LoadUPRsFromBuildingsBlockingCollection(addressList, context, new BlockingCollection<SearchAutoCompleteResult>());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searches"></param>
        /// <param name="section"></param>
        /// <param name="context"></param>
        /// <param name="result"></param>
        public void LoadSearchAutoCompleteBlockingCollection(List<string> searches, string section, JSONContext context, BlockingCollection<SearchAutoCompleteResult> result = null)
        {
            searches.Sort();
            if (result == null) result = DomLoader.BlockingCollectionUPRs;
            context.Configuration.AutoDetectChangesEnabled = false;
            //Загрузка с сайта
            using (CancellationTokenSource ts = new CancellationTokenSource())
            {
                Task t1 = Task.Run(() => DomLoader.GetSearchAutoComplete(searches, section, Encoding.UTF8, result));
                //запись найденных
                Task t2 = Task.Run(() =>
                {
                    SearchAutoCompleteResult upr = new SearchAutoCompleteResult();
                    foreach (var n in DomLoader.BlockingCollectionUPRs.GetConsumingEnumerable())
                    {
                        try
                        {
                            context.UPRs.AddOrUpdate(up => up.Url, n);

                            Logger.Logger.Info(string.Join(" ", "ВНЕСЕНО", n.Value, DomLoader.BlockingCollectionUPRs.Count));
                        }
                        catch (Exception) { }
                    }
                    context.SaveChanges();
                    ts.Cancel();
                });
                Task.WaitAll(new Task[] { t1, t2 });
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void LoadBuildingsBlockingCollection()
        {
            using (JSONContext context = new JSONContext(ConnectionString))
            {
                var aol = context.AO_60562s.ToList();
                var addressList1 = (aol.Select(s => s.ADDRESS).ToList()).ConvertAll(new Converter<string, string>(AddressOperator.CleanToSearch));
                // TODO var addressList2 = aol.ConvertAll(new Converter<AO_60562, string>(AddressOperator.AO_60562_ToSearch));
                // TODO var addressList = addressList1.Union(addressList2).ToList();
                //TODO addressList.Sort();
                //TODO LoadSearchAutoCompleteBlockingCollection(addressList, "Buildings", context);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void LoadUPRsBlockingCollection()
        {
            using (JSONContext context = new JSONContext(ConnectionString))
            {
                var aol = context.AO_60562s.ToList();
                /*var addressList = (aol.Where(p=>p.P5!=null)
                    .Select(s => s.P5)
                    .Distinct()
                    .ToList())
                        .ConvertAll(new Converter<string, string>(AddressOperator.CleanToSearch));*/
                var addressList = new List<string>() { "жилищник", "рэу", "гбу", "тсж", "ооо", "жск", "гск", "кооператив" };
                //var addressList = addressList1.Union(addressList2).ToList();
                addressList.Sort();
                LoadSearchAutoCompleteBlockingCollection(addressList, "UPR", context, new BlockingCollection<SearchAutoCompleteResult>());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void UpdateOrganizationsByDomMosRu()
        {
            using (JSONContext jscontext = new JSONContext())
            using (UNSModel unscontext = new UNSModel())
            {
                Regex reHref = new Regex("&#\\d+;");
                List<UPRsite> inserted = (from upr in jscontext.UPRsites
                                          select upr).ToList();
                foreach (UPRsite uprsite in inserted)
                {
                    uprsite.InfTableRows.ToList();
                    var ogrn = FirstVal(uprsite.InfTableRows.Where(p => p.Name.Trim() == "Основной государственный регистрационный номер (ОГРН):" ? true : false).Select(p => p.Value));
                    var inn = FirstVal(uprsite.InfTableRows.Where(p => p.Name != null && p.Name.Trim() == "Идентификационный номер налогоплательщика(ИНН):" ? true : false).Select(p => p.Value));
                    var shname = FirstVal(uprsite.InfTableRows.Where(p => p.Name != null && p.Name.Trim() == "Сокращенное наименование" ? true : false).Select(p => p.Value));
                    var uaddress = FirstVal(uprsite.InfTableRows.Where(p => p.Name != null && p.Name.Trim() == "Место государственной регистрации юридического лица(место нахождения юридического лица):" ? true : false).Select(p => p.Value));
                    var form = FirstVal(uprsite.InfTableRows.Where(p => p.Name != null && p.Name.Trim() == "Организационно-правовая форма" ? true : false).Select(p => p.Value));
                    var orgType = unscontext.OrganizationTypes.Where(ot => ot.FullTypeName.Trim() == form ? true : false).FirstOrDefault();
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
                        unscontext.Organizations.AddOrUpdate(p => new { p.OGRN }, organization);
                    }
                    else
                    {
                        unscontext.Organizations.AddOrUpdate(p => new { p.Id }, organization);
                    }
                    jscontext.SaveChanges();
                    if (fio.Any())
                    {
                        var dirpos = (new AccountantGeneralPosition()
                        {
                            PositionType = new PersonPositionType() { PositionType = "" },
                            Human = new Person() { Family = fio, Id = Guid.NewGuid() },
                            InstDocument = new Document() { DocumentName = "" },
                            //Organization_Id = organization.Id
                        });
                        //unscontext.AccountantGeneralPositions.AddOrUpdate(p => p.Organization_Id, dirpos);
                        jscontext.SaveChanges();
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public string FirstVal<T>(IEnumerable<T> list)
        {
            if (list.Any())
            {
                return list.FirstOrDefault().ToString().Replace("&#171;", "\"").Replace("&#187;", "\"");
            }
            else
                return null;
        }


    }
}
