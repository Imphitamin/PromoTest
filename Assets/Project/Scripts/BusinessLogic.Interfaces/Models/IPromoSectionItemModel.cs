using System;
using UnityEngine;

namespace PromoTest.Project.BusinessLogic.Interfaces.Models
{
    public interface IPromoSectionItemModel : IBaseModel
    {
        string Title { get; }
        Sprite Icon { get; }
        Sprite RarityBackground { get; }
        int Cost { get; }
        Action<string, int> PurchaseHandler { get; }
    }
}