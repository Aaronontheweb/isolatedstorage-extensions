using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Net;
using System.Text;
using System.Linq;
using System.Windows.Shapes;

namespace IsolatedStorageExtensions
{
    public static partial class IsolatedStorageHelper
    {
        public static void MakeFile(byte[] data, string filepath, IsolatedStorageFile storage)
        {
            CreateDirectoryTree(filepath, storage);

            using (var filestream = new IsolatedStorageFileStream(filepath, FileMode.Create, FileAccess.Write, storage))
            {
                filestream.Write(data, 0, data.Count());
            }
        }

        public static void MakeFile(byte[] data, string filepath)
        {
            using (var storage = GetStore())
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
