using System.Collections.Generic;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using PromoTest.Project.BusinessLogic.Interfaces.Services;
using PromoTest.Project.Common.Enums;
using UnityEngine;
using UnityEngine.U2D;

namespace PromoTest.Project.BusinessLogic.Services
{
    [UsedImplicitly]
    public class SpriteAssetLoader : ISpriteAssetLoader
    {
        private const string PathToSpriteAtlases = "SpriteAtlases";
        private const string PathToPromoSpriteAtlas = PathToSpriteAtlases + "/PromoSpriteAtlas";
        private const string RareBkgSpriteName = "background_rare";
        private const string EpicBkgSpriteName = "background_epic";
        private const string CommonBkgSpriteName = "background_common";

        private readonly Regex _removeCloneInNameRgx = new(@"\(Clone\)");
        private readonly Dictionary<int, Sprite> _spritesDict = new();

        public SpriteAssetLoader()
        {
            Initialize();
        }

        private void Initialize()
        {
            var spriteAtlas = LoadSpriteAtlas();
            var spriteCount = spriteAtlas.spriteCount;
            var sprites = new Sprite[spriteCount];
            spriteAtlas.GetSprites(sprites);

            for (var i = 0; i < spriteCount; i++)
            {
                var sprite = sprites[i];
                var spriteName = sprite.name;
                spriteName = _removeCloneInNameRgx.Replace(spriteName, "");
                var hash = spriteName.GetHashCode();
                sprite.name = spriteName;

                if (!_spritesDict.ContainsKey(hash))
                {
                    _spritesDict.Add(hash, sprite);
                }
            }
        }

        public Sprite GetSpriteByName(string spriteName)
        {
            var hash = spriteName.GetHashCode();

            return _spritesDict.TryGetValue(hash, out var sprite)
                ? sprite
                : null;
        }

        public Sprite GetSpriteByRarity(PromoRarity promoRarity)
        {
            var spriteName = GetSpriteNameByRarity(promoRarity);

            return GetSpriteByName(spriteName);
        }
        
        private string GetSpriteNameByRarity(PromoRarity promoRarity)
        {
            switch (promoRarity)
            {
                case PromoRarity.Rare:
                    return RareBkgSpriteName;
                case PromoRarity.Epic:
                    return EpicBkgSpriteName;
                default:
                    return CommonBkgSpriteName;
            }
        }

        private SpriteAtlas LoadSpriteAtlas()
        {
            return Resources.Load<SpriteAtlas>(PathToPromoSpriteAtlas);
        }

        #region NOT USED YET!

        /*private AssetBundle LoadAssetBundle()
        {
            var assetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "sprite_atlases"));
            
            if (assetBundle == null)
            {
                Debug.LogError("Failed to load AssetBundle!");
                return null;
            }

            return assetBundle;
        }

        private Sprite LoadSpriteFromAssetBundle(AssetBundle assetBundle, string spriteName)
        {
            var prefab = assetBundle.LoadAsset<Sprite>(spriteName);
            var sprite = Object.Instantiate(prefab);

            return sprite;
        }*/

        #endregion NOT USED YET!
    }
}