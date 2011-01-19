using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text;

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

        /// <summary>
        /// Begins reading the file from IsolatedStorage as a stream.
        /// </summary>
        /// <param name="filepath">The path to the file.</param>
        /// <param name="storage">A valid IsolatedStorageFile instance.</param>
        /// <returns>A valid Stream object which can be used to access the contents of the file.</returns>
        public static Stream ReadFileStream(string filepath, IsolatedStorageFile storage)
        {
            if (FileExists(filepath, storage))
            {
                return new IsolatedStorageFileStream(filepath, FileMode.Open, FileAccess.Read, storage);
            }

            return null;
        }

        /// <summary>
        /// Begins reading the file from IsolatedStorage as a stream.
        /// </summary>
        /// <param name="filepath">The path to the file.</param>
        /// <returns>A valid Stream object which can be used to access the contents of the file.</returns>
        public static Stream ReadFileStream(string filepath)
        {
            using (var storage = GetStore())
            {
                return ReadFileStream(filepath, storage);
            }
        }

        #endregion

        #region Text methods

        /// <summary>
        /// Returns the contents of a file as text.
        /// </summary>
        /// <param name="filepath">The path to the file.</param>
        /// <param name="storage">A reference to a valid IsolatedStorageFile instance.</param>
        /// <returns>A string containing the contents of the file.</returns>
        public static string ReadFileText(string filepath, IsolatedStorageFile storage)
        {
            if (FileExists(filepath, storage))
            {
                var stream = ReadFileStream(filepath, storage);
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }

            //If the file doesn't exist, return an empty string.
            return string.Empty;
        }

        /// <summary>
        /// Returns the contents of a file as text.
        /// </summary>
        /// <param name="filepath">The path to the file.</param>
        /// <returns>A string containing the contents of the file.</returns>
        public static string ReadFileText(string filepath)
        {
            using (var storage = GetStore())
            {
                return ReadFileText(filepath, storage);
            }
        }

        #endregion
    }
}
