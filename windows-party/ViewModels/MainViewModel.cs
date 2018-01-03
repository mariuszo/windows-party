using Autofac;
using Tesonet.Windows.Party.Models;

namespace Tesonet.Windows.Party.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private LogInViewModel _loginViewModel;
        private ServerListViewModel _serverListViewModel;

        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        public MainViewModel()
        {
            _loginViewModel = Bootstrapper.Container.Resolve<LogInViewModel>();
            _serverListViewModel = Bootstrapper.Container.Resolve<ServerListViewModel>();
            CurrentViewModel = _loginViewModel;
            _loginViewModel.LogInSuccessful += ShowServerList;
        }

        private void ShowServerList(User user)
        {
            _serverListViewModel.LoggedInUser = user;
            CurrentViewModel = _serverListViewModel;
        }
    }
}
