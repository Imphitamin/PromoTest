using JetBrains.Annotations;
using PromoTest.Project.BusinessLogic.Interfaces.Models;
using PromoTest.Project.Presentation.Views;
using UnityEngine;

namespace PromoTest.Project.BusinessLogic.Interfaces.Factories
{
    public interface IPromoSectionFactory
    {
        PromoSection Create(string prefabFullPath, IPromoSectionModel promoSectionModel, [CanBeNull] Transform parent = null);
    }
}