using System;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using Unity;

using $xxxAPPLICATIONxxx$.Core;
using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.DomainServices;
using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.Views;
using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.ViewModels;

using VNC;
namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$
{
    public class $xxxTYPExxx$Module : IModule
    {
        private readonly IRegionManager _regionManager;

        // 01

        public $xxxTYPExxx$Module(IRegionManager regionManager)
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

            containerRegistry.RegisterSingleton<I$xxxTYPExxx$MainViewModel, $xxxTYPExxx$MainViewModel>();
            containerRegistry.RegisterSingleton<I$xxxTYPExxx$Main, $xxxTYPExxx$Main>();

            containerRegistry.RegisterSingleton<I$xxxTYPExxx$NavigationViewModel, $xxxTYPExxx$NavigationViewModel>();
            containerRegistry.RegisterSingleton<I$xxxTYPExxx$Navigation, $xxxTYPExxx$Navigation>();

            containerRegistry.Register<I$xxxTYPExxx$DetailViewModel, $xxxTYPExxx$DetailViewModel>();
            containerRegistry.RegisterSingleton<I$xxxTYPExxx$Detail, $xxxTYPExxx$Detail>();

            containerRegistry.RegisterSingleton<I$xxxTYPExxx$LookupDataService, $xxxTYPExxx$LookupDataService>();
            containerRegistry.Register<I$xxxTYPExxx$DataService, $xxxTYPExxx$DataService>();

            if (Common.VNCLogging.ModuleInitialize) Log.MODULE_INITIALIZE("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ModuleInitialize) startTicks = Log.MODULE_INITIALIZE("Enter", Common.LOG_CATEGORY);

            // NOTE(crhodes)
            // using typeof(TYPE) calls constructor
            // using typeof(ITYPE) resolves type (see RegisterTypes)

            //this loads $xxxTYPExxx$Main into the Shell loaded in CreateShell() in App.Xaml.cs
            _regionManager.RegisterViewWithRegion(RegionNames.$xxxTYPExxx$MainRegion, typeof(I$xxxTYPExxx$Main));

            // These load into $xxxTYPExxx$Main.xaml
            _regionManager.RegisterViewWithRegion(RegionNames.$xxxTYPExxx$NavigationRegion, typeof(I$xxxTYPExxx$Navigation));
            _regionManager.RegisterViewWithRegion(RegionNames.$xxxTYPExxx$DetailRegion, typeof(I$xxxTYPExxx$Detail));

            if (Common.VNCLogging.ModuleInitialize) Log.MODULE_INITIALIZE("Exit", Common.LOG_CATEGORY, startTicks);
        }
    }
}
