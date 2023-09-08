using JetBrains.Annotations;
using PromoTest.Project.BusinessLogic.Interfaces.Factories;
using PromoTest.Project.BusinessLogic.Interfaces.Models;
using PromoTest.Project.Presentation.Views;

namespace PromoTest.Project.BusinessLogic.Factories
{
    [UsedImplicitly]
    public class PromoSectionFactory : GenericMonoFactory<IPromoSectionModel, PromoSection>, IPromoSectionFactory
    { }
}