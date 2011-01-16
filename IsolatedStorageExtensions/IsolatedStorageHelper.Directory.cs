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
    /* IsolatedStorageHelper.Directory - used for manipulating directories in IsolatedStorage.
     * 
     * Contributors: Aaron Stannard (http://www.aaronstannard.com/), 1/15/2011
     * License: See LICENSE.TXT in the root directory.
     */
    public static partial class IsolatedStorageHelper
    {
        #region Directory creation methods

        /// <summary>
        /// Creates all of the directories included in the given filepath.
        /// </summary>
        /// <param name="filepath">A string containing a filepath which may or may not contain any number of directories.</param>
        public static void CreateDirectoryTree(string filepath)
        {
            using (var storage = GetStore())
            {
                CreateDirectoryTree(filepath, storage);
            }
        }

        /// <summary>
        /// Creates all of the directories included in the given filepath.
        /// </summary>
        /// <param name="filepath">A string containing a filepath which may or may not contain any number of directories.</param>
        /// <param name="storage">A reference to a valid IsolatedStorageFile instance</param>
        public static void CreateDirectoryTree(string filepath, IsolatedStorageFile storage)
        {
            //If this filepath is flat and doesn't contain any folders - bail.
            if (!filepath.Contains(DirectorySeparatorConstant)) return;

            //Extract the full directory path from the filename
            var directory = GetDirectoryPath(filepath);

            //If the directory doesn't already exist, create it.
            if (!storage.DirectoryExists(directory))
                storage.CreateDirectory(directory);
        }

        /// <summary>
        /// Extracts the directory path based on what's present in a given filename.
        /// </summary>
        /// <param name="filepath">A string containing a filepath which may or may not contain any number of directories.</param>
        /// <returns>The string of the path which contains just the folder tree and not the filename.</returns>
        public static string GetDirectoryPath(string filepath)
        {
            //If the filepath is actually flat and there are no directories, bail.
            if (!filepath.Contains(DirectorySeparatorConstant)) return string.Empty;

            /*Find the last instance of the directory sperator constant (//)
              and return everything that came before it.*/
            var directoryPos = filepath.LastIndexOf(DirectorySeparatorConstant);
            return filepath.Substring(0, directoryPos);
        }

        #endregion
    }
}
