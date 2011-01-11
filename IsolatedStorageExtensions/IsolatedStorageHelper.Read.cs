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

namespace IsolatedStorageExtensions
{
    public static partial class IsolatedStorageHelper
    {

        #region Exists Overloads

        public static bool FileExists(string filepath)
        {
            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                return FileExists(filepath, storage);
            }
        }

        public static bool FileExists(string filepath, IsolatedStorageFile storage)
        {
            return storage.FileExists(filepath);
        }

        #endregion

        #region Stream methods

        public static Stream GetFileStream(string filepath, IsolatedStorageFile storage)
        {
            if (FileExists(filepath, storage))
            {
                using (var stream = new IsolatedStorageFileStream(filepath, FileMode.Open, FileAccess.Read, storage))
                {
                    return stream;
                }
            }

            return null;
        }

        public static Stream GetFileStream(string filepath)
        {
            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                return GetFileStream(filepath, storage);
            }
        }

        #endregion

        #region Text methods

        public static string GetFileText(string filepath)
        {
            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                return GetFileText(filepath, storage);
            }
        }

        #endregion
    }
}
