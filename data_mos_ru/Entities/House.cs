using HtmlAgilityPack;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace data_mos_ru.Entities
{
    [Table("Houses", Schema = "dom_mos_ru")]
    public class House
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [MaxLength(100)]
        public string UriString { get; set; }
        [NotMapped]
        public Uri Uri { get { return new Uri(UriString); } set { UriString = value.ToString(); } }
        public string Address { get; set; }
        public string AdmArea { get; set; }
        public int? YearOfConstruction { get; set; }
        public string Series { get; set; }
        public int? StoreysCount { get; set; }
        public string TotalArea  {get; set; }
        public string TotalAreaResidentialPremises { get; set; }

        public void DecodeUPR(string html)
        {
            HtmlDocument hap = new HtmlDocument();
            hap.LoadHtml(html);
            HtmlNode _content = hap.DocumentNode.SelectSingleNode("/html/body/div[@id='container']/div[@id='wrapper']/div[@id='page']/div[@id='content']");
            HtmlNode _h1_Address = _content.SelectSingleNode("div/div/h1[@class='tClr1']");
            if (_h1_Address != null) Address = _h1_Address.InnerText;
            HtmlNode _h2_AdmArea = _content.SelectSingleNode("div/div/h2[@class='tClr2']");
            if (_h2_AdmArea != null) AdmArea = _h2_AdmArea.InnerText;
            HtmlNode _table = _content.SelectSingleNode("div/div/div/div/table[@class='infoCompanyTable']");
            if (_table != null)
            {
                HtmlNode _tablerowYearOfConstruction = _table.SelectSingleNode("tbody/tr/td[text()='Год постройки:']").ParentNode.SelectNodes("td")[1];
                if (_tablerowYearOfConstruction != null && !string.IsNullOrEmpty(_tablerowYearOfConstruction.InnerText.Trim())) YearOfConstruction = int.Parse(_tablerowYearOfConstruction.InnerText);
                HtmlNode _tablerowSeries = _table.SelectSingleNode("tbody/tr/td[text()='Серия']").ParentNode.SelectNodes("td")[1];
                if (_tablerowSeries != null) Series = _tablerowSeries.InnerText;
                HtmlNode _tablerowStoreysCount = _table.SelectSingleNode("tbody/tr/td[text()='Этажность:']").ParentNode.SelectNodes("td")[1];
                if (_tablerowStoreysCount != null) StoreysCount = int.Parse(_tablerowStoreysCount.InnerText);
                HtmlNode _tablerowTotalArea = _table.SelectSingleNode("tbody/tr/td[text()='Этажность:']").ParentNode.SelectNodes("td")[1];
                if (_tablerowTotalArea != null) TotalArea = _tablerowTotalArea.InnerText;
                HtmlNode _tablerowotalAreaResidentialPremises = _table.SelectSingleNode("tbody/tr/td[text()='Общая площадь жилых помещений:']").ParentNode.SelectNodes("td")[1];
                if (_tablerowotalAreaResidentialPremises != null) TotalAreaResidentialPremises = _tablerowotalAreaResidentialPremises.InnerText;
            }

        }
                    //Logger.Log.Debug(upr.Url);
        
}
}
