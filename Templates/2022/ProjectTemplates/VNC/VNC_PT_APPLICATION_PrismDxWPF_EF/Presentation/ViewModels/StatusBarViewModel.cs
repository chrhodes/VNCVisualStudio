using System;
using System.Collections.ObjectModel;

using Prism.Events;
using Prism.Services.Dialogs;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Net;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.ViewModels
{
    public class StatusBarViewModel : EventViewModelBase, IInstanceCountVM
    {

        #region Constructors, Initialization, and Load

        public StatusBarViewModel(
            IEventAggregator eventAggregator,
            DialogService dialogService) : base(eventAggregator, dialogService)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.Constructor) startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InitializeViewModel();

            if (Common.VNCLogging.Constructor) Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void InitializeViewModel()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ViewModelLow) startTicks = Log.VIEWMODEL_LOW("Enter", Common.LOG_CATEGORY);

            InstanceCountVM++;

            EventAggregator.GetEvent<StatusMessageEvent>().Subscribe(UpdateStatusMessage);

            if (Common.VNCLogging.ViewModelLow) Log.VIEWMODEL_LOW("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Enums (none)


        #endregion

        #region Structures (none)


        #endregion

        #region Fields and Properties

        private string _currentHTTPRequest;
        private string _title = "StatusBar";

        public string Title
        {
            get => _title;
            set
            {
                if (_title == value)
                    return;
                _title = value;
                OnPropertyChanged();
            }
        }

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
