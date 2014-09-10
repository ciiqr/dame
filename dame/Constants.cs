using System;
using System.IO;
using System.Reflection;

namespace dame
{
    public static class Constants
    {
        // Application
        public const string APPLICATION_NAME = "Dame";
        public static readonly Version APPLICATION_VERSION = Assembly.GetExecutingAssembly().GetName().Version;

        // Directories
        public static readonly string APPLICATION_SHARED_DATA_DIRECTORY = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), APPLICATION_NAME); // /usr/share/Dame
        public static readonly string UI_PLUGINS_DIRECTORY = Path.Combine(APPLICATION_SHARED_DATA_DIRECTORY, "ui"); // /usr/share/Dame/ui

        // OS User
        public static readonly string USER_DIRECTORY = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        public static readonly string USER_CONFIG_DIRECTORY = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), APPLICATION_NAME);
        public static readonly string USER_APPLICATION_CACHE_DIRECTORY = Path.Combine(USER_DIRECTORY, ".cache", APPLICATION_NAME); // TODO: Implement XDG.BaseDirectory

        // Files
        public static readonly string LAST_USER_PATH = Path.Combine(USER_CONFIG_DIRECTORY, "lastUser"); // ~/.config/Dame/lastUser

        // Resources
        // TODO: Move to APPLICATION_SHARED_DATA_DIRECTORY/Resources
        public static readonly string RESOURCES_DIRECTORY = "Resources"; // ./Resources/InitialDatabase.sql
        public static readonly string INITIAL_DATABASE_PATH = Path.Combine(RESOURCES_DIRECTORY, "InitialDatabase.sql"); // ./Resources/InitialDatabase.sql

        // Option Keys
        public const string OPTIONS_UI_KEY = "ui";
        public const string OPTIONS_USERNAME_KEY = "username";

        // Default Options
        public const string DEFAULT_OPTION_UI = "gtk";

        // Miscellaneous
        public const string DATABASE_FILE_EXTENSION = "db";
    }
}

