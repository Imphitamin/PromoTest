using PromoTest.Project.BusinessLogic.Interfaces.Models;
using PromoTest.Project.Common.Extenders;
using PromoTest.Project.Common.Extensions;
using PromoTest.Project.Presentation.Interfaces.Views;
using TMPro;
using UnityEngine;

namespace PromoTest.Project.Presentation.Views
{
    public class PromoSection : MonoBehaviour, IPromoSection
    {
        [SerializeField]
        private Transform _sectionItemsGroup;

        [SerializeField]
        private ScrollRectExtended _sectionScrollRect;

        [SerializeField]
        private TMP_Text _sectionTitleTMP;

        public Transform SectionItemsGroup => _sectionItemsGroup;

        public GameObject GameObject => gameObject;

        private void Awake()
        {
#if UNITY_EDITOR || DEBUG
            Verify();
#endif
        }

#if UNITY_EDITOR || DEBUG
        private void Verify()
        {
            _sectionItemsGroup.VerifyNotNull("The reference is NULL or missing! Did you forget to set " +
                                               "the reference in the prefab/inspector?");
            _sectionScrollRect.VerifyNotNull();
            _sectionTitleTMP.VerifyNotNull();
        }
#endif
        
        public void OnCreate(IPromoSectionModel promoSectionModel)
        {
            _sectionTitleTMP.text = promoSectionModel.SectionTitle;
        }

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent, false);
        }

        public void SetParentScrollRect(ScrollRectExtended parentScrollRect)
        {
            _sectionScrollRect.SetParentScrollRect(parentScrollRect);
        }
    }
}