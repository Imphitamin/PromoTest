using System;
using PromoTest.Project.BusinessLogic.Interfaces.Services;

namespace PromoTest.Project.BusinessLogic.Services
{
    public sealed class UserService : IUserService
    {
        private int _currency;

        public int Currency
        {
            get => _currency;
            private set
            {
                _currency = value;
                CurrencyUpdated?.Invoke(value);
            }
        }

        public event Action<int> CurrencyUpdated;
        
        public UserService()
        {
            Currency = 1000;
        }

        void IUserService.AddCurrency(int delta)
        {
            Currency += delta;
        }

        void IUserService.ReduceCurrency(int delta)
        {
            Currency -= delta;
        }
        
        bool IUserService.HasCurrency(int amount)
        {
            return Currency >= amount;
        }

        void IUserService.AddListener(Action<int> currencyUpdateHandler)
        {
            CurrencyUpdated += currencyUpdateHandler;
        }

        void IUserService.RemoveListener(Action<int> currencyUpdateHandler)
        {
            CurrencyUpdated -= currencyUpdateHandler;
        }
    }
}