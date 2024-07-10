using System;

using VNC;
using VNC.Core.Mvvm;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.Views
{
    public partial class $xxxITEMxxx$Detail : ViewBase, I$xxxITEMxxx$Detail, IInstanceCountV
    {

        public $xxxITEMxxx$Detail()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.Constructor) startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InstanceCountV++;
            InitializeComponent();
            InitializeView();

            if (Common.VNCLogging.Constructor) Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public $xxxITEMxxx$Detail(ViewModels.I$xxxITEMxxx$DetailViewModel viewModel)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.Constructor) startTicks = Log.CONSTRUCTOR($"Enter viewModel({viewModel.GetType()})", Common.LOG_CATEGORY);

            InstanceCountVP++;
            InitializeComponent();
            InitializeView();
            
            ViewModel = viewModel;

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
