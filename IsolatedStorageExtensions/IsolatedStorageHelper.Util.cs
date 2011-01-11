using System;
using System.Linq;
using System.IO;
using System.Windows.Shapes;

namespace IsolatedStorageExtensions
{
    public static partial class IsolatedStorageHelper
    {
        #region Filenaming Methods

        public static string GetSafeFileName(string filename)
        {
            return (System.IO.Path.GetInvalidPathChars().Aggregate(filename, (current, c) => current.Replace(c, '_')));
        }

        #endregion
    }
}
