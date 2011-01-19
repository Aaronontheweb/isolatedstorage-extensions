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
using System.Xml;
using System.Xml.Serialization;

namespace IsolatedStorageExtensions
{
    public static partial class IsolatedStorageHelper
    {
        public static T GetFile<T>(string filepath, XmlSerializer serializer)
        {
            using (var storage = GetStore())
            {
                return GetFile<T>(filepath, serializer, storage);
            }
        }

        public static T GetFile<T>(string filepath, XmlSerializer serializer, IsolatedStorageFile storage)
        {
            if (FileExists(filepath, storage))
            {
                var stream = ReadFileStream(filepath, storage);
                using (var reader = XmlReader.Create(stream))
                {
                    return (T)serializer.Deserialize(reader);
                }
            }

            return default(T);
        }
    }
}
