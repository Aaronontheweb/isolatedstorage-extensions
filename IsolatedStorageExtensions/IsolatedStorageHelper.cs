using System;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;

namespace IsolatedStorageExtensions
{
    public static partial class IsolatedStorageHelper
    {
        //A constant used for extracting directories from filepaths.
        private const string ForwardSlashDirectorySeparatorConstant = "//";
        private const string BackSlashDirectorySeparatorConstant = "\\";
    }
}
