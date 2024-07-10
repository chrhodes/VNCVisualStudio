using System;

using $xxxAPPLICATIONxxx$.Domain$xxxNAMESPACExxx$;
using $xxxAPPLICATIONxxx$.Domain$xxxNAMESPACExxx$.Events;
using $xxxAPPLICATIONxxx$.Presentation.ViewModels;

using DevExpress.Xpf.Grid;

using VNC;
using VNC.Core.Mvvm;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.Views
{
    public partial class $xxxTYPExxx$Main : ViewBase, IInstanceCountV
    {
       
        public $xxxTYPExxx$Main(DomainViewModel<$xxxTYPExxx$, Get$xxxTYPExxx$sEvent, Get$xxxTYPExxx$sEventArgs, Selected$xxxTYPExxx$ChangedEvent> viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InstanceCountV++;
            InitializeComponent();

            ViewModel = viewModel;
            TargetGrid = grdResults;

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }        

        private GridControl _targetGrid;

        public GridControl TargetGrid
        {
            get => _targetGrid;
            set => _targetGrid = value;

        }
        
        #region IInstanceCount

        private static int _instanceCountV;

        public int InstanceCountV
        {
            get => _instanceCountV;
            set => _instanceCountV = value;
        }

        #endregion

    }
}
