using System;
using PromoTest.Project.BusinessLogic.Interfaces.Models;
using UnityEngine;

namespace PromoTest.Project.BusinessLogic.Models
{
    public class PromoSectionItemModel : IPromoSectionItemModel
    {
        public string Title { get; }
        public Sprite Icon { get; }
        public Sprite RarityBackground { get; }
        public int Cost { get; }
        public Action<string, int> PurchaseHandler { get; }

        public PromoSectionItemModel(
            string title,
            Sprite icon,
            Sprite rarityBackground,
            int cost,
            Action<string, int> purchaseHandler)
        {
            Title = title;
            Icon = icon;
            RarityBackground = rarityBackground;
            Cost = cost;
            PurchaseHandler = purchaseHandler;
        }
    }
}