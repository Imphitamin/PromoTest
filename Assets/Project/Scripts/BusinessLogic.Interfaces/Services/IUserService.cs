using System;

namespace PromoTest.Project.BusinessLogic.Interfaces.Services
{
    public interface IUserService
    {
        int Currency { get; }
        
        void AddCurrency(int delta);
        void ReduceCurrency(int delta);
        bool HasCurrency(int amount);
        void AddListener(Action<int> currencyUpdateHandler);
        void RemoveListener(Action<int> currencyUpdateHandler);
    }
}