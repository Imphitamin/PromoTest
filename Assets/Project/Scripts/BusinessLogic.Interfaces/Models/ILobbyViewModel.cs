using System;

namespace PromoTest.Project.BusinessLogic.Interfaces.Models
{
    public interface ILobbyViewModel : IBaseModel
    {
        Action StartButtonClickHandler { get; }
    }
}