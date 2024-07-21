﻿using System;
using System.Reflection;
using System.Threading;
using System.Windows;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;

using $xxxAPPLICATIONxxx$.Presentation.Views;

using VNC;
using VNC.Core.Presentation.ViewModels;
using VNC.Core.Presentation.Views;

namespace $xxxAPPLICATIONxxx$
{
    public partial class App : PrismApplication
    {
        #region Constructors, Initialization, and Load

        public App()
        {
#if DEBUG
            Common.InitializeLogging(debugConfig: true);
#else
            Common.InitializeLogging();
#endif
            
            // HACK(crhodes)
            // If don't delay a bit here, the SignalR logging infrastructure does not initialize quickly enough
            // and the first few log messages are missed.
            // NB.  All are properly recored in the log file.

            Int64 startTicks = 0;
            if (Common.VNCLogging.ApplicationStart) startTicks = Log.APPLICATION_START("Initialize SignalR", Common.LOG_CATEGORY);

            Thread.Sleep(150);

            if (Common.VNCLogging.ApplicationStart) Log.APPLICATION_START("App()", Common.LOG_CATEGORY, startTicks);
            
            // NOTE(crhodes)
            // Look at Application_Start event for things that should happen early.
            //try
            //{
            //    VerifyApplicationPrerequisites();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //    MessageBox.Show(ex.InnerException.ToString());
            //}

            // TODO(crhodes)
            // Should this go here or in VerifyApplicationPrerequisites

            if (Common.VNCLogging.ApplicationStart) Log.APPLICATION_START(String.Format("Exit"), Common.LOG_CATEGORY, startTicks);
        }        

        // 01

        protected override void ConfigureViewModelLocator()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ApplicationInitialize) startTicks = Log.APPLICATION_INITIALIZE("Enter", Common.LOG_CATEGORY);

            base.ConfigureViewModelLocator();

            if (Common.VNCLogging.ApplicationInitialize) Log.APPLICATION_INITIALIZE("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // 02

        protected override IContainerExtension CreateContainerExtension()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ApplicationInitialize) startTicks = Log.APPLICATION_INITIALIZE("Enter", Common.LOG_CATEGORY);

            if (Common.VNCLogging.ApplicationInitialize) Log.APPLICATION_INITIALIZE("Exit", Common.LOG_CATEGORY, startTicks);

            return base.CreateContainerExtension();
        }

        // 03 - Create the catalog of Modules

        protected override IModuleCatalog CreateModuleCatalog()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ApplicationInitialize) startTicks = Log.APPLICATION_INITIALIZE("Enter", Common.LOG_CATEGORY);

            if (Common.VNCLogging.ApplicationInitialize) Log.APPLICATION_INITIALIZE("Exit", Common.LOG_CATEGORY, startTicks);

            return base.CreateModuleCatalog();
        }

        // 04

        protected override void RegisterRequiredTypes(IContainerRegistry containerRegistry)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ApplicationInitialize) startTicks = Log.APPLICATION_INITIALIZE("Enter", Common.LOG_CATEGORY);

            base.RegisterRequiredTypes(containerRegistry);

            if (Common.VNCLogging.ApplicationInitialize) Log.APPLICATION_INITIALIZE("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // 05

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ApplicationInitialize) startTicks = Log.APPLICATION_INITIALIZE("Enter", Common.LOG_CATEGORY);

            //containerRegistry.RegisterSingleton<ICustomerDataService, CustomerDataServiceMock>();
            //containerRegistry.RegisterSingleton<IMaterialDataService, MaterialDataServiceMock>();

            // TODO(crhodes)
            // Think this is where we switch to using the Generic Repository.
            // But how to avoid pulling knowledge of EF Context in.  Maybe Service hides details
            // of
            //containerRegistry.RegisterSingleton<IAddressDataService, AddressDataService>();
            // AddressDataService2 has a constructor that takes a CustomPoolAndSpaDbContext.

            //containerRegistry.RegisterSingleton<I$xxxTYPExxx$LookupDataService, $xxxTYPExxx$LookupDataService>();

            // Common Dialogs used my most applications.

            containerRegistry.RegisterDialog<NotificationDialog, NotificationDialogViewModel>("NotificationDialog");
            containerRegistry.RegisterDialog<OkCancelDialog, OkCancelDialogViewModel>("OkCancelDialog");

            // Add the new UI elements

            if (Common.VNCLogging.ApplicationInitialize) Log.APPLICATION_INITIALIZE("Exit", Common.LOG_CATEGORY, startTicks);
        }

        //NOTE(crhodes)
        // This has been removed in Prism 8.0

        // 06

        // protected override void ConfigureServiceLocator()
        // {
            // Int64 startTicks = Log.APPLICATION_INITIALIZE("Enter", Common.LOG_CATEGORY);

            // base.ConfigureServiceLocator();

            // Log.APPLICATION_INITIALIZE("Exit", Common.LOG_CATEGORY, startTicks);
        // }

        // 07 - Configure the catalog of modules
        // Modules are loaded at Startup and must be a project reference

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ApplicationInitialize) startTicks = Log.APPLICATION_INITIALIZE("Enter", Common.LOG_CATEGORY);

            //NOTE(crhodes)
            // Order matters here.  Application depends on types in $xxxTYPExxx$
#if VNCTYPES            
            moduleCatalog.AddModule(typeof($xxxTYPExxx$Module));
#endif
            moduleCatalog.AddModule(typeof($xxxAPPLICATIONxxx$Module));

            if (Common.VNCLogging.ApplicationInitialize)Log.APPLICATION_INITIALIZE("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // 08

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ApplicationInitialize) startTicks = Log.APPLICATION_INITIALIZE("Enter", Common.LOG_CATEGORY);

            base.ConfigureRegionAdapterMappings(regionAdapterMappings);

            if (Common.VNCLogging.ApplicationInitialize)Log.APPLICATION_INITIALIZE("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // 09

        protected override void ConfigureDefaultRegionBehaviors(IRegionBehaviorFactory regionBehaviors)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ApplicationInitialize) startTicks = Log.APPLICATION_INITIALIZE("Enter", Common.LOG_CATEGORY);

            base.ConfigureDefaultRegionBehaviors(regionBehaviors);

            if (Common.VNCLogging.ApplicationInitialize)Log.APPLICATION_INITIALIZE("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // 10

        protected override void RegisterFrameworkExceptionTypes()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ApplicationInitialize) startTicks = Log.APPLICATION_INITIALIZE("Enter", Common.LOG_CATEGORY);

            base.RegisterFrameworkExceptionTypes();
            
            if (Common.VNCLogging.ApplicationInitialize)Log.APPLICATION_INITIALIZE("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // 11

        protected override Window CreateShell()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ApplicationInitialize) startTicks = Log.APPLICATION_INITIALIZE("Enter", Common.LOG_CATEGORY);

            // TODO(crhodes)
            // Figure out how early we can save Container

            Common.Container = Container;   

            if (Common.VNCLogging.ApplicationInitialize)Log.APPLICATION_INITIALIZE("Exit", Common.LOG_CATEGORY, startTicks);

            // TODO(crhodes)
            // Pick the shell to start with.

            return Container.Resolve<Shell>();
            // return Container.Resolve<RibbonShell>();

            // NOTE(crhodes)
            // The type of view to load into the shell is handled in $xxxAPPLICATIONxxx$Module.cs
        }

        // 12

        protected override void InitializeShell(Window shell)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ApplicationInitialize) startTicks = Log.APPLICATION_INITIALIZE("Enter", Common.LOG_CATEGORY);

            base.InitializeShell(shell);

            if (Common.VNCLogging.ApplicationInitialize)Log.APPLICATION_INITIALIZE("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // 13

        protected override void InitializeModules()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ApplicationInitialize) startTicks = Log.APPLICATION_INITIALIZE("Enter", Common.LOG_CATEGORY);

            base.InitializeModules();

            if (Common.VNCLogging.ApplicationInitialize)Log.APPLICATION_INITIALIZE("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Enums (none)


        #endregion

        #region Structures (none)


        #endregion

        #region Fields and Properties (none)


        #endregion

        #region Event Handlers

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);

            try
            {
                GetAndSetInformation();
                VerifyApplicationPrerequisites();
                InitializeApplication();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show(ex.InnerException.ToString());
            }

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void GetAndSetInformation()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ApplicationInitialize) startTicks = Log.APPLICATION_INITIALIZE("Enter", Common.LOG_CATEGORY);
            
            // Get Information about VNC.Core

            Common.SetVersionInfoVNCCore();

            var appFileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);

            // Get Information about ourselves

            Common.SetVersionInfoApplication(Assembly.GetExecutingAssembly(), appFileVersionInfo);
            
            if (Common.VNCLogging.ApplicationInitialize)Log.APPLICATION_INITIALIZE("Exit", Common.LOG_CATEGORY, startTicks);            
        }

        private void VerifyApplicationPrerequisites()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ApplicationInitialize) startTicks = Log.APPLICATION_INITIALIZE("Enter", Common.LOG_CATEGORY);
            
            //TODO(crhodes)
            // Add any necessary checks for config files, etc
            // That are required by application

            if (Common.VNCLogging.ApplicationInitialize)Log.APPLICATION_INITIALIZE("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void InitializeApplication()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ApplicationInitialize) startTicks = Log.APPLICATION_INITIALIZE("Enter", Common.LOG_CATEGORY);
            
            //TODO(crhodes)
            // Perform any required Initialization.

#if DEBUG
                Common.DeveloperMode = true;
                Common.DeveloperUIMode = Visibility.Visible;
                //Common.DeveloperUIMode = Visibility.Hidden;
                //Common.DeveloperUIMode = Visibility.Collapsed;
#else
            Common.DeveloperMode = false;
            Common.DeveloperUIMode = Visibility.Collapsed;  // No space reserved
#endif

            if (Common.VNCLogging.ApplicationInitialize)Log.APPLICATION_INITIALIZE("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void Application_Activated(object sender, EventArgs e)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);


            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void Application_Deactivated(object sender, EventArgs e)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.APPLICATION_END("Enter", Common.LOG_CATEGORY);


            if (Common.VNCLogging.EventHandler) Log.APPLICATION_END("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);


            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void Application_SessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER($"Enter: ReasonSessionEnding:({e.ReasonSessionEnding})", Common.LOG_CATEGORY);


            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void Application_DispatcherUnhandledException(object sender,
            System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Log.Error("Unexpected error occurred. Please inform the admin."
              + Environment.NewLine + e.Exception.Message, Common.LOG_CATEGORY);

            MessageBox.Show("Unexpected error occurred. Please inform the admin."
              + Environment.NewLine + e.Exception.Message, "Unexpected error");

            e.Handled = true;
        }

        #endregion

        #region Public Methods (none)


        #endregion

        #region Protected Methods (none)


        #endregion

        #region Private Methods (none)


        #endregion
    }
}
