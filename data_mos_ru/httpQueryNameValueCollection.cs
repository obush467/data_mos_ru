using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_mos_ru
{
    class httpQueryNameValueCollection:NameValueCollection
    {
        public override string ToString()
        {
            List<string> Result = new List<string>();
            Parallel.ForEach(AllKeys, p =>
            { if (BaseGet(p) != null)
                    Result.Add(p + "=" + Get(p));
            });
            return string.Join("&", Result);
        }
    }
}
