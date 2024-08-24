using System;
using System.Linq;

using Prism.Regions;

using VNC;
using VNC.Core.Mvvm;
using VNC.Core.Mvvm.Prism;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.Views
{
    public partial class $xxxTYPExxx$DetailMV : ViewBase, I$xxxTYPExxx$DetailMV, INavigationAware, IInstanceCountV
    {
        #region Constructors, Initialization, and Load

        public $xxxTYPExxx$DetailMV()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.Constructor) startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InstanceCountV++;

            InitializeComponent();

            // Wire up ViewModel if needed

            // If View First with ViewModel in Xaml

            // ViewModel = (I$xxxTYPExxx$DetailViewModel)DataContext;

            // Can create directly

            // ViewModel = new $xxxTYPExxx$DetailViewModel();

            // Can use ourselves for everything

            //DataContext = this;

            InitializeView();

            if (Common.VNCLogging.Constructor) Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public $xxxTYPExxx$DetailMV(ViewModels.I$xxxTYPExxx$DetailMVViewModel viewModel)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.Constructor) startTicks = Log.CONSTRUCTOR($"Enter ({viewModel.GetType()})", Common.LOG_CATEGORY);

            InstanceCountVP++;

            InitializeComponent();

            ViewModel = viewModel;  // ViewBase sets the DataContext to ViewModel

            // For the rare case where the ViewModel needs to know about the View
            // ViewModel.View = this;

            InitializeView();

            if (Common.VNCLogging.Constructor) Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void InitializeView()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ViewLow) startTicks = Log.VIEW_LOW("Enter", Common.LOG_CATEGORY);

            // NOTE(crhodes)
            // Put things here that initialize the View
            // Hook eventhandlers, etc.

            ViewType = this.GetType().ToString().Split('.').Last();

            // HACK(crhodes)
            // Not sure when is best time to do this
            //
            // Well not here because it creates a loop

            //IRegionManager regionManager = (RegionManager)Common.Container.Resolve(typeof(RegionManager));

            //IRegionManager regionManager2 = Common.DefaultRegionManager;

            //var regions = regionManager.Regions;
            //var regions2 = regionManager2.Regions;

            ////RegionManager _regionManager = (RegionManager)Common.Container.Resolve(typeof(RegionManager));
            ////var regions = _regionManager.Regions;

            ////IRegion region = _regionManager.Regions["MultiStepProcessViewMV"];
            ////region.RequestNavigate("uicatdetaila");

            ////_regionManager.RequestNavigate("MultiStepProcessViewMV", "uicatdetaila");

            //// Establish any additional DataContext(s), e.g. to things held in this View

            //var ok = regions2.ContainsRegionWithName(RegionNames.MultiStepProcessViewMV);

            // Establish any additional DataContext(s), e.g. to things held in this View

            if (Common.VNCLogging.ViewLow) Log.VIEW_LOW("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        #endregion

        #region Enums (none)


        #endregion

        #region Structures (none)


        #endregion

        #region Fields and Properties (none)


        #endregion

        #region Event Handlers (none)


        #endregion

        #region Commands (none)

        #endregion

        #region Public Methods (none)


        #endregion

        #region Protected Methods (none)


        #endregion

        #region Private Methods (none)


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
