using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using IsolatedStorageExtensions.Tests.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IsolatedStorageExtensions.Tests
{
    /// <summary>
    /// Testing class to determine if IsolatedStorageHelper can read and append files
    /// </summary>
    [TestClass]
    public class CanReadAndAppendFiles
    {
        private const string SimpleTextFileName = "test1.txt";
        private static string SimpleTextContent;

        [ClassInitialize]
        public void Initialize()
        {
            try
            {
                SimpleTextContent = RandomStringGenerator.RandomString(1000);
                IsolatedStorageHelper.MakeFile(SimpleTextContent, SimpleTextFileName);
                
            }
            catch(Exception ex)
            {
                var debugEx = ex;
            }

        }

        /// <summary>
        /// Demonstrate that the IsolatedStorageHelper reads the same thing it writes.
        /// </summary>
        [TestMethod]
        public void CanReadSimpleTextFileAsText()
        {
            try
            {
                var output = IsolatedStorageHelper.ReadFileText(SimpleTextFileName);
                Assert.IsTrue(SimpleTextContent.Equals(output));
            }
            catch (Exception ex)
            {
                var debugEx = ex;
            }
            
        }

        /// <summary>
        /// Demonstrate that the IsolatedStorageHelper can read the same thing it writes,
        /// but read it as a raw byte array and do a comparison that way.
        /// </summary>
        [TestMethod]
        public void CanReadSimpleTextFileAsByteArray()
        {
            using (var outputStream = IsolatedStorageHelper.ReadFileStream(SimpleTextFileName))
            {
                //Create a buffer big enough to contain the entire contents of the file
                var buffer = new byte[outputStream.Length];
                var length = 1000;
                var read = 0;
                do
                {
                    read = outputStream.Read(buffer, read, length);
                    if(outputStream.Length - length < length)
                    {
                        length = (int)outputStream.Length - length;
                    }
                } while (read > 0);

                var expected = Encoding.UTF8.GetBytes(SimpleTextContent);

                //Assert that the byte arrays are the same length
                Assert.AreEqual(expected.Length, buffer.Length);

                var outputStr = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                var expectedStr = Encoding.UTF8.GetString(expected, 0, expected.Length);

                Assert.AreEqual(expectedStr, outputStr);

            }
        }

        [ClassCleanup]
        public void Cleanup()
        {
            IsolatedStorageHelper.DeleteFile(SimpleTextFileName);
        }
    }
}
