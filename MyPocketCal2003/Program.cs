using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyPocketCal2003
{
    static class Program
    {
        static public Form activeWindow;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            activeWindow = new MainDisplay();
            Application.Run(activeWindow);
        }
    }
}