using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IsolatedStorageExtensions.Tests
{
    /// <summary>
    /// The testing harness is used just for basic read/write scenarios for string data.
    /// 
    /// We're primarily interested in determining if the IsolatedStorageExtensions Make/ReadFile methods don't do anything weird
    /// with the underlying buffers, mangle file names, serialize and deserialize consistently, and so forth.
    /// </summary>
    [TestClass]
    public class StringReadWriteTests
    {
        [TestMethod]
        public void CanReadAndWriteSmallString()
        {
        }
    }
}