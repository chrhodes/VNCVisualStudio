using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

using PAEF1Core.Presentation.Views;

using Prism.Commands;
using Prism.Events;
using Prism.Services.Dialogs;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Presentation;
using VNC.WPF.Presentation.Dx.Views;
using VNC.WPF.Presentation.Views;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.ViewModels
{
    public class StatusBarViewModel : EventViewModelBase, IStatusBarViewModel, IInstanceCountVM
    {
        #region Constructors, Initialization, and Load

        public StatusBarViewModel(
            IEventAggregator eventAggregator,
            DialogService dialogService) : base(eventAggregator, dialogService)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.Constructor) startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            // TODO(crhodes)
            // Save constructor parameters here

            InstanceCountVM++;

            InitializeViewModel();

            if (Common.VNCLogging.Constructor) Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void InitializeViewModel()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ViewModelLow) startTicks = Log.VIEWMODEL_LOW("Enter", Common.LOG_CATEGORY);

            // NOTE(crhodes)
            // Put things here that initialize the ViewModel
            // Initialize EventHandlers, Commands, etc.

            DeveloperModeCommand = new DelegateCommand(DeveloperMode, DeveloperModeCanExecute);
            LoggingConfigurationCommand = new DelegateCommand(LoggingConfiguration, LoggingConfigurationCanExecute);

            EventAggregator.GetEvent<StatusMessageEvent>().Subscribe(UpdateStatusMessage);

#if DEBUG
            DeveloperModeToolTip = "Turn off Developer Mode";
#else
            DeveloperModeToolTip = "Turn on Developer Mode";
#endif

            if (Common.VNCLogging.ViewModelLow) Log.VIEWMODEL_LOW("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Enums (none)


        #endregion

        #region Structures (none)


        #endregion

        #region Fields and Properties

        public DelegateCommand DeveloperModeCommand { get; set; }
        public DelegateCommand LoggingConfigurationCommand { get; set; }

        #endregion

        #region Event Handlers

        private void UpdateStatusMessage(string message)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);

            Message = message;

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Commands

        #region DeveloperMode Command

        //public TYPE DeveloperModeCommandParameter;
        public string DeveloperModeContent { get; set; } = "DeveloperMode";
        private string? _developerModeToolTip = "DeveloperMode ToolTip";
        public string? DeveloperModeToolTip
        {
            get => _developerModeToolTip;
            set
            {
                if (_developerModeToolTip == value) { return; }

                _developerModeToolTip = value;
                OnPropertyChanged();
            }
        }

        // Can get fancy and use Resources
        //public string DeveloperModeContent { get; set; } = "ViewName_DeveloperModeContent";
        //public string DeveloperModeToolTip { get; set; } = "ViewName_DeveloperModeContentToolTip";

        // Put these in Resource File
        //    <system:String x:Key="ViewName_DeveloperModeContent">DeveloperMode</system:String>
        //    <system:String x:Key="ViewName_DeveloperModeContentToolTip">DeveloperMode ToolTip</system:String>

        // If using CommandParameter, figure out TYPE and fix above
        //public void DeveloperMode(TYPE value)
        public void DeveloperMode()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);

            if (Common.DeveloperMode)
            {
                Message = "Cool, you turned off DeveloperMode";
                DeveloperModeToolTip = "Turn on Developer Mode";

                if (Common.CurrentRibbonShell is not null) Common.CurrentRibbonShell.DeveloperUIMode = System.Windows.Visibility.Collapsed;
                if (Common.CurrentShell is not null) Common.CurrentShell.DeveloperUIMode = System.Windows.Visibility.Collapsed;

                // NOTE(crhodes)
                // Use this if Build Action - Content - Copy
                //ImageBrush brush = new ImageBrush();
                //brush.ImageSource = new BitmapImage(new Uri(".\\Resources\\Images\\ToolBox.png", UriKind.Relative));
                //((StatusBar)View).btnDeveloperMode.Background = brush;

                // NOTE(crhodes)
                // Use this if Build Action - Resource
                Uri resourceUri = new Uri(".\\Resources\\Images\\ToolBox.png", UriKind.Relative);
                StreamResourceInfo streamInfo = App.GetResourceStream(resourceUri);
                BitmapFrame bitmapFrame = BitmapFrame.Create(streamInfo.Stream);

                ImageBrush brush = new ImageBrush();
                brush.ImageSource = bitmapFrame;
                ((StatusBar)View).btnDeveloperMode.Background = brush;

                ((StatusBar)View).btnDeveloperMode.Width = 24;
                ((StatusBar)View).btnDeveloperMode.Height = 20;
            }
            else
            {
                Message = "Cool, you turned on DeveloperMode";
                DeveloperModeToolTip = "Turn off Developer Mode";

                if (Common.CurrentRibbonShell is not null) Common.CurrentRibbonShell.DeveloperUIMode = System.Windows.Visibility.Visible;
                if (Common.CurrentShell is not null) Common.CurrentShell.DeveloperUIMode = System.Windows.Visibility.Visible;

                // NOTE(crhodes)
                //// Use this if Build Action - Content - Copy
                //ImageBrush brush = new ImageBrush();
                //brush.ImageSource = new BitmapImage(new Uri(".\\Resources\\Images\\VNCDeveloperMotivation.png", UriKind.Relative));
                //((StatusBar)View).btnDeveloperMode.Background = brush;

                // NOTE(crhodes)
                // Use this if Build Action - Resource
                Uri resourceUri = new Uri(".\\Resources\\Images\\VNCDeveloperMotivation.png", UriKind.Relative);
                StreamResourceInfo streamInfo = App.GetResourceStream(resourceUri);
                BitmapFrame bitmapFrame = BitmapFrame.Create(streamInfo.Stream);

                ImageBrush brush = new ImageBrush();
                brush.ImageSource = bitmapFrame;
                ((StatusBar)View).btnDeveloperMode.Background = brush;

                ((StatusBar)View).btnDeveloperMode.Width = 48;
                ((StatusBar)View).btnDeveloperMode.Height = 39;
            }

            Common.DeveloperMode = !Common.DeveloperMode;

            // Uncomment this if you are telling someone else to handle this

            // Common.EventAggregator.GetEvent<DeveloperModeEvent>().Publish();

            // May want EventArgs

            //  EventAggregator.GetEvent<DeveloperModeEvent>().Publish(
            //      new DeveloperModeEventArgs()
            //      {
            //            Organization = _collectionMainViewModel.SelectedCollection.Organization,
            //            Process = _contextMainViewModel.Context.SelectedProcess
            //      });

            // Start Cut Four - Put this in PrismEvents

            // public class DeveloperModeEvent : PubSubEvent { }

            // End Cut Four

            // Start Cut Five - Put this in places that listen for event

            //Common.EventAggregator.GetEvent<DeveloperModeEvent>().Subscribe(DeveloperMode);

            // End Cut Five

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // If using CommandParameter, figure out TYPE and fix above
        //public bool DeveloperModeCanExecute(TYPE value)
        public bool DeveloperModeCanExecute()
        {
            // TODO(crhodes)
            // Add any before button is enabled logic.
            return true;
        }

        #endregion

        #region LoggingConfiguration Command

        public static WindowHost _loggingConfigurationHost = null;

        //public TYPE LoggingConfigurationCommandParameter;
        public string LoggingConfigurationContent { get; set; } = "LoggingConfiguration";
        public string? LoggingConfigurationToolTip { get; set; } = "LoggingConfiguration ToolTip";

        // Can get fancy and use Resources
        //public string LoggingConfigurationContent { get; set; } = "ViewName_LoggingConfigurationContent";
        //public string LoggingConfigurationToolTip { get; set; } = "ViewName_LoggingConfigurationContentToolTip";

        // Put these in Resource File
        //    <system:String x:Key="ViewName_LoggingConfigurationContent">LoggingConfiguration</system:String>
        //    <system:String x:Key="ViewName_LoggingConfigurationContentToolTip">LoggingConfiguration ToolTip</system:String>

        // If using CommandParameter, figure out TYPE and fix above
        //public void LoggingConfiguration(TYPE value)
        public void LoggingConfiguration()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);

            Message = "Cool, you called LoggingConfiguration";

            if (_loggingConfigurationHost is null) _loggingConfigurationHost = new WindowHost();

            var userControl = new VNCLoggingConfigMain();

            _loggingConfigurationHost.DisplayUserControlInHost(
                "VNC Logging Configuration",
                //Common.DEFAULT_WINDOW_WIDTH,
                //Common.DEFAULT_WINDOW_HEIGHT,
                (Int32)userControl.Width + Common.WINDOW_HOSTING_USER_CONTROL_WIDTH_PAD,
                (Int32)userControl.Height + Common.WINDOW_HOSTING_USER_CONTROL_HEIGHT_PAD,
                ShowWindowMode.Modeless_Show,
                userControl);

            // Uncomment this if you are telling someone else to handle this

            // Common.EventAggregator.GetEvent<LoggingConfigurationEvent>().Publish();

            // May want EventArgs

            //  EventAggregator.GetEvent<LoggingConfigurationEvent>().Publish(
            //      new LoggingConfigurationEventArgs()
            //      {
            //            Organization = _collectionMainViewModel.SelectedCollection.Organization,
            //            Process = _contextMainViewModel.Context.SelectedProcess
            //      });

            // Start Cut Four - Put this in PrismEvents

            // public class LoggingConfigurationEvent : PubSubEvent { }

            // End Cut Four

            // Start Cut Five - Put this in places that listen for event

            //Common.EventAggregator.GetEvent<LoggingConfigurationEvent>().Subscribe(LoggingConfiguration);

            // End Cut Five

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // If using CommandParameter, figure out TYPE and fix above
        //public bool LoggingConfigurationCanExecute(TYPE value)
        public bool LoggingConfigurationCanExecute()
        {
            // TODO(crhodes)
            // Add any before button is enabled logic.
            return true;
        }

        #endregion

        #endregion

        #region Public Methods (none)


        #endregion

        #region Protected Methods (none)


        #endregion

        #region Private Methods (none)


        #endregion

        #region IInstanceCount

        private static int _instanceCountVM;

        public int InstanceCountVM
        {
            get => _instanceCountVM;
            set => _instanceCountVM = value;
        }

        #endregion
    }
}
