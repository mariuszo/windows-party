using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesonet.Windows.Party.Models;
using Tesonet.Windows.Party.Repositories;

namespace Tesonet.Windows.Party.ViewModels
{
    public class ServerListViewModel : ViewModelBase
    {
        public User LoggedInUser { get; set; }
        private readonly IServerRepository _serverRepository;

        public ServerListViewModel(IServerRepository serverRepository)
        {
            _serverRepository = serverRepository;
        }
    }
}
