using JetBrains.Annotations;
using PromoTest.Project.BusinessLogic.Interfaces.Services;
using UnityEngine;

namespace PromoTest.Project.BusinessLogic.Services
{
    [UsedImplicitly]
    public class PurchaseManager : IPurchaseManager
    {
        private readonly IUserService _userService;
        
        public PurchaseManager(IUserService userService)
        {
            _userService = userService;
        }

        public void Purchase(string itemName, int cost)
        {
            var currentCurrency = _userService.Currency;

            if (currentCurrency < cost)
            {
                PrintErrorMessage(itemName, cost, currentCurrency);
                return;
            }
            
            _userService.ReduceCurrency(cost);
            PrintSuccessMessage(itemName, cost);
        }

        private void PrintSuccessMessage(string itemName, int cost)
        {
            var fixedName = itemName.Replace("\n", "");
            Debug.Log($"{nameof(PurchaseManager)} -> Successfully purchased \"{fixedName}\" for {cost.ToString()} crystals!");
        }
        
        private void PrintErrorMessage(string itemName, int cost, int userCurrency)
        {
            var fixedName = itemName.Replace("\n", "");
            Debug.LogError($"{nameof(PurchaseManager)} -> Unable to buy \"{fixedName}\" for {cost.ToString()} crystals," +
                      $" because the user have insufficient amount of crystals: \"{userCurrency.ToString()}\"");
        }
    }
}