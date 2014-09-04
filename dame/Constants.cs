using System;
using System.IO;
using System.Reflection;

namespace dame
{
    public static class Constants
    {
        // Application
        public const string APPLICATION_NAME = "Dame";
//        public static readonly string APPLICATION_VERSION = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        // Directories
        public static readonly string APPLICATION_SHARED_DATA_DIRECTORY = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), APPLICATION_NAME); // /usr/share/Dame
        public static readonly string USER_INTERFACE_PLUGINS_DIRECTORY = Path.Combine(APPLICATION_SHARED_DATA_DIRECTORY, "ui"); // /usr/share/Dame/ui


        // Option Keys
        public const string OPTIONS_UI_KEY = "ui";
        public const string OPTIONS_DBPATH_KEY = "dbpath";

        // Default Options
        public const string DEFAULT_OPTION_UI = "gtk";
    }
}

