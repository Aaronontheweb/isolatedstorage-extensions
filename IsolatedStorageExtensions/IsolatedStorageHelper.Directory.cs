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
        //A constant used for extracting directories from filepaths.
        private const string ForwardSlashDirectorySeparatorConstant = @"/";
        private const string BackSlashDirectorySeparatorConstant = @"\";

        #region Directory exists methods

        /// <summary>
        /// Verifies whether or not a given directory exists in IsolatedStorage
        /// </summary>
        /// <param name="directorypath">The path to a given directory</param>
        /// <param name="storage">A reference to a valid IsolatedStorageFile instance.</param>
        /// <returns>True if the directory exists, false otherwise.</returns>
        public static bool DirectoryExists(string directorypath, IsolatedStorageFile storage)
        {
            return storage.DirectoryExists(directorypath);
        }

        /// <summary>
        /// Verifies whether or not a given directory exists in IsolatedStorage
        /// </summary>
        /// <param name="directorypath">The path to a given directory</param>
        /// <returns>True if the directory exists, false otherwise.</returns>
        public static bool DirectoryExists(string directorypath)
        {
            using(var storage = GetStore())
            {
                return DirectoryExists(directorypath, storage);
            }
        }

        #endregion

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
             if (!HasDirectories(filepath)) return;

            //Extract the full directory path from the filename
            var directory = GetFullDirectoryPath(filepath);

            //If the directory doesn't already exist, create it.
            if (!storage.DirectoryExists(directory))
                storage.CreateDirectory(directory);
        }

        #endregion

        #region Directory deletion methods

        /// <summary>
        /// Deletes all of the folders and their contents in a given file-path.
        /// </summary>
        /// <param name="filepath">A valid filepath in IsolatedStorage.</param>
        /// <param name="storage">A reference to a valid IsolateStorageFile object.</param>
        public static void DeleteDirectoryTree(string filepath, IsolatedStorageFile storage)
        {
            //Bail if we don't detect any folders
            if (!HasDirectories(filepath)) return;

            //Get the root folder from the path
            var folderPath = GetRootDirectory(filepath);

            //Delete the root directory and have it cascade down
            storage.DeleteDirectory(folderPath);
            
        }

        /// <summary>
        /// Deletes all of the folders and their contents in a given file-path.
        /// </summary>
        /// <param name="filepath">A valid filepath in IsolatedStorage.</param>
        public static void DeleteDirectoryTree(string filepath)
        {
            //Create our own IsolatedStorageFile instance and then pass it to the overloaded method.
            using(var storage = GetStore())
            {
                DeleteDirectoryTree(filepath, storage);
            }
        }

        #endregion

        #region Directory parsing methods

        /// <summary>
        /// Returns true if a given path contains folders
        /// </summary>
        /// <param name="filepath">A filepath to test</param>
        /// <returns>True if folders are detected, false otherwise.</returns>
        public static bool HasDirectories(string filepath)
        {
            return filepath.Contains(ForwardSlashDirectorySeparatorConstant) || filepath.Contains(BackSlashDirectorySeparatorConstant);
        }

        /// <summary>
        /// Extracts the directory path based on what's present in a given filename.
        /// </summary>
        /// <param name="filepath">A string containing a filepath which may or may not contain any number of directories.</param>
        /// <returns>The string of the path which contains just the folder tree and not the filename.</returns>
        public static string GetFullDirectoryPath(string filepath)
        {
            var directoryPos = 0;
            //If the filepath is actually flat and there are no directories, bail.
            if (filepath.Contains(ForwardSlashDirectorySeparatorConstant))
            {
                /*Find the last instance of the directory sperator constant (//)
                   and return everything that came before it.*/
                directoryPos = filepath.LastIndexOf(ForwardSlashDirectorySeparatorConstant);
                return filepath.Substring(0, directoryPos);
            }

            if (filepath.Contains(BackSlashDirectorySeparatorConstant))
            {
                /*Find the last instance of the directory sperator constant (\\)
                   and return everything that came before it.*/
                directoryPos = filepath.LastIndexOf(BackSlashDirectorySeparatorConstant);
                return filepath.Substring(0, directoryPos);
            }

            return string.Empty;
        }

        /// <summary>
        /// Extracts the root folder from a path and returns its name
        /// </summary>
        /// <param name="filepath">A filepath to be evaluated</param>
        /// <returns>The root folder if one exists, an empty string otherwise</returns>
        public static string GetRootDirectory(string filepath)
        {
            var directoryPos = 0;
            //If the filepath is actually flat and there are no directories, bail.
            if (filepath.Contains(ForwardSlashDirectorySeparatorConstant))
            {
                /*Find the last instance of the directory sperator constant (//)
                   and return everything that came before it.*/
                directoryPos = filepath.IndexOf(ForwardSlashDirectorySeparatorConstant);
                return filepath.Substring(0, directoryPos);
            }

            if (filepath.Contains(BackSlashDirectorySeparatorConstant))
            {
                /*Find the last instance of the directory sperator constant (\\)
                   and return everything that came before it.*/
                directoryPos = filepath.IndexOf(BackSlashDirectorySeparatorConstant);
                return filepath.Substring(0, directoryPos);
            }

            return string.Empty;
        }

        #endregion
    }
}
