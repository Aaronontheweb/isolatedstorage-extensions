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
    /// Test class used for determining if the IsolatedStorageHelper can successfully write and delete text files.
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
            Assert.IsTrue(IsolatedStorageHelper.FileExists(SimpleFileName), string.Format("The file {0} should exist!", SimpleFileName));
        }

        /// <summary>
        /// Can IsolatedStorageHelper delete a simple text file?
        /// </summary>
        [TestMethod]
        public void CanDeleteSimpleFile()
        {
            TestDeleteFile(SimpleFileName);
        }

        /// <summary>
        /// Can IsolatedStorageExtensions create a file which has a deep, multi-nested folder path?
        /// </summary>
        [TestMethod]
        public void CanCreateComplexFile()
        {
            IsolatedStorageHelper.MakeFile(RandomStringGenerator.RandomString(10), ComplexPathFileName);
            Assert.IsTrue(IsolatedStorageHelper.FileExists(ComplexPathFileName), string.Format("The file {0} should exist!", ComplexPathFileName));
        }

        /// <summary>
        /// Can IsolatedStorageExtensions delete a file which has a deep, multi-nested folder path?
        /// </summary>
        [TestMethod]
        public void CanDeleteComplexFile()
        {
            //Create the file if it doesn't exist already
            TestDeleteFile(ComplexPathFileName);
        }

        /// <summary>
        /// Can IsolatedStorage create a file which contains a massive amount of text?
        /// </summary>
        [TestMethod]
        public void CanCreateLargeFile()
        {
            IsolatedStorageHelper.MakeFile(RandomStringGenerator.RandomString(60000), SimpleFileName);
            Assert.IsTrue(IsolatedStorageHelper.FileExists(SimpleFileName), string.Format("The file {0} should exist!", SimpleFileName));
        }

        private static void TestDeleteFile(string filename)
        {
            if (!IsolatedStorageHelper.FileExists(filename))
            {
                IsolatedStorageHelper.MakeFile(RandomStringGenerator.RandomString(10), filename);
            }

            Assert.IsTrue(IsolatedStorageHelper.FileExists(filename), string.Format("The file {0} should exist!", filename));

            IsolatedStorageHelper.DeleteFile(filename);

            Assert.IsFalse(IsolatedStorageHelper.FileExists(filename), string.Format("The file {0} should not exist!", filename));
        }
    }
}