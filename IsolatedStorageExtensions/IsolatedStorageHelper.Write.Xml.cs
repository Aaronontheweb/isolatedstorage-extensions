using System;
using System.IO;
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
        /// <summary>
        /// Serialize an object to a given file in IsolatedStorage
        /// </summary>
        /// <typeparam name="T">a Type that can be serialized.</typeparam>
        /// <param name="data">An object to be serialized.</param>
        /// <param name="filepath">The file where the serialized object will be stored.</param>
        /// <param name="serializer">An XML serializer</param>
        /// <param name="storage">A reference to a valid IsolatedStorageFile instance.</param>
        public static void MakeFile<T>(T data, string filepath, XmlSerializer serializer, IsolatedStorageFile storage)
        {
            //Create directores if there are any missing
            CreateDirectoryTree(filepath, storage);

            using (var stream = new IsolatedStorageFileStream(filepath, FileMode.CreateNew, FileAccess.Write, storage))
            {
                serializer.Serialize(stream, data);
                stream.Close();
            }
        }

        /// <summary>
        /// Serialize an object to a given file in IsolatedStorage
        /// </summary>
        /// <typeparam name="T">a Type that can be serialized.</typeparam>
        /// <param name="data">An object to be serialized.</param>
        /// <param name="filepath">The file where the serialized object will be stored.</param>
        /// <param name="serializer">An XML serializer</param>
        public static void MakeFile<T>(T data, string filepath, XmlSerializer serializer)
        {
            using (var storage = GetStore())
            {
                MakeFile(data, filepath, serializer, storage);
            }
        }
    }
}
