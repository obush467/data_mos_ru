using data_mos_ru.Entityes;
using HtmlAgilityPack;
using log4net;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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
            LoadUPR(LoadUPRsList(encoding), encoding);
        }
        public void UpdateHouses(Encoding encoding)
        {
            JSONContext context = new JSONContext();
            IEnumerable<House> houses =
                from house in context.Houses
                where house.Address == null
                select house;
            foreach (House house1 in houses.ToList())
            {
                Uri _houseuri = new Uri(BaseUri, house1.Uri);
                string _html = DownloadString(_houseuri, encoding);
                house1.DecodeUPR(_html);
                context.SaveChanges();
                logger.Info(_houseuri.ToString());
            }
        }
       
        public UPRsite LoadUPR(UPR upr, Encoding encoding)
        {
            Uri _upruri = new Uri(BaseUri, upr.Url);
            string _html = DownloadString(_upruri, encoding);
            Guid _id = new Guid(_upruri.Segments[_upruri.Segments.Count() - 1]);
            logger.Info(_upruri.ToString());
            return new UPRsite( _id, upr.Value, _upruri.ToString(), _html);        
        }
        public List<UPRsite> LoadUPR(IEnumerable<UPR> uprs, Encoding encoding)
        {
            List<UPRsite> _UPRsites = new List<UPRsite>();
            JSONContext context = new JSONContext();
            IEnumerable<UPR> _upserted =
                from _upr in uprs
                //join _old in context.UPRsites.ToList() on _upr.ID equals _old.ID into l
                //from _left in l
                select _upr;
            foreach (UPR upr in _upserted.ToList())
            {
                UPRsite _uPRsite = LoadUPR(upr, encoding);                
                _UPRsites.Add(_uPRsite);
                List<UPRsite> _uPRsites = new List<UPRsite>();
                context.UPRsites.Add(_uPRsite);
                //context.UPRsites.AddOrUpdate(_uPRsites.ToArray());
                context.SaveChanges();
            }
            return _UPRsites;
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
            Result.Enqueue(LoadUPR(upr,encoding));
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



