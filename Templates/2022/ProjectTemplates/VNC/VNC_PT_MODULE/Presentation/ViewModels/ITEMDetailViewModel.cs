using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Prism.Commands;
using Prism.Events;
using Prism.Services.Dialogs;

using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Domain;
using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.DomainServices;
using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.ModelWrappers;

using VNC;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.ViewModels
{
    public class $xxxITEMxxx$DetailViewModel : DetailViewModelBase, I$xxxITEMxxx$DetailViewModel, IInstanceCountVM
    {
        #region Contructors, Initialization, and Load

        public $xxxITEMxxx$DetailViewModel(
            I$xxxITEMxxx$DataService $xxxITEMxxx$DataService,
            IEventAggregator eventAggregator,
            IDialogService dialogService) : base(eventAggregator, dialogService)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.Constructor) startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            // TODO(crhodes)
            // Save constructor parameters here

            _$xxxITEMxxx$DataService = $xxxITEMxxx$DataService;

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

            Title = "$xxxITEMxxx$s";
            $xxxITEMxxx$s = new ObservableCollection<$xxxITEMxxx$Wrapper>();

            AddCommand = new DelegateCommand(AddExecute);
            RemoveCommand = new DelegateCommand(RemoveExecute, RemoveCanExecute);

            if (Common.VNCLogging.ViewModelLow) Log.VIEWMODEL_LOW("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Enums (none)

        #endregion

        #region Structures (none)

        #endregion

        #region Fields and Properties

        private I$xxxITEMxxx$DataService _$xxxITEMxxx$DataService;

        public ICommand AddCommand { get; private set;}

        public ICommand RemoveCommand { get; private set;}

        public ObservableCollection<$xxxITEMxxx$Wrapper> $xxxITEMxxx$s { get; private set;}

        private $xxxITEMxxx$Wrapper _selected$xxxITEMxxx$;

        public $xxxITEMxxx$Wrapper Selected$xxxITEMxxx$
        {
            get { return _selected$xxxITEMxxx$; }
            set
            {
                _selected$xxxITEMxxx$ = value;
                OnPropertyChanged();
                ((DelegateCommand)RemoveCommand).RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region Event Handlers

        // private async void OpenDetailView(OpenDetailViewEventArgs args)
        // {
            // Int64 startTicks = Log.EVENT("($xxxITEMxxx$DetailViewModel) Enter", Common.LOG_CATEGORY);

            // await LoadAsync(args.Id);

            // Log.EVENT("($xxxITEMxxx$DetailViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        // }

        #endregion

        #region Commands (none)


        #endregion

        #region Public Methods

        public override async Task LoadAsync(int id)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ViewModel) startTicks = Log.VIEWMODEL("($xxxITEMxxx$DetailViewModel) Enter Id:({id})", Common.LOG_CATEGORY);

            Id = id;

            foreach (var wrapper in $xxxITEMxxx$s)
            {
                wrapper.PropertyChanged -= Wrapper_PropertyChanged;
            }

            $xxxITEMxxx$s.Clear();

            var items = await _$xxxITEMxxx$DataService.AllAsync();

            foreach (var model in items)
            {
                var wrapper = new $xxxITEMxxx$Wrapper(model);
                wrapper.PropertyChanged += Wrapper_PropertyChanged;
                $xxxITEMxxx$s.Add(wrapper);
            }

            if (Common.VNCLogging.ViewModel) Log.VIEWMODEL("($xxxITEMxxx$DetailViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        }

        void Wrapper_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (! HasChanges)
            {
                HasChanges = _$xxxITEMxxx$DataService.HasChanges();
            }

            if (e.PropertyName == nameof($xxxITEMxxx$Wrapper.HasErrors))
            {
                ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region Protected Methods

        protected override bool DeleteCanExecute()
        {
            // TODO(crhodes)
            // Why do we need this?
            return true;
        }

        protected override async void DeleteExecute()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER($"($xxxITEMxxx$DetailViewModel) Enter Id:({Selected$xxxITEMxxx$.Id})", Common.LOG_CATEGORY);

            if (Common.VNCLogging.EventHandler)Log.EVENT_HANDLER("($xxxITEMxxx$DetailViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        }

        protected override bool SaveCanExecute()
        {
            return HasChanges && $xxxITEMxxx$s.All(p => !p.HasErrors);
        }

        protected override async void SaveExecute()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER($"($xxxITEMxxx$DetailViewModel) Enter Id:({Selected$xxxITEMxxx$.Id})", Common.LOG_CATEGORY);

            try
            {
                await _$xxxITEMxxx$DataService.UpdateAsync();

                HasChanges = _$xxxITEMxxx$DataService.HasChanges();

                PublishAfterCollectionSavedEvent();
            }
            catch (Exception ex)
            {
                // while (ex.InnerException != null)
                // {
                    // ex = ex.InnerException;
                // }

                var message = "Error while saving the $xxxITEMxxx$s, the data will be reloaded.  Details: " + ex;

                var dialogParameters = new DialogParameters();
                dialogParameters.Add("message", message);
                dialogParameters.Add("title", "Alert");

                DialogService.Show("NotificationDialog", dialogParameters, r =>
                {
                });

                await LoadAsync(Id);
            }

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("($xxxITEMxxx$DetailViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Private Methods

        void AddExecute()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("($xxxITEMxxx$DetailViewModel) Enter", Common.LOG_CATEGORY);

            var wrapper = new $xxxITEMxxx$Wrapper(new Domain.$xxxITEMxxx$());
            wrapper.PropertyChanged += Wrapper_PropertyChanged;

            _$xxxITEMxxx$DataService.Add(wrapper.Model);
            $xxxITEMxxx$s.Add(wrapper);

            wrapper.Name = "";  // Trigger the validation

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("($xxxITEMxxx$DetailViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        }

        private async void RemoveExecute()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("($xxxITEMxxx$DetailViewModel) Enter", Common.LOG_CATEGORY);

            var isReferenced =
                await _$xxxITEMxxx$DataService.IsReferencedBy$xxxTYPExxx$Async(Selected$xxxITEMxxx$.Id);

            if (isReferenced)
            {
                var message = $"The $xxxTYPExxx$ ({Selected$xxxITEMxxx$.Name})" +
                    " can't be removed;  It is referenced by at least one $xxxTYPExxx$";

                DialogService.Show("NotificationDialog", new DialogParameters($"message={message}"), r =>
                {

                });

                return;
            }

            Selected$xxxITEMxxx$.PropertyChanged -= Wrapper_PropertyChanged;
            _$xxxITEMxxx$DataService.Remove(Selected$xxxITEMxxx$.Model);
            $xxxITEMxxx$s.Remove(Selected$xxxITEMxxx$);
            Selected$xxxITEMxxx$ = null;
            HasChanges = _$xxxITEMxxx$DataService.HasChanges();

            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("($xxxITEMxxx$DetailViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        }

        bool RemoveCanExecute()
        {
            return Selected$xxxITEMxxx$ != null;
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
