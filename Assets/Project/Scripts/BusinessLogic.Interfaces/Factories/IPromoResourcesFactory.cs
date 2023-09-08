using JetBrains.Annotations;
using PromoTest.Project.BusinessLogic.Interfaces.Models;
using PromoTest.Project.Presentation.Views;
using UnityEngine;

namespace PromoTest.Project.BusinessLogic.Interfaces.Factories
{
    public interface IPromoResourcesFactory
    {
        PromoSection CreatePromoSection(IPromoSectionModel promoSectionModel, [CanBeNull] Transform parent = null);
        
        PromoSectionItem CreatePromoSectionItem(IPromoSectionItemModel promoSectionItemModel, [CanBeNull] Transform parent = null);
    }
}