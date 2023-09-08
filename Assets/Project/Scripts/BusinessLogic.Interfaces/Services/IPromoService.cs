using System.Collections.Generic;
using PromoTest.Project.BusinessLogic.Interfaces.Models;

namespace PromoTest.Project.BusinessLogic.Interfaces.Services
{
    public interface IPromoService
    {
        IReadOnlyList<IPromoModel> GetPromos();
    }
}