using data_mos_ru.Entityes;
using HtmlAgilityPack;
using log4net;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace data_mos_ru
{
    public class House
    {
        [Key]
        public Guid ID { get; set; }
        public Uri Uri { get; set; }
    }
        public class HouseList
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public House Houses { get; set; }
    }
    public class InfTableRow 
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class UPRsite
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }
        public ICollection<InfTableRow> InfTableRows { get; set; }
}
    public class dom_mos_ru_Loader
    {
        UriBuilder r = new UriBuilder();
        WebClient w = new WebClient();
        NameValueCollection Query=new httpQueryNameValueCollection();
        private ILog logger;
        public ConcurrentQueue<String> Result = new ConcurrentQueue<String>();
        public string ApiKey { get; set; } = "43829b1b6ff23da601a17e8a65c081ed";
        public string dataset { get; set; }
        string link { get { return "/v1/datasets/" + dataset; } } //ссылка
        public Uri BaseUri { get; set; } = new Uri("http://dom.mos.ru");
        public dom_mos_ru_Loader(string vdataset, ILog Logger)
        {
            logger = Logger;
            dataset = vdataset;
            r.Scheme = "https";
            Query.Add("api_key", ApiKey);
        }

        public void Load(Encoding encoding)
        {
            LoadURIList(URIs(encoding),encoding);
        }

        public void LoadUPRs(IEnumerable<UPR> uprs, Encoding encoding)
        {
            List<UPRsite> _UPRsites = new List<UPRsite>();
            foreach (UPR upr in uprs)
            {
                UPRsite _newUPRsite = new UPRsite();
                Uri _upruri = new Uri(BaseUri, upr.Url);
                _newUPRsite.Name = upr.Value;
                _newUPRsite.Uri = _upruri.ToString();
                HtmlDocument hap = new HtmlDocument();
                hap.LoadHtml(DownloadString(_upruri, encoding));
                HtmlNode _content = hap.DocumentNode.SelectSingleNode("/html/body/div[@id='container']/div[@id='wrapper']/div[@id='page']/div[@class='inside inside-company-caption']");
                HtmlNode h1 = _content.SelectSingleNode("h1[@class='tClr1']");
                HtmlNode inf = _content.SelectSingleNode("div[@class='rndBrdBlock mrgT18 uk-inf']");

                HtmlNode table = inf.SelectSingleNode("table");
                HtmlNodeCollection tablerows = table.SelectNodes("tbody/tr");
                if (tablerows != null)
                {
                    _newUPRsite.InfTableRows = new List<InfTableRow>();
                    foreach (HtmlNode node in tablerows)
                    {
                        InfTableRow _infTableRow = new InfTableRow();
                        _infTableRow.Name = node.SelectSingleNode("td[@class='td1']").InnerText;
                        _infTableRow.Value = node.SelectSingleNode("td[@class='td2']").InnerText;
                        _newUPRsite.InfTableRows.Add(_infTableRow);
                    }
                }

                HtmlNodeCollection _houses = _content.SelectNodes("div[@class='rndBrdBlock mrgT18 uk-houses']");
                if (_houses != null)
                {
                    foreach(HtmlNode _houselistnode in _houses)
                    {
                        HouseList _houselist = new HouseList();
                        foreach (HtmlNode _housenode in _houselistnode.SelectNodes("table//tr/td//a"))
                        {
                            _housenode.GetAttributeValue("href",true);
                        }
                    }
                    
                }
                _UPRsites.Add(_newUPRsite);
            }
        }
        public void LoadUPRsList(Encoding encoding)
        { }
        protected List<Uri> URIs(Encoding encoding)
        {
            r.Path = link + "/count";
            r.Host = "apidata.mos.ru";
            r.Query = Query.ToString();
            List<Uri> uris = new List<Uri>();
            try
            {
                string countstr = w.DownloadString(r.Uri);
                int Count, blockCount, blockLength = 500;
                Query["$top"] = blockLength.ToString();
                if (!(string.IsNullOrEmpty(countstr) | string.IsNullOrWhiteSpace(countstr)))
                {
                    if (int.TryParse(countstr, out Count))
                    {
                        blockCount = Count / blockLength + 1;
                        for (int i = 1; i <= blockCount; i++)
                        {
                            Query["$skip"] = ((i - 1) * blockLength).ToString();
                            logger.Info(i);
                            r.Path = link + "/rows";
                            r.Query = Query.ToString();
                            uris.Add(r.Uri);
                        }
                    }
                }
                return uris;
            }
            catch (WebException)
            { return null; }
        }
        protected void LoadURIList(List<Uri> uris,Encoding encoding)
        {
            List<Task> Tasks = new List<Task>();
            foreach (Uri _uri in uris)
            {
                Action<Task, object> at = new Action<Task, object>((delegate (Task ff, object Parameters)
                    {
                       Download((Uri)Parameters,encoding);
                    }));
                Action<object> a = new Action<object>((delegate (object Parameters)
                {
                    Download((Uri)Parameters, encoding);
                }));


                if (Tasks.Count< 1)
                    { Tasks.Add(new Task(a, _uri));}
                    else
                    {Tasks.Add(Tasks[Tasks.Count - 1].ContinueWith(at, _uri)); }
              }
                        
            Tasks[0].Start();
            Tasks[0].Wait();
        }
        delegate void loadURIList();
        protected Task LoadURIListTask(List<Uri> uris, Encoding encoding)
        {
            loadURIList t = (() =>LoadURIList(uris, encoding));
            Action a = new Action(t);
            Task _task = new Task(a);
            return _task;
        }
private void WebClient_DownloadDataCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e != null)
            {
                try
                {
                    Result.Enqueue(e.Result);
                    logger.Info("Блок считан" +e.UserState.ToString());
                }
                catch (Exception)
                { }
            }
        }
        public Task DownloadStringTask(Uri url, Encoding encoding)
        {
            WebClient client = new WebClient();
            client.Encoding = encoding;
            client.DownloadStringCompleted += WebClient_DownloadDataCompleted;
            return client.DownloadStringTaskAsync(url); 
        }
        protected void Download(Uri uri, Encoding encoding)
        {
            WebClient client = new WebClient();
            client.Encoding = encoding;
            Result.Enqueue(client.DownloadString(uri));
        }
        protected string DownloadString(Uri uri, Encoding encoding)
        {
            WebClient client = new WebClient();
            client.Encoding = encoding;
            return client.DownloadString(uri);
        }


    }
}
    

