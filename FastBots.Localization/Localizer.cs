using System;
using System.Collections.Generic;
using System.Text;

namespace FastBots.Localization
{
    public static class Localizer
    {
        public static string Localize(dynamic localizationDictionary, params object[] keys)
        {
            string result = null;
            Type[] arguments = localizationDictionary.GetType().GetGenericArguments();
            Type keyType = arguments[0];
            Type valueType = arguments[1];
            for (int i = 0; i < keys.Length; i++)
            {
                dynamic key = Convert.ChangeType(keys[i], keyType);
                if (valueType == typeof(string))
                {
                    result = localizationDictionary[key].ToString();
                    break;
                }
                else
                {
                    localizationDictionary = localizationDictionary[key];
                    arguments = localizationDictionary.GetType().GetGenericArguments();
                    keyType = arguments[0];
                    valueType = arguments[1];
                }
            }
            if (result == null)
            {
                throw new KeyNotFoundException();
            }
            return result;
        }
    }
}
