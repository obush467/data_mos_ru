using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UNS.Models.Entities;

namespace data_mos_ru.Loaders
{
    public class Rospt_ru_Loader : Loader
    {


        public OwnerRawAddress DecodePostOffice(HtmlDocument html)
        {
            var result = new OwnerRawAddress() { /*Organization_ID = Guid.Parse("9fe00de6-fa0d-48d0-9f17-abfae9e601ad")*/ };
            HtmlNode address = html.DocumentNode.SelectSingleNode("//span[@class='adr']/b[@class='locality street-address']");
            HtmlNode contacts = html.DocumentNode.SelectSingleNode("//span[@class='tel']/b");
            if (address != null) result.Address = address.InnerText.Trim();
            if (contacts != null) result.Contacts = contacts.InnerText.Trim();
            return result;
        }

        public OwnerRawAddress Load(Stream html)
        {
            return DecodePostOffice(LoadHtmlDocument(html));
        }

        public OwnerRawAddress Load(Stream html, Encoding encoding)
        {
            return DecodePostOffice(LoadHtmlDocument(html, encoding));
        }

        public OwnerRawAddress Load(Stream html, bool detectEncoding)
        {
            return DecodePostOffice(LoadHtmlDocument(html, detectEncoding));
        }

        public OwnerRawAddress Load(Stream html, Encoding encoding, bool detectEncoding)
        {
            return DecodePostOffice(LoadHtmlDocument(html, encoding, detectEncoding));
        }

        public OwnerRawAddress Load(Stream html, Encoding encoding, bool detectEncoding, int buffersize)
        {
            return DecodePostOffice(LoadHtmlDocument(html, encoding, detectEncoding, buffersize));
        }

        public IEnumerable<OwnerRawAddress> Load(IEnumerable<FileInfo> files)
        {
            return files.Select(i => Load(i.OpenRead()));
        }
        public IEnumerable<OwnerRawAddress> Load(IEnumerable<FileInfo> files, Encoding encoding)
        {
            return files.Select(i => Load(i.OpenRead(), encoding));
        }
        public IEnumerable<OwnerRawAddress> Load(IEnumerable<FileInfo> files, bool detectEncoding)
        {
            return files.Select(i => Load(i.OpenRead(), detectEncoding));
        }
        public IEnumerable<OwnerRawAddress> Load(IEnumerable<FileInfo> files, Encoding encoding, bool detectEncoding)
        {
            return files.Select(i => Load(i.OpenRead(), encoding, detectEncoding));
        }

        public IEnumerable<OwnerRawAddress> Load(IEnumerable<FileInfo> files, Encoding encoding, bool detectEncoding, int buffersize)
        {
            return files.Select(i => Load(i.OpenRead(), encoding, detectEncoding, buffersize));
        }


    }
}
