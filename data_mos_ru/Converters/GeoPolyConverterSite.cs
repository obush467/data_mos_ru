using data_mos_ru.Entities;
using NetTopologySuite.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace data_mos_ru
{
    class GeoPolyConverterSite : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        { return (objectType == typeof(AO_JSON_site)); }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            GeoJsonReader geoReadert = new GeoJsonReader();
            JObject obj = JObject.Load(reader);
            AO_JSON_site ao = new AO_JSON_site();
            ao.Cells = new AO_JSON_Cells();
            ao.Cells.ADRES = (string)obj["Cells"]["ADRES"];
            ao.Cells.DDOC = (string)obj["Cells"]["DDOC"];
            ao.Cells.DMT = (string)obj["Cells"]["DMT"];
            ao.Cells.DREG = (string)obj["Cells"]["DREG"];
            ao.Cells.global_id = (int)obj["global_id"];
            ao.Cells.KAD_KV = (int)obj["Cells"]["KAD_KV"];
            ao.Cells.KAD_RN = (int)obj["Cells"]["KAD_RN"];
            ao.Cells.KAD_ZU = (int)obj["Cells"]["KAD_ZU"];
            ao.Cells.KRT = (string)obj["Cells"]["KRT"];
            ao.Cells.NDOC = (string)obj["Cells"]["NDOC"];
            ao.Cells.NREG = (int)obj["Cells"]["NREG"];
            ao.Cells.SOOR = (string)obj["Cells"]["SOOR"];
            ao.Cells.STRT = (string)obj["Cells"]["STRT"];
            ao.Cells.system_object_id = (String)obj["Cells"]["system_object_id"];
            ao.Cells.TDOC = (string)obj["Cells"]["TDOC"];
            ao.Cells.UNOM = (int)obj["Cells"]["UNOM"];
            ao.Cells.VLD = (string)obj["Cells"]["VLD"];
            ao.Cells.VYVAD = (string)obj["Cells"]["VYVAD"];
            if (obj["Cells"]["geoData"] == null) { ao.Cells.geoData = null; }
            else
            {
                ao.Cells.geoData = geoReadert.Read<NetTopologySuite.Geometries.Geometry>(obj["Cells"]["geoData"].ToString());
            }
            return ao;
        }

        public override bool CanWrite
        { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
