using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.ViewModels;

using VNC;
using VNC.Core.Mvvm;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.Views
{
    public partial class AppVersionInfo : ViewBase, IInstanceCountV
    {
        #region Constructors, Initialization, and Load

        public AppVersionInfo()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.Constructor) startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InstanceCountV++;
            InitializeComponent();
            InitializeView();

            // Expose ViewModel

            // If View First with ViewModel in Xaml

            // ViewModel = (IAppVersionInfoViewModel)DataContext;

            // Can create directly
            // ViewModel = AppVersionInfoViewModel();

            if (Common.VNCLogging.Constructor) Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        //public AppVersionInfo(IAppVersionInfoViewModel viewModel)
        //{
        //    Int64 startTicks = 0;
        //    if (Common.VNCLogging.Constructor) startTicks = Log.CONSTRUCTOR($"Enter viewModel({viewModel.GetType()}", Common.LOG_CATEGORY);

        //    InstanceCountV++;
        //    InitializeComponent();
        //    InitializeView();

        //    ViewModel = viewModel;

        //    InitializeView();

        //    if (Common.VNCLogging.Constructor) Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        //}

        private void InitializeView()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ViewLow) startTicks = Log.VIEW_LOW("Enter", Common.LOG_CATEGORY);

            // NOTE(crhodes)
            // Put things here that initialize the View

            if (Common.VNCLogging.ViewLow) Log.VIEW_LOW("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

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
