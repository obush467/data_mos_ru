using data_mos_ru.Entities;
using HtmlAgilityPack;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace data_mos_ru.Loaders
{
    public class Dom_mos_ru_Loader : Loader
    {
        public ConcurrentQueue<UPRsite> QueueUPRsites = new ConcurrentQueue<UPRsite>();
        public ConcurrentQueue<SearchAutoCompleteResult> QueueUPRs = new ConcurrentQueue<SearchAutoCompleteResult>();
        public BlockingCollection<SearchAutoCompleteResult> BlockingCollectionUPRs = new BlockingCollection<SearchAutoCompleteResult>();
        public Uri BaseUri { get; set; } = new Uri("http://dom.mos.ru");
        public void Load(Encoding encoding)
        {
            //TODO Load
        }
        /// <summary>
        /// Обновляет Дома, внесенные в таблицу, но имеющие незаполненные поля. Обновление по фирме-управляшке не производится
        /// </summary>
        /// <param name="encoding"></param>
        public void UpdateHouses(Encoding encoding)
        {
            JSONContext context = new JSONContext();
            IEnumerable<House> houses =
                (from _house in context.Houses
                 where _house.Address == null
                 select _house).ToList();
            foreach (House house in houses)
            {
                Uri _houseuri = new Uri(BaseUri, house.UriString);
                string _html = DownloadString(_houseuri, encoding, null);
                DecodeHouse(house, _html);
                context.SaveChanges();
                Logger.Log.Info(_houseuri.ToString());
            }
        }

        public void UPRsFromHouses(IEnumerable<Uri> uris, Encoding encoding, BlockingCollection<SearchAutoCompleteResult> result = null)
        {
            if (result == null) result = BlockingCollectionUPRs;
            Parallel.ForEach(uris, new ParallelOptions() { MaxDegreeOfParallelism = 100 },
                uri =>
                {
                    string html = DownloadString(uri, encoding, null);
                    House house = new House();
                    DecodeHouse(house, html);
                    if (!string.IsNullOrEmpty(house.UPRUriString))
                        house.UPRUri = new Uri(BaseUri, house.UPRUriString);
                    if (house.UPRUriString != null)
                        house.ID = GuidFromUri(house.UPRUri);
                    else house.ID = Guid.NewGuid();
                    result.Add(new SearchAutoCompleteResult()
                    {
                        Url = house.UPRUriString,
                        ID = house.ID
                    }
                        ); ;
                    Logger.Log.Info(string.Join(" ", "Загружена УК по адресу дома", house.Address, house.UPRUriString));
                });
        }

        public void DecodeHouse(House house, string html)
        {
            HtmlDocument hap = new HtmlDocument();
            hap.LoadHtml(html);
            HtmlNode _content = hap.DocumentNode.SelectSingleNode("/html/body/div[@id='container']/div[@id='wrapper']/div[@id='page']/div[@id='content']");
            HtmlNode _h1_Address = _content.SelectSingleNode("div/div/h1[@class='tClr1']");
            if (_h1_Address != null) house.Address = _h1_Address.InnerText;
            HtmlNode _h2_AdmArea = _content.SelectSingleNode("div/div/h2[@class='tClr2']");
            if (_h2_AdmArea != null) house.AdmArea = _h2_AdmArea.InnerText;
            HtmlNode _table = _content.SelectSingleNode("div/div/div/div/table[@class='infoCompanyTable']");
            HtmlNode CompaniDiv = _content.SelectSingleNode("//@href[contains(.,'Comp')]");
            HtmlNode _OrgHref2 = null;

            if (_table != null)
            {
                //HtmlNode _tablerowYearOfConstruction = _table.SelectSingleNode("tbody/tr/td[text()='Год постройки:']").ParentNode.SelectNodes("td")[1];
                HtmlNode _tablerowYearOfConstruction = _table.SelectSingleNode("tbody/tr/td[text()='Год постройки:']/../td[2]");
                if (_tablerowYearOfConstruction != null && !string.IsNullOrEmpty(_tablerowYearOfConstruction.InnerText.Trim()))
                    house.YearOfConstruction = int.Parse(_tablerowYearOfConstruction.InnerText);
                HtmlNode _tablerowSeries = _table.SelectSingleNode("tbody/tr/td[text()='Серия']/../td[2]");
                if (_tablerowSeries != null) house.Series = _tablerowSeries.InnerText;
                var _tablerowStoreysCount = _table.SelectSingleNode("tbody/tr/td[text()='Этажность:']/../td[2]");
                if (_tablerowStoreysCount != null) house.StoreysCount = int.Parse(_tablerowStoreysCount.InnerText);
                HtmlNode _tablerowTotalArea = _table.SelectSingleNode("tbody/tr/td[text()='Общая площадь:']/../td[2]");
                if (_tablerowTotalArea != null) house.TotalArea = _tablerowTotalArea.InnerText;
                HtmlNode _tablerowotalAreaResidentialPremises = _table.SelectSingleNode("tbody/tr/td[text()='Общая площадь жилых помещений:']/../td[2]");
                if (_tablerowotalAreaResidentialPremises != null) house.TotalAreaResidentialPremises = _tablerowotalAreaResidentialPremises.InnerText;
                _OrgHref2 = _table.SelectSingleNode("tbody/tr/td[text()='Управляющая организация:']/../td[2]/a");
            }

            if (CompaniDiv != null)
            {
                try
                {
                    house.UPRUri = new Uri(BaseUri, CompaniDiv.GetAttributeValue("href", null).Trim());
                    if (Guid.Empty == house.ID) house.ID = GuidFromUri(house.UPRUri);
                }
                catch (Exception)
                {
                    house.UPRUriString = null;
                    house.ID = Guid.Empty;
                }
            }
            else
            {
                if (_OrgHref2 != null)
                {
                    house.UPRUriString = _OrgHref2.InnerText;
                    if (Guid.Empty == house.ID) house.ID = GuidFromUri(house.UPRUri);
                }
                else
                {
                    house.UPRUriString = null;
                    if (Guid.Empty == house.ID) house.ID = Guid.Empty;
                }
            }

        }
        public Guid GelHouseListid(Guid orgId)
        {
            //TODO GelHouseListid
            return Guid.Empty;
            throw new NotImplementedException();

        }

        public UPRsite LoadUpr(SearchAutoCompleteResult upr, Encoding encoding)
        {
            Uri _upruri = new Uri(BaseUri, upr.Url);
            string _html = DownloadString(_upruri, encoding, null);
            Guid _id = new Guid(_upruri.Segments[_upruri.Segments.Count() - 1]);
            Logger.Log.Info(_upruri.ToString());
            return new UPRsite(_id, upr.Value, _upruri.ToString(), _html);
        }
        public List<UPRsite> LoadUpr(IEnumerable<SearchAutoCompleteResult> uprs, Encoding encoding)
        {
            var uprsites = new List<UPRsite>();
            var context = new JSONContext();
            var updatedUprs =
                (from upr in uprs
                     //join _old in context.UPRsites.ToList() on _upr.ID equals _old.ID into l
                     //from _left in l
                 select upr).ToList();
            foreach (var upr in updatedUprs)
            {
                var uprsite = LoadUpr(upr, encoding);
                uprsites.Add(uprsite);
                context.UPRsites.Add(uprsite);
                //var mergedUprSites = new List<UPRsite>();
                //context.UPRsites.AddOrUpdate(_uPRsites.ToArray());
                context.SaveChanges();
            }
            return uprsites;
        }
        public async void LoadUPR_Async(IEnumerable<SearchAutoCompleteResult> uprs, Encoding encoding)
        {
            List<Task> Tasks = new List<Task>();

            Parallel.ForEach(uprs,
                async p =>
                {
                    Uri _upruri = new Uri(BaseUri, new Uri(p.Url));
                    Guid _id = new Guid(_upruri.Segments[_upruri.Segments.Count() - 1]);
                    await (new UPRsite(_id, p.Value, p.Url, "")).DownloadStringTask(new Uri(BaseUri, p.Url), encoding);
                });
            Logger.Log.Info(string.Join(" ", "Завершена загрузка", QueueUPRsites.Count.ToString()));
        }
        public async Task LoadUPR_Async(SearchAutoCompleteResult upr, Encoding encoding)
        { await Task.Run(() => { }); }
        //delegate void loadURIList();
        protected async Task LoadURIListTask(SearchAutoCompleteResult upr, Encoding encoding)
        {
            await LoadUPR_Async(upr, encoding);
        }

        protected void DownloadUPR(SearchAutoCompleteResult upr, Encoding encoding)
        {
            QueueUPRsites.Enqueue(LoadUpr(upr, encoding));
        }

        public async Task LoadBuildingsAsync(List<string> searches, Encoding encoding)
        {

            Parallel.ForEach(searches, new ParallelOptions() { MaxDegreeOfParallelism = 50000 },
                async p =>
                    {
                        foreach (SearchAutoCompleteResult ups in await LoadBuildingsAsync(p, encoding))
                        { QueueUPRs.Enqueue(ups); }
                    });
        }

        public List<SearchAutoCompleteResult> LoadBuildings(List<string> searches, Encoding encoding)
        {
            ConcurrentQueue<SearchAutoCompleteResult> result = new ConcurrentQueue<SearchAutoCompleteResult>();
            Parallel.ForEach(searches, new ParallelOptions() { MaxDegreeOfParallelism = 50000 },
                p =>
                {
                    foreach (SearchAutoCompleteResult ups in GetSearchAutoComplete(p, "Buildings", encoding))
                    { result.Enqueue(ups); }
                });
            return result.ToList();
        }

        public void LoadBuildings(List<string> searches, Encoding encoding, BlockingCollection<SearchAutoCompleteResult> result = null)
        {
            if (result == null) result = BlockingCollectionUPRs;
            Parallel.ForEach(searches, new ParallelOptions() { MaxDegreeOfParallelism = 50000 },
                p =>
                {
                    foreach (SearchAutoCompleteResult ups in GetSearchAutoComplete(p, "Buildings", encoding))
                    { result.Add(ups); }
                });
        }
        /// <summary>
        /// Закачивает автопоиск с сайта по поисковой строке и названию секции
        /// </summary>
        /// <param name="search">поисковая строка</param>
        /// <param name="section">секция (Buildings,UPR)</param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public List<SearchAutoCompleteResult> GetSearchAutoComplete(string search, string section, Encoding encoding)
        {
            Uri uri = new Uri(BaseUri, "/Lookups/GetSearchAutoComplete");
            List<SearchAutoCompleteResult> result = new List<SearchAutoCompleteResult>();
            try
            {
                string html = DownloadString(uri, encoding, GetSearchAutoCompleteParameters(search, section));
                Logger.Log.Info(string.Join(" ", section, search));
                result = Deserialize<SearchAutoCompleteResult>(new MemoryStream(encoding.GetBytes(html)), encoding);
            }
            catch (Exception e)
            {
                Logger.Log.Error(string.Join(" ", uri.ToString(), search, e.Message));
            }
            finally
            { }
            return result;
        }
        public List<SearchAutoCompleteResult> GetSearchAutoComplete(List<string> searches, string section, Encoding encoding)
        {
            BlockingCollection<SearchAutoCompleteResult> result = new BlockingCollection<SearchAutoCompleteResult>();
            GetSearchAutoComplete(searches, section, encoding, result);
            return result.ToList();
        }
        public Guid GuidFromUri(Uri uri)
        {
            Guid id = Guid.Empty;
            UriBuilder uriBuilder = new UriBuilder(uri);
            if (uriBuilder.Query == null || (uriBuilder.Query != null && string.IsNullOrEmpty(uriBuilder.Query)))
            {
                Guid.TryParse(uriBuilder.Uri.Segments.LastOrDefault().ToString(), out id);
            }
            return id;
        }
        public Guid GuidFromUri(string uri)
        {
            Guid id = Guid.Empty;
            UriBuilder uriBuilder = new UriBuilder(uri);
            if (uriBuilder.Query == null || (uriBuilder.Query != null && string.IsNullOrEmpty(uriBuilder.Query)))
            {
                Guid.TryParse(uriBuilder.Uri.Segments.LastOrDefault().ToString(), out id);
            }
            return id;
        }
        public void GetSearchAutoComplete(List<string> searches, string section, Encoding encoding, BlockingCollection<SearchAutoCompleteResult> result = null)
        {
            if (result == null) result = BlockingCollectionUPRs;
            Parallel.ForEach(searches, new ParallelOptions() { MaxDegreeOfParallelism = 50000 },

                p =>
                {
                    foreach (SearchAutoCompleteResult ups in GetSearchAutoComplete(p, section, encoding))
                    {
                        ups.ID = GuidFromUri(new Uri(BaseUri, ups.Url));
                        result.Add(ups);
                    }
                });
            //result.CompleteAdding();
        }

        public async Task<List<SearchAutoCompleteResult>> LoadBuildingsAsync(string search, Encoding encoding)
        {
            Uri uri = new Uri(BaseUri, "/Lookups/GetSearchAutoComplete");
            search = search.Replace("город Москва, ", "");
            List<SearchAutoCompleteResult> result = new List<SearchAutoCompleteResult>();
            try
            {
                string html = await DownloadStringAsync(uri, encoding, GetSearchAutoCompleteParameters(search, "Buildings"));
                Logger.Log.Info(uri.ToString() + search);
                result = Deserialize<SearchAutoCompleteResult>(new MemoryStream(encoding.GetBytes(html)), encoding);
            }
            catch (Exception e)
            {
                Logger.Log.Error(string.Join(" ", uri.ToString(), search, e.Message));
            }
            finally
            { }
            return result;
        }

        public HttpQueryNameValueCollection GetSearchAutoCompleteParameters(string search, string section)
        {
            HttpQueryNameValueCollection parameters = new HttpQueryNameValueCollection
            {
                { "term", search },
                { "section", section }
            };
            return parameters;
        }
    }
}



