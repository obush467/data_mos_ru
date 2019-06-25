using System;

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
        public DateTime? VersionDate { get; set; }
        public int ItemsCount { get; set; }
    }
}
