using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace data_mos_ru.Entities
{
    [Table("UPRsites", Schema = "dom_mos_ru")]
    public class UPRsite
    {      
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }
        public virtual ICollection<InfTableRow> InfTableRows { get; set; } = new List<InfTableRow>();
        public virtual ICollection<HouseList> HouseLists { get; set; } = new List<HouseList>();

        public UPRsite(Guid id, string name,string uri,string html=null)
        {
            ID = id;
            Name = name;
            Uri = uri;
            if (html!=null ) DecodeUPR(html);
            foreach (HouseList houseList in HouseLists)
            {
                foreach (House house in houseList.Houses)
                { }
            }
        }

        public UPRsite()
        {
        }
        private void WebClient_DownloadDataCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            DecodeUPR(e.Result);
        }
        public async Task DownloadStringTask(Uri url, Encoding encoding)
        {
            WebClient client = new WebClient
            {
                Encoding = encoding
            };
            client.DownloadStringCompleted += WebClient_DownloadDataCompleted;
            await client.DownloadStringTaskAsync(url);
        }
        public void DecodeUPR(string html)
        {           
            HtmlDocument hap = new HtmlDocument();
            hap.LoadHtml(html);
            HtmlNode _content = hap.DocumentNode.SelectSingleNode("/html/body/div[@id='container']/div[@id='wrapper']/div[@id='page']/div[@class='inside inside-company-caption']");
            HtmlNode h1 = _content.SelectSingleNode("h1[@class='tClr1']");
            HtmlNode inf = _content.SelectSingleNode("div[@class='rndBrdBlock mrgT18 uk-inf']");
            HtmlNode table = inf.SelectSingleNode("table");
            HtmlNodeCollection tablerows = table.SelectNodes("tbody/tr");
            if (tablerows != null)
            {
                InfTableRows = new List<InfTableRow>();
                foreach (HtmlNode node in tablerows)
                {
                    InfTableRow _infTableRow = new InfTableRow();
                    HtmlNode td1 = node.SelectSingleNode("td[@class='td1']");
                    HtmlNode td2 = node.SelectSingleNode("td[@class='td2']");
                    if (td1 != null)
                        _infTableRow.Name = td1.InnerText;
                    if (td2 != null)
                        _infTableRow.Value = td2.InnerText;
                    InfTableRows.Add(_infTableRow);
                }
            }

            HtmlNodeCollection _houses = _content.SelectNodes("div[@class='rndBrdBlock mrgT18 uk-houses']");
            if (_houses != null)
            {
                foreach (HtmlNode _houselistnode in _houses)
                {
                    HouseList _houselist = new HouseList();
                    HtmlNode _housesTableH1 = _houselistnode.SelectSingleNode("h1");
                    if (_housesTableH1 != null && _housesTableH1.InnerText != null)
                        _houselist.Name = _housesTableH1.InnerText;
                    HtmlNodeCollection arefs = _houselistnode.SelectNodes("table//tr//td//a");
                    if (arefs != null)
                        foreach (HtmlNode _housenode in arefs)
                        {
                            House house = new House();
                            HtmlAttribute _href = _housenode.Attributes["href"];
                            if (_href != null && _href.Value != null)
                                house.Uri = new Uri(_href.Value, UriKind.Relative);
                            _houselist.Houses.Add(house);
                        }
                    HouseLists.Add(_houselist);

                }
            }
            //logger.Debug(upr.Url);
        }
    }
}
