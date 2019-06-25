using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace data_mos_ru.Entities
{
    [Table("Houses", Schema = "dom_mos_ru")]
    public class House
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ID { get; set; }
        [MaxLength(100)]
        public string UriString { get; set; }
        [NotMapped]
        public Uri Uri
        {
            get
            {
                if (UriString == null)
                    return null;
                else
                {
                    return new Uri(UriString);
                }
            }
            set { UriString = value.ToString(); }
        }

        [MaxLength(100)]
        public string UPRUriString { get; set; }
        [NotMapped]
        public Uri UPRUri
        {
            get
            {
                if (UPRUriString == null)
                    return null;
                else
                {
                    return new Uri(UPRUriString);
                }
            }
            set { UPRUriString = value.ToString(); }
        }
        public string Address { get; set; }
        public string AdmArea { get; set; }
        public int? YearOfConstruction { get; set; }
        public string Series { get; set; }
        public int? StoreysCount { get; set; }
        public string TotalArea { get; set; }
        public string TotalAreaResidentialPremises { get; set; }
        [ForeignKey("HouseList")]
        public Guid HouseList_ID { get; set; }
        public HouseList HouseList { get; set; }


        //Logger.Log.Debug(upr.Url);

    }
}
