using System.Windows.Controls;

using VNC;
//using System.Windows.Forms;

namespace SupportTools_Visio.Presentation.Views
{
    public partial class $safeitemname$ : UserControl
    {
        private readonly XXXViewModel _viewModel;

        #region Constructors and Load

        public $safeitemname$(XXXViewModel viewModel)
        {
            Int64 startTicks = Log.CONSTRUCTOR($"Enter viewModel({viewModel.GetType()}", Common.LOG_APPNAME);
            
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            
            Log.CONSTRUCTOR("Exit", Common.PROJECT_NAME, startTicks);
        }

        #endregion
    }
}
