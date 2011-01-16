using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace IsolatedStorageExtensions.Tests.Utils
{
    public class RandomStringGenerator
    {
        public static string RandomString(int size)
        {
            var rand = new Random();
            var result = string.Empty;
            for(var i =0; i < size;i++)
            {
                var nchar = Convert.ToChar(rand.Next(1, 255));
                result += nchar;
            }

            return result;
        }
    }
}
