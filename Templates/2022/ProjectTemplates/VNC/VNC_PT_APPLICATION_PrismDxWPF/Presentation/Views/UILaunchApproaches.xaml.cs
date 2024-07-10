using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.ViewModels;

using VNC;
using VNC.Core.Mvvm;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.Views
{
    public partial class UILaunchApproaches : ViewBase, IUILaunchApproaches, IInstanceCountV //, INotifyPropertyChanged
    {
        #region Constructors, Initialization, and Load
        
        public UILaunchApproaches()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.Constructor) startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InstanceCountV++;
            InitializeComponent();
            InitializeView();
            
            // Expose ViewModel
                        
            // If View First with ViewModel in Xaml

            // ViewModel = (IUILaunchApproachesViewModel)DataContext;

            // Can create directly
            
            // ViewModel = UILaunchApproachesViewModel();
            
            // Can use ourselves for everything

            //DataContext = this;

            // Or just a specific thing
            
            //tbViewMessage.DataContext = this;             

            if (Common.VNCLogging.Constructor) Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }
        
        public UILaunchApproaches(IUILaunchApproachesViewModel viewModel)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.Constructor) startTicks = Log.CONSTRUCTOR($"Enter viewModel({viewModel.GetType()})", Common.LOG_CATEGORY);

            InstanceCountVP++;
            InitializeComponent();

            ViewModel = viewModel;
            
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
