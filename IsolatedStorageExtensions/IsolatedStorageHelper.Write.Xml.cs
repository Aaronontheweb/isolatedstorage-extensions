using System;
using System.IO.IsolatedStorage;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace IsolatedStorageExtensions
{
    public static partial class IsolatedStorageHelper
    {
        public static void MakeFile<T>(T data, string filepath, XmlSerializer serializer, IsolatedStorageFile storage)
        {
            
        }

        public static void MakeFile<T>(T data, string filepath, XmlSerializer serialzer)
        {
            using(var storage = GetStore())
            {
                MakeFile(data, filepath, serialzer, storage);
            }
        }
    }
}
