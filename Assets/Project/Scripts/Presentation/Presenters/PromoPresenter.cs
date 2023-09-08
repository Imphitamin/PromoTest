using System;
using System.Collections.Generic;
using System.Linq;
using Grace.DependencyInjection.Attributes;
using PromoTest.Project.BusinessLogic.Interfaces.Factories;
using PromoTest.Project.BusinessLogic.Interfaces.Models;
using PromoTest.Project.BusinessLogic.Interfaces.Services;
using PromoTest.Project.BusinessLogic.Models;
using PromoTest.Project.Common.Enums;
using PromoTest.Project.Presentation.Views;
using UnityEngine;

namespace PromoTest.Project.Presentation.Presenters
{
    public class PromoPresenter : BasePresenter<IPromoViewModel, PromoView>
    {
        #region Injected

        private readonly IPromoService _promoService;
        private readonly IPromoResourcesFactory _promoResourcesFactory;
        private readonly ISpriteAssetLoader _spriteAssetLoader;
        private readonly IPurchaseManager _purchaseManager;
        private readonly IUserService _userService;

        #endregion Injected
        
        public PromoPresenter(
            [Import(Key = "MainCanvasTransform")] Func<Transform> mainCanvasTransformGetter,
            IPromoService promoService,
            IPromoResourcesFactory promoResourcesFactory,
            ISpriteAssetLoader spriteAssetLoader,
            IPurchaseManager purchaseManager,
            IUserService userService)
            : base(mainCanvasTransformGetter)
        {
            _promoService = promoService;
            _promoResourcesFactory = promoResourcesFactory;
            _spriteAssetLoader = spriteAssetLoader;
            _purchaseManager = purchaseManager;
            _userService = userService;
        }
        
        protected override IPromoViewModel ConstructViewModel()
        {
            var promoModels = _promoService
                .GetPromos()
                .OrderBy(x => x.Type)
                .ThenByDescending(x => x.Rarity)
                .ToArray(); 
            
            Dictionary<PromoType, PromoSection> sectionsDict = new();

            for (var i = 0; i < promoModels.Length; i++)
            {
                var promoModel = promoModels[i];
                var promoType = promoModel.Type;

                if (!sectionsDict.TryGetValue(promoType, out var promoSection))
                {
                    var sectionTitle = GetSectionNameByType(promoModel.Type);
                    var promoSectionModel = new PromoSectionModel(sectionTitle);
                    promoSection = _promoResourcesFactory.CreatePromoSection(promoSectionModel);
                    sectionsDict.Add(promoType, promoSection);
                }

                var icon = _spriteAssetLoader.GetSpriteByName(promoModel.GetIcon());
                var rarityBackground = _spriteAssetLoader.GetSpriteByRarity(promoModel.Rarity);
                var promoSectionItemModel = new PromoSectionItemModel(
                    promoModel.Title,
                    icon,
                    rarityBackground,
                    promoModel.Cost,
                    _purchaseManager.Purchase);
                
                _promoResourcesFactory.CreatePromoSectionItem(
                    promoSectionItemModel,
                    promoSection.SectionItemsGroup);
            }

            return new PromoViewModel(sectionsDict.Values.ToArray(), _userService);
        }
        
        private static string GetSectionNameByType(PromoType promoType)
        {
            switch (promoType)
            {
                case PromoType.Chest:
                    return "Chests";
                case PromoType.Special:
                    return "Specials";
                case PromoType.InApp:
                    return "Crystals";
                default:
                    return "Section";
            }
        }
    }
}