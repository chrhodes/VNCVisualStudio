using System.Collections.ObjectModel;
using System.Threading.Tasks;

using $customAPPLICATION$.Core.Events;
using $customAPPLICATION$.DomainServices;

using Prism.Events;

using VNC.Core.Domain;
using VNC.Core.Mvvm;

namespace $safeprojectname$.ViewModels
{
    public class $customTYPE$ViewModel : ViewModelBase, I$customTYPE$ViewModel, IViewModel
    {
        private I$customTYPE$LookupDataService _dataService;
        private IEventAggregator _eventAggregator;

        public $customTYPE$ViewModel(
                I$customTYPE$LookupDataService $customTYPE$LookupDataService,
                IEventAggregator eventAggregator)
        {
            _dataService = $customTYPE$LookupDataService;
            _eventAggregator = eventAggregator;
            $customTYPE$s = new ObservableCollection<NavigationItemViewModel>();
        }

        public async Task LoadAsync()
        {
            var lookup = await _dataService.Get$customTYPE$LookupAsync();
            $customTYPE$s.Clear();

            foreach (var item in lookup)
            {
                $customTYPE$s.Add(new NavigationItemViewModel(item.Id, item.DisplayMember));
            }
        }

        public ObservableCollection<NavigationItemViewModel> $customTYPE$s { get; }

        public IView View
        {
            get;
            set;
        }

        NavigationItemViewModel _selected$customTYPE$;

        public NavigationItemViewModel Selected$customTYPE$
        {
            get { return _selected$customTYPE$; }
            set
            {
                _selected$customTYPE$ = value;
                OnPropertyChanged();

                if (_selected$customTYPE$ != null)
                {
                    _eventAggregator.GetEvent<Open$customTYPE$DetailViewEvent>()
                        .Publish(_selected$customTYPE$.Id);
                }
            }
        }
    }
}
