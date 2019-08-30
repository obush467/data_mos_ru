using System.Collections.Generic;
using System.Data.Entity;

namespace data_mos_ru.Converters
{
    public interface IMapConverter<S,D>
    {
        List<D> Convert(IEnumerable<S> list);
    }
}