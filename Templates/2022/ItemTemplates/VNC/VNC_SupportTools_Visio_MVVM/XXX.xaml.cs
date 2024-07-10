using System.Windows.Controls;
using SupportTools_Visio.Presentation.ViewModels;
using VNC;

namespace SupportTools_Visio.Presentation.Views
{
    public partial class $safeitemname$ : UserControl
    {
        private readonly $safeitemname$ViewModel _viewModel;

        #region Constructors and Load

        public $safeitemname$($safeitemname$ViewModel viewModel)
        {
            nt64 startTicks = Log.CONSTRUCTOR($"Enter viewModel({viewModel.GetType()}", Common.LOG_CATEGORY);
            
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            
            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion
    }
}
