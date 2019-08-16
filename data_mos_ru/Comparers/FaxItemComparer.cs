using System.Collections.Generic;
using UNS.Models.Entities;

namespace data_mos_ru.Operators
{
    internal class FaxItemComparer : IEqualityComparer<FaxItem>
    {
        public bool Equals(FaxItem x, FaxItem y)
        {
            return (x != null && y != null && !string.IsNullOrEmpty(x.Fax) && !string.IsNullOrEmpty(y.Fax) && x.Fax == y.Fax) ? true : false;
        }

        public int GetHashCode(FaxItem obj)
        {
            return 0;
        }
    }
}