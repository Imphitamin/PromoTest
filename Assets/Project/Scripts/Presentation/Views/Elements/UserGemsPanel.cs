using System.Diagnostics.CodeAnalysis;
using PromoTest.Project.BusinessLogic.Interfaces.Services;
using PromoTest.Project.Common.Constants;
using PromoTest.Project.Common.Extensions;
using PromoTest.Project.Presentation.Interfaces.Views;
using TMPro;
using UnityEngine;

namespace PromoTest.Project.Presentation.Views
{
    public class UserGemsPanel : MonoBehaviour, IUserGemsPanel
    {
        [SerializeField]
        private TMP_Text _totalGemsTMP;

        private IUserService _userService;
        
        private void Awake()
        {
#if UNITY_EDITOR || DEBUG
            Verify();
#endif
        }

#if UNITY_EDITOR || DEBUG
        private void Verify()
        {
            _totalGemsTMP.VerifyNotNull();
        }
#endif

        private void OnDisable()
        {
            _userService.RemoveListener(UpdateTotalGems);
        }

        public void Initialize([NotNull] IUserService userService)
        {
            _userService = userService;
            
            UpdateTotalGems(userService.Currency);
            _userService.AddListener(UpdateTotalGems);
        }

        private void UpdateTotalGems(int totalGems)
        {
            _totalGemsTMP.text = string.Format(ProjectConstants.CostFormat, totalGems.ToString());
        }
    }
}