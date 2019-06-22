using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_mos_ru.Entities
{
    /// <summary>
    /// Описание наборов данных data_mos_ru
    /// </summary>
    class datasetMeta
    {
        public int Id { get; set; }
        public string IdentificationNumber { get; set; }
        public int CategoryId { get; set; }
        public string CategoryCaption { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentCaption { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string FullDescription { get; set; }
        public string Keywords { get; set; }
        public bool ContainsGeodata { get; set; }
        public string VersionNumber { get; set; }
        public Nullable<DateTime> VersionDate { get; set; }
        public int ItemsCount { get; set; }
    }
}
