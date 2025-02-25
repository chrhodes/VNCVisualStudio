using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.DomainServices;

using Prism.Events;
using Prism.Services.Dialogs;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.ViewModels
{
    public class CombinedNavigationViewModel : EventViewModelBase, ICombinedNavigationViewModel, IInstanceCountVM
    {
        #region Constructors, Initialization, and Load

        public CombinedNavigationViewModel(
            I$xxxTYPExxx$LookupDataService $xxxTYPExxx$LookupDataService,
            IEventAggregator eventAggregator,
            IDialogService dialogService) : base(eventAggregator, dialogService)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.Constructor) startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            // TODO(crhodes)
            // Save constructor parameters here

            _$xxxTYPExxx$LookupDataService = $xxxTYPExxx$LookupDataService;

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

            $xxxTYPExxx$s = new ObservableCollection<NavigationItemViewModel>();

            EventAggregator.GetEvent<AfterDetailSavedEvent>()
                .Subscribe(AfterDetailSaved);

            EventAggregator.GetEvent<AfterDetailDeletedEvent>()
                .Subscribe(AfterDetailDeleted);

            if (Common.VNCLogging.ViewModelLow) Log.VIEWMODEL_LOW("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Enums (none)



        #endregion

        #region Structures (none)



        #endregion

        #region Fields and Properties

        private I$xxxTYPExxx$LookupDataService _$xxxTYPExxx$LookupDataService;

        public ObservableCollection<NavigationItemViewModel> $xxxTYPExxx$s { get; private set;}

        #endregion

        #region Event Handlers

        private void AfterDetailSaved(AfterDetailSavedEventArgs args)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);

            switch (args.ViewModelName)
            {
                case nameof($xxxTYPExxx$DetailViewModel):
                    AddNavigationItem($xxxTYPExxx$s, args);
                    break;

                // case nameof(xxxxDetailViewModel):
                    // AddNavigationItem(XXXXXs, args);
                    // break;

                default:
                    throw new System.Exception($"AfterDetailSaved(): ViewModel {args.ViewModelName} not mapped.");
            }

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void AfterDetailDeleted(AfterDetailDeletedEventArgs args)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);

            switch (args.ViewModelName)
            {
                case nameof($xxxTYPExxx$DetailViewModel):
                    DeleteNavigationItem($xxxTYPExxx$s, args);
                    break;

                // case nameof(xxxxDetailViewModel):
                    // DeleteNavigationItem(XXXXs, args);
                    // break;

                default:
                    throw new System.Exception($"AfterDetailDeleted(): ViewModel {args.ViewModelName} not mapped.");
            }

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Commands (none)


        #endregion

        #region Public Methods

        public async Task LoadAsync()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ViewModel) startTicks = Log.VIEWMODEL("(CombinedNavigationViewModel) Enter", Common.LOG_CATEGORY);

            var lookup$xxxTYPExxx$s = await _$xxxTYPExxx$LookupDataService.Get$xxxTYPExxx$LookupAsync();
            $xxxTYPExxx$s.Clear();

            foreach (var item in lookup$xxxTYPExxx$s)
            {
                $xxxTYPExxx$s.Add(
                    new NavigationItemViewModel(item.Id, item.DisplayMember,
                    nameof($xxxTYPExxx$DetailViewModel),
                    EventAggregator, DialogService));
            }

            //TODO(crhodes)
            // Load more TYPEs as needed here

            // var lookupXXXs = await _XXXLookupDataService.GetXXXLookupAsync();
            // XXXs.Clear();

            // foreach (var item in lookupXXXs)
            // {
            // XXXs.Add(
            // new NavigationItemViewModel(item.Id, item.DisplayMember,
            // nameof(XXXDetailViewModel),
            // EventAggregator, DialogService));
            // }

            if (Common.VNCLogging.ViewModel) Log.VIEWMODEL("(CombinedNavigationViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Protected Methods (none)


        #endregion

        #region Private Methods

        private void AddNavigationItem(ObservableCollection<NavigationItemViewModel> items,
            AfterDetailSavedEventArgs args)
        {
#if LOGGING
            Int64 startTicks = 0;
            if (Common.VNCCoreLogging.ViewModel) startTicks = Log.VIEWMODEL($"Enter Id:({args.Id})", Common.LOG_CATEGORY);
#endif
            var lookupItem = items.SingleOrDefault(l => l.Id == args.Id);

            if (lookupItem == null)
            {
                items.Add(new NavigationItemViewModel(args.Id, args.DisplayMember,
                    args.ViewModelName,
                    EventAggregator, DialogService));
            }
            else
            {
                lookupItem.DisplayMember = args.DisplayMember;
            }
#if LOGGING
            if (Common.VNCCoreLogging.ViewModel) Log.VIEWMODEL("Exit", Common.LOG_CATEGORY, startTicks);
#endif
        }

        private void DeleteNavigationItem(ObservableCollection<NavigationItemViewModel> items,
            AfterDetailDeletedEventArgs args)
        {
#if LOGGING
            Int64 startTicks = 0;
            if (Common.VNCCoreLogging.ViewModel) startTicks = Log.VIEWMODEL($"Enter Id:({args.Id})", Common.LOG_CATEGORY);
#endif
            var lookupItem = items.SingleOrDefault(f => f.Id == args.Id);

            if (lookupItem != null)
            {
                items.Remove(lookupItem);
            }
#if LOGGING
            if (Common.VNCCoreLogging.ViewModel) Log.VIEWMODEL("Exit", Common.LOG_CATEGORY, startTicks);
#endif
        }

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
