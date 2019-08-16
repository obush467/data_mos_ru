﻿using System.Collections.Generic;
using UNS.Models.Entities;

namespace data_mos_ru.Operators
{
    internal class PhoneItemComparer : IEqualityComparer<PhoneItem>
    {
        public bool Equals(PhoneItem x, PhoneItem y)
        {
            return (x != null && y != null && !string.IsNullOrEmpty(x.Phone) && !string.IsNullOrEmpty(y.Phone) && x.Phone==y.Phone) ? true : false;
        }

        public int GetHashCode(PhoneItem obj)
        {
            return 0;
        }
    }
}