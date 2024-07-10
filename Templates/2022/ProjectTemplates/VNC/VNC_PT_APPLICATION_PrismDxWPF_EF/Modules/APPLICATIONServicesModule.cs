using System;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using VNC;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.DomainServices
{
    public class $xxxAPPLICATIONxxx$ServicesModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public $xxxAPPLICATIONxxx$ServicesModule(IRegionManager regionManager)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.Constructor) startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            _regionManager = regionManager;

            if (Common.VNCLogging.Constructor) Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ModuleInitialize) startTicks = Log.MODULE_INITIALIZE("Enter", Common.LOG_CATEGORY);

            // TODO(crhodes)
            // Maybe this is where we register the CustomPoolAndSpaDbContext

            //throw new NotImplementedException();

            if (Common.VNCLogging.ModuleInitialize) Log.MODULE(String.Format("Exit"), Common.LOG_CATEGORY, startTicks);
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ModuleInitialize) startTicks = Log.MODULE_INITIALIZE("Enter", Common.LOG_CATEGORY);

            // Load controls into regions, etc.
            // _containerProvider = containerProvider;

            if (Common.VNCLogging.ModuleInitialize) Log.MODULE_INITIALIZE("Exit", Common.LOG_CATEGORY, startTicks);
        }
    }
}
