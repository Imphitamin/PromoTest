using System.Collections.Generic;
using PromoTest.Project.BusinessLogic.Interfaces.Models;
using PromoTest.Project.Common.Extenders;
using PromoTest.Project.Common.Extensions;
using PromoTest.Project.Presentation.Interfaces.Views;
using UnityEngine;

namespace PromoTest.Project.Presentation.Views
{
    public class PromoView : BaseView<IPromoViewModel>
    {
        [SerializeField]
        private ScrollRectExtended _mainScrollRect;
        
        [SerializeField]
        private Transform _sectionsGroup;

        [SerializeField]
        private UserGemsPanel _userGemsPanel;

        private IReadOnlyList<IPromoSection> _promoSections;

        private void Awake()
        {
#if UNITY_EDITOR || DEBUG
            Verify();
#endif
        }

#if UNITY_EDITOR || DEBUG
        private void Verify()
        {
            _mainScrollRect.VerifyNotNull();
            _sectionsGroup.VerifyNotNull();
            _userGemsPanel.VerifyNotNull();
        }
#endif

        public override void Show(IPromoViewModel model)
        {
            _promoSections = model.PromoSections;
            _userGemsPanel.Initialize(model.UserService);
            
            UpdateViewInternal();
        }
        
        public override void Close()
        {
            if (_promoSections == null)
            {
                return;
            }
            
            for (var i = _promoSections.Count - 1 ; i >= 0; i--)
            {
                Destroy(_promoSections[i].GameObject);
            }

            _promoSections = null;
        }
        
        private void UpdateViewInternal()
        {
            if (_promoSections == null)
            {
                return;
            }
            
            for (var i = 0; i < _promoSections.Count; i++)
            {
                var promoSection = _promoSections[i];
                promoSection.SetParent(_sectionsGroup);
                promoSection.SetParentScrollRect(_mainScrollRect);
            }
        }
    }
}