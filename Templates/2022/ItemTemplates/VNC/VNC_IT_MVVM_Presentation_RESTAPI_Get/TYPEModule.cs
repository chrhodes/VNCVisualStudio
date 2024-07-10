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
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            _regionManager = regionManager;

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // 02

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_CATEGORY);

            //containerRegistry.Register<$xxxTYPExxx$MainViewModel>();
            containerRegistry.RegisterSingleton<$xxxTYPExxx$Main>();
            
            // containerRegistry.RegisterSingleton<I$xxxTYPExxx$LookupDataService, $xxxTYPExxx$LookupDataService>();
            // containerRegistry.Register<I$xxxTYPExxx$DataService, $xxxTYPExxx$DataService>();

            Log.MODULE("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_CATEGORY);

            // NOTE(crhodes)
            // using typeof(TYPE) calls constructor
            // using typeof(ITYPE) resolves type (see RegisterTypes)
            
            //this loads $xxxTYPExxx$Main into the Shell loaded in CreateShell() in App.Xaml.cs
            _regionManager.RegisterViewWithRegion(RegionNames.$xxxTYPExxx$MainRegion, typeof($xxxTYPExxx$Main));


            Log.MODULE("Exit", Common.LOG_CATEGORY, startTicks);
        }
        
        // TODO(crhodes)
        // Place these in Core\RegionNames.cs
        
        public static string $xxxTYPExxx$MainRegion = "$xxxTYPExxx$MainRegion";
        // public static string $xxxTYPExxx$NavigationRegion = "$xxxTYPExxx$NavigationRegion";
        // public static string $xxxTYPExxx$DetailRegion = "$xxxTYPExxx$DetailRegion";
        
        // TODO(crhodes)
        // Add this to App.xaml.cs - ConfigureModuleCatalog()
        
        moduleCatalog.AddModule(typeof($xxxTYPExxx$Module));
    }
}
