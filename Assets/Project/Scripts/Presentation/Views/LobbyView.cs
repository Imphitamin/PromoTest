using System;
using PromoTest.Project.BusinessLogic.Interfaces.Models;
using PromoTest.Project.Common.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace PromoTest.Project.Presentation.Views
{
    public sealed class LobbyView : BaseView<ILobbyViewModel>
    {
        [SerializeField]
        private Button _startBtn;

        private Action _startButtonClickHandler;

        private void Awake()
        {
#if UNITY_EDITOR || DEBUG
            Verify();
#endif
            
            Unsubscribe();
        }
        
        
#if UNITY_EDITOR || DEBUG
        private void Verify()
        {
            _startBtn.VerifyNotNull();
        }
#endif

        public override void Show(ILobbyViewModel model)
        {
            _startButtonClickHandler = model.StartButtonClickHandler;
            
            UpdateInternal();
        }

        public override void Close()
        {
            Unsubscribe();
            _startButtonClickHandler = null;
        }

        private void UpdateInternal()
        {
            if (_startButtonClickHandler != null)
            {
                _startBtn.onClick.AddListener(() => _startButtonClickHandler.Invoke());
            }
        }

        private void Unsubscribe()
        {
            _startBtn.onClick.RemoveAllListeners();
        }
    }
}