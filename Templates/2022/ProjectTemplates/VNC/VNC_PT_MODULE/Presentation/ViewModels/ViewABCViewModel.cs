﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Prism.Commands;
using Prism.Events;
using Prism.Services.Dialogs;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

namespace $xxxMODULExxx$$xxxNAMESPACExxx$.Presentation.ViewModels
{
    public class ViewABCViewModel : EventViewModelBase, IViewABCViewModel, IInstanceCountVM
    {

        #region Constructors, Initialization, and Load

        public ViewABCViewModel(
            IEventAggregator eventAggregator,
            IDialogService dialogService) : base(eventAggregator, dialogService)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            // TODO(crhodes)
            // Save constructor parameters here

            InitializeViewModel();

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void InitializeViewModel()
        {
            Int64 startTicks = Log.VIEWMODEL("Enter", Common.LOG_CATEGORY);

            InstanceCountVM++;

            // TODO(crhodes)
            //

            Message = "ViewModelABC says hello";
            MessageA = "ViewModelABC says hello A";
            MessageB = "ViewModelABC says hello B";
            MessageC = "ViewModelABC says hello C";

            Log.VIEWMODEL("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Enums (none)


        #endregion

        #region Structures (none)


        #endregion

        #region Fields and Properties
        
        private string _message;
        
        public string Message
        {
            get => _message;
            set
            {
                if (_message == value)
                    return;
                _message = value;
                OnPropertyChanged();
            }
        }

        private string _messageA;
        
        public string MessageA
        {
            get => _messageA;
            set
            {
                if (_messageA == value)
                    return;
                _messageA = value;
                OnPropertyChanged();
            }
        }

        private string _messageB;
        
        public string MessageB
        {
            get => _messageB;
            set
            {
                if (_messageB == value)
                    return;
                _messageB = value;
                OnPropertyChanged();
            }
        }

        private string _messageC;
        
        public string MessageC
        {
            get => _messageC;
            set
            {
                if (_messageC == value)
                    return;
                _messageC = value;
                OnPropertyChanged();
            }
        }
        
        #endregion

        #region Event Handlers (none)


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
