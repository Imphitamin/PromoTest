using System;
using PromoTest.Project.BusinessLogic.Interfaces.Models;

namespace PromoTest.Project.BusinessLogic.Models
{
    public class LobbyViewModel : ILobbyViewModel
    {
        public Action StartButtonClickHandler { get; }

        public LobbyViewModel(Action startButtonClickHandler)
        {
            StartButtonClickHandler = startButtonClickHandler;
        }
    }
}