using System.Windows;
using System.Windows.Controls;

using VNC.Core.Mvvm;

namespace $safeprojectname$.Views
{
    public partial class $customTYPE$ : UserControl, I$customTYPE$
    {

        public $customTYPE$(ViewModels.I$customTYPE$ViewModel viewModel)
        {
            InitializeComponent();

            ViewModel = viewModel;
            Loaded += $customTYPE$_Loaded;
        }

        private async void $customTYPE$_Loaded(object sender, RoutedEventArgs e)
        {
            await ((ViewModels.I$customTYPE$ViewModel)ViewModel).LoadAsync();
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
