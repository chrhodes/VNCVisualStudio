using System;

using Prism.Commands;

using SupportTools_Visio.Actions;

using VNC;
using VNC.Core.Mvvm;

using Visio = Microsoft.Office.Interop.Visio;

namespace $rootnamespace$
{
    public class $safeitemname$ : ViewModelBase, IEditTextViewModel
    {
        public System.Collections.ObjectModel.ObservableCollection<Domain.ControlsRow> ControlRows { get; set; }


        public DelegateCommand UpdateSettings { get; private set; }
        public DelegateCommand LoadCurrentSettings { get; private set; }

        public XXXWrapper XXX { get; set; }


        public $safeitemname$()
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);
            
            UpdateSettings = new DelegateCommand(OnUpdateSettingsExecute, OnUpdateSettingsCanExecute);
            LoadCurrentSettings = new DelegateCommand(OnLoadCurrentSettingsExecute, OnLoadCurrentSettingsCanExecute);

            // TODO(crhodes)
            // Decide if we want defaults
            //XXX = new XXXWrapper(new Domain.XXX());
            
            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        public void OnUpdateSettingsExecute()
        {
            Log.Trace("Enter", Common.PROJECT_NAME);
            // Wrap a big, OMG, what have I done ???, undo around the whole thing !!!

            int undoScope = Globals.ThisAddIn.Application.BeginUndoScope("UpdateControlRow");

            // Just need to pass in the model.

            //Visio.Application app = Globals.ThisAddIn.Application;

            //Visio.Selection selection = app.ActiveWindow.Selection;

            //// Verify only one shape, for now just grab first.

            //foreach (Visio.Shape shape in selection)
            //{
            //    //Visio_Shape.Set_XXX_Section(shape, XXX.Model);
            //}

            Globals.ThisAddIn.Application.EndUndoScope(undoScope, true);
            Log.Trace("Exit", Common.PROJECT_NAME);
        }

        public Boolean OnUpdateSettingsCanExecute()
        {
            // TODO(crhodes)
            // Validate we have new settings

            return true;
        }

        void OnLoadCurrentSettingsExecute()
        {
            Visio.Application app = Globals.ThisAddIn.Application;

            Visio.Selection selection = app.ActiveWindow.Selection;

            // Verify only one shape, for now just grab first.

            foreach (Visio.Shape shape in selection)
            {
                XXX = new XXXrapper(Visio_Shape.Get_XXX(shape));
                OnPropertyChanged("XXX");
            }
        }

        bool OnLoadCurrentSettingsCanExecute()
        {
            // TODO(crhodes)
            // Check if shape selected

            return true;
        }
    }
}
