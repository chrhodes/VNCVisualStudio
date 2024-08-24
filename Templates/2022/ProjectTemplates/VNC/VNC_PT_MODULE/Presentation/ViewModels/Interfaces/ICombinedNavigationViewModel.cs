using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.ViewModels
{
    public interface ICombinedNavigationViewModel : IViewModel
    {
        // TODO(crhodes)
        // Add items here that the ICombinedNavigationViewModel must support
        // to enable all the binding demands of the View
        
        Task LoadAsync();
    }
}
