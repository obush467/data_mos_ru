using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using data_mos_ru.Entityes;

namespace data_mos_ru
{
    class geoPolyConverter_file : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(AO_JSON_file));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            /*JObject obj = JObject.Load(reader);
            AO_JSON_file ao = new AO_JSON_file();
            ao.ADRES = (string)obj["ADRES"];
            ao.DDOC = (string)obj["DDOC"];
            ao.DMT = (string)obj["DMT"]; 
            ao.DREG = (string)obj["DREG"]; 
            ao.global_id = (int)obj["global_id"];
            ao.KAD_KV = (int)obj["KAD_KV"];
            ao.KAD_RN = (int)obj["KAD_RN"];
            ao.KAD_ZU = (int)obj["KAD_ZU"];
            ao.KRT = (string)obj["KRT"]; 
            ao.NDOC = (string)obj["NDOC"];
            ao.NREG = (int)obj["NREG"];
            ao.SOOR = (string)obj["SOOR"];
            ao.STRT = (string)obj["STRT"]; 
            ao.system_object_id = (String)obj["system_object_id"];
            ao.TDOC = (string)obj["TDOC"]; 
            ao.UNOM = (int)obj["UNOM"];
            ao.VLD = (string)obj["VLD"];
            ao.VYVAD = (string)obj["VYVAD"];
            if (obj["geoData"] == null)  { ao.geoData = null; }
            else
            {
                ao.geoData = new geoData_JSON();
                ao.geoData.Type = obj["geoData"]["type"].ToString();
                ao.geoData.Coordinates = (DeserializePoly(obj, serializer));
            }
            return ao;*/
            return null;
        }

        private object DeserializePoly(JObject obj, JsonSerializer serializer)
        {
            if (obj.Properties().Where(p => p.Name.StartsWith("Cells")).Any())
            {
                if (obj.Properties().Where(p => p.Name.StartsWith("geoData")).Any())
                {
                    JProperty geoDataJSONprop = obj.Properties().Where(p => p.Name.StartsWith("geoData")).First();

                    JObject child = (JObject)geoDataJSONprop.Value;
                    JProperty geoDataJSON_type_prop = child.Properties().Where(p => p.Name.StartsWith("type")).First();
                    switch (geoDataJSON_type_prop.Value.ToString())
                    {
                        case "Polygon":
                            {
                                geoPolygon Poly = new geoPolygon();
                                foreach (var jo in child["coordinates"])
                                {
                                    geoDataBase p = new geoDataBase();
                                    foreach (var pp in jo)
                                    { p.Add(new geoPoint(pp[1].Value<double>(), pp[0].Value<double>())); }
                                    p.Reverse();
                                    Poly.Add(p);
                                }
                                return Poly;
                            }
                        case "MultiPolygon":
                            {
                                geoMPolygon MPoly = new geoMPolygon();
                                foreach (var jo in child["coordinates"])
                                {
                                    geoPolygon Poly = new geoPolygon();
                                    foreach (var mp in jo)
                                    {
                                        geoDataBase polygon = new geoDataBase();
                                        foreach (var pp in mp)
                                        { polygon.Add(new geoPoint(pp[1].Value<double>(), pp[0].Value<double>())); }
                                        polygon.Reverse();
                                        Poly.Add(polygon);
                                    }
                                    MPoly.Add(Poly);
                                }
                                return MPoly;
                            }
                        default: { throw new JsonSerializationException("Unrecognized type: geo"); }
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
