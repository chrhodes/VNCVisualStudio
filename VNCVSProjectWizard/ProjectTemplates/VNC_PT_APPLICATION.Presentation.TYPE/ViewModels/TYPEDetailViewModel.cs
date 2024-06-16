using System.Threading.Tasks;

using $customAPPLICATION$.Core.Events;
using $customAPPLICATION$.DomainServices;
using Prism.Events;

using VNC.Core.Mvvm;
using System;
using System.Windows.Input;
using Prism.Commands;

namespace $safeprojectname$.ViewModels
{
    class $customTYPE$DetailViewModel : ViewModelBase, I$customTYPE$DetailViewModel
    {
        private I$customTYPE$DataService _dataService;
        private IEventAggregator _eventAggregator;

        public $customTYPE$DetailViewModel(
                I$customTYPE$DataService dataService,
                IEventAggregator eventAggregator)
        {
            _dataService = dataService;
            _eventAggregator = eventAggregator;
       
            _eventAggregator.GetEvent<Open$customTYPE$DetailViewEvent>()
                .Subscribe(OnOpen$customTYPE$DetailView);

            SaveCommand = new DelegateCommand(
                OnSaveExecute, OnSaveCanExecute);
        }

        private void OnOpen$customTYPE$DetailView(After$customTYPE$SavedEventArgs obj)
        {
            throw new NotImplementedException();
        }

        private async void OnOpen$customTYPE$DetailView(int typeId)
        {
            await LoadAsync(typeId);
        }

        public async Task LoadAsync(int id)
        {
            Type = await _dataService.FindByIdAsync(id);
        }

        private $customAPPLICATION$.Domain.$customTYPE$ _type;

        public $customAPPLICATION$.Domain.$customTYPE$ Type
        {
            get { return _type; }
            private set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        async void OnSaveExecute()
        {
            await _dataService.UpdateAsync(Type);

            // Tell the Customer that we have updated something
            _eventAggregator.GetEvent<After$customTYPE$SavedEvent>()
                .Publish(new After$customTYPE$SavedEventArgs
                {
                    Id = Type.Id,
                    DisplayMember = Type.FieldString
                    //DisplayMember = $"{Type.FieldString} {Customer.LastName}"
                });

        }

        bool OnSaveCanExecute()
        {
            // TODO(crhodes)
            // Check if Customer is valid
            return true;
        }
    }
}
