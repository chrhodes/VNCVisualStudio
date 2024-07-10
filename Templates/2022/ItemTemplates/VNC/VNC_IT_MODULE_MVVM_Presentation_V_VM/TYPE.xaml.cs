using System;
using System.Windows;

using $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.ViewModels;

using VNC;
using VNC.Core.Mvvm;

namespace $xxxMODULExxx$$xxxNAMESPACExxx$.Presentation.Views
{
    public partial class $xxxTYPExxx$ : ViewBase, I$xxxTYPExxx$, IInstanceCountV
    {

        #region Constructors and Load
        
        public $xxxTYPExxx$()
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            InstanceCountV++;
            InitializeComponent();

			// Expose ViewModel
						
            // If View First with ViewModel in Xaml

            // ViewModel = (I$xxxTYPExxx$ViewModel)DataContext;

            // Can create directly
            // ViewModel = $xxxTYPExxx$ViewModel();

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }
        
        public $xxxTYPExxx$(I$xxxTYPExxx$ViewModel viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR($"Enter viewModel({viewModel.GetType()}", Common.LOG_CATEGORY);

            InstanceCountV++;
            InitializeComponent();

            ViewModel = viewModel;

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }
        
        #endregion

        #region Enums (None)


        #endregion

        #region Structures (None)


        #endregion

        #region Fields and Properties (None)


        #endregion

        #region Event Handlers (None)


        #endregion

        #region Commands (None)
         
        #endregion

        #region Public Methods (None)


        #endregion

        #region Protected Methods (None)


        #endregion

        #region Private Methods (None)


        #endregion   
        
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
