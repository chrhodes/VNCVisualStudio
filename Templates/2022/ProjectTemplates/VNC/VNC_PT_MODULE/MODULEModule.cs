using System;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using $xxxMODULExxx$.Core;

using $xxxMODULExxx$$xxxNAMESPACExxx$.DomainServices;
using $xxxMODULExxx$$xxxNAMESPACExxx$.Presentation.Views;
using $xxxMODULExxx$$xxxNAMESPACExxx$.Presentation.ViewModels;

using Unity;

using VNC;
using VNC.Core.Presentation.ViewModels;
using VNC.Core.Presentation.Views;
namespace $xxxMODULExxx$$xxxNAMESPACExxx$
{
    public class $xxxMODULExxx$Module : IModule
    {
        private readonly IRegionManager _regionManager;

        // 01

        public $xxxMODULExxx$Module(IRegionManager regionManager)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            _regionManager = regionManager;

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // 02

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_CATEGORY);
                       
            containerRegistry.Register<I$xxxITEMxxx$DetailViewModel, $xxxITEMxxx$DetailViewModel>();
            containerRegistry.RegisterSingleton<I$xxxITEMxxx$Detail, $xxxITEMxxx$Detail>();

			containerRegistry.Register<IViewABCViewModel, ViewABCViewModel>();
            containerRegistry.RegisterSingleton<IViewABC, ViewABC>();
            containerRegistry.RegisterSingleton<IViewABC, ViewA>();
            containerRegistry.RegisterSingleton<IViewABC, ViewB>();
            containerRegistry.RegisterSingleton<IViewABC, ViewC>();
            
            containerRegistry.RegisterSingleton<I$xxxITEMxxx$DataService, $xxxITEMxxx$DataService>();
            containerRegistry.RegisterSingleton<I$xxxITEMxxx$LookupDataService, $xxxITEMxxx$LookupDataService>();
			
            containerRegistry.RegisterDialog<OkCancelDialog, OkCancelDialogViewModel>("OkCancelDialog");			
                       
            // Figure out how to use one Type
            
            //containerRegistry.Register<IFriendLookupDataService, LookupDataService>();
            //containerRegistry.Register<IProgrammingLanguageLookupDataService, LookupDataService>();
            //containerRegistry.Register<IMeetingLookupDataService, LookupDataService>();

            Log.MODULE("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_CATEGORY);



            Log.MODULE("Exit", Common.LOG_CATEGORY, startTicks);
        }
    }
}
