using System;

using VNC;
using VNC.Core.Mvvm;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.Views
{
    public partial class $xxxTYPExxx$Navigation : ViewBase, I$xxxTYPExxx$Navigation, IInstanceCountV
    {
        public $xxxTYPExxx$Navigation()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.Constructor) startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InstanceCountV++;
            InitializeComponent();
            InitializeView();

            if (Common.VNCLogging.Constructor) Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void InitializeView()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ViewLow) startTicks = Log.VIEW_LOW("Enter", Common.LOG_CATEGORY);

            // NOTE(crhodes)
            // Put things here that initialize the View

            if (Common.VNCLogging.ViewLow) Log.VIEW_LOW("Exit", Common.LOG_CATEGORY, startTicks);
        }
        
        #region IInstanceCount

        private static int _instanceCountV;

        public int InstanceCountV
        {
            get => _instanceCountV;
            set => _instanceCountV = value;
        }
        
        private static int _instanceCountVP;

        public int InstanceCountVP
        {
            get => _instanceCountVP;
            set => _instanceCountVP = value;
        }        

        #endregion

    }
}
