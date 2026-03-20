using System;
using System.Windows;

namespace $safeprojectname$.Actions
{
    public class Visio_Application
    {
        public static void DeveloperModeUI(Boolean developerUIMode)
        {
            if (developerUIMode)
            {
                Common.DeveloperUIMode = Visibility.Visible;
            }
            else
            {
                Common.DeveloperUIMode = Visibility.Collapsed;
            }
        }
    }
}
