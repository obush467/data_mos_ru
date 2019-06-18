using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace data_mos_ru
{
    public class HttpQueryNameValueCollection:NameValueCollection
    {
        private ParallelLoopResult _parallelLoopResult;

        public override string ToString()
        {
            List<string> result;
            result = new List<string>();
            _parallelLoopResult = Parallel.ForEach(AllKeys, p =>
            { if (BaseGet(p) != null)
                result.Add(p + "=" + Get(p));
            });
            return string.Join("&", result);
        }
    }
}
