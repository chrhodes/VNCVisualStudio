using System;
using System.Windows.Input;

using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;

using VNC;
using VNC.Core.Mvvm;
using VNC.WPF.Presentation.Views;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.ViewModels
{
    public class RegionNavigationViewModel : EventViewModelBase, IRegionNavigationViewModel, IInstanceCountVM
    {
        #region Constructors, Initialization, and Load

        private readonly IRegionManager _regionManager;

        public RegionNavigationViewModel(
            IRegionManager regionManager,
            IEventAggregator eventAggregator,
            IDialogService dialogService) : base(eventAggregator, dialogService)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.Constructor) startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            // TODO(crhodes)
            // Save constructor parameters here

            _regionManager = regionManager;

            InstanceCountVM++;

            InitializeViewModel();

            if (Common.VNCLogging.Constructor) Log.CONSTRUCTOR($"Exit VM:{InstanceCountVM}", Common.LOG_CATEGORY, startTicks);
        }

        private void InitializeViewModel()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ViewModelLow) startTicks = Log.VIEWMODEL_LOW("Enter", Common.LOG_CATEGORY);

            // NOTE(crhodes)
            // Put things here that initialize the ViewModel
            // Initialize EventHandlers, Commands, etc.

            NavigateUI1Command = new DelegateCommand<string>(NavigateUI1, NavigateUI1CanExecute);
            NavigateUI2Command = new DelegateCommand<string>(NavigateUI2, NavigateUI2CanExecute);
            NavigateUI3Command = new DelegateCommand<string>(NavigateUI3, NavigateUI3CanExecute);
            NavigateUI4Command = new DelegateCommand<string>(NavigateUI4, NavigateUI4CanExecute);
            NavigateUI5Command = new DelegateCommand<string>(NavigateUI5, NavigateUI5CanExecute);

            Message = "RegionNavigationViewModel says hello";

            if (Common.VNCLogging.ViewModelLow) Log.VIEWMODEL_LOW("Exit", Common.LOG_CATEGORY, startTicks);
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

        #region Public Methods (none)



        #endregion

        #region Commands

        #region NavigateUI1 Command

        public DelegateCommand<string> NavigateUI1Command { get; set; }

        // If displaying UserControl
        // public static WindowHost _NavigateUI1Host = null;

        // If using CommandParameter, figure out TYPE here
        public string NavigateUI1CommandParameter;

        public string NavigateUI1Content { get; set; } = "NavigateUI1";
        public string NavigateUI1ToolTip { get; set; } = "NavigateUI1 Add ToolTip";
        public string NavigateUI1BetaContent { get; set; } = "NavigateUI1 Beta";
        public string NavigateUI1BetaToolTip { get; set; } = "NavigateUI1 Beta ToolTip";

        // Can get fancy and use Resources
        //public string NavigateUI1Content { get; set; } = "ViewName_NavigateUI1Content";
        //public string NavigateUI1ToolTip { get; set; } = "ViewName_NavigateUI1ContentToolTip";

        // Put these in Resource File
        //    <system:String x:Key="ViewName_NavigateUI1Content">NavigateUI1</system:String>
        //    <system:String x:Key="ViewName_NavigateUI1ContentToolTip">NavigateUI1 ToolTip</system:String>

        // If using CommandParameter, figure out TYPE here
        //public void NavigateUI1(TYPE value)
        public void NavigateUI1(string action)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);
            // TODO(crhodes)
            // Do something amazing.

            Message = $"Cool, you called NavigateUI1 {action}";

            PublishStatusMessage(Message);

            switch (action)
            {
                case "beta":
                    _regionManager.RequestNavigate("RegionNavigationView", "UI1beta");
                    break;

                default:
                    _regionManager.RequestNavigate("RegionNavigationView", "UI1");

                    // Or this way

                    //IRegion region = _regionManager.Regions["RegionNavigationView"];

                    //region.RequestNavigate("UI1");
                    break;
            }

            //IRegion region = _regionManager.Regions[RegionNames.ViewNavigationView];

            //switch (action)
            //{
            //    case "add":
            //        UI1 = new UI1();
            //        region.Add(UI1);
            //        NavigateUI1Command.RaiseCanExecuteChanged();
            //        ModifyUI1Command.RaiseCanExecuteChanged();
            //        RemoveUI1Command.RaiseCanExecuteChanged();
            //        break;
            //}

            // If launching a UserControl

            // if (_NavigateUI1Host is null) _NavigateUI1nHost = new WindowHost();
            // var userControl = new USERCONTROL();

            // _loggingConfigurationHost.DisplayUserControlInHost(
            //     "TITLE GOES HERE",
            //     //Common.DEFAULT_WINDOW_WIDTH,
            //     //Common.DEFAULT_WINDOW_HEIGHT,
            //     (Int32)userControl.Width + Common.WINDOW_HOSTING_USER_CONTROL_WIDTH_PAD,
            //     (Int32)userControl.Height + Common.WINDOW_HOSTING_USER_CONTROL_HEIGHT_PAD,
            //     ShowWindowMode.Modeless_Show,
            //     userControl);

            // Uncomment this if you are telling someone else to handle this

            // Common.EventAggregator.GetEvent<NavigateUI1Event>().Publish();

            // May want EventArgs

            //  EventAggregator.GetEvent<NavigateUI1Event>().Publish(
            //      new NavigateUI1EventArgs()
            //      {
            //            Organization = _collectionMainViewModel.SelectedCollection.Organization,
            //            Process = _contextMainViewModel.Context.SelectedProcess
            //      });

            // Start Cut Four - Put this in PrismEvents

            // public class NavigateUI1Event : PubSubEvent { }

            // End Cut Four

            // Start Cut Five - Put this in places that listen for event

            //Common.EventAggregator.GetEvent<NavigateUI1Event>().Subscribe(NavigateUI1);

            // End Cut Five

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // If using CommandParameter, figure out TYPE and fix above
        //public bool NavigateUI1CanExecute(TYPE value)
        public bool NavigateUI1CanExecute(string action)
        {
            // TODO(crhodes)
            // Add any before button is enabled logic.

            return true;
        }

        #endregion

        #region NavigateUI2 Command

        public DelegateCommand<string> NavigateUI2Command { get; set; }

        // If displaying UserControl
        // public static WindowHost _NavigateUI2Host = null;

        // If using CommandParameter, figure out TYPE here
        public string NavigateUI2CommandParameter;

        public string NavigateUI2Content { get; set; } = "NavigateUI2";
        public string NavigateUI2ToolTip { get; set; } = "NavigateUI2 Add ToolTip";
        public string NavigateUI2BetaContent { get; set; } = "NavigateUI2 Beta";
        public string NavigateUI2BetaToolTip { get; set; } = "NavigateUI2 Beta ToolTip";

        // Can get fancy and use Resources
        //public string NavigateUI2Content { get; set; } = "ViewName_NavigateUI2Content";
        //public string NavigateUI2ToolTip { get; set; } = "ViewName_NavigateUI2ContentToolTip";

        // Put these in Resource File
        //    <system:String x:Key="ViewName_NavigateUI2Content">NavigateUI2</system:String>
        //    <system:String x:Key="ViewName_NavigateUI2ContentToolTip">NavigateUI2 ToolTip</system:String>

        // If using CommandParameter, figure out TYPE here
        //public void NavigateUI2(TYPE value)
        public void NavigateUI2(string action)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);
            // TODO(crhodes)
            // Do something amazing.

            Message = $"Cool, you called NavigateUI2 {action}";

            PublishStatusMessage(Message);

            switch (action)
            {
                case "beta":
                    _regionManager.RequestNavigate("RegionNavigationView", "UI2beta");
                    break;

                default:
                    //_regionManager.RequestNavigate("RegionNavigationView", "UI2");

                    // Or this way

                    IRegion region = _regionManager.Regions["RegionNavigationView"];

                    region.RequestNavigate("UI2");
                    break;
            }

            // If launching a UserControl

            // if (_NavigateUI2Host is null) _NavigateUI2nHost = new WindowHost();
            // var userControl = new USERCONTROL();

            // _loggingConfigurationHost.DisplayUserControlInHost(
            //     "TITLE GOES HERE",
            //     //Common.DEFAULT_WINDOW_WIDTH,
            //     //Common.DEFAULT_WINDOW_HEIGHT,
            //     (Int32)userControl.Width + Common.WINDOW_HOSTING_USER_CONTROL_WIDTH_PAD,
            //     (Int32)userControl.Height + Common.WINDOW_HOSTING_USER_CONTROL_HEIGHT_PAD,
            //     ShowWindowMode.Modeless_Show,
            //     userControl);

            // Uncomment this if you are telling someTwo else to handle this

            // Common.EventAggregator.GetEvent<NavigateUI2Event>().Publish();

            // May want EventArgs

            //  EventAggregator.GetEvent<NavigateUI2Event>().Publish(
            //      new NavigateUI2EventArgs()
            //      {
            //            Organization = _collectionMainViewModel.SelectedCollection.Organization,
            //            Process = _contextMainViewModel.Context.SelectedProcess
            //      });

            // Start Cut Four - Put this in PrismEvents

            // public class NavigateUI2Event : PubSubEvent { }

            // End Cut Four

            // Start Cut Five - Put this in places that listen for event

            //Common.EventAggregator.GetEvent<NavigateUI2Event>().Subscribe(NavigateUI2);

            // End Cut Five

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // If using CommandParameter, figure out TYPE and fix above
        //public bool NavigateUI2CanExecute(TYPE value)
        public bool NavigateUI2CanExecute(string action)
        {
            // TODO(crhodes)
            // Add any before button is enabled logic.
            return true;
        }

        #endregion

        #region NavigateUI3 Command

        public DelegateCommand<string> NavigateUI3Command { get; set; }

        // If displaying UserControl
        // public static WindowHost _NavigateUI3Host = null;

        // If using CommandParameter, figure out TYPE here
        public string NavigateUI3CommandParameter;

        public string NavigateUI3Content { get; set; } = "NavigateUI3";
        public string NavigateUI3ToolTip { get; set; } = "NavigateUI3 Add ToolTip";
        public string NavigateUI3BetaContent { get; set; } = "NavigateUI3 Beta";
        public string NavigateUI3BetaToolTip { get; set; } = "NavigateUI3 Beta ToolTip";

        // Can get fancy and use Resources
        //public string NavigateUI3Content { get; set; } = "ViewName_NavigateUI3Content";
        //public string NavigateUI3ToolTip { get; set; } = "ViewName_NavigateUI3ContentToolTip";

        // Put these in Resource File
        //    <system:String x:Key="ViewName_NavigateUI3Content">NavigateUI3</system:String>
        //    <system:String x:Key="ViewName_NavigateUI3ContentToolTip">NavigateUI3 ToolTip</system:String>

        // If using CommandParameter, figure out TYPE here
        //public void NavigateUI3(TYPE value)
        public void NavigateUI3(string action)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);
            // TODO(crhodes)
            // Do something amazing.

            Message = $"Cool, you called NavigateUI3 {action}";

            PublishStatusMessage(Message);

            switch (action)
            {
                case "beta":
                    _regionManager.RequestNavigate("RegionNavigationView", "UI3beta");
                    break;

                default:
                    _regionManager.RequestNavigate("RegionNavigationView", "UI3");

                    // Or this way

                    //IRegion region = _regionManager.Regions["RegionNavigationView"];

                    //region.RequestNavigate("UI3");
                    break;
            }

            // If launching a UserControl

            // if (_NavigateUI3Host is null) _NavigateUI3nHost = new WindowHost();
            // var userControl = new USERCONTROL();

            // _loggingConfigurationHost.DisplayUserControlInHost(
            //     "TITLE GOES HERE",
            //     //Common.DEFAULT_WINDOW_WIDTH,
            //     //Common.DEFAULT_WINDOW_HEIGHT,
            //     (Int32)userControl.Width + Common.WINDOW_HOSTING_USER_CONTROL_WIDTH_PAD,
            //     (Int32)userControl.Height + Common.WINDOW_HOSTING_USER_CONTROL_HEIGHT_PAD,
            //     ShowWindowMode.Modeless_Show,
            //     userControl);

            // Uncomment this if you are telling someThree else to handle this

            // Common.EventAggregator.GetEvent<NavigateUI3Event>().Publish();

            // May want EventArgs

            //  EventAggregator.GetEvent<NavigateUI3Event>().Publish(
            //      new NavigateUI3EventArgs()
            //      {
            //            Organization = _collectionMainViewModel.SelectedCollection.Organization,
            //            Process = _contextMainViewModel.Context.SelectedProcess
            //      });

            // Start Cut Three - Put this in PrismEvents

            // public class NavigateUI3Event : PubSubEvent { }

            // End Cut Three

            // Start Cut Five - Put this in places that listen for event

            //Common.EventAggregator.GetEvent<NavigateUI3Event>().Subscribe(NavigateUI3);

            // End Cut Five

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // If using CommandParameter, figure out TYPE and fix above
        //public bool NavigateUI3CanExecute(TYPE value)
        public bool NavigateUI3CanExecute(string action)
        {
            // TODO(crhodes)
            // Add any before button is enabled logic.
            return true;
        }

        #endregion

        #region NavigateUI4 Command

        public DelegateCommand<string> NavigateUI4Command { get; set; }

        // If displaying UserControl
        // public static WindowHost _NavigateUI4Host = null;

        // If using CommandParameter, figure out TYPE here
        public string NavigateUI4CommandParameter;

        public string NavigateUI4Content { get; set; } = "NavigateUI4";
        public string NavigateUI4ToolTip { get; set; } = "NavigateUI4 Add ToolTip";
        public string NavigateUI4BetaContent { get; set; } = "NavigateUI4 Beta";
        public string NavigateUI4BetaToolTip { get; set; } = "NavigateUI4 Beta ToolTip";

        // Can get fancy and use Resources
        //public string NavigateUI4Content { get; set; } = "ViewName_NavigateUI4Content";
        //public string NavigateUI4ToolTip { get; set; } = "ViewName_NavigateUI4ContentToolTip";

        // Put these in Resource File
        //    <system:String x:Key="ViewName_NavigateUI4Content">NavigateUI4</system:String>
        //    <system:String x:Key="ViewName_NavigateUI4ContentToolTip">NavigateUI4 ToolTip</system:String>

        // If using CommandParameter, figure out TYPE here
        //public void NavigateUI4(TYPE value)
        public void NavigateUI4(string action)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);
            // TODO(crhodes)
            // Do something amazing.

            Message = $"Cool, you called NavigateUI4 {action}";

            PublishStatusMessage(Message);

            switch (action)
            {
                case "beta":
                    _regionManager.RequestNavigate("RegionNavigationView", "UI4beta");
                    break;

                default:
                    _regionManager.RequestNavigate("RegionNavigationView", "UI4");

                    // Or this way

                    //IRegion region = _regionManager.Regions["RegionNavigationView"];

                    //region.RequestNavigate("UI4");
                    break;
            }

            // If launching a UserControl

            // if (_NavigateUI4Host is null) _NavigateUI4nHost = new WindowHost();
            // var userControl = new USERCONTROL();

            // _loggingConfigurationHost.DisplayUserControlInHost(
            //     "TITLE GOES HERE",
            //     //Common.DEFAULT_WINDOW_WIDTH,
            //     //Common.DEFAULT_WINDOW_HEIGHT,
            //     (Int32)userControl.Width + Common.WINDOW_HOSTING_USER_CONTROL_WIDTH_PAD,
            //     (Int32)userControl.Height + Common.WINDOW_HOSTING_USER_CONTROL_HEIGHT_PAD,
            //     ShowWindowMode.Modeless_Show,
            //     userControl);

            // Uncomment this if you are telling someFour else to handle this

            // Common.EventAggregator.GetEvent<NavigateUI4Event>().Publish();

            // May want EventArgs

            //  EventAggregator.GetEvent<NavigateUI4Event>().Publish(
            //      new NavigateUI4EventArgs()
            //      {
            //            Organization = _collectionMainViewModel.SelectedCollection.Organization,
            //            Process = _contextMainViewModel.Context.SelectedProcess
            //      });

            // Start Cut Four - Put this in PrismEvents

            // public class NavigateUI4Event : PubSubEvent { }

            // End Cut Four

            // Start Cut Five - Put this in places that listen for event

            //Common.EventAggregator.GetEvent<NavigateUI4Event>().Subscribe(NavigateUI4);

            // End Cut Five

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // If using CommandParameter, figure out TYPE and fix above
        //public bool NavigateUI4CanExecute(TYPE value)
        public bool NavigateUI4CanExecute(string action)
        {
            // TODO(crhodes)
            // Add any before button is enabled logic.
            return true;
        }

        #endregion

        #region NavigateUI5 Command

        public DelegateCommand<string> NavigateUI5Command { get; set; }

        // If displaying UserControl
        // public static WindowHost _NavigateUI5Host = null;

        // If using CommandParameter, figure out TYPE here
        public string NavigateUI5CommandParameter;

        public string NavigateUI5Content { get; set; } = "NavigateUI5";
        public string NavigateUI5ToolTip { get; set; } = "NavigateUI5 Add ToolTip";
        public string NavigateUI5BetaContent { get; set; } = "NavigateUI5 Beta";
        public string NavigateUI5BetaToolTip { get; set; } = "NavigateUI5 Beta ToolTip";

        // Can get fancy and use Resources
        //public string NavigateUI5Content { get; set; } = "ViewName_NavigateUI5Content";
        //public string NavigateUI5ToolTip { get; set; } = "ViewName_NavigateUI5ContentToolTip";

        // Put these in Resource File
        //    <system:String x:Key="ViewName_NavigateUI5Content">NavigateUI5</system:String>
        //    <system:String x:Key="ViewName_NavigateUI5ContentToolTip">NavigateUI5 ToolTip</system:String>

        // If using CommandParameter, figure out TYPE here
        //public void NavigateUI5(TYPE value)
        public void NavigateUI5(string action)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);
            // TODO(crhodes)
            // Do something amazing.

            Message = $"Cool, you called NavigateUI5 {action}";

            PublishStatusMessage(Message);

            switch (action)
            {
                case "beta":
                    _regionManager.RequestNavigate("RegionNavigationView", "UI5beta");
                    break;

                default:
                    _regionManager.RequestNavigate("RegionNavigationView", "UI5");

                    // Or this way

                    //IRegion region = _regionManager.Regions["RegionNavigationView"];

                    //region.RequestNavigate("UI5");
                    break;
            }

            // If launching a UserControl

            // if (_NavigateUI5Host is null) _NavigateUI5nHost = new WindowHost();
            // var userControl = new USERCONTROL();

            // _loggingConfigurationHost.DisplayUserControlInHost(
            //     "TITLE GOES HERE",
            //     //Common.DEFAULT_WINDOW_WIDTH,
            //     //Common.DEFAULT_WINDOW_HEIGHT,
            //     (Int32)userControl.Width + Common.WINDOW_HOSTING_USER_CONTROL_WIDTH_PAD,
            //     (Int32)userControl.Height + Common.WINDOW_HOSTING_USER_CONTROL_HEIGHT_PAD,
            //     ShowWindowMode.Modeless_Show,
            //     userControl);

            // Uncomment this if you are telling someFive else to handle this

            // Common.EventAggregator.GetEvent<NavigateUI5Event>().Publish();

            // May want EventArgs

            //  EventAggregator.GetEvent<NavigateUI5Event>().Publish(
            //      new NavigateUI5EventArgs()
            //      {
            //            Organization = _collectionMainViewModel.SelectedCollection.Organization,
            //            Process = _contextMainViewModel.Context.SelectedProcess
            //      });

            // Start Cut Five - Put this in PrismEvents

            // public class NavigateUI5Event : PubSubEvent { }

            // End Cut Five

            // Start Cut Five - Put this in places that listen for event

            //Common.EventAggregator.GetEvent<NavigateUI5Event>().Subscribe(NavigateUI5);

            // End Cut Five

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // If using CommandParameter, figure out TYPE and fix above
        //public bool NavigateUI5CanExecute(TYPE value)
        public bool NavigateUI5CanExecute(string action)
        {
            // TODO(crhodes)
            // Add any before button is enabled logic.
            return true;
        }

        #endregion

        #endregion

        #region Protected Methods (none)



        #endregion

        #region Private Methods (none)



        #endregion

        #region IInstanceCountVM

        private static int _instanceCountVM;

        public int InstanceCountVM
        {
            get => _instanceCountVM;
            set => _instanceCountVM = value;
        }

        #endregion
    }
}
