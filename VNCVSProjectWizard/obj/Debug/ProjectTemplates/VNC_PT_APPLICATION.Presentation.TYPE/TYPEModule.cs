using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using Unity;

using $customAPPLICATION$.Core;
using $customAPPLICATION$.DomainServices;

namespace $safeprojectname$
{
    public class $customTYPE$Module : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        // 01

        public $customTYPE$Module(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        // 02

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // TODO(crhodes)
            // Should we be registering stuff here and not in App.Xaml.cs
            _container.RegisterType<ViewModels.I$customTYPE$DetailViewModel, ViewModels.$customTYPE$DetailViewModel>();
            _container.RegisterType<Views.I$customTYPE$Detail, Views.$customTYPE$Detail>();

            _container.RegisterType<I$customTYPE$DataService, $customTYPE$DataService>();

            _container.RegisterType<ViewModels.I$customTYPE$ViewModel, ViewModels.$customTYPE$ViewModel>();
            _container.RegisterType<Views.I$customTYPE$, Views.$customTYPE$>();

            _container.RegisterType<I$customTYPE$LookupDataService, $customTYPE$LookupDataService>();
        }

        // 03

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.$customTYPE$Region, typeof(Views.$customTYPE$));
            _regionManager.RegisterViewWithRegion(RegionNames.$customTYPE$DetailRegion, typeof(Views.$customTYPE$Detail));
        }
    }
}