using JetBrains.Annotations;
using PromoTest.Project.BusinessLogic.Interfaces.Models;
using PromoTest.Project.Presentation.Views;
using UnityEngine;

namespace PromoTest.Project.BusinessLogic.Interfaces.Factories
{
    public interface IPromoSectionItemFactory
    {
        PromoSectionItem Create(
            string prefabFullPath,
            IPromoSectionItemModel promoSectionItemModel,
            [CanBeNull] Transform parent = null);
    }
}