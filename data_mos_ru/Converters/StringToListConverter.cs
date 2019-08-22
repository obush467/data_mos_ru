using data_mos_ru.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace data_mos_ru
{
    public class StringToListConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<string>));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken obj = JToken.Load(reader);
            if (objectType == typeof(List<string>))
                return string.Join("@@@", (obj.Values().ToList())).Trim();
            else return obj.Value<string>();

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

    public class StringToListConverter1 : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(PublicPhoneItem));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken obj = JToken.Load(reader);
            if (objectType == typeof(PublicPhoneItem) && obj.Values() != null && obj.Values().Count() > 0)
            {
                return new PublicPhoneItem() { PublicPhone = string.Join("; ", obj.Values()) };
            }
            else return obj.Value<PublicPhoneItem>();

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

    public class StringToListConverter2 : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(FaxItem));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken obj = JToken.Load(reader);
            if (objectType == typeof(FaxItem))
                return new FaxItem() { Fax = string.Join("; ", (obj.Values().ToList())).Trim() };
            else return obj.Value<string>();

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
    public class StringToListConverter3 : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(EmailItem));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken obj = JToken.Load(reader);
            if (objectType == typeof(EmailItem))
                return new EmailItem() { Email = string.Join("; ", (obj.Values().ToList())).Trim() };
            else return obj.Value<string>();

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

    public class StringToListConverter4 : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(ChiefPhoneItem));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken obj = JToken.Load(reader);
            if (objectType == typeof(ChiefPhoneItem))
                return new ChiefPhoneItem() { ChiefPhone = string.Join("; ", (obj.Values().ToList())).Trim() };
            else return obj.Value<string>();

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
