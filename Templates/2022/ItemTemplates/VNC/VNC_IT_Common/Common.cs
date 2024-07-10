using System;
using System.Security.Principal;
using Prism.Events;
using $rootnamespace$.User_Interface;

namespace $rootnamespace$
{
    ///<summary>
    ///$safeitemname$ items declared at the Class level.
    ///</summary>
    ///<remarks>
    ///Use this class for any thing you want globally available.
    ///Place only Static items in this class.  This Class cannot not be instantiated.
    ///</remarks>  
    ///
    public class $safeitemname$
    {
        public const string PROJECT_NAME = "$rootnamespace$";
        public const string LOG_APPNAME = "$rootnamespace$";

        public const string cCONFIG_FILE = @"C:\temp\$rootnamespace$.xml";

        public static IEventAggregator EventAggregator = new EventAggregator();

        // These values are added to the dimensions of a hosting window if the
        // hosted User_Control specifies values for MinWidth/MinHeight.
        // They have not been thought through but do seem to "work".

        internal const int DEFAULT_WINDOW_LARGE_WIDTH = 1800;
        internal const int DEFAULT_WINDOW_LARGE_HEIGHT = 1200;

        internal const int DEFAULT_WINDOW_WIDTH = 900;
        internal const int DEFAULT_WINDOW_HEIGHT = 600;

        internal const int DEFAULT_WINDOW_SMALL_WIDTH = 450;
        internal const int DEFAULT_WINDOW_SMALL_HEIGHT = 300;

        internal const int WINDOW_HOSTING_USER_CONTROL_WIDTH_PAD = 30;
        internal const int WINDOW_HOSTING_USER_CONTROL_HEIGHT_PAD = 75;

        public static IPrincipal CurrentUser
        {
            get;
            set;
        }

        internal static string PriorStatusBar;

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

        // This controls the behavior of the overall application.
        // It is initialized from app.config and is updated when the user changes the mode.
        // Changes are reflected in the app.config file.

        public static ViewMode UserMode { get; set; }

        public static bool IsAdministrator { get; set; }
        public static bool IsBetaUser { get; set; }
        public static bool IsDeveloper { get; set; }
        //public static bool IsAdvancedUser { get; set; }

        public static bool AllowEditing { get; set; }

        public static string RowDetailMode { get; set; }

    }
}
