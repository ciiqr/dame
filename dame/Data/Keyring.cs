using System;
using System.Collections;

using Gnome.Keyring;

namespace dame.Data.Utilities
{
    public class Keyring
    {
        private const string USERNAME_ATTRIBUTE = "username";

        static Keyring()
        {
            Ring.ApplicationName = Constants.APPLICATION_NAME;
        }

        public static string getAuthToken(string username)
        {
            string authToken = null;

            var keyring = Ring.GetDefaultKeyring();
            foreach (int keystoreID in Ring.ListItemIDs(keyring))
            {
                Hashtable attributes = Ring.GetItemAttributes(keyring, keystoreID);

                if (username == (string)attributes[USERNAME_ATTRIBUTE])
                {
                    ItemData keyringItem = Ring.GetItemInfo(keyring, keystoreID);
                    authToken = keyringItem.Secret;
                    break;
                }
            }

            return authToken;
        }

        public static bool saveAuthToken(string username, string authToken)
        {
            var keyring = Ring.GetDefaultKeyring();
            var description = String.Format("Evernote authtoken for '{0}' in '{1}'", username, Constants.APPLICATION_NAME);
            var attributes = new System.Collections.Hashtable(1);
            attributes.Add(USERNAME_ATTRIBUTE, username);

            try
            {
                Ring.CreateItem(keyring, ItemType.NetworkPassword, description, attributes, authToken, true);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }
}

