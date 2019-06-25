using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace data_mos_ru.Loaders
{
    public class Data_mos_ru_Loader : Loader
    {
        NameValueCollection Query = new HttpQueryNameValueCollection();
        public string ApiKey { get; set; } = "43829b1b6ff23da601a17e8a65c081ed";
        public string Dataset { get; set; }
        string Link { get { return "/v1/datasets/" + Dataset; } } //ссылка
        public Data_mos_ru_Loader(string dataset)
        {
            Dataset = dataset;
            Query.Add("api_key", ApiKey);
        }

        public void Load(Encoding encoding)
        {
            LoadURIList(URIs(encoding), encoding);
        }
        protected List<Uri> URIs(Encoding encoding)
        {
            UriBuilder.Path = Link + "/count";
            UriBuilder.Host = "apidata.mos.ru";
            UriBuilder.Query = Query.ToString();
            List<Uri> uris = new List<Uri>();
            try
            {
                string countstr = WebClient.DownloadString(UriBuilder.Uri);
                int blockCount, blockLength = 500;
                Query["$top"] = blockLength.ToString();
                if (!(string.IsNullOrEmpty(countstr) | string.IsNullOrWhiteSpace(countstr)))
                {
                    if (int.TryParse(countstr, out int count))
                    {
                        blockCount = count / blockLength + 1;
                        for (int i = 1; i <= blockCount; i++)
                        {
                            Query["$skip"] = ((i - 1) * blockLength).ToString();
                            Logger.Log.Info(i);
                            UriBuilder.Path = Link + "/rows";
                            UriBuilder.Query = Query.ToString();
                            uris.Add(UriBuilder.Uri);
                        }
                    }
                }
                return uris;
            }
            catch (WebException)
            { return null; }
        }
        protected void LoadURIList(List<Uri> uris, Encoding encoding)
        {
            List<Task> Tasks = new List<Task>();
            foreach (Uri _uri in uris)
            {
                Action<Task, object> at = new Action<Task, object>((delegate (Task ff, object Parameters)
                    {
                        DownloadString((Uri)Parameters, encoding);
                    }));
                Action<object> a = new Action<object>((delegate (object Parameters)
                {
                    DownloadString((Uri)Parameters, encoding);
                }));


                if (Tasks.Count < 1)
                { Tasks.Add(new Task(a, _uri)); }
                else
                { Tasks.Add(Tasks[Tasks.Count - 1].ContinueWith(at, _uri)); }
            }

            Tasks[0].Start();
            Tasks[0].Wait();
        }
        delegate void loadURIList();
        protected Task LoadURIListTask(List<Uri> uris, Encoding encoding)
        {
            loadURIList t = (() => LoadURIList(uris, encoding));
            Action a = new Action(t);
            Task _task = new Task(a);
            return _task;
        }




    }
}


