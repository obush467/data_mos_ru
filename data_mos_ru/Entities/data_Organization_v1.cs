using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_mos_ru.Entities
{

    public class data_Organization_v1
    {
    /// <summary>
    /// 
    /// </summary>
    public int global_id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Category { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<string> Services { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string FullName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string ShortName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string CommonName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<OrgInfoItem> OrgInfo { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<ObjectAddressItem> ObjectAddress { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string ChiefName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string ChiefPosition { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<ChiefPhoneItem> ChiefPhone { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<PublicPhoneItem> PublicPhone { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<string> Fax { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<EmailItem> Email { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<WorkingHoursItem> WorkingHours { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public GeoData geoData { get; set; }
}
}
