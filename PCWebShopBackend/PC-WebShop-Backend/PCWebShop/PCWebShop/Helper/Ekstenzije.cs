﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PCWebShop.Helper
{
    public static class Ekstenzije
    {
        public static string ToBase64(this byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        public static byte[] parseBase64(this string base64)
        {
            base64 = base64.Split(',')[1];
            return System.Convert.FromBase64String(base64);
        }

        public static string RemoveTags(this string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

        public static List<T> GetRandomElements<T>(this IEnumerable<T> list, int elementsCount)
        {
            return list.OrderBy(arg => Guid.NewGuid()).Take(elementsCount).ToList();
        }
    }
}
