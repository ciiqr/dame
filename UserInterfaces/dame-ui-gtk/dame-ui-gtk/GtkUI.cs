using System;

using dame.Plugins;

namespace dameuigtk
{
    public class GtkUI : UserInterface
    {
        // TODO: Determine how to use a custom application
        private Gtk.Application application = new Gtk.Application("ca.williamvilleneuve.dame", GLib.ApplicationFlags.None);

        private Gtk.Window window;

        public GtkUI()
        {
            Gtk.Application.Init();

            application.Activated += onActivated;
        }

        private void onActivated(object sender, EventArgs e)
        {
            window = new Gtk.Window("Dame - Oh Yeah!");
            window.DeleteEvent += onWindowDeleted;
            window.ShowAll();
        }

        public void onWindowDeleted(object o, Gtk.DeleteEventArgs args)
        {
            // TODO: Debug only, have event to callback
            stopMainLoop();
        }
    
        public override void runMainLoop()
        {
            // TODO: Idk if this is correct...
            application.Run(0, "");
            Gtk.Application.Run();
        }

        public override void stopMainLoop()
        {
            Gtk.Application.Quit();
        }
    }
}

