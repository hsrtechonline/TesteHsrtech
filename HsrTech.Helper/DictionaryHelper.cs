using System;
using System.Collections.Generic;
using System.Globalization;

namespace HsrTech.Helper
{
    public static class DictionaryHelper
    {
        public static string ValueAsString(this Dictionary<string, object> dic, string key)
        {
            object valor = null;
            return dic.TryGetValue(key, out valor) ? valor.ToString() : string.Empty;
        }

        public static DateTime? ValueAsDateTimeNullable(this Dictionary<string, object> dic, string key)
        {
            DateTime data = DateTime.MinValue;
            DateTime? dataNullable = null;

            if (!string.IsNullOrEmpty(dic.ValueAsString(key)))
                DateTime.TryParse(dic.ValueAsString(key), out data);

            if (data != DateTime.MinValue)
                dataNullable = data;

            return dataNullable;
        }

        public static decimal ValueAsDecimal(this Dictionary<string, object> dic, string key)
        {
            object valor = null;
            if (dic.TryGetValue(key, out valor))
            {
                try
                {
                    return Convert.ToDecimal(valor, CultureInfo.CurrentCulture);
                }
                catch (Exception ex)
                {
                    throw new InvalidCastException($"valor não suportado: {valor}", ex);
                }

            }
            else
            {
                throw new InvalidCastException($"valor não suportado: {valor}");
            }
        }
    }
}
