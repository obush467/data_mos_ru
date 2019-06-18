using data_mos_ru.Entities;
using log4net;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace data_mos_ru
{
    public class dom_mos_ru_Loader
    {
        readonly UriBuilder uriBuilder = new UriBuilder();
        readonly WebClient webClient = new WebClient();
        private ILog logger;
        public ConcurrentQueue<UPRsite> Result = new ConcurrentQueue<UPRsite>();
        public Uri BaseUri { get; set; } = new Uri("http://dom.mos.ru");
        public dom_mos_ru_Loader(ILog Logger)
        {
            logger = Logger;
            uriBuilder.Scheme = "https";
        }

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
                string _html = DownloadString(_houseuri, encoding);
                house1.DecodeUPR(_html);
                context.SaveChanges();
                logger.Info(_houseuri.ToString());
            }
        }
       
        public UPRsite LoadUpr(UPR upr, Encoding encoding)
        {
            Uri _upruri = new Uri(BaseUri, upr.Url);
            string _html = DownloadString(_upruri, encoding);
            Guid _id = new Guid(_upruri.Segments[_upruri.Segments.Count() - 1]);
            logger.Info(_upruri.ToString());
            return new UPRsite( _id, upr.Value, _upruri.ToString(), _html);        
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
                async p => {
                    Uri _upruri = new Uri(BaseUri, new Uri(p.Url));
                    Guid _id = new Guid(_upruri.Segments[_upruri.Segments.Count() - 1]);
                    await (new UPRsite(_id, p.Value, p.Url, "")).DownloadStringTask(new Uri(BaseUri,p.Url), encoding); });

            logger.Info(Result.Count.ToString());
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
            Result.Enqueue(LoadUpr(upr,encoding));
        }
        protected string DownloadString(Uri uri, Encoding encoding)
        {
            WebClient client = new WebClient
            {
                Encoding = encoding
            };
            return client.DownloadString(uri);
        }


    }
}



