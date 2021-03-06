﻿using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace data_mos_ru.Loaders
{
    public class Loader
    {
        public UriBuilder UriBuilder = new UriBuilder();
        public TimeoutedWebClient WebClient = new TimeoutedWebClient();
        public ConcurrentQueue<String> Result = new ConcurrentQueue<String>();
        public Loader()
        {
            UriBuilder.Scheme = "https";
        }

        public void Deserialize<T>(IEnumerable<FileInfo> Files, Encoding encoding)
        {
            foreach (FileInfo file in Files)
            { Deserialize<T>(file, encoding); }
        }
        public List<T> Deserialize<T>(FileInfo file, Encoding encoding)
        {
            if (file.Exists) return Deserialize<T>(file.OpenRead(), encoding);
            else return null;
        }

        public List<T> Deserialize<T>(Stream stream, Encoding encoding)
        {
            //Logger.Log.Debug(string.Join(" ", "Запущено преобразование", typeof(T).Name));
            JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.Converters.Add(new GeoDataConverter());
            //jss.Converters.Add(new StringToListConverter());
            jss.Converters.Add(new StringToListConverter1());
            jss.Converters.Add(new StringToListConverter2());
            jss.Converters.Add(new StringToListConverter3());
            jss.Converters.Add(new StringToListConverter4());
            jss.Culture = CultureInfo.CurrentCulture;
            Logger.Logger.Debug(string.Join(" ", "Преобразовано", typeof(T).Name));
            return JsonConvert.DeserializeObject<T[]>((new StreamReader(stream, encoding)).ReadToEnd(), jss).ToList();
        }
        public List<List<T>> Convert<T>(string fileName, Encoding encoding)
        {
            int counter = 0;
            int counterLength = 200;
            return Deserialize<T>(new FileInfo(fileName), encoding).GroupBy(_ => counter++ / counterLength).Distinct().Select(v => v.ToList()).ToList();
        }
        protected string DownloadString(Uri uri, Encoding encoding, HttpQueryNameValueCollection parameters = null)
        {
            using (TimeoutedWebClient client = new TimeoutedWebClient(1000000)
            {
                Encoding = encoding,
            })
            {
                if (parameters != null) client.QueryString.Add(parameters);
                return client.DownloadString(uri);
            }
        }

        protected async Task<string> DownloadStringAsync(Uri uri, Encoding encoding, HttpQueryNameValueCollection parameters = null)
        {
            using (TimeoutedWebClient client = new TimeoutedWebClient(1000000)
            {
                Encoding = encoding,
            })
            {
                if (parameters != null) client.QueryString.Add(parameters);
                return await client.DownloadStringTaskAsync(uri);
            }
        }

        public Task DownloadStringTask(Uri url, Encoding encoding)
        {
            WebClient client = new WebClient
            {
                Encoding = encoding
            };
            client.DownloadStringCompleted += WebClient_DownloadDataCompleted;
            return client.DownloadStringTaskAsync(url);
        }
        protected void DownloadString(Uri uri, Encoding encoding)
        {
            WebClient client = new WebClient
            {
                Encoding = encoding
            };
            Result.Enqueue(client.DownloadString(uri));
        }
        private void WebClient_DownloadDataCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e != null)
            {
                try
                {
                    Result.Enqueue(e.Result);
                    Logger.Logger.Info("Блок считан" + e.UserState.ToString());
                }
                catch (Exception)
                { }
            }
        }

        public HtmlDocument LoadHtmlDocument1(string html)
        {
            HtmlDocument hap = new HtmlDocument();
            hap.LoadHtml(html);
            return hap;
        }
        public HtmlDocument LoadHtmlDocument(Stream html)
        {
            HtmlDocument hap = new HtmlDocument();
            hap.Load(html);
            return hap;
        }

        public HtmlDocument LoadHtmlDocument(Stream html, Encoding encoding)
        {
            HtmlDocument hap = new HtmlDocument();
            hap.Load(html, encoding);
            return hap;
        }

        public HtmlDocument LoadHtmlDocument(Stream html, bool detectEncoding)
        {
            HtmlDocument hap = new HtmlDocument();
            hap.Load(html, Encoding.GetEncoding(1251));
            return hap;
        }

        public HtmlDocument LoadHtmlDocument(TextReader html)
        {
            HtmlDocument hap = new HtmlDocument();
            hap.Load(html);
            return hap;
        }

        public HtmlDocument LoadHtmlDocument(Stream html, Encoding encoding, bool detectEncoding)
        {
            HtmlDocument hap = new HtmlDocument();
            hap.Load(html, encoding, detectEncoding);
            return hap;
        }

        public HtmlDocument LoadHtmlDocument(Stream html, Encoding encoding, bool detectEncoding, int buffersize)
        {
            HtmlDocument hap = new HtmlDocument();
            hap.Load(html, encoding, detectEncoding, buffersize);
            return hap;
        }
    }
}
