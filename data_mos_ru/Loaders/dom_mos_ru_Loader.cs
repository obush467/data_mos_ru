using data_mos_ru.Entities;
using data_mos_ru.Utility;
using log4net;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace data_mos_ru.Loaders
{
    public class Dom_mos_ru_Loader : Loader
    {
        public ConcurrentQueue<UPRsite> QueueUPRsites = new ConcurrentQueue<UPRsite>();
        public ConcurrentQueue<UPR> QueueUPRs = new ConcurrentQueue<UPR>();
        public BlockingCollection<UPR> BlockingCollectionUPRs = new BlockingCollection<UPR>();
        public Uri BaseUri { get; set; } = new Uri("http://dom.mos.ru");
        public void Load(Encoding encoding)
        {
            LoadUpr(LoadUPRsList(encoding), encoding);
        }
        public void UpdateHouses(Encoding encoding)
        {
            JSONContext context = new JSONContext();
            IEnumerable<House> houses =
                (from house in context.Houses
                 where house.Address == null
                 select house).ToList();
            foreach (House house1 in houses)
            {
                Uri _houseuri = new Uri(BaseUri, house1.Uri);
                string _html = DownloadString(_houseuri, encoding,null);
                house1.DecodeUPR(_html);
                context.SaveChanges();
                Logger.Log. Info(_houseuri.ToString());
            }
        }

        public UPRsite LoadUpr(UPR upr, Encoding encoding)
        {
            Uri _upruri = new Uri(BaseUri, upr.Url);
            string _html = DownloadString(_upruri, encoding,null);
            Guid _id = new Guid(_upruri.Segments[_upruri.Segments.Count() - 1]);
            Logger.Log.Info(_upruri.ToString());
            return new UPRsite(_id, upr.Value, _upruri.ToString(), _html);
        }
        public List<UPRsite> LoadUpr(IEnumerable<UPR> uprs, Encoding encoding)
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
        public List<UPR> LoadUPRsList(Encoding encoding)
        { return new List<UPR>(); }

        public async void LoadUPR_Async(IEnumerable<UPR> uprs, Encoding encoding)
        {
            List<Task> Tasks = new List<Task>();

            Parallel.ForEach(uprs,
                async p =>
                {
                    Uri _upruri = new Uri(BaseUri, new Uri(p.Url));
                    Guid _id = new Guid(_upruri.Segments[_upruri.Segments.Count() - 1]);
                    await (new UPRsite(_id, p.Value, p.Url, "")).DownloadStringTask(new Uri(BaseUri, p.Url), encoding);
                });
            Logger.Log.Info(string.Join(" ","Завершена загрузка",QueueUPRsites.Count.ToString()));
        }
        public async Task LoadUPR_Async(UPR upr, Encoding encoding)
        { }
        delegate void loadURIList();
        protected async Task LoadURIListTask(UPR upr, Encoding encoding)
        {
            await LoadUPR_Async(upr, encoding);
        }

        protected void DownloadUPR(UPR upr, Encoding encoding)
        {
            QueueUPRsites.Enqueue(LoadUpr(upr, encoding));
        }

        public async Task LoadBuildingsAsync(List<string> searches, Encoding encoding)
        {
      
            Parallel.ForEach(searches, new ParallelOptions() { MaxDegreeOfParallelism = 50000 },
                async p =>
                    {
                        foreach (UPR ups in await LoadBuildingsAsync(p, encoding))
                        { QueueUPRs.Enqueue(ups); }
                    });
        }

        public List<UPR> LoadBuildings(List<string> searches, Encoding encoding)
        {
            ConcurrentQueue<UPR> result = new ConcurrentQueue<UPR>();
            Parallel.ForEach(searches, new ParallelOptions() { MaxDegreeOfParallelism = 50000 },
                async p =>
                {
                    foreach (UPR ups in LoadBuildings(p, encoding))
                    { result.Enqueue(ups); }
                });
            return result.ToList();
        }

        public void LoadBuildings(List<string> searches, Encoding encoding, BlockingCollection<UPR> result)
        {
            Parallel.ForEach(searches, new ParallelOptions() { MaxDegreeOfParallelism = 50000 },
                async p =>
                {
                    foreach (UPR ups in LoadBuildings(p, encoding))
                    { result.Add(ups); }
                });
        }

        public List<UPR> LoadBuildings(string search, Encoding encoding)
        {
            Uri uri = new Uri(BaseUri, "/Lookups/GetSearchAutoComplete");          
            List<UPR> result = new List<UPR>();
            try
            {
                string html = DownloadString(uri, encoding, GetSearchAutoCompleteParameters(search, "Buildings"));
                Logger.Log.Info(string.Join(" ", search));
                result = Deserialize<UPR>(new MemoryStream(encoding.GetBytes(html)), encoding);
            }
            catch (Exception e)
            {
                Logger.Log.Error(string.Join(" " , uri.ToString(),search,e.Message));
            }
            finally
            { }
            return result;
        }
        public async Task<List<UPR>> LoadBuildingsAsync(string search, Encoding encoding)
        {
            Uri uri = new Uri(BaseUri, "/Lookups/GetSearchAutoComplete");
            search = search.Replace("город Москва, ", "");
            List<UPR> result =new List<UPR>();
            try
            {
                string html =await DownloadStringAsync(uri, encoding, GetSearchAutoCompleteParameters(search, "Buildings"));
                Logger.Log.Info(uri.ToString() + search);
                result= Deserialize<UPR>(new MemoryStream(encoding.GetBytes(html)), encoding);
            }
            catch (Exception e)
            {
                Logger.Log.Error(string.Join(" ", uri.ToString(), search, e.Message));
            }
            finally
            {  }
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



