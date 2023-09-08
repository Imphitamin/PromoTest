using System;
using Grace.DependencyInjection.Attributes;
using PromoTest.Project.BusinessLogic.Interfaces.Models;
using PromoTest.Project.BusinessLogic.Models;
using PromoTest.Project.Presentation.Views;
using UnityEngine;

namespace PromoTest.Project.Presentation.Presenters
{
    public class LobbyPresenter : BasePresenter<ILobbyViewModel, LobbyView>
    {
        private readonly PromoPresenter _promoPresenter;
        
        public LobbyPresenter(
            [Import(Key = "MainCanvasTransform")] Func<Transform> mainCanvasTransformGetter,
            PromoPresenter promoPresenter)
            : base(mainCanvasTransformGetter)
        {
            _promoPresenter = promoPresenter;
        }
        
        protected override ILobbyViewModel ConstructViewModel()
        {
            return new LobbyViewModel(OnStartButtonClickHandler);
        }

        private void OnStartButtonClickHandler()
        {
            _promoPresenter.Show();
            Close();
        }
    }
}