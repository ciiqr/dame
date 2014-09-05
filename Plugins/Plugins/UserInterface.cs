using System;

namespace dame.Plugins
{
    public abstract class UserInterface
    {
        abstract public void runMainLoop();
        abstract public void stopMainLoop();

        // Loading Indicator (HUD (Loading indicator & text) style)
        // Keybinding creator, preferably using a delegate which is passed with the creation code

        // Windows
        // Menubars
        // Toolbars
        // etc

        // Lots of Events aswell
    }
}

