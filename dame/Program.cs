using System;
using System.Collections.Generic;

using dame.Utilities;

namespace dame
{
    class MainClass
    {
        public static void Main(string[] args)
        {
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
                else if (arg == ("--" + Constants.OPTIONS_DBPATH_KEY))
                {
                    index++;
                    if (index < arg.Length)
                        options[Constants.OPTIONS_DBPATH_KEY] = args[index];
                    else
                        ExitWithReason("Must provide path for " + Constants.OPTIONS_DBPATH_KEY);
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
            Console.WriteLine("--dbpath\tPath to database");
            Console.WriteLine("--ui\tUser interface type (ie. gtk, qt, ncurses)");
            Console.WriteLine("=====================");
        }

        public static void ExitWithReason(string reason)
        {
            Console.WriteLine(reason);
            Environment.Exit(ExitCode.FAILURE);
        }

        public static void ValidateOptions(Dictionary<string, string> options)
        {
            string dbpath;

            if (options.TryGetValue("dbpath", out dbpath) && !Uri.IsWellFormedUriString(dbpath, UriKind.Absolute))
                ExitWithReason(String.Format("Options is not a valid file path:{0}", dbpath));

            // TODO: Check if the given ui exists on disk?
//            bool UserInterfaceProxy.exists();
//            UserInterface UserInterfaceProxy.Load();
//            UserInterface UserInterfaceProxy.UnLoad();

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

// Directory's
//// User config
//String CONFIG_DIR = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "APPLICATION_NAME");
//Console.WriteLine("ApplicationData: " + CONFIG_DIR);
//// User folder, can then get .cache, or implemenet XDG.BaseDirectory
//Console.WriteLine("UserProfile: " + Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
//// Plugins
//Console.WriteLine("CommonApplicationData: " + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));

// Enum Values
//Enum.GetValues(typeof(Sync.SyncState))

// Enum Names
//Enum.GetNames(typeof(Sync.SyncState))

// Basic time profiling
//var startTime = Environment.TickCount;
//...
//var endTime = Environment.TickCount;
//Console.WriteLine(endTime - startTime + "ms");