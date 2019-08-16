using System.Collections.Generic;
using UNS.Models.Entities;

namespace data_mos_ru.Comparers
{
    internal class PersonPositionComparer : IEqualityComparer<PersonPosition>
    {
        public bool Equals(PersonPosition x, PersonPosition y)
        {
            return (x != null 
                && y != null 
                && x.PositionType==y.PositionType
                && x.Human.Family== y.Human.Family
                && x.Human.Name == y.Human.Name
                && x.Human.Patronymic == y.Human.Patronymic) 
                ? true : false;
        }

        public int GetHashCode(PersonPosition obj)
        {
            return 0;
        }
    }
}