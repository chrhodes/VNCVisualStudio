using System;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using VNC;

namespace $xxxMODULExxx$$xxxNAMESPACExxx$.DomainServices
{
    public class $xxxMODULExxx$ServicesModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public $xxxMODULExxx$ServicesModule(IRegionManager regionManager)
        {
            Int64 startTicks = Log.CONSTRUCTOR(String.Format("Enter"), Common.LOG_CATEGORY);

            _regionManager = regionManager;

            Log.CONSTRUCTOR(String.Format("Exit"), Common.LOG_CATEGORY, startTicks);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Int64 startTicks = Log.MODULE(String.Format("Enter"), Common.LOG_CATEGORY);

            // TODO(crhodes)
            // Maybe this is where we register the CustomPoolAndSpaDbContext

            //throw new NotImplementedException();

            Log.MODULE(String.Format("Exit"), Common.LOG_CATEGORY, startTicks);
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            Int64 startTicks = Log.MODULE("Enter", Common.LOG_CATEGORY);

            // Load controls into regions, etc.
            // _containerProvider = containerProvider;

            Log.MODULE(String.Format("Exit"), Common.LOG_CATEGORY, startTicks);
        }
    }
}
