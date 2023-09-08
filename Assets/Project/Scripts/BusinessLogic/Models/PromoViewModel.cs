using System.Collections.Generic;
using PromoTest.Project.BusinessLogic.Interfaces.Models;
using PromoTest.Project.BusinessLogic.Interfaces.Services;
using PromoTest.Project.Presentation.Interfaces.Views;

namespace PromoTest.Project.BusinessLogic.Models
{
    public class PromoViewModel : IPromoViewModel
    {
        public IReadOnlyList<IPromoSection> PromoSections { get; }
        public IUserService UserService { get; }

        public PromoViewModel(
            IReadOnlyList<IPromoSection> promoSections,
            IUserService userService)
        {
            PromoSections = promoSections;
            UserService = userService;
        }

        
    }
}