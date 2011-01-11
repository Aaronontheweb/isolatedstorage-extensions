using System;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;

namespace IsolatedStorageExtensions
{
    public static partial class IsolatedStorageHelper
    {
        private const string DirectorySeparatorConstant = "\\";

        #region Write methods

        public static void MakeFile(byte[] data, string filepath, IsolatedStorageFile storage)
        {
            CreateDirectoryTree(filepath, storage);

            using (var filestream = new IsolatedStorageFileStream(filepath, FileMode.Create, FileAccess.Write, storage))
            {
                filestream.Write(data, 0, data.Count());
            }
        }

        #endregion

        #region Read methods

        public static string GetFileText(string filepath, IsolatedStorageFile storage)
        {
            if (FileExists(filepath, storage))
            {
                var stream = GetFileStream(filepath, storage);

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }

            return string.Empty;
        }

        #endregion

    }
}
