using System;
using System.IO;

namespace dame
{
    public static class DameUser
    {
        // TODO: Multi-User: switchToUser(username) saveInitialUsername(username)
        public static string _currentUser;
        public static string currentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    _currentUser = getInitialUsername();
                }
                return _currentUser;
            }
            set
            {
                saveInitialUsername(value);
                _currentUser = value;
            }
        }

        private static string getInitialUsername()
        {
            string username = null;
            if (File.Exists(Constants.LAST_USER_PATH))
            {
                StreamReader streamReader = null;
                try
                {
                    streamReader = new StreamReader(Constants.LAST_USER_PATH, System.Text.Encoding.UTF8);
                    username = streamReader.ReadToEnd();
                    return username;
                }
                catch (Exception ex)
                {
                    // TODO: Handle Exceptions
                    Console.WriteLine(ex);
                }
                finally
                {
                    if (streamReader != null)
                        streamReader.Dispose();
                }
            }
            // If Here then LAST_USER_PATH doesn't exist OR an error was thrown while reading it

            if (Directory.Exists(Constants.USER_CONFIG_DIRECTORY))
            {
                foreach (string directory in Directory.GetDirectories(Constants.USER_CONFIG_DIRECTORY))
                {
                    if (Directory.GetFiles(directory, "*." + Constants.DATABASE_FILE_EXTENSION).Length > 0)
                    {
                        username = Path.GetDirectoryName(directory);
                        saveInitialUsername(username);
                        break;
                    }
                }
            }

            return username;
        }

        public static void setInitialUsername(string username)
        {
            saveInitialUsername(username);
        }

        private static void saveInitialUsername(string username)
        {
            using (StreamWriter streamWriter = new StreamWriter(Constants.LAST_USER_PATH))
            {
                streamWriter.Write(username);
            }
        }

        public static bool databaseExists()
        {
            return databaseExists(currentUser);
        }
        public static bool databaseExists(string username)
        {
            return File.Exists(getDatabasePath(username));
        }

        // ie. ~/.config/Dame/willvill1995/
        public static string getConfigDirectory()
        {
            return Path.Combine(Constants.USER_CONFIG_DIRECTORY, currentUser);
        }

        // ie. ~/.config/Dame/willvill1995/willvill1995.db
        public static string getDatabasePath()
        {
            return getDatabasePath(currentUser);
        }

        private static string getDatabasePath(string username)
        {
            return Path.ChangeExtension(Path.Combine(getUserPath(username), username), Constants.DATABASE_FILE_EXTENSION);
        }

        public static string getUserPath(string username)
        {
            return Path.Combine(Constants.USER_APPLICATION_CACHE_DIRECTORY, username);
        }

        public static void createUserDirectory(string username)
        {
            string userPath = getUserPath(username);

            if (!File.Exists(Constants.USER_APPLICATION_CACHE_DIRECTORY))
                Directory.CreateDirectory(Constants.USER_APPLICATION_CACHE_DIRECTORY);

            if (!File.Exists(userPath))
                Directory.CreateDirectory(userPath);
        }
    }
}

