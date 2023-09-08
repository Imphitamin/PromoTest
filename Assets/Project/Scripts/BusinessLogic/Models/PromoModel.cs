using PromoTest.Project.BusinessLogic.Interfaces.Models;
using PromoTest.Project.Common.Enums;
using PromoTest.Project.Data;

namespace PromoTest.Project.BusinessLogic.Models
{
    public sealed class PromoModel<TModelData> : IPromoModel
        where TModelData : PromoData
    {
        private readonly TModelData _data;
        
        string IPromoModel.Title => _data.Title;
        string IPromoModel.GetIcon() => _data.Icon();
        PromoType IPromoModel.Type => _data.Type;
        PromoRarity IPromoModel.Rarity => _data.Rarity;
        int IPromoModel.Cost => _data.Cost;
        
        public PromoModel(TModelData data)
        {
            _data = data;
        }
    }
}