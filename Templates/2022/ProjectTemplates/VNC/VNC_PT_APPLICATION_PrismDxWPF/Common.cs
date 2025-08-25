using System;

using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.Views;

using Prism.Events;
using Prism.Ioc;
using Prism.Regions;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$
{
    public class Common : VNC.WPF.Presentation.Common
    {
        public const string APPLICATION_NAME = "$xxxAPPLICATIONxxx$";
        public new const string LOG_CATEGORY = "$xxxAPPLICATIONxxx$";

        public const string cCONFIG_FILE = @"C:\temp\$xxxAPPLICATIONxxx$_Config.xml";
        
        // NOTE(crhodes)
        // Add new VNC.Core.Information InformationXXX
        // for other Assemblies that should provide Info
        // Initialize in App.xaml.cs GetAndSetInformation()
        //
        // Extend Views\AppVersionInfo.xaml as needed

        // public static VNC.Core.Information? InformationXXX;

        // HACK(crhodes)
        // Decide if want to keep this.
        // Put here to try to get in View and ViewModel can ask for in constructor

        public static IContainerProvider Container;
        public static IEventAggregator EventAggregator;
        public static IRegionManager DefaultRegionManager;

        public static Shell? CurrentShell;

        public static event EventHandler AutoHideGroupSpeedChanged;

        private static int _AutoHideGroupSpeed = 250;

        public static int AutoHideGroupSpeed
        {
            get { return _AutoHideGroupSpeed; }
            set
            {
                _AutoHideGroupSpeed = value;

                EventHandler evt = AutoHideGroupSpeedChanged;

                if (evt != null)
                {
                    evt(null, EventArgs.Empty); ;
                }
            }
        }

    }
}
