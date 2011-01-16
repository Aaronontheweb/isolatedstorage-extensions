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
    /* IsolatedStorageHelper.Read - used for basic read operations against IsolatedStorage.
     * 
     * Contributors: Aaron Stannard (http://www.aaronstannard.com/), 1/11/2011
     * License: See LICENSE.TXT in the root directory.
     */
    public static partial class IsolatedStorageHelper
    {
        #region Exists Overloads

        /// <summary>
        /// Determines whether or not a given filepath exists.
        /// </summary>
        /// <param name="filepath">A string containing a filepath.</param>
        /// <returns>True if the file exists, false otherwise</returns>
        public static bool FileExists(string filepath)
        {
            using (var storage = GetStore())
            {
                return FileExists(filepath, storage);
            }
        }

        /// <summary>
        /// Determines whether or not a given filepath exists.
        /// </summary>
        /// <param name="filepath">A string containing a filepath.</param>
        /// <param name="storage">A reference to a valid IsolatedStorageFile instance.</param>
        /// <returns>True if the file exists, false otherwise</returns>
        public static bool FileExists(string filepath, IsolatedStorageFile storage)
        {
            return storage.FileExists(filepath);
        }

        #endregion

        #region File Age

#if !WINDOWS_PHONE

        /// <summary>
        /// Determines the age of a file based on the last time it was written to
        /// </summary>
        /// <param name="filepath">The path of the file to test.</param>
        /// <returns>A DateTimeOffset indiciating the last valid file write date.</returns>
        public static DateTimeOffset GetFileAge(string filepath)
        {
            using(var storage = GetStore())
            {
                return GetFileAge(filepath, storage);
            }
        }

        /// <summary>
        /// Determines the age of a file based on the last time it was written to
        /// </summary>
        /// <param name="filepath">The path of the file to test.</param>
        /// <param name="storage">A reference to a valid IsolatedStorageFile instance.</param>
        /// <returns>A DateTimeOffset indiciating the last valid file write date.</returns>
        public static DateTimeOffset GetFileAge(string filepath, IsolatedStorageFile storage)
        {
            return storage.GetLastWriteTime(filepath);
        }

#endif

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
            using (var storage = GetStore())
            {
                return GetFileStream(filepath, storage);
            }
        }

        #endregion

        #region Text methods

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


        public static string GetFileText(string filepath)
        {
            using (var storage = GetStore())
            {
                return GetFileText(filepath, storage);
            }
        }

        #endregion
    }
}
