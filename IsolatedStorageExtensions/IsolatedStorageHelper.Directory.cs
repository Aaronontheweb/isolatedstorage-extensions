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

namespace IsolatedStorageExtensions
{
    public static partial class IsolatedStorageHelper
    {
        #region Directory creation methods

        public static void CreateDirectoryTree(string filepath)
        {
            using (var storage = GetStore())
            {
                CreateDirectoryTree(filepath, storage);
            }
        }

        public static void CreateDirectoryTree(string filepath, IsolatedStorageFile storage)
        {
            if (!filepath.Contains(DirectorySeparatorConstant)) return;

            var directory = GetDirectoryPath(filepath);

            if (!storage.DirectoryExists(directory))
                storage.CreateDirectory(directory);
        }

        public static string GetDirectoryPath(string filepath)
        {
            if (!filepath.Contains(DirectorySeparatorConstant)) return string.Empty;

            var directoryPos = filepath.LastIndexOf(DirectorySeparatorConstant);
            return filepath.Substring(0, directoryPos);
        }

        #endregion
    }
}
