using System;
using System.Collections;
using PromoTest.Project.BusinessLogic.Interfaces.Models;
using PromoTest.Project.Common.Constants;
using PromoTest.Project.Common.Extensions;
using PromoTest.Project.Presentation.Interfaces.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PromoTest.Project.Presentation.Views
{
    [RequireComponent(typeof(Button))]
    public class PromoSectionItem : MonoBehaviour, IPromoSectionItem
    {
        private const float ScaleDuration = 0.1f;
        private static readonly Vector3 NormalScale = Vector3.one;
        private static readonly Vector3 ClickedScale = new(1.1f, 0.9f, 1.0f);

        [SerializeField]
        private Button _selfButton;
        
        [SerializeField]
        private TMP_Text _titleTMP;

        [SerializeField]
        private Image _iconImage;

        [SerializeField]
        private Image _rarityBkgImage;

        [SerializeField]
        private TMP_Text _costTMP;

        private Action<string, int> _purchaseHandler;
        private string _title;
        private int _cost;
        private Coroutine _currentCoroutine;
        private Vector3 _cachedScale;

        private void Awake()
        {
#if UNITY_EDITOR || DEBUG
            Verify();
#endif
        }

#if UNITY_EDITOR || DEBUG
        private void Verify()
        {
            _selfButton.VerifyNotNull();
            _titleTMP.VerifyNotNull();
            _iconImage.VerifyNotNull();
            _rarityBkgImage.VerifyNotNull();
            _costTMP.VerifyNotNull();
        }
#endif

        private void OnDisable()
        {
            _selfButton.onClick.RemoveAllListeners();
        }

        public void OnCreate(IPromoSectionItemModel promoSectionItemModel)
        {
            _purchaseHandler = promoSectionItemModel.PurchaseHandler;
            _title = promoSectionItemModel.Title;
            _cost = promoSectionItemModel.Cost;
            
            _titleTMP.text = _title;
            _iconImage.sprite = promoSectionItemModel.Icon;
            _rarityBkgImage.sprite = promoSectionItemModel.RarityBackground;
            _costTMP.text = string.Format(ProjectConstants.CostFormat, _cost.ToString());
            
            _selfButton.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
                _currentCoroutine = null;
            }
            
            _currentCoroutine = StartCoroutine(ButtonScalingCoroutine());

            // Invoke purchase on Click
            _purchaseHandler?.Invoke(_title, _cost);
        }

        private IEnumerator ButtonScalingCoroutine()
        {
            var currentTransform = transform;
            var currentScale = currentTransform.localScale;
            
            yield return currentTransform.ScaleFromTo(currentScale, ClickedScale, ScaleDuration);
            yield return currentTransform.ScaleFromTo(ClickedScale, NormalScale, ScaleDuration * 0.5f);

            _currentCoroutine = null;
        }
    }
}