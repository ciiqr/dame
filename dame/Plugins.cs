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
            string uiPath = Path.ChangeExtension(Path.Combine(Constants.USER_INTERFACE_PLUGINS_DIRECTORY, uiName), "dll");
            Assembly uiAssembly = Assembly.LoadFile(uiPath);
            var uiClasses = uiAssembly.GetTypes().Where(t => t.BaseType == typeof(UserInterface));
            return (UserInterface)Activator.CreateInstance(uiClasses.First());
        }
    }
}

