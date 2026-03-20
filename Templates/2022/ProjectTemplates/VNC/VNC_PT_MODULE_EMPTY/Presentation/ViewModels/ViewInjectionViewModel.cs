using System;
using System.Linq;
using System.Reflection;
using System.Windows.Input;

using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Core;

using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;

using VNC;
using VNC.Core.Mvvm;
using VNC.WPF.Presentation.Views;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.ViewModels
{
    // NOTE(crhodes)
    // This ViewModel has knowledge of concrete views, UI1, UI2, UI3
    // which is generally a bad practice
    // Could put Commands/EventHandlers in ViewInjection.xaml.cs to avoid
    // Generally better to use Uri based Region Navigation in ViewModel
    // See ViewNavigationViewModel

    public class ViewInjectionViewModel : EventViewModelBase, IViewInjectionViewModel, IInstanceCountVM
    {
        #region Constructors, Initialization, and Load

        private readonly IRegionManager _regionManager;

        public ViewInjectionViewModel(
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

            SayHelloCommand = new DelegateCommand(
                SayHello, SayHelloCanExecute);

            PerformViewInjectionCommand = new DelegateCommand<string>(PerformViewInjection);

            Message = "ViewInjectionViewModel says hello";

            if (Common.VNCLogging.ViewModelLow) Log.VIEWMODEL_LOW("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Enums (none)


        #endregion

        #region Structures (none)


        #endregion

        #region Fields and Properties

        private ViewsCollection _activeViews;
        public ViewsCollection ActiveViews
        {
            get => _activeViews;
            set
            {
                if (_activeViews == value) return;
                _activeViews = value;
                OnPropertyChanged();
            }
        }

        private ViewsCollection _Views;
        public ViewsCollection Views
        {
            get => _Views;
            set
            {
                if (_Views == value) return;
                _Views = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Event Handlers (none)


        #endregion

        #region Public Methods (none)


        #endregion

        #region Commands

        #region PerformViewInjectionCommand

        public DelegateCommand<string> PerformViewInjectionCommand { get; set; }

        public void PerformViewInjection(string parameters)
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);

            var actionDetails = parameters.Split('|');

            var assemblyName = actionDetails[0];
            var typeName = actionDetails[1];
            var action = actionDetails[2];
            
            Boolean useContainer = actionDetails.Length > 3;

            Message = $"PerformViewInjection >{assemblyName}< >{typeName}> >{action}< useContainer:{useContainer}";

            PublishStatusMessage(Message);

            IRegion region = _regionManager.Regions[RegionNames.ViewInjectionView];            

            //Boolean useBeta = actionDetails.Length > 3;

            // NOTE(crhodes)
            // For now cheat an go to the assembly we know has what we want.

            var vncWPFPresentation = Assembly.GetAssembly(typeof(UI1));

            // These works
            var assembly = Assembly.Load("VNC.WPF.Presentation");

            var assembly2 = Assembly.Load(assemblyName);

            // Good
            Type ucType = vncWPFPresentation.GetType($"{assemblyName}.{typeName}");

            Type ucType2 = assembly.GetType($"{assemblyName}.{typeName}");

            Type ucType3 = assembly.GetType("VNC.WPF.Presentation.Views.UI1");

            //Type viewType = GetType().Assembly.GetType($"VNC.WPF.Presentation.Views.{viewName}");

            //var foo = Common.Container.Resolve(viewType);

            //Assembly.Ge
            //var vncWPFPresentation = Assembly.GetAssembly(typeof(UI1));

            //var viewType2 = vncWPFPresentation.GetType($"VNC.WPF.Presentation.Views.{viewName}");

            //var foo = Common.Container.Resolve(viewType);

            //if (viewType is null)
            //{
            //    Message = $"View {viewName} not found.  Check xaml";
            //    PublishStatusMessage(Message);
            //    if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
            //    return;
            //}

            var viewType = typeName.Split('.').Last();
            Boolean viewExists = region.Views.Any(v => v.GetType() == ucType2);

            if (viewExists)
            {
                var foo = region.Views.First(v => v.GetType() == ucType2);
            }

            switch (action)
            {
                case "add":

                    if (!viewExists)
                        if (useContainer)
                        {
                            region.Add(Common.Container.Resolve(ucType2));
                        }
                        else
                        {
                            region.Add(Activator.CreateInstance(ucType2));
                        }

                    break;

                case "activate":
                      if (viewExists)
                    {
                        region.Activate(region.Views.First(v => v.GetType() == ucType2));
                    }
                    
                    break;

                case "deactivate":
                    if (viewExists)
                    {
                        region.Deactivate(region.Views.First(v => v.GetType() == ucType2));
                    }
                    
                    break;

                case "remove":
                    if (viewExists)
                    {
                        region.Remove(region.Views.First(v => v.GetType() == ucType2));
                    }

                    break;
            }

            Views = region.Views as ViewsCollection;
            ActiveViews = region.ActiveViews as ViewsCollection;

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
        }

        public bool PerformViewInjectionCanExecute(string parameters)
        {
            // TODO(crhodes)
            // Add any before button is enabled logic.

            return true;
        }

        #endregion

        #region SayHello Command

        public ICommand SayHelloCommand { get; private set; }

        private bool SayHelloCanExecute()
        {
            return true;
        }

        private void SayHello()
        {
            Int64 startTicks = 0;
            if (Common.VNCLogging.EventHandler) startTicks = Log.EVENT_HANDLER("Enter", Common.LOG_CATEGORY);

            Message = "Hello";

            if (Common.VNCLogging.EventHandler) Log.EVENT_HANDLER("Exit", Common.LOG_CATEGORY, startTicks);
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
