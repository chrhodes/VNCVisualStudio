using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Domain;
using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.DomainServices;
using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.ModelWrappers;
using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.Views;

using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;

using VNC;
using VNC.Core.DomainServices;
using VNC.Core.Events;
using VNC.Core.Mvvm;
using VNC.Core.Mvvm.Prism;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.ViewModels
{
    public class $xxxTYPExxx$DetailMVViewModel : DetailViewModelBase, I$xxxTYPExxx$DetailMVViewModel, INavigationAware, IRegionManagerAware, IInstanceCountVM
    {
        #region Contructors, Initialization, and Load

        private readonly IShellService _shellService;
        //private readOnly IRegionManager _regionManager;

        // HACK(crhodes)
        // Asking for a IRegionManager here is going to get the initial default region manager
        // Need to implement custom code so we can create and use a scoped region manager.
        // Watch Prism Problems & Solutions: Showing Multiple Shells - Controlling View Composition

        public $xxxTYPExxx$DetailMVViewModel(
            I$xxxTYPExxx$DataService $xxxTYPExxx$DataService,
            IMouseLookupDataService MouseLookupDataService,
            // IRegionManager regionManager,
            IShellService shellService,
            IEventAggregator eventAggregator,
            IDialogService dialogService) : base(eventAggregator, dialogService)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.Constructor) startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            // TODO(crhodes)
            // Save constructor parameters here

            _$xxxTYPExxx$DataService = $xxxTYPExxx$DataService;
            _MouseLookupDataService = MouseLookupDataService;
            // _regionManager = regionManager;
            _shellService = shellService;

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

            BackCommand = new DelegateCommand<string>(Back, BackCanExecute);
            NextCommand = new DelegateCommand<string>(Next, NextCanExecute);

            EventAggregator.GetEvent<AfterCollectionSavedEvent>()
                .Subscribe(AfterCollectionSaved);

            AddPhoneNumberCommand = new DelegateCommand(
                AddPhoneNumberExecute);

            RemovePhoneNumberCommand = new DelegateCommand(
                RemovePhoneNumberExecute, RemovePhoneNumberCanExecute);

            Mouses = new ObservableCollection<LookupItem>();
            PhoneNumbers = new ObservableCollection<$xxxTYPExxx$PhoneNumberWrapper>();

            Load$xxxTYPExxx$DetailMVACommand = new DelegateCommand(Load$xxxTYPExxx$DetailMVA, Load$xxxTYPExxx$DetailMVACanExecute);

            // If using CommandParameter, figure out TYPE here and below
            // and remove above declaration
            //Load$xxxTYPExxx$DetailMVACommand = new DelegateCommand<TYPE>(Load$xxxTYPExxx$DetailMVA, Load$xxxTYPExxx$DetailMVACanExecute);

            // NOTE(crhodes)
            // Not sure when is best time to do this

            //IRegion region = (IRegion)_regionManager.Regions["MultiStepProcessViewMV"];

            //var r = _regionManager.Regions;

            ////region.RequestNavigate("uicatdetaila");
            ////_regionManager.RequestNavigate("MultiStepProcessViewMV", "uicatdetaila");
            ///
            //var regions = RegionManager.Regions;
            //RegionManager.RequestNavigate("MultiStepProcessViewMV", "uicatdetaila");

            //var ok = _regionManager.Regions.ContainsRegionWithName(RegionNames.MultiStepProcessViewMV);

            if (Common.VNCLogging.ViewModelLow) Log.VIEWMODEL_LOW("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Enums (none)

        #endregion

        #region Structures (none)

        #endregion

        #region Fields and Properties

        #region IRegionManagerAware

        public IRegionManager RegionManager
        {
            get;
            set;
        }

        #endregion

        private I$xxxTYPExxx$DataService _$xxxTYPExxx$DataService;
        private IMouseLookupDataService _MouseLookupDataService;

        public ICommand AddPhoneNumberCommand { get; private set; }
        public ICommand RemovePhoneNumberCommand { get; private set; }

        public DelegateCommand Load$xxxTYPExxx$DetailMVACommand { get; set; }
        // If using CommandParameter, figure out TYPE here and above
        // and remove above declaration
        //public DelegateCommand<TYPE> Load$xxxTYPExxx$DetailMVACommand { get; set; }

        private $xxxTYPExxx$PhoneNumberWrapper _selectedPhoneNumber;

        public ObservableCollection<LookupItem> Mouses { get; private set; }
        public ObservableCollection<$xxxTYPExxx$PhoneNumberWrapper> PhoneNumbers { get; private set; }


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

        public DelegateCommand<string> BackCommand { get; set; }
        public DelegateCommand<string> NextCommand { get; set; }

        public DelegateCommand FirstName_DoubleClick_Command { get; set; }

        private bool _stepAComplete;
        public bool StepAComplete
        {
            get => _stepAComplete;
            set
            {
                if (_stepAComplete == value)
                    return;
                _stepAComplete = value;
                OnPropertyChanged();
            }
        }

        private bool _stepBComplete;
        public bool StepBComplete
        {
            get => _stepBComplete;
            set
            {
                if (_stepBComplete == value)
                    return;
                _stepBComplete = value;
                OnPropertyChanged();
            }
        }

        private bool _stepCComplete;
        public bool StepCComplete
        {
            get => _stepCComplete;
            set
            {
                if (_stepCComplete == value)
                    return;
                _stepCComplete = value;
                OnPropertyChanged();
            }
        }

        private bool _stepDComplete;
        public bool StepDComplete
        {
            get => _stepDComplete;
            set
            {
                if (_stepDComplete == value)
                    return;
                _stepDComplete = value;
                OnPropertyChanged();
            }
        }

        private bool _stepEComplete;
        public bool StepEComplete
        {
            get => _stepEComplete;
            set
            {
                if (_stepEComplete == value)
                    return;
                _stepEComplete = value;
                OnPropertyChanged();
            }
        }

        private string _FirstName;
        public string FirstName
        {
            get => _FirstName;
            set
            {
                if (_FirstName == value) return;
                _FirstName = value;
                OnPropertyChanged();
            }
        }

        public string FirstNameToolTip { get; set; }

        #endregion

        #region Event Handlers

        private async void OpenDetailView(OpenDetailViewEventArgs args)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("(OpenDetailView) Enter", Common.LOG_CATEGORY);

            await LoadAsync(args.Id);

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("(OpenDetailView) Exit", Common.LOG_CATEGORY, startTicks);
        }

        private async void AfterCollectionSaved(AfterCollectionSavedEventArgs args)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("(AfterCollectionSaved) Enter", Common.LOG_CATEGORY);

            if (args.ViewModelName == nameof(MouseDetailViewModel))
            {
                await LoadMousesLookupAsync();
            }

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("(AfterCollectionSaved) Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Commands

       #region Load$xxxTYPExxx$DetailMVA Command

       // If using CommandParameter, figure out TYPE here
       //public TYPE Load$xxxTYPExxx$DetailMVACommandParameter;

       public string Load$xxxTYPExxx$DetailMVAContent { get; set; } = "Load$xxxTYPExxx$DetailMVA";
       public string Load$xxxTYPExxx$DetailMVAToolTip { get; set; } = "Load$xxxTYPExxx$DetailMVA ToolTip";

       // Can get fancy and use Resources
       //public string Load$xxxTYPExxx$DetailMVAContent { get; set; } = "ViewName_Load$xxxTYPExxx$DetailMVAContent";
       //public string Load$xxxTYPExxx$DetailMVAToolTip { get; set; } = "ViewName_Load$xxxTYPExxx$DetailMVAContentToolTip";

       // Put these in Resource File
       //    <system:String x:Key="ViewName_Load$xxxTYPExxx$DetailMVAContent">Load$xxxTYPExxx$DetailMVA</system:String>
       //    <system:String x:Key="ViewName_Load$xxxTYPExxx$DetailMVAContentToolTip">Load$xxxTYPExxx$DetailMVA ToolTip</system:String>

       // If using CommandParameter, figure out TYPE here
       //public void Load$xxxTYPExxx$DetailMVA(TYPE value)
       public void Load$xxxTYPExxx$DetailMVA()
       {
           Int64 startTicks = 0;
           if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);
           // TODO(crhodes)
           // Do something amazing.

           Message = "Cool, you called Load$xxxTYPExxx$DetailMVA";

           PublishStatusMessage(Message);

           var regions = RegionManager.Regions;
           RegionManager.RequestNavigate("MultiStepProcessViewMV", "uicatdetaila");

           // If launching a UserControl

           // if (_Load$xxxTYPExxx$DetailMVAHost is null) _Load$xxxTYPExxx$DetailMVAHost = new WindowHost();
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

           // Common.EventAggregator.GetEvent<Load$xxxTYPExxx$DetailMVAEvent>().Publish();

           // May want EventArgs

           //  EventAggregator.GetEvent<Load$xxxTYPExxx$DetailMVAEvent>().Publish(
           //      new Load$xxxTYPExxx$DetailMVAEventArgs()
           //      {
           //            Organization = _collectionMainViewModel.SelectedCollection.Organization,
           //            Process = _contextMainViewModel.Context.SelectedProcess
           //      });

           // Start Cut Four - Put this in PrismEvents

           // public class Load$xxxTYPExxx$DetailMVAEvent : PubSubEvent { }

           // End Cut Four

           // Start Cut Five - Put this in places that listen for event

           //Common.EventAggregator.GetEvent<Load$xxxTYPExxx$DetailMVAEvent>().Subscribe(Load$xxxTYPExxx$DetailMVA);

           // End Cut Five

           if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
       }

        // If using CommandParameter, figure out TYPE and fix above
        //public bool Load$xxxTYPExxx$DetailMVACanExecute(TYPE value)
        public bool Load$xxxTYPExxx$DetailMVACanExecute()
        {
            // TODO(crhodes)
            // Add any before button is enabled logic.
            return true;
        }

        #endregion


        #region Command FirstName DoubleClick

        public void FirstName_DoubleClick()
        {
            Message = "FirstName_DoubleClick";
        }

        #endregion

        #region Back Command

        // If displaying UserControl
        // public static WindowHost _BackHost = null;

        // If using CommandParameter, figure out TYPE here
        //public TYPE BackCommandParameter;

        public string BackContent { get; set; } = "Back";
        public string BackToolTip { get; set; } = "Back ToolTip";

        // Can get fancy and use Resources
        //public string BackContent { get; set; } = "ViewName_BackContent";
        //public string BackToolTip { get; set; } = "ViewName_BackContentToolTip";

        // Put these in Resource File
        //    <system:String x:Key="ViewName_BackContent">Back</system:String>
        //    <system:String x:Key="ViewName_BackContentToolTip">Back ToolTip</system:String>

        // If using CommandParameter, figure out TYPE here
        public void Back(string viewNavigationName)
        //public void Back()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);
            // TODO(crhodes)
            // Do something amazing.

            Message = $"Cool, you called Back {viewNavigationName}";

            PublishStatusMessage(Message);

            // HACK(crhodes)
            // Need to implement custom RegionManager and use it
            // This is using the default reigon manager

            //var ok = _regionManager.Regions.ContainsRegionWithName(RegionNames.MultiStepProcessViewMV);

            //if (ok)
            //{
            //    _regionManager.RequestNavigate("MultiStepProcessViewMV", viewNavigationName);
            //}
            //_regionManager.RequestNavigate("MultiStepProcessViewMV", viewNavigationName);

            RegionManager.RequestNavigate("MultiStepProcessViewMV", viewNavigationName);

            // If launching a UserControl

            // if (_BackHost is null) _BacknHost = new WindowHost();
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

            // Common.EventAggregator.GetEvent<BackEvent>().Publish();

            // May want EventArgs

            //  EventAggregator.GetEvent<BackEvent>().Publish(
            //      new BackEventArgs()
            //      {
            //            Organization = _collectionMainViewModel.SelectedCollection.Organization,
            //            Process = _contextMainViewModel.Context.SelectedProcess
            //      });

            // Start Cut Four - Put this in PrismEvents

            // public class BackEvent : PubSubEvent { }

            // End Cut Four

            // Start Cut Five - Put this in places that listen for event

            //Common.EventAggregator.GetEvent<BackEvent>().Subscribe(Back);

            // End Cut Five

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // If using CommandParameter, figure out TYPE and fix above
        public bool BackCanExecute(string viewNavigationName)
        //public bool BackCanExecute()
        {
            // TODO(crhodes)
            // Add any before button is enabled logic.
            return true;
        }

        #endregion

        #region Next Command

        // If displaying UserControl
        // public static WindowHost _NextHost = null;

        // If using CommandParameter, figure out TYPE here
        //public TYPE NextCommandParameter;

        public string NextContent { get; set; } = "Next";
        public string NextToolTip { get; set; } = "Next ToolTip";

        // Can get fancy and use Resources
        //public string NextContent { get; set; } = "ViewName_NextContent";
        //public string NextToolTip { get; set; } = "ViewName_NextContentToolTip";

        // Put these in Resource File
        //    <system:String x:Key="ViewName_NextContent">Next</system:String>
        //    <system:String x:Key="ViewName_NextContentToolTip">Next ToolTip</system:String>

        // If using CommandParameter, figure out TYPE here
        public void Next(string viewNavigationName)
        //public void Next()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);
            // TODO(crhodes)
            // Do something amazing.

            Message = $"Cool, you called Next {viewNavigationName}";

            PublishStatusMessage(Message);

            _shellService.ShowShell(viewNavigationName);

            //var ok = _regionManager.Regions.ContainsRegionWithName(RegionNames.MultiStepProcessViewMV);

            //if (ok)
            //{
            //    var targetRegion = _regionManager.Regions[RegionNames.MultiStepProcessViewMV];
            //    targetRegion.RequestNavigate(viewNavigationName);

            //    //switch (viewNavigationName)
            //    //{
            //    //    case "uicatdetaila":
            //    //        if (catDetailMVA is null)
            //    //        { 
            //    //            catDetailMVA = new CatDetailMVA();
            //    //            targetRegion.Add(catDetailMVA);
            //    //            targetRegion.Activate(catDetailMVA);
            //    //        }

            //    //        //targetRegion.RequestNavigate(viewNavigationName);
            //    //        targetRegion.Activate(catDetailMVA);
            //    //        break;

            //    //    case "uicatdetailb":
            //    //        if (catDetailMVB is null)
            //    //        {
            //    //            catDetailMVB = new CatDetailMVB();
            //    //            targetRegion.Add(catDetailMVB);
            //    //            targetRegion.Activate(catDetailMVB);
            //    //        }

            //    //        //targetRegion.RequestNavigate(viewNavigationName);
            //    //        //targetRegion.Activate(catDetailMVB);
            //    //        break;

            //    //    case "uicatdetailc":
            //    //        if (catDetailMVC is null)
            //    //        {
            //    //            catDetailMVC = new CatDetailMVC();
            //    //            targetRegion.Add(catDetailMVC);
            //    //        }

            //    //        //targetRegion.RequestNavigate(viewNavigationName);
            //    //        targetRegion.Activate(catDetailMVC);
            //    //        break;

            //    //    case "uicatdetaild":
            //    //        if (catDetailMVD is null)
            //    //        {
            //    //            catDetailMVD = new CatDetailMVD();
            //    //            targetRegion.Add(catDetailMVD);
            //    //        }

            //    //        //targetRegion.RequestNavigate(viewNavigationName);
            //    //        targetRegion.Activate(catDetailMVE);
            //    //        break;

            //    //    case "uicatdetaile":
            //    //        if (catDetailMVE is null)
            //    //        {
            //    //            catDetailMVE = new CatDetailMVE();
            //    //            targetRegion.Add(catDetailMVE);
            //    //        }

            //    //        //targetRegion.RequestNavigate(viewNavigationName);
            //    //        targetRegion.Activate(catDetailMVE);
            //    //        break;

            //    //    default:
            //    //        break;
            //    //}

                
            //    //_regionManager.RequestNavigate("MultiStepProcessViewMV", viewNavigationName);
            //}
            //_regionManager.RequestNavigate("MultiStepProcessViewMV", viewNavigationName);

            RegionManager.RequestNavigate("MultiStepProcessViewMV", viewNavigationName);

            // If launching a UserControl

            // if (_NextHost is null) _NextnHost = new WindowHost();
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

            // Common.EventAggregator.GetEvent<NextEvent>().Publish();

            // May want EventArgs

            //  EventAggregator.GetEvent<NextEvent>().Publish(
            //      new NextEventArgs()
            //      {
            //            Organization = _collectionMainViewModel.SelectedCollection.Organization,
            //            Process = _contextMainViewModel.Context.SelectedProcess
            //      });

            // Start Cut Four - Put this in PrismEvents

            // public class NextEvent : PubSubEvent { }

            // End Cut Four

            // Start Cut Five - Put this in places that listen for event

            //Common.EventAggregator.GetEvent<NextEvent>().Subscribe(Next);

            // End Cut Five

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        // If using CommandParameter, figure out TYPE and fix above
        public bool NextCanExecute(string value)
        //public bool NextCanExecute()
        {
            // TODO(crhodes)
            // Add any before button is enabled logic.
            return true;
        }

        #endregion

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

            await LoadMousesLookupAsync();

            if (Common.VNCLogging.ViewModel) Log.VIEWMODEL("($xxxTYPExxx$DetailViewModel) Exit", Common.LOG_CATEGORY, startTicks);
        }


        #region INavigationAware

        // TODO(crhodes)
        // Override these methods as necessary
        // Default implementation logs and returns false from IsNavigationTarget

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER($"Enter {navigationContext.Uri}", Common.LOG_CATEGORY);

            var n = navigationContext;

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);

            // Create New Instance
            //return false;
            // Use Existing Instance
            return true;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER($"Enter {navigationContext.Uri}", Common.LOG_CATEGORY);

            var n = navigationContext;

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER($"Enter {navigationContext.Uri}", Common.LOG_CATEGORY);

            var n = navigationContext;

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

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

        protected override bool SaveCanExecute()
        {
            // TODO(crhodes)
            // Check if $xxxTYPExxx$ is valid or has changes
            // This enables and disables the button

            var result = $xxxTYPExxx$ != null
                && !$xxxTYPExxx$.HasErrors
                && HasChanges;

            return result;

            //return true;
        }

        protected override async void SaveExecute()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER($"(SaveExecute) Enter Id:({$xxxTYPExxx$.Id})", Common.LOG_CATEGORY);

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

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("(SaveExecute) Exit", Common.LOG_CATEGORY, startTicks);
        }

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

            if (Common.VNCLogging.ViewModel) Log.VIEWMODEL("Exit", Common.LOG_CATEGORY, startTicks);
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

        private async Task LoadMousesLookupAsync()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.ViewModel) startTicks = Log.VIEWMODEL("($xxxTYPExxx$DetailViewModel) Enter", Common.LOG_CATEGORY);

            Mouses.Clear();

            //ProgrammingLanguages.Add(new NullLookupItem());
            Mouses.Add(new NullLookupItem { DisplayMember = " - " });

            var lookup = await _MouseLookupDataService
                                .GetMouseLookupAsync();

            foreach (var lookupItem in lookup)
            {
                Mouses.Add(lookupItem);
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
