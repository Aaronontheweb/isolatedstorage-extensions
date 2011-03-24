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
using IsolatedStorageExtensions.Tests.Models;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IsolatedStorageExtensions.Tests
{
    /// <summary>
    /// Test class used for asserting as to whether or not IsolatedStorageHelper can write to the settings file or not
    /// </summary>
    [TestClass]
    public class CanModifyAndAccessSettings
    {
        #region Application Settings Tests

        /// <summary>
        /// Can we read and write from / to application storage using primitive types?
        /// </summary>
        [TestMethod]
        public void CanWriteAndReadSimpleApplicationSetting()
        {
            var key = "monkey1";
            var value = 3;

            IsolatedStorageHelper.SaveApplicationSetting(key, value);

            var returnValue = IsolatedStorageHelper.GetApplicationSetting(key);

            Assert.IsInstanceOfType(returnValue, value.GetType());
            Assert.IsTrue((int)returnValue == value);
        }

        /// <summary>
        /// Can we read, write, AND DELETE to / from application storage using primitive types?
        /// </summary>
        [TestMethod]
        public void CanWriteAndDeleteSimpleApplicationSetting()
        {
            var key = "monkey2";
            var value = 14;

            IsolatedStorageHelper.SaveApplicationSetting(key, value);

            var returnValue = IsolatedStorageHelper.GetApplicationSetting(key);

            Assert.IsInstanceOfType(returnValue, value.GetType());
            Assert.IsTrue((int)returnValue == value);

            IsolatedStorageHelper.RemoveApplicationSetting(key);

            var returnValue2 = IsolatedStorageHelper.GetApplicationSetting(key);

            Assert.IsNull(returnValue2);
        }

        /// <summary>
        /// Can we read, write, AND DELETE to / from application storage using reference types?
        /// </summary>
        [TestMethod]
        public void CanWriteAndDeleteComplexApplicationSetting()
        {
            var key = "monkey2";
            var value = new DuckObject{ Var1 = "beans", Var2 = "ham"};

            IsolatedStorageHelper.SaveApplicationSetting(key, value);

            var returnValue = IsolatedStorageHelper.GetApplicationSetting(key);

            Assert.IsInstanceOfType(returnValue, value.GetType());
            Assert.IsTrue((DuckObject)returnValue == value);

            IsolatedStorageHelper.RemoveApplicationSetting(key);

            var returnValue2 = IsolatedStorageHelper.GetApplicationSetting(key);

            Assert.IsNull(returnValue2);
        }

        #endregion

        #region Site Storage Tests

        /// <summary>
        /// Can we read and write from / to site storage using primitive types?
        /// </summary>
        [TestMethod]
        public void CanWriteAndReadSimpleSiteSetting()
        {
            var key = "monkey1";
            var value = 3;

            IsolatedStorageHelper.SaveSiteSetting(key, value);

            var returnValue = IsolatedStorageHelper.GetSiteSetting(key);

            Assert.IsInstanceOfType(returnValue, value.GetType());
            Assert.IsTrue((int)returnValue == value);
        }

        /// <summary>
        /// Can we read, write, AND DELETE to / from site storage using primitive types?
        /// </summary>
        [TestMethod]
        public void CanWriteAndDeleteSimpleSiteSetting()
        {
            var key = "monkey2";
            var value = 14;

            IsolatedStorageHelper.SaveSiteSetting(key, value);

            var returnValue = IsolatedStorageHelper.GetSiteSetting(key);

            Assert.IsInstanceOfType(returnValue, value.GetType());
            Assert.IsTrue((int)returnValue == value);

            IsolatedStorageHelper.RemoveSiteSetting(key);

            var returnValue2 = IsolatedStorageHelper.GetSiteSetting(key);

            Assert.IsNull(returnValue2);
        }

        /// <summary>
        /// Can we read, write, AND DELETE to / from application storage using reference types?
        /// </summary>
        [TestMethod]
        public void CanWriteAndDeleteComplexSiteSetting()
        {
            var key = "monkey2";
            var value = new DuckObject { Var1 = "beans", Var2 = "ham" };

            IsolatedStorageHelper.SaveSiteSetting(key, value);

            var returnValue = IsolatedStorageHelper.GetSiteSetting(key);

            Assert.IsInstanceOfType(returnValue, value.GetType());
            Assert.IsTrue((DuckObject)returnValue == value);

            IsolatedStorageHelper.RemoveSiteSetting(key);

            var returnValue2 = IsolatedStorageHelper.GetSiteSetting(key);

            Assert.IsNull(returnValue2);
        }

        #endregion
    }
}