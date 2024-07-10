using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using VNC;
using VNC.Core.Mvvm;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.Views
{
    public partial class ViewB : ViewBase, IViewABCD, IInstanceCountV
    {
        public ViewB()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.Constructor) startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InstanceCountV++;
            InitializeComponent();
            InitializeView();

            // Wire up ViewModel if needed

            // If View First with ViewModel in Xaml

            // ViewModel = (IViewABCViewModel)DataContext;

            // Can create directly

            // ViewModel = IViewABC$ViewModel();

            // Can use ourselves for everything

            //DataContext = this;

            // Or just a specific thing

            //tbViewMessage.DataContext = this;

            if (Common.VNCLogging.Constructor) Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public ViewB(ViewModels.IViewABCDViewModel viewModel)
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

            ViewMessage = "ViewMessage from ViewB";

            if (Common.VNCLogging.ViewLow) Log.VIEW_LOW("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public string ViewMessage { get; set; }

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
