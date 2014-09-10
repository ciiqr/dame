using System;
using System.IO;
using System.Collections.Generic;

using dame.Utilities;

namespace dame
{
    class Program
    {
        public static void Main(string[] args)
        {
            // TODO: Move to the most appropriate place
            if (!Directory.Exists(Constants.USER_CONFIG_DIRECTORY))
                Directory.CreateDirectory(Constants.USER_CONFIG_DIRECTORY);

            // Parse options
            var options = ParseArguments(args);
            ValidateOptions(options);

            var controller = new Controller(options);
            controller.Run();
        }

        public static Dictionary<string, string> ParseArguments(string[] args)
        {
            var options = new  Dictionary<string, string>(StringComparer.Ordinal);

            for (int index = 0; index < args.Length; index++)
            {
                string arg = args[index];

                if (arg == "-h" || arg == "--help")
                {
                    PrintHelp();
                    Environment.Exit(ExitCode.SUCCESS);
                }
                else if (arg == ("--" + Constants.OPTIONS_USERNAME_KEY))
                {
                    index++;
                    if (index < arg.Length)
                        options[Constants.OPTIONS_USERNAME_KEY] = args[index];
                    else
                        ExitWithReason("Must provide username for " + Constants.OPTIONS_USERNAME_KEY);
                }
                else if (arg == ("--" + Constants.OPTIONS_UI_KEY))
                {
                    index++;
                    if (index < arg.Length)
                        options[Constants.OPTIONS_UI_KEY] = args[index];
                    else
                        ExitWithReason("Must provide uiType after " + Constants.OPTIONS_UI_KEY);
                }
                else
                {
                    PrintHelp();
                    ExitWithReason("Unknown argument");
                }
            }

            return options;
        }

        public static void PrintHelp()
        {
            Console.WriteLine("Dame: Evernote Client");
            Console.WriteLine("=====================");
            Console.WriteLine("-h | --help\tDisplay this menu");
            Console.WriteLine("--username\tEvernote username");
            Console.WriteLine("--ui\tUser interface type ie. gtk, qt, ncurses (only gtk supported atm)");
            Console.WriteLine("=====================");
        }

        public static void ExitWithReason(string reason)
        {
            Console.WriteLine(reason);
            Environment.Exit(ExitCode.FAILURE);
        }

        public static void ValidateOptions(Dictionary<string, string> options)
        {
            string username;
            string uiName;

            if (options.TryGetValue(Constants.OPTIONS_USERNAME_KEY, out username) && !DameUser.databaseExists(username)) // Uri.IsWellFormedUriString(username, UriKind.Absolute)
                ExitWithReason(String.Format("User database does not exist:{0}", username));

            if (options.TryGetValue(Constants.OPTIONS_UI_KEY, out uiName) && !Plugins.Plugins.uiExists(uiName))
                ExitWithReason(String.Format("UI plugin does not exist:{0}", uiName));
        }
    }
}

// Timers
// TODO: Check out System.Threading.Timer aswell
//Timer timer = new Timer(500);
////            timer.AutoReset = false; // Once
//timer.Elapsed += delegate
//{
//    Async.main(() =>
//    {
//        Console.WriteLine("TIME OUT!");
//    });
//};
//timer.Start();

// Enum Values
//Enum.GetValues(typeof(Sync.SyncState))

// Enum Names
//Enum.GetNames(typeof(Sync.SyncState))

// Basic time profiling
//var startTime = Environment.TickCount;
//...
//var endTime = Environment.TickCount;
//Console.WriteLine(endTime - startTime + "ms");