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
        public static readonly string BackSlashFileName = "path\\path\\simple.txt";
        public static readonly string LargeFileName = "largefile.txt";

        /// <summary>
        /// Can IsolatedStorageHelper create a simple text file?
        /// </summary>
        [TestMethod]
        public void CanCreateSimpleFile()
        {
            TestCreateFile(SimpleFileName);
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
        /// Can IsolatedStorageHelper create a file which has a deep, multi-nested folder path?
        /// </summary>
        [TestMethod]
        public void CanCreateComplexFile()
        {
            TestCreateFile(ComplexPathFileName);
        }

        /// <summary>
        /// Can IsolatedStorageHelper delete a file which has a deep, multi-nested folder path?
        /// </summary>
        [TestMethod]
        public void CanDeleteComplexFile()
        {
            //Create the file if it doesn't exist already
            TestDeleteFile(ComplexPathFileName);
        }

        /// <summary>
        /// Can IsolatedStorageHelper create a file which contains a massive amount of text?
        /// </summary>
        [TestMethod]
        public void CanCreateLargeFile()
        {
            TestCreateFile(LargeFileName, 600000);
        }

        /// <summary>
        /// Can IsolatedStorageHelper delete a file which contains a massive amount of text?
        /// </summary>
        [TestMethod]
        public void CanDeleteLargeFile()
        {
            TestDeleteFile(LargeFileName, 600000);
        }

        /// <summary>
        /// Can IsolatedStorageHelper create a file name where the paths are extremely repetitive?
        /// </summary>
        [TestMethod]
        public void CanCreateFileWithRepetitiveName()
        {
            TestCreateFile(SimilarPathFolders);
        }

        /// <summary>
        /// Can IsolatedStorageHelper delete a file name where the paths are extremely repetitive?
        /// </summary>
        [TestMethod]
        public void CanDeleteFileWithRepetitiveName()
        {
            TestDeleteFile(SimilarPathFolders);
        }

        /// <summary>
        /// Can IsolatedStorageHelper create an XML file?
        /// </summary>
        [TestMethod]
        public void CanCreateXmlFile()
        {
            IsolatedStorageHelper.MakeFile(RandomStringGenerator.RandomXmlString(1000), XmlFileName);
            Assert.IsTrue(IsolatedStorageHelper.FileExists(XmlFileName), string.Format("The file {0} should exist!", XmlFileName));
        }

        /// <summary>
        /// Can IsolatedStorageHelper delete an XML file?
        /// </summary>
        [TestMethod]
        public void CanDeleteXmlFile()
        {
            TestDeleteFile(XmlFileName);
        }

        /// <summary>
        /// Can IsolatedStorageHelper create a file with folders which are expressed as back slashes?
        /// </summary>
        [TestMethod]
        public void CanCreateFileWithFoldersWithBackSlashes()
        {
            TestCreateFile(BackSlashFileName);
        }

        /// <summary>
        /// Can IsolatedStorageHelper delete files living in folders with back slashes?
        /// </summary>
        [TestMethod]
        public void CanDeleteFileWithFoldersWithBackSlashes()
        {
            TestDeleteFile(BackSlashFileName);
        }
        /// <summary>
        /// Can successfully transform an invalid filename into a valid filename and create the appropriate file.
        /// </summary>
        [TestMethod]
        public void CanCreateFileWithSanitizedName()
        {
            var invalidFileName = "><aaa<>.txt";
            var validFileName = IsolatedStorageHelper.GetSafeFileName(invalidFileName);
            TestCreateFile(validFileName);
        }

        /// <summary>
        /// Private helper method for performing common file CREATE operations during unit testing.
        /// </summary>
        /// <param name="filename">The filename of the object to create.</param>
        /// <param name="stringlen">The length of the string file to create (default is 10 characters).</param>
        private static void TestCreateFile(string filename, int stringlen = 10)
        {
            IsolatedStorageHelper.MakeFile(RandomStringGenerator.RandomString(stringlen), filename);
            Assert.IsTrue(IsolatedStorageHelper.FileExists(filename), string.Format("The file {0} should exist!", filename));
        }

        /// <summary>
        /// Private helper method for performing common DELETE operations during unit testing.
        /// </summary>
        /// <param name="filename">The filename of the object to delete.</param>
        /// <param name="stringlen">The length of the string file to check for (default is 10 characters).</param>
        private static void TestDeleteFile(string filename, int stringlen = 10)
        {
            //If the file doesn't yet exist, create it!
            if (!IsolatedStorageHelper.FileExists(filename))
            {
                IsolatedStorageHelper.MakeFile(RandomStringGenerator.RandomString(stringlen), filename);
            }

            //Verify that the file exists
            Assert.IsTrue(IsolatedStorageHelper.FileExists(filename), string.Format("The file {0} should exist!", filename));

            //Delete the file
            IsolatedStorageHelper.DeleteFile(filename);

            //Verify that the file doesn't exist
            Assert.IsFalse(IsolatedStorageHelper.FileExists(filename), string.Format("The file {0} should not exist!", filename));
        }
    }
}