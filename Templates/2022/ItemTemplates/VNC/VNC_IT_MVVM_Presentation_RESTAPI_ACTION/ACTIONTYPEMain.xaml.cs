using System;

using VNC;
using VNC.Core.Mvvm;

namespace $xxxAPPLICATIONxxx$.$xxxNAMESPACExxx$.Presentation.Views
{
    public partial class $xxxACTIONxxx$$xxxTYPExxx$Main : ViewBase, I$xxxACTIONxxx$$xxxTYPExxx$Main, IInstanceCountV
    {

        public $xxxACTIONxxx$$xxxTYPExxx$Main(ViewModels.I$xxxACTIONxxx$$xxxTYPExxx$MainViewModel viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            InstanceCountV++;
            InitializeComponent();

            ViewModel = viewModel;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }
       
        #region IInstanceCount

        private static int _instanceCountV;

        public int InstanceCountV
        {
            get => _instanceCountV;
            set => _instanceCountV = value;
        }

        #endregion

    }
}
