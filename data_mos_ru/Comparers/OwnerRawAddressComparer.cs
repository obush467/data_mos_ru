using System.Collections.Generic;
using UNS.Models.Entities;

namespace data_mos_ru.Comparers
{
    internal class OwnerRawAddressComparer : IEqualityComparer<OwnerRawAddress>
    {
        public bool Equals(OwnerRawAddress x, OwnerRawAddress y)
        {
            return (x != null
                && y != null
                && x.Organization == y.Organization
                && x.Address.ToLower().Trim() == y.Address.ToLower().Trim()
                && x.TypeOwner.ToLower().Trim() == y.TypeOwner.ToLower().Trim()) ? true : false;
        }

        public int GetHashCode(OwnerRawAddress obj)
        {
            return 0;
        }
    }
}