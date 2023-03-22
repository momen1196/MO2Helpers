using System;

namespace MO2Helpers
{
    public static class Strings
    {
        public static string Base64Encode(
            this string plainText) =>
            Convert.ToBase64String(
                System.Text.Encoding.UTF8.GetBytes(plainText));

        public static string Base64Decode(
            this string base64EncodedData) =>
            System.Text.Encoding.UTF8.GetString(
                Convert.FromBase64String(base64EncodedData));

        public static string Remove(
            this string value,
            string removeValue) =>
            value.Replace(removeValue, "");
    }

}
