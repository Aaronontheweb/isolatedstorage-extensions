using System;
using System.Net;
using System.Text;
using System.Windows;

namespace IsolatedStorageExtensions.Tests.Utils
{
    /// <summary>
    /// Generates random strings to use as test data for writing.
    /// </summary>
    public class RandomStringGenerator
    {
        /// <summary>
        /// Returns a random string of the specified size (ASCII characters only)
        /// </summary>
        /// <param name="size">The # of characters in the string</param>
        /// <returns>A random ASCII string with [size] characters</returns>
        public static string RandomString(int size)
        {
            var rand = new Random();
            //Using a stringbuilder here just in case there are a large number of append operations
            var sb = new StringBuilder(); 
            for(var i =0; i < size;i++)
            {
                var nchar = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rand.NextDouble() + 65)));
                sb.Append(nchar);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Removes unsafe characters from the 
        /// </summary>
        /// <param name="initialstr">An unescaped XML string</param>
        /// <returns>An escaped XML string</returns>
        public static string EscapeXmlString(string initialstr)
        {
            return initialstr.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;");

        }

        /// <summary>
        /// Returns a random XML string
        /// </summary>
        /// <param name="size">The size of the XML string in # of characters</param>
        /// <returns>A valid XML string.</returns>
        public static string RandomXmlString(int size)
        {
            return "<document><item>" + EscapeXmlString(RandomString(size)) + "</item></document>";
        }
    }
}
