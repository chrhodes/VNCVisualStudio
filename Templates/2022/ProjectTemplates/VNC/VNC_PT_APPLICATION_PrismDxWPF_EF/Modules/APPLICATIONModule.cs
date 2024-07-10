using System;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using $xxxAPPLICATIONxxx$.Core;

#if VNCEF
using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.DomainServices;
#endif
using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.Views;
using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.ViewModels;

using Unity;

using VNC;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$
{
    public class $xxxAPPLICATIONxxx$Module : IModule
    {
        private readonly IRegionManager _regionManager;

        // 01

        public $xxxAPPLICATIONxxx$Module(IRegionManager regionManager)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.Constructor) startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            _regionManager = regionManager;

            if (Common.VNCLogging.Constructor) Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // 02

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ModuleInitialize) startTicks = Log.MODULE_INITIALIZE("Enter", Common.LOG_CATEGORY);

            // TODO(crhodes)
            // This is where you pick the style of what gets loaded in the Shell.

            // If you are using the Ribbon Shell and the RibbonRegion

            containerRegistry.RegisterSingleton<IRibbonViewModel, RibbonViewModel>();
            containerRegistry.RegisterSingleton<IRibbon, Ribbon>();

            // Pick one of these for the MainRegion

            //containerRegistry.Register<IMain, Main>();
            containerRegistry.Register<IMain, MainDxLayoutControl>();
            //containerRegistry.Register<IMain, MainDxDockLayoutManager>();

            containerRegistry.Register<StatusBar>();

#if VNCEF
            containerRegistry.Register<ICombinedMainViewModel, CombinedMainViewModel>();
            containerRegistry.RegisterSingleton<ICombinedMain, CombinedMain>();

            containerRegistry.Register<ICombinedNavigationViewModel, CombinedNavigationViewModel>();
            containerRegistry.RegisterSingleton<ICombinedNavigation, CombinedNavigation>();

            containerRegistry.Register<I$xxxITEMxxx$DetailViewModel, $xxxITEMxxx$DetailViewModel>();
            containerRegistry.RegisterSingleton<I$xxxITEMxxx$Detail, $xxxITEMxxx$Detail>();

            containerRegistry.RegisterSingleton<I$xxxITEMxxx$DataService, $xxxITEMxxx$DataService>();
            containerRegistry.RegisterSingleton<I$xxxITEMxxx$LookupDataService, $xxxITEMxxx$LookupDataService>();
            
#endif            

            // This shows the AutoWire ViewModel in action.

            containerRegistry.Register<ViewCViewModel>();

            containerRegistry.Register<ViewA>();
            containerRegistry.Register<ViewB>();
            containerRegistry.Register<ViewC>();
            containerRegistry.Register<ViewD>();

            containerRegistry.Register<IViewABCDViewModel, ViewABCDViewModel>();
            containerRegistry.Register<IViewABCD, ViewABCD>();

            containerRegistry.Register<IUILaunchApproachesViewModel, UILaunchApproachesViewModel>();
            containerRegistry.Register<UILaunchApproaches>();

            // Figure out how to use one Type

            //containerRegistry.Register<IFriendLookupDataService, LookupDataService>();
            //containerRegistry.Register<IProgrammingLanguageLookupDataService, LookupDataService>();
            //containerRegistry.Register<IMeetingLookupDataService, LookupDataService>();

            if (Common.VNCLogging.ModuleInitialize) Log.MODULE_INITIALIZE("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ModuleInitialize) startTicks = Log.MODULE_INITIALIZE("Enter", Common.LOG_CATEGORY);

            _regionManager.RegisterViewWithRegion(RegionNames.RibbonRegion, typeof(IRibbon));
            _regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(IMain));
            _regionManager.RegisterViewWithRegion(RegionNames.StatusBarRegion, typeof(StatusBar));
            
            _regionManager.RegisterViewWithRegion(RegionNames.VNCLoggingConfigRegion, typeof(VNC.WPF.Presentation.Dx.Views.VNCLoggingConfig));
            _regionManager.RegisterViewWithRegion(RegionNames.VNCCoreLoggingConfigRegion, typeof(VNC.WPF.Presentation.Dx.Views.VNCCoreLoggingConfig));

#if VNCEF
            // This loads CombinedMain into the IMain configured
            // in RegisterTypes (MainDxLayout or MainDxDocLayoutManager), supra

            _regionManager.RegisterViewWithRegion(RegionNames.CombinedMainRegion, typeof(ICombinedMain));

            _regionManager.RegisterViewWithRegion(RegionNames.CombinedNavigationRegion, typeof(ICombinedNavigation));
            
#endif

            // This is for Main

            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ViewA));

            // and AutoWireViewModel demo

            _regionManager.RegisterViewWithRegion(RegionNames.ViewABCDRegion, typeof(IViewABCD));
            _regionManager.RegisterViewWithRegion(RegionNames.ViewARegion, typeof(ViewA));
            _regionManager.RegisterViewWithRegion(RegionNames.ViewBRegion, typeof(ViewB));
            _regionManager.RegisterViewWithRegion(RegionNames.ViewCRegion, typeof(ViewC));
            _regionManager.RegisterViewWithRegion(RegionNames.ViewDRegion, typeof(ViewD));
            
            _regionManager.RegisterViewWithRegion(RegionNames.UILaunchApproaches, typeof(UILaunchApproaches));            

            if (Common.VNCLogging.ModuleInitialize) Log.MODULE_INITIALIZE("Exit", Common.LOG_CATEGORY, startTicks);
        }
    }
}
