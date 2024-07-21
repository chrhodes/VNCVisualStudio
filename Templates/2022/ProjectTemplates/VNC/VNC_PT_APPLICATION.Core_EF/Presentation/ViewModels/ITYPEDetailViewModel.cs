using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace $xxxAPPLICATIONxxx$$xxxNAMESPACExxx$.Presentation.ViewModels
{
    public interface I$xxxTYPExxx$DetailViewModel : IViewModel
    {
        // TODO(crhodes)
        // Add items here that the I$xxxTYPExxx$DetailViewModel must support
        // to enable all the binding demands of the View
        
        Task LoadAsync(int id);
    }
}
