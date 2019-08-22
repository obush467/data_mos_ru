using UNS.Models.Entities;

namespace data_mos_ru.Mappers
{
    public static class OrganizationExtensions
    {
        public static void Merge(this Organization destination, Organization source)
        {
            if (destination != null && source != null)
            {
                if (source.INN != null && destination.INN == null) destination.INN = source.INN;
                if (destination.ShortName == null && source.ShortName != null) destination.ShortName = source.ShortName;
                if (destination.FullName == null && source.FullName != null) destination.FullName = source.FullName;
                if (destination.INN == null && source.INN != null) destination.INN = source.INN;
                if (destination.INN == null && source.INN != null) destination.INN = source.INN;
                if (destination.INN == null && source.INN != null) destination.INN = source.INN;
                if (destination.INN == null && source.INN != null) destination.INN = source.INN;
                if (destination.INN == null && source.INN != null) destination.INN = source.INN;
                if (destination.INN == null && source.INN != null) destination.INN = source.INN;
                if (destination.INN == null && source.INN != null) destination.INN = source.INN;
                if (destination.INN == null && source.INN != null) destination.INN = source.INN;
                if (destination.INN == null && source.INN != null) destination.INN = source.INN;
                if (destination.INN == null && source.INN != null) destination.INN = source.INN;
                if (destination.INN == null && source.INN != null) destination.INN = source.INN;
                if (destination.INN == null && source.INN != null) destination.INN = source.INN;
                if (destination.INN == null && source.INN != null) destination.INN = source.INN;
                if (destination.INN == null && source.INN != null) destination.INN = source.INN;
                if (destination.INN == null && source.INN != null) destination.INN = source.INN;


            }
        }
    }
}
