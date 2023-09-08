using JetBrains.Annotations;
using PromoTest.Project.BusinessLogic.Interfaces.Factories;
using PromoTest.Project.BusinessLogic.Interfaces.Models;
using PromoTest.Project.Presentation.Views;
using UnityEngine;

namespace PromoTest.Project.BusinessLogic.Factories
{
    [UsedImplicitly]
    public class PromoResourcesFactory : IPromoResourcesFactory
    {
        private const string PromoSectionPrefabFullPath = "Prefabs/UI/" + nameof(PromoSection);
        private const string PromoSectionItemPrefabFullPath = "Prefabs/UI/" + nameof(PromoSectionItem);
        
        private readonly IPromoSectionFactory _promoSectionFactory;
        private readonly IPromoSectionItemFactory _promoSectionItemFactory;
        
        public PromoResourcesFactory(
            IPromoSectionFactory promoSectionFactory,
            IPromoSectionItemFactory promoSectionItemFactory)
        {
            _promoSectionFactory = promoSectionFactory;
            _promoSectionItemFactory = promoSectionItemFactory;
        }

        public PromoSection CreatePromoSection(IPromoSectionModel promoSectionModel, Transform parent = null)
        {
            return _promoSectionFactory.Create(PromoSectionPrefabFullPath, promoSectionModel, parent);
        }

        public PromoSectionItem CreatePromoSectionItem(
            IPromoSectionItemModel promoSectionItemModel,
            Transform parent = null)
        {
            return _promoSectionItemFactory.Create(PromoSectionItemPrefabFullPath, promoSectionItemModel, parent);
        }
    }
}