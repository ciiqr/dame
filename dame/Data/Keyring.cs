using System;
using System.Collections;

using Gnome.Keyring;

namespace dame.Data.Utilities
{
    public class Keyring
    {
        private const string USERNAME_ATTRIBUTE = "username";
        private const string IS_SANDBOX_ATTRIBUTE = "isSandbox";

        static Keyring()
        {
            Ring.ApplicationName = Constants.APPLICATION_NAME;
        }

        public static string getAuthToken(string username, out bool isSandbox)
        {
            string authToken = null;
            var keyring = Ring.GetDefaultKeyring();

            isSandbox = false;

            foreach (int keystoreID in Ring.ListItemIDs(keyring))
            {
                Hashtable attributes = Ring.GetItemAttributes(keyring, keystoreID);

                if (username == (string)attributes[USERNAME_ATTRIBUTE])
                {
                    ItemData keyringItem = Ring.GetItemInfo(keyring, keystoreID);
                    authToken = keyringItem.Secret;
                    isSandbox = Convert.ToBoolean(attributes[IS_SANDBOX_ATTRIBUTE]);
                    break;
                }
            }

            return authToken;
        }

        public static bool saveAuthToken(string username, string authToken, bool isSandbox)
        {
            var keyring = Ring.GetDefaultKeyring();
            var description = String.Format("Evernote authtoken for '{0}' in '{1}'", username, Constants.APPLICATION_NAME);
            var attributes = new System.Collections.Hashtable(2);
            attributes.Add(USERNAME_ATTRIBUTE, username);
            attributes.Add(IS_SANDBOX_ATTRIBUTE, isSandbox.ToString());

            try
            {
                Ring.CreateItem(keyring, ItemType.NetworkPassword, description, attributes, authToken, true);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}

