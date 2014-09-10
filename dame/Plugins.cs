using System;
using System.IO;
using System.Linq;
using System.Reflection;

using dame.Plugins;

namespace dame.Plugins
{
    public static class Plugins
    {
        public static UserInterface LoadUserInterface(string uiName)
        {
            try
            {
                string uiPath = getUIPath(uiName);
                Assembly uiAssembly = Assembly.LoadFile(uiPath);
                var uiClasses = uiAssembly.GetTypes().Where(t => t.BaseType == typeof(UserInterface));
                return (UserInterface)Activator.CreateInstance(uiClasses.First());
            }
            catch (ReflectionTypeLoadException ex)
            {
                string errorMessage = String.Format("Could not load user interface \"{0}\", plugin is likely out of date", uiName);
                Console.WriteLine(errorMessage);
                Console.WriteLine(ex);
                throw new Exception(errorMessage, ex);
            }
        }

        private static string getUIPath(string uiName)
        {
            return Path.ChangeExtension(Path.Combine(Constants.UI_PLUGINS_DIRECTORY, uiName), "dll");
        }

        public static bool uiExists(string uiName)
        {
            return File.Exists(getUIPath(uiName));
        }
    }
}

