using System.IO.IsolatedStorage;

namespace IsolatedStorageExtensions
{
    /* IsolatedStorageHelper.Settings - used for manipulating settings in IsolatedStorage
     * 
     * Contributors: Aaron Stannard (http://www.aaronstannard.com/), 1/15/2011
     * License: See LICENSE.TXT in the root directory.
     */
    public static partial class IsolatedStorageHelper
    {

        #region Application Settings

        /// <summary>
        /// Adds a new object to the application settings store
        /// </summary>
        /// <param name="key">The key to identify the object with</param>
        /// <param name="value">The object to put into storage</param>
        public static void SaveApplicationSetting(string key, object value)
        {
            var store = GetApplicationSettings();

            //If the store already contains this key, then just perform an update
            SaveOrUpdateSetting(store, key, value);
        }
        

        /// <summary>
        /// Retrieves an object from the application settings store
        /// </summary>
        /// <param name="key">The key to identify the object with</param>
        /// <returns>An object in storage associated with this key</returns>
        public static object GetApplicationSetting(string key)
        {
            var store = GetApplicationSettings();

            return SafeGetStorageValue(store, key);
        }

        /// <summary>
        /// Removes an object from the application settings store
        /// </summary>
        /// <param name="key"></param>
        public static void RemoveApplicationSetting(string key)
        {
            var store = GetApplicationSettings();

            DeleteSetting(store, key);
        }



        #endregion

        #region Site Settings

#if !WINDOWS_PHONE

        /// <summary>
        /// Adds a new object to the site settings store
        /// </summary>
        /// <param name="key">The key to identify the object with</param>
        /// <param name="value">The object to put into storage</param>
        public static void SaveSiteSetting(string key, object value)
        {
            var store = GetSiteSettings();

            //If the store already contains this key, then just perform an update
            SaveOrUpdateSetting(store, key, value);
        }


        /// <summary>
        /// Retrieves an object from the site settings store
        /// </summary>
        /// <param name="key">The key to identify the object with</param>
        /// <returns>An object in storage associated with this key</returns>
        public static object GetSiteSetting(string key)
        {
            var store = GetSiteSettings();
            return SafeGetStorageValue(store, key);
        }

        /// <summary>
        /// Removes an object from the site settings store
        /// </summary>
        /// <param name="key"></param>
        public static void RemoveSiteSetting(string key)
        {
            var store = GetSiteSettings();

            DeleteSetting(store, key);
        }

#endif

        #endregion
        

        #region Private Settings Helper Methods

        /// <summary>
        /// Returns a value from storage if it exists; otherwise, null
        /// </summary>
        /// <param name="store">The IsolatedStorageSettings store to use (either "site" or "application")</param>
        /// <param name="key">The key of the object to save</param>
        /// <returns>The value to be saved in storage, or null</returns>
        private static object SafeGetStorageValue(IsolatedStorageSettings store, string key)
        {
            return store.Contains(key) ? store[key] : null;
        }

        /// <summary>
        /// Private helper method for performing saves on settings
        /// </summary>
        /// <param name="store">The IsolatedStorageSettings store to use (either "site" or "application")</param>
        /// <param name="key">The key of the object to save</param>
        /// <param name="value">The value to be saved in storage</param>
        private static void SaveOrUpdateSetting(IsolatedStorageSettings store, string key, object value)
        {
            if (store.Contains(key))
            {
                store[key] = value;
            }

                //Otheriwse, add this new key and its value to the store
            else
            {
                store.Add(key, value);
            }
            store.Save();
        }

        /// <summary>
        /// Private helper method for performing deletes on a setting
        /// </summary>
        /// <param name="store">The IsolatedStorageSettings store to use (either "site" or "application")</param>
        /// <param name="key">The key of the object to delete</param>
        private static void DeleteSetting(IsolatedStorageSettings store, string key)
        {
            if(store.Contains(key))
            {
                store.Remove(key);
                store.Save();
            }
        }

        #endregion
    }
}