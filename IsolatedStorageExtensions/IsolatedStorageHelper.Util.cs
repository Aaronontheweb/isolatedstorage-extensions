using System;
using System.IO.IsolatedStorage;
using System.Linq;
using System.IO;
using System.Windows.Shapes;

namespace IsolatedStorageExtensions
{
    /* IsolatedStorageHelper.Util - utility methods that don't directly impact anything in IsolatedStorage,
     * but are useful in the course of accessing it.
     * 
     * Contributors: Aaron Stannard (http://www.aaronstannard.com/), 1/13/2011
     * License: See LICENSE.TXT in the root directory.
     */
    public static partial class IsolatedStorageHelper
    {
        #region Storage Factory

        /// <summary>
        /// Internal factory method for creating storage instances used in other methods.
        /// </summary>
        /// <returns>An IsolatedStorageFile</returns>
        private static IsolatedStorageFile GetStore()
        {
            return IsolatedStorageFile.GetUserStoreForApplication();
        }

        #endregion

        #region Filenaming Methods

        /// <summary>
        /// Returns a safe filename based on an incoming string. 
        /// Makes it easy to create valid filenames based off of any type of string.
        /// </summary>
        /// <param name="filename">A string which doesn't necessarily contain a valid filename.</param>
        /// <returns>A string containing a valid filename.</returns>
        public static string GetSafeFileName(string filename)
        {
            return (System.IO.Path.GetInvalidPathChars().Aggregate(filename, (current, c) => current.Replace(c, '_')));
        }

        #endregion
    }
}
