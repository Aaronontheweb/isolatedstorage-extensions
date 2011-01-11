using System;
using System.IO.IsolatedStorage;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace IsolatedStorageExtensions
{
    public static partial class IsolatedStorageHelper
    {
        public static void MakeFile(byte[] data, string filepath)
        {
            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                MakeFile(data, filepath, storage);
            }
        }

        public static void MakeFile(string textdata, string filepath)
        {
            var data = Encoding.UTF8.GetBytes(textdata);
            MakeFile(data, filepath);
        }

        public static void MakeFile(string textdata, string filepath, IsolatedStorageFile storage)
        {
            var data = Encoding.UTF8.GetBytes(filepath);
            MakeFile(data, filepath, storage);
        }
    }
}
