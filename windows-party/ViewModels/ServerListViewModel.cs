using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesonet.Windows.Party.Helpers;
using Tesonet.Windows.Party.Models;
using Tesonet.Windows.Party.Repositories;

namespace Tesonet.Windows.Party.ViewModels
{
    public class ServerListViewModel : ViewModelBase
    {
        public User LoggedInUser { get; set; }

        private readonly IServerRepository _serverRepository;

        public Action LogOut = delegate { };

        public RelayCommand LogOutCommand { get; private set; }

        private ObservableCollection<Server> _servers;
        public ObservableCollection<Server> Servers
        {
            get => _servers;
            set => SetProperty(ref _servers, value);
        }

        public ServerListViewModel(IServerRepository serverRepository)
        {
            _serverRepository = serverRepository;
            LogOutCommand = new RelayCommand(OnLogOut);
        }

        public async Task LoadServers()
        {
            // TODO handle exception
            Servers = new ObservableCollection<Server>(await _serverRepository.GetServers(LoggedInUser.Token));
        }

        private void OnLogOut()
        {
            LoggedInUser = null;
            LogOut();
        }
    }
}
