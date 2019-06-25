using System;
using System.Net;

namespace data_mos_ru
{
    public class TimeoutedWebClient : WebClient
    {
        public int TimeOut { get; set; } = 100000;
        public TimeoutedWebClient(int timeout = 1000) : base()
        { TimeOut = timeout; }
        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest w = base.GetWebRequest(uri);
            w.Timeout = TimeOut;
            return w;
        }
    }
}
