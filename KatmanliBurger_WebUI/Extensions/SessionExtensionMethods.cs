﻿using Newtonsoft.Json;

namespace KatmanliBurger_WebUI.Extensions
{
    public static class SessionExtensionMethods
    {
        public static void SetObject(this ISession session, string key, object value)  //key i sepet, value yu sepet datası olarak düşünebiliriz
        {
            string objectString = JsonConvert.SerializeObject(value); //objeyi string formata çeviriyoruz
            session.SetString(key, objectString);
        }

        public static T GetObject<T>(this ISession session, string key) where T : class
        {
            string objectString = session.GetString(key);
            if (string.IsNullOrEmpty(objectString))
            {
                return null;
            }
            else
            {
                T value = JsonConvert.DeserializeObject<T>(objectString);
                return value;
            }
        }
    }
}
