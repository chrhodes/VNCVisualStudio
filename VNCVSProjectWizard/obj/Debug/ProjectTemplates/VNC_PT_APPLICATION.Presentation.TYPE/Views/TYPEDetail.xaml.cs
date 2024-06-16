using System.Windows.Controls;

using VNC.Core.Mvvm;

namespace $safeprojectname$.Views
{
    public partial class $customTYPE$Detail : UserControl, I$customTYPE$Detail
    {
        public $customTYPE$Detail(ViewModels.I$customTYPE$DetailViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
