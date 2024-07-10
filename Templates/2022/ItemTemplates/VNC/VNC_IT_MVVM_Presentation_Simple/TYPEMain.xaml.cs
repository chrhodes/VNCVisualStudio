using System;
using System.Windows;

using VNC;
using VNC.Core.Mvvm;

namespace $customAPPLICATION$.Presentation.Views
{
    public partial class $customTYPE$Main : ViewBase, I$customTYPE$Main, IInstanceCountV
    {

        public $customTYPE$Main(ViewModels.I$customTYPE$MainViewModel viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR($"Enter viewModel({viewModel.GetType()}", Common.LOG_APPNAME);

            InstanceCountV++;
            InitializeComponent();

            ViewModel = viewModel;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
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
