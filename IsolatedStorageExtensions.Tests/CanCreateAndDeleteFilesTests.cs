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
using IsolatedStorageExtensions.Tests.Utils;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IsolatedStorageExtensions.Tests
{
    /// <summary>
    /// Test class used for determining if the IsolatedStorageHelper can successfully write and delete simple text files.
    /// </summary>
    [TestClass]
    public class CanCreateAndDeleteFilesTests
    {
        public static readonly string SimpleFileName = "simple.txt";
        public static readonly string XmlFileName = "xml.xml";
        public static readonly string ComplexPathFileName = "path//path2//path3//simple.txt";
        public static readonly string SimilarPathFolders = "path//path//path//path//path//path.txt";

        /// <summary>
        /// Can IsolatedStorageHelper create a simple text file?
        /// </summary>
        [TestMethod]
        public void CanCreateSimpleFile()
        {
            IsolatedStorageHelper.MakeFile(RandomStringGenerator.RandomString(10), SimpleFileName);
            Assert.IsTrue(IsolatedStorageHelper.FileExists(SimpleFileName));
        }

        /// <summary>
        /// Can IsolatedStorageHelper delete a simple text file?
        /// </summary>
        [TestMethod]
        public void CanDeleteSimpleFile()
        {
            //Create the file if it doesn't exist already
            if(!IsolatedStorageHelper.FileExists(SimpleFileName))
            {
                IsolatedStorageHelper.MakeFile(RandomStringGenerator.RandomString(10), SimpleFileName);
            }
            
            Assert.IsTrue(IsolatedStorageHelper.FileExists(SimpleFileName), string.Format("The file {0} should exist!", SimpleFileName));

            IsolatedStorageHelper.DeleteFile(SimpleFileName);

            Assert.IsFalse(IsolatedStorageHelper.FileExists(SimpleFileName), string.Format("The file {0} should not exist!", SimpleFileName));
        }
    }
}