using System;
using System.Collections.Generic;
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
using VNC.Core.DomainServices;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Services;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.ViewModels
{
    public class $xxxTYPExxx$DetailViewModel : DetailViewModelBase, I$xxxTYPExxx$DetailViewModel, IInstanceCountVM
    {
        #region Contructors, Initialization, and Load

        public $xxxTYPExxx$DetailViewModel(
            I$xxxTYPExxx$DataService $xxxTYPExxx$DataService,
            I$xxxITEMxxx$LookupDataService $xxxITEMxxx$LookupDataService,
            IEventAggregator eventAggregator,
            IDialogService dialogService) : base(eventAggregator, dialogService)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.Constructor) startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            // TODO(crhodes)
            // Save constructor parameters here

            _$xxxTYPExxx$DataService = $xxxTYPExxx$DataService;
            _$xxxITEMxxx$LookupDataService = $xxxITEMxxx$LookupDataService;

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

            EventAggregator.GetEvent<AfterCollectionSavedEvent>()
                .Subscribe(AfterCollectionSaved);

            AddPhoneNumberCommand = new DelegateCommand(
                AddPhoneNumberExecute);

            RemovePhoneNumberCommand = new DelegateCommand(
                RemovePhoneNumberExecute, RemovePhoneNumberCanExecute);

            $xxxITEMxxx$s = new ObservableCollection<LookupItem>();
            PhoneNumbers = new ObservableCollection<$xxxTYPExxx$PhoneNumberWrapper>();

            if (Common.VNCLogging.ViewModelLow) Log.VIEWMODEL_LOW("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Enums (none)



        #endregion

        #region Structures (none)



        #endregion

        #region Fields and Properties

        private I$xxxTYPExxx$DataService _$xxxTYPExxx$DataService;
        private I$xxxITEMxxx$LookupDataService _$xxxITEMxxx$LookupDataService;

        private $xxxTYPExxx$PhoneNumberWrapper _selectedPhoneNumber;

        public ObservableCollection<LookupItem> $xxxITEMxxx$s { get; private set;}
        public ObservableCollection<$xxxTYPExxx$PhoneNumberWrapper> PhoneNumbers { get; private set;}

        private $xxxTYPExxx$Wrapper _$xxxTYPExxx$;

        public $xxxTYPExxx$Wrapper $xxxTYPExxx$
        {
            get { return _$xxxTYPExxx$; }
            private set
            {
                _$xxxTYPExxx$ = value;
                OnPropertyChanged();
            }
        }

        public $xxxTYPExxx$PhoneNumberWrapper SelectedPhoneNumber
        {
            get { return _selectedPhoneNumber; }
            set
            {
                _selectedPhoneNumber = value;
                OnPropertyChanged();
                ((DelegateCommand)RemovePhoneNumberCommand).RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region Event Handlers

        private async void OpenDetailView(OpenDetailViewEventArgs args)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("($xxxTYPExxx$DetailViewModel) Enter", Common.LOG_CATEGORY);

            await LoadAsync(args.Id);

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("($xxxTYPExxx$DetailViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        }

        private async void AfterCollectionSaved(AfterCollectionSavedEventArgs args)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("($xxxTYPExxx$DetailViewModel) Enter", Common.LOG_CATEGORY);

            if (args.ViewModelName == nameof($xxxITEMxxx$DetailViewModel))
            {
                await Load$xxxITEMxxx$sLookupAsync();
            }

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("($xxxTYPExxx$DetailViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Commands

        #region Delete Command

        protected override async void DeleteExecute()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER($"($xxxTYPExxx$DetailViewModel) Enter Id:({$xxxTYPExxx$.Id})", Common.LOG_CATEGORY);

            var message = "Do you really want to delete the $xxxTYPExxx$? ?";

            var dialogParameters = new DialogParameters();
            dialogParameters.Add("message", message);
            dialogParameters.Add("title", "Approve Deletion");
            dialogParameters.Add("okcontent", "Yes");
            dialogParameters.Add("cancelcontent", "No");

            DialogService.Show("OkCancelDialog", dialogParameters, async r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    _$xxxTYPExxx$DataService.Remove($xxxTYPExxx$.Model);

                    await _$xxxTYPExxx$DataService.UpdateAsync();

                    PublishAfterDetailDeletedEvent($xxxTYPExxx$.Id);
                }
            });

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("($xxxTYPExxx$DetailViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        }

        protected override bool DeleteCanExecute()
        {
            // TODO(crhodes)
            // Why do we need this?
            return true;
        }

        #endregion

        #region Save Command

        protected override async void SaveExecute()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER($"($xxxTYPExxx$DetailViewModel) Enter Id:({$xxxTYPExxx$.Id})", Common.LOG_CATEGORY);

            await _$xxxTYPExxx$DataService.UpdateAsync();

            //await SaveWithOptimisticConcurrencyAsync(_$xxxTYPExxx$DataService.UpdateAsync,
            //  () =>
            //  {
            //      HasChanges = _$xxxTYPExxx$DataService.HasChanges();
            //      Id = $xxxTYPExxx$.Id;
            //      RaiseDetailSavedEvent($xxxTYPExxx$.Id, $"{$xxxTYPExxx$.FieldString}");
            //  });

            HasChanges = false;
            Id = $xxxTYPExxx$.Id;

            PublishAfterDetailSavedEvent($xxxTYPExxx$.Id, $xxxTYPExxx$.FieldString);

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("($xxxTYPExxx$DetailViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        }

        protected override bool SaveCanExecute()
        {
            // TODO(crhodes)
            // Check if $xxxTYPExxx$ is valid or has changes
            // This enables and disables the button

            var result =  $xxxTYPExxx$ != null
                && !$xxxTYPExxx$.HasErrors
                && HasChanges;

            return result;

            //return true;
        }

        #endregion

        #region AddPhoneNumber Command

        public ICommand AddPhoneNumberCommand { get; private set; }

        private void AddPhoneNumberExecute()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);

            var newNumber = new $xxxTYPExxx$PhoneNumberWrapper(new $xxxTYPExxx$PhoneNumber());
            newNumber.PropertyChanged += $xxxTYPExxx$PhoneNumberWrapper_PropertyChanged;
            PhoneNumbers.Add(newNumber);
            $xxxTYPExxx$.Model.PhoneNumbers.Add(newNumber.Model);
            newNumber.Number = ""; // Trigger validation :-)

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region RemovePhoneNumber Command

        #endregion

        #region Public Methods

        public override async Task LoadAsync(int id)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ViewModel) startTicks = Log.VIEWMODEL($"($xxxTYPExxx$DetailViewModel) Enter Id:({id})", Common.LOG_CATEGORY);

            var item = id > 0
                ? await _$xxxTYPExxx$DataService.FindByIdAsync(id)
                : CreateNew$xxxTYPExxx$();

            Id = item.Id;

            Initialize$xxxTYPExxx$(item);

            Initialize$xxxTYPExxx$PhoneNumbers(item.PhoneNumbers);

            await Load$xxxITEMxxx$sLookupAsync();

            if (Common.VNCLogging.ViewModel) Log.VIEWMODEL("($xxxTYPExxx$DetailViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Protected Methods (none)


        public ICommand RemovePhoneNumberCommand { get; private set;}

        private void RemovePhoneNumberExecute()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);

            SelectedPhoneNumber.PropertyChanged -= $xxxTYPExxx$PhoneNumberWrapper_PropertyChanged;
            //_friendRepository.RemovePhoneNumber(SelectedPhoneNumber.Model);
            PhoneNumbers.Remove(SelectedPhoneNumber);
            SelectedPhoneNumber = null;
            HasChanges = _$xxxTYPExxx$DataService.HasChanges();
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private bool RemovePhoneNumberCanExecute()
        {
            return SelectedPhoneNumber != null;
        }

        #endregion

        #endregion

        #region Private Methods

        private Domain.$xxxTYPExxx$ CreateNew$xxxTYPExxx$()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ViewModel) startTicks = Log.VIEWMODEL("Enter", Common.LOG_CATEGORY);

            var item = new Domain.$xxxTYPExxx$();
            item.FieldDate = DateTime.Now;
            item.FieldDate2 = DateTime.Now;
            _$xxxTYPExxx$DataService.Add(item);

            // TODO(crhodes)
            // Need to figure out how to handle creating new.
            // This tries to push all the way to the database which complains because
            // Haven't set Required Fields (e.g. FieldString)

            // This was our attempt to use our DataService later - but that creates a context and tries to add item which
            // throws exception

            //_dataService.Insert(item);

            // This is what was in Claudius Code (NB>  Add does not call Save Changes in his code
            //_friendRepository.Add(friend);

            if (Common.VNCLogging.ViewModel) Log.VIEWMODEL("Exit", Common.LOG_CATEGORY, startTicks);

            return item;
        }

        private void Initialize$xxxTYPExxx$($xxxTYPExxx$ item)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ViewModel) startTicks = Log.VIEWMODEL("Enter", Common.LOG_CATEGORY);

            $xxxTYPExxx$ = new $xxxTYPExxx$Wrapper(item);

            $xxxTYPExxx$.PropertyChanged += (s, e) =>
            {
                if (!HasChanges)
                {
                    HasChanges = _$xxxTYPExxx$DataService.HasChanges();
                }

                if (e.PropertyName == nameof($xxxTYPExxx$.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }

                if (e.PropertyName == nameof($xxxTYPExxx$.FieldString))
                {
                    SetTitle();
                }
            };

            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

            // Little trick to trigger the validation when creating new entries
            if ($xxxTYPExxx$.Id == 0)
            {
                $xxxTYPExxx$.FieldString = "";
            }

            SetTitle();

            if (Common.VNCLogging.ViewModel)Log.VIEWMODEL("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void Initialize$xxxTYPExxx$PhoneNumbers(ICollection<$xxxTYPExxx$PhoneNumber> phoneNumbers)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ViewModel) startTicks = Log.VIEWMODEL("Enter", Common.LOG_CATEGORY);

            foreach (var wrapper in PhoneNumbers)
            {
                wrapper.PropertyChanged -= $xxxTYPExxx$PhoneNumberWrapper_PropertyChanged;
            }

            PhoneNumbers.Clear();

            foreach (var phoneNumber in phoneNumbers)
            {
                var wrapper = new $xxxTYPExxx$PhoneNumberWrapper(phoneNumber);
                PhoneNumbers.Add(wrapper);
                wrapper.PropertyChanged += $xxxTYPExxx$PhoneNumberWrapper_PropertyChanged;
            }

            if (Common.VNCLogging.ViewModel) Log.VIEWMODEL("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void $xxxTYPExxx$PhoneNumberWrapper_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ViewModel) startTicks = Log.VIEWMODEL("Enter", Common.LOG_CATEGORY);

            if (!HasChanges)
            {
                HasChanges = _$xxxTYPExxx$DataService.HasChanges();
            }
            if (e.PropertyName == nameof($xxxTYPExxx$PhoneNumberWrapper.HasErrors))
            {
                ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
            }

            if (Common.VNCLogging.ViewModel) Log.VIEWMODEL("Exit", Common.LOG_CATEGORY, startTicks);
        }

        private async Task Load$xxxITEMxxx$sLookupAsync()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ViewModel) startTicks = Log.VIEWMODEL("($xxxTYPExxx$DetailViewModel) Enter", Common.LOG_CATEGORY);

            $xxxITEMxxx$s.Clear();

            //ProgrammingLanguages.Add(new NullLookupItem());
            $xxxITEMxxx$s.Add(new NullLookupItem { DisplayMember = " - " });

            var lookup = await _$xxxITEMxxx$LookupDataService
                                .Get$xxxITEMxxx$LookupAsync();

            foreach (var lookupItem in lookup)
            {
                $xxxITEMxxx$s.Add(lookupItem);
            }

            if (Common.VNCLogging.ViewModel) Log.VIEWMODEL("($xxxTYPExxx$DetailViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        }

        private void SetTitle()
        {
            Title = $"{$xxxTYPExxx$.FieldString}";
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
