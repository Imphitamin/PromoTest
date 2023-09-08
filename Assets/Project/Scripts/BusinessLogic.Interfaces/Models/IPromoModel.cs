using PromoTest.Project.Common.Enums;

namespace PromoTest.Project.BusinessLogic.Interfaces.Models
{
    public interface IPromoModel : IBaseModel
    {
        string Title { get; }
        string GetIcon();
        PromoType Type { get; }
        PromoRarity Rarity { get; }
        int Cost { get; }
    }
}