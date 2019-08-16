using System.Collections.Generic;
using UNS.Models.Entities;

namespace data_mos_ru.Operators
{
    internal class OwnerRawAddressComparer : IEqualityComparer<OwnerRawAddress>
    {
        public bool Equals(OwnerRawAddress x, OwnerRawAddress y)
        {
            return (x != null 
                && y != null 
                //&& x.Organization==y.Organization
                && x.Address==y.Address
                && x.TypeOwner == y.TypeOwner) ? true : false;
        }

        public int GetHashCode(OwnerRawAddress obj)
        {
            return 0;
        }
    }
}