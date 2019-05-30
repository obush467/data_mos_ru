using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using data_mos_ru.Entityes;
using System.Data.Entity.Spatial;
using Microsoft.SqlServer.Types;

namespace data_mos_ru
{
    class geoDataConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(geoData));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            geoData geo = new geoData();
            if (obj.Properties().Where(p => p.Name.StartsWith("center")).Any())
            {
                geo.Сenter = ((JArray)obj["center"]).ToString();
            }
            if (obj.Properties().Where(p => p.Name.StartsWith("type")).Any())
            {
                geo.Type = (string)obj["type"];
                switch (geo.Type)
                {
                    case "Polygon":
                        {
                            geo.Coordinates = (DbGeography)DeserializePolygon(obj, serializer);
                            break;
                        }
                    case "MultiPolygon":
                        {
                            geo.Coordinates = (DbGeography)DeserializeMPolygon(obj, serializer);
                            break;
                        }
                    default: { throw new JsonSerializationException("Unrecognized type: geo"); }
                };
            }
            //if (geo.Type != null || geo.Coordinates != null || geo.Сenter !=null)
            return geo;
            //else { return null; }
        }
        private object DeserializePolygon(JObject obj, JsonSerializer serializer)
        {
            JProperty coordinates = obj.Properties().Where(p => p.Name.StartsWith("coordinates")).First();
            geoPolygon Poly = new geoPolygon((JArray)coordinates.Value);
            return Poly.dbGeography(4326);
        }
        private object DeserializeMPolygon(JObject obj, JsonSerializer serializer)
        {
            JProperty coordinates = obj.Properties().Where(p => p.Name.StartsWith("coordinates")).First();
            geoMPolygon MPoly = new geoMPolygon((JArray)coordinates.Value);
            return MPoly.dbGeography(4326);
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
