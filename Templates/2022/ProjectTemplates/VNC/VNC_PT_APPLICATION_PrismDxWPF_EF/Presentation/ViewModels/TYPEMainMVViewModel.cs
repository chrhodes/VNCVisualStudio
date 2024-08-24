using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.ViewModels
{
    public class $xxxTYPExxx$MainMVViewModel : EventViewModelBase, I$xxxTYPExxx$MainMVViewModel, INavigationAware, IInstanceCountVM
    {
        #region Constructors, Initialization, and Load

        //private readonly IRegionManager _regionManager;

        // HACK(crhodes)
        // Asking for a IRegionManager here is going to get the initial default region manager
        // Need to implement custom code so we can create and use a scoped region manager.
        // Watch Prism Problems & Solutions: Showing Multiple Shells - Controlling View Composition

        public $xxxTYPExxx$MainMVViewModel(
            I$xxxTYPExxx$NavigationMVViewModel $xxxTYPExxx$NavigationViewModel,
            Func<I$xxxTYPExxx$DetailMVViewModel> $xxxTYPExxx$DetailViewModelCreator,
            Func<IMouseDetailViewModel> MouseDetailViewModelCreator,
            // IRegionManager regionManager,
            IEventAggregator eventAggregator,
            IDialogService dialogService) : base(eventAggregator, dialogService)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.Constructor) startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            // TODO(crhodes)
            // Save constructor parameters here

            NavigationViewModel = $xxxTYPExxx$NavigationViewModel;
            _$xxxTYPExxx$DetailViewModelCreator = $xxxTYPExxx$DetailViewModelCreator;
            _MouseDetailViewModelCreator = MouseDetailViewModelCreator;

            // _regionManager = regionManager;

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

            DetailViewModels = new ObservableCollection<IDetailViewModel>();

            EventAggregator.GetEvent<OpenDetailViewEvent>()
                .Subscribe(OpenDetailView);

            EventAggregator.GetEvent<AfterDetailDeletedEvent>()
                .Subscribe(AfterDetailDeleted);

            EventAggregator.GetEvent<AfterDetailClosedEvent>()
                .Subscribe(AfterDetailClosed);

            CreateNewDetailViewCommand = new DelegateCommand<Type>(
                CreateNewDetailView);

            OpenSingleDetailViewCommand = new DelegateCommand<Type>(
                OpenSingleDetailExecute);

            if (Common.VNCLogging.ViewModelLow) Log.VIEWMODEL_LOW("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Enums (none)


        #endregion

        #region Structures (none)


        #endregion

        #region Fields and Properties

        private Func<I$xxxTYPExxx$DetailMVViewModel> _$xxxTYPExxx$DetailViewModelCreator;
        private Func<IMouseDetailViewModel> _MouseDetailViewModelCreator;

        private IDetailViewModel _selectedDetailViewModel;

        public ICommand CreateNewDetailViewCommand { get; private set; }

        public ICommand OpenSingleDetailViewCommand { get; private set; }

        // N.B. This is public so View.Xaml can bind to it.
        public I$xxxTYPExxx$NavigationMVViewModel NavigationViewModel { get; private set; }

        public ObservableCollection<IDetailViewModel> DetailViewModels { get; private set; }

        private int _nextNewItemId = 0;

        public IDetailViewModel SelectedDetailViewModel
        {
            get
            {
                return _selectedDetailViewModel;
            }
            set
            {
                _selectedDetailViewModel = value;
                // NOTE(crhodes)
                // We can check if different and skip notifi$xxxTYPExxx$ion,
                // however, raising the event will cause the tab to be selected
                // which will draw user to tab if another is selected.
                OnPropertyChanged();
            }
        }

        #endregion

        #region Event Handlers

        void OpenSingleDetailExecute(Type viewModelType)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);

            OpenDetailView(
                new OpenDetailViewEventArgs
                {
                    Id = -1,
                    ViewModelName = viewModelType.Name
                });

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void CreateNewDetailView(Type viewModelType)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);

            OpenDetailView(
                new OpenDetailViewEventArgs
                {
                    Id = _nextNewItemId--,  // Ids in DB > 0.  Can now create multiple new items
                    ViewModelName = viewModelType.Name
                });

            //HACK(crhodes)
            // Not sure when is best time to do this

            //// Well not here nothing seems to happen
            //var r = _regionManager.Regions;
            //IRegion region = _regionManager.Regions["MultiStepProcessViewMV"];
            //region.RequestNavigate("uicatdetaila");

            //_regionManager.RequestNavigate("MultiStepProcessViewMV", "uicatdetaila");

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private async void OpenDetailView(OpenDetailViewEventArgs args)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ViewModel) startTicks = Log.VIEWMODEL($"($xxxTYPExxx$MainViewModelMV) Enter Id:({args.Id})", Common.LOG_CATEGORY);

            var detailViewModel = DetailViewModels
                    .SingleOrDefault(vm => vm.Id == args.Id
                    && vm.GetType().Name == args.ViewModelName);

            if (detailViewModel == null)
            {
                switch (args.ViewModelName)
                {
                    case nameof($xxxTYPExxx$DetailMVViewModel):
                        detailViewModel = (IDetailViewModel)_$xxxTYPExxx$DetailViewModelCreator();
                        break;

                    //case nameof(MeetingDetailViewModel):
                    //    detailViewModel = _meetingDetailViewModelCreator();
                    //    break;

                    case nameof(MouseDetailViewModel):
                        detailViewModel = _MouseDetailViewModelCreator();
                        break;

                    // Ignore event if we don't handle
                    default:
                        return;
                }

                // Verify item still exists (may have been deleted)

                try
                {
                    await detailViewModel.LoadAsync(args.Id);
                }
                catch (Exception ex)
                {
                    var message = $"Cannot load the entity ({ex}) It may have been deleted by another user";

                    DialogService.Show("Notifi$xxxTYPExxx$ionDialog", new DialogParameters($"message={message}"), r =>
                    {
                    });

                    await NavigationViewModel.LoadAsync();

                    return;
                }

                DetailViewModels.Add(detailViewModel);
            }

            SelectedDetailViewModel = detailViewModel;

            if (Common.VNCLogging.ViewModel) Log.VIEWMODEL("($xxxTYPExxx$MainViewModelMV) Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void AfterDetailDeleted(AfterDetailDeletedEventArgs args)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);

            RemoveDetailViewModel(args.Id, args.ViewModelName);

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        void AfterDetailClosed(AfterDetailClosedEventArgs args)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);

            RemoveDetailViewModel(args.Id, args.ViewModelName);

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void RemoveDetailViewModel(int id, string viewModelName)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ViewModel) startTicks = Log.VIEWMODEL("Enter", Common.LOG_CATEGORY);

            var detailViewModel = DetailViewModels
                .SingleOrDefault(vm => vm.Id == id
                && vm.GetType().Name == viewModelName);

            if (detailViewModel != null)
            {
                DetailViewModels.Remove(detailViewModel);
            }

            if (Common.VNCLogging.ViewModel) Log.VIEWMODEL("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Commands (none)


        #endregion

        #region Public Methods

        public async Task LoadAsync()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ViewModel) startTicks = Log.VIEWMODEL("($xxxTYPExxx$MainViewModelMV) Enter", Common.LOG_CATEGORY);

            await NavigationViewModel.LoadAsync();

            if (Common.VNCLogging.ViewModel) Log.VIEWMODEL("($xxxTYPExxx$MainViewModelMV) Exit", Common.LOG_CATEGORY, startTicks);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

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
