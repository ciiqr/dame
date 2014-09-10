using System;

namespace dame.Plugins
{
    public delegate void UserInterfaceMainLoopInitialized(UserInterface sender);

    public abstract class UserInterface
    {
        public abstract event UserInterfaceMainLoopInitialized mainLoopInitializedEvent;

        abstract public void runMainLoop();
        abstract public void stopMainLoop();

        // Loading Indicator (HUD (Loading indicator & text) style)
        // Keybinding creator, preferably using a delegate which is passed with the creation code

        // Windows
        // Menubars
        // Toolbars
        // etc
    }
}

