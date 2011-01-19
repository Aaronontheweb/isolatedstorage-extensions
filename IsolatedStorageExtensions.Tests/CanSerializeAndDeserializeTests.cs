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
            try
            {
                using(var storage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    IsolatedStorageHelper.CreateDirectoryTree(object1FilePath);

                    using(var stream = new IsolatedStorageFileStream(object1FilePath, FileMode.Create, FileAccess.Write, storage))
                    {
                        _serializer.Serialize(stream, Object1);

                        Assert.IsTrue(stream.Length > 0);
                    }
                }
  

                ////Serialize the file to disk
                //IsolatedStorageHelper.MakeFile(Object1, object1FilePath, _serializer);

                ////Verify that we created the file
                //Assert.IsTrue(IsolatedStorageHelper.FileExists(object1FilePath));
            }
            catch(Exception ex)
            {
                var debugEx = ex;
            }
        }

        [TestMethod]
        public void DeserializeObjectFromXml()
        {
            if(!IsolatedStorageHelper.FileExists(object1FilePath))
            {
                //Serialize the file to disk if it doesn't exist already
                IsolatedStorageHelper.MakeFile<DuckObject>(Object1, object1FilePath, _serializer);
            }

            var resultantObject = IsolatedStorageHelper.ReadFile<DuckObject>(object1FilePath, _serializer);

            Assert.IsTrue(Object1.Equals(resultantObject));

        }

        /// <summary>
        /// Internal class to be used as a guinea pig for serialization tests
        /// </summary>
        public class DuckObject : IEquatable<DuckObject>
        {
            public string Var1 { get; set; }
            public string Var2 { get; set; }

            #region Implementation of IEquatable<DuckObject>

            public bool Equals(DuckObject other)
            {
                return Var1.Equals(other.Var1) && Var2.Equals(other.Var2);
            }

            #endregion
        }
    }
}
