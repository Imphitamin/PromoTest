using System.Collections.Generic;
using PromoTest.Project.BusinessLogic.Interfaces.Services;
using PromoTest.Project.Presentation.Interfaces.Views;

namespace PromoTest.Project.BusinessLogic.Interfaces.Models
{
    public interface IPromoViewModel : IBaseModel
    {
        IReadOnlyList<IPromoSection> PromoSections { get; }
        IUserService UserService { get; }
    }
}