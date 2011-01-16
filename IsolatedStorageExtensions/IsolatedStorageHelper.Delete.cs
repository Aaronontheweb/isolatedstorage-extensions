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
    /* IsolatedStorageHelper.Delete - used for deleting files from IsolatedStorage.
     * 
     * Contributors: Aaron Stannard (http://www.aaronstannard.com/), 1/15/2011
     * License: See LICENSE.TXT in the root directory.
     */
    public static partial class IsolatedStorageHelper
    {
        /// <summary>
        /// Used for deleting a file from IsolatedStorage.
        /// </summary>
        /// <param name="filename">The name of the file to be deleted.</param>
        public static void DeleteFile(string filename)
        {
            using(var storage = IsolatedStorageHelper.GetStore())
            {
                DeleteFile(filename, storage);
            }
        }

        /// <summary>
        /// Used for deleting a file from IsolatedStorage.
        /// </summary>
        /// <param name="filename">The name of the file to be deleted.</param>
        /// <param name="storage">A reference to an activate IsolatedStorageFile object.</param>
        public static void DeleteFile(string filename, IsolatedStorageFile storage)
        {
            storage.DeleteFile(filename);
        }
    }
}
