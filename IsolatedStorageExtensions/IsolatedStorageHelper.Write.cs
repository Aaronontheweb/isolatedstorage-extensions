using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Net;
using System.Text;
using System.Linq;
using System.Windows.Shapes;

namespace IsolatedStorageExtensions
{
    /* IsolatedStorageHelper.Write - used for basic file write operations in IsolatedStorage.
     * 
     * Contributors: Aaron Stannard (http://www.aaronstannard.com/), 1/11/2011
     * License: See LICENSE.TXT in the root directory.
     */
    public static partial class IsolatedStorageHelper
    {
        /// <summary>
        /// Create a file in IsolatedStorage.
        /// </summary>
        /// <param name="data">The data you want to write, expressed as a byte array.</param>
        /// <param name="filepath">The path of the file you want to write.</param>
        /// <param name="storage">A reference to a valid IsolatedStorageFile instance.</param>
        public static void MakeFile(byte[] data, string filepath, IsolatedStorageFile storage)
        {
            CreateDirectoryTree(filepath, storage);

            using (var filestream = new IsolatedStorageFileStream(filepath, FileMode.Create, FileAccess.Write, storage))
            {
                filestream.Write(data, 0, data.Count());
                filestream.Close();
            }
        }

        /// <summary>
        /// Create a file in IsolatedStorage.
        /// </summary>
        /// <param name="data">The data you want to write, expressed as a byte array.</param>
        /// <param name="filepath">The path of the file you want to write.</param>
        public static void MakeFile(byte[] data, string filepath)
        {
            using (var storage = GetStore())
            {
                MakeFile(data, filepath, storage);
            }
        }

        /// <summary>
        /// Create a file in IsolatedStorage.
        /// </summary>
        /// <param name="textdata">The data you want to write, expressed as a string.</param>
        /// <param name="filepath">The path of the file you want to write.</param>
        public static void MakeFile(string textdata, string filepath)
        {
            var data = Encoding.UTF8.GetBytes(textdata);
            MakeFile(data, filepath);
        }

        /// <summary>
        /// Create a file in IsolatedStorage.
        /// </summary>
        /// <param name="textdata">The data you want to write, expressed as a string.</param>
        /// <param name="filepath">The path of the file you want to write.</param>
        /// <param name="storage">A reference to a valid IsolatedStorageFile instance.</param>
        public static void MakeFile(string textdata, string filepath, IsolatedStorageFile storage)
        {
            var data = Encoding.UTF8.GetBytes(filepath);
            MakeFile(data, filepath, storage);
        }
    }
}
