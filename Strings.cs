using System;

namespace MO2Helpers
{
    /// <summary>
    /// Add support methods to a string.
    /// </summary>
    public static class Strings
    {
        /// <summary>
        /// Encode input string to Base64 encode.
        /// </summary>
        /// <param name="plainText">The input string to be converted</param>
        /// <returns>Base64 string encode.</returns>
        public static string Base64Encode(
            this string plainText) =>
            Convert.ToBase64String(
                System.Text.Encoding.UTF8.GetBytes(plainText));

        /// <summary>
        /// Decode input Base64 string back to original string.
        /// </summary>
        /// <param name="base64EncodedData"></param>
        /// <returns>Decoded(original) string.</returns>
        public static string Base64Decode(
            this string base64EncodedData) =>
            System.Text.Encoding.UTF8.GetString(
                Convert.FromBase64String(base64EncodedData));

        /// <summary>
        /// Remove a specified character from a string.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="removeValue"></param>
        /// <returns>A string after removing a character.</returns>
        public static string Remove(
            this string value,
            string removeValue) =>
            value.Replace(removeValue, "");
    }
}
