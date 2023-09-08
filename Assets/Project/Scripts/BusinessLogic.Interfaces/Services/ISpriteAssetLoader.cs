using JetBrains.Annotations;
using PromoTest.Project.Common.Enums;
using UnityEngine;

namespace PromoTest.Project.BusinessLogic.Interfaces.Services
{
    public interface ISpriteAssetLoader
    {
        [CanBeNull]
        Sprite GetSpriteByName([NotNull] string spriteName);

        [CanBeNull]
        Sprite GetSpriteByRarity(PromoRarity promoRarity);
    }
}