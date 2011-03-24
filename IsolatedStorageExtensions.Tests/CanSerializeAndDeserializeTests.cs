using System;
using System.IO;
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
using System.Xml.Serialization;
using IsolatedStorageExtensions.Tests.Models;
using IsolatedStorageExtensions.Tests.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IsolatedStorageExtensions.Tests
{
    [TestClass]
    public class CanSerializeAndDeserializeTests
    {
        private static DuckObject Object1;
        private static DuckObject Object2;
        private static string object1FilePath = "serialobjects/object1.xml";
        private static string object2FilePath = "serialobjects/object2.xml";
        private static XmlSerializer _serializer;

        [ClassInitialize]
        public void Initialize()
        {
            Object1 = new DuckObject
                          {
                              Var1 = RandomStringGenerator.RandomString(155),
                              Var2 = RandomStringGenerator.RandomString(190)
                          };

            Object2 = new DuckObject
                          {
                              Var1 = RandomStringGenerator.RandomString(143),
                              Var2 = RandomStringGenerator.RandomString(550)
                          };

            _serializer = new XmlSerializer(typeof(DuckObject));

        }

        [TestMethod]
        public void SerializeObjectToXml()
        {
            // Delete the file if it exists already
            if (IsolatedStorageHelper.FileExists(object1FilePath))
            {
                IsolatedStorageHelper.DeleteFile(object1FilePath);
            }

            //Serialize the file to disk
            IsolatedStorageHelper.MakeFile(Object1, object1FilePath, _serializer);

            //Verify that we created the file
            Assert.IsTrue(IsolatedStorageHelper.FileExists(object1FilePath));

        }

        [TestMethod]
        public void DeserializeObjectFromXml()
        {
            if (!IsolatedStorageHelper.FileExists(object1FilePath))
            {
                //Serialize the file to disk if it doesn't exist already
                IsolatedStorageHelper.MakeFile<DuckObject>(Object1, object1FilePath, _serializer);
            }

            var resultantObject = IsolatedStorageHelper.ReadFile<DuckObject>(object1FilePath, _serializer);

            Assert.IsTrue(Object1.Equals(resultantObject));

        }

        [ClassCleanup]
        public void CleanUp()
        {
            IsolatedStorageHelper.DeleteFile(object1FilePath);
            IsolatedStorageHelper.DeleteFile(object2FilePath);
        }
    }
}
