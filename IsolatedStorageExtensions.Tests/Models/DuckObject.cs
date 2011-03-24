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

namespace IsolatedStorageExtensions.Tests.Models
{
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
