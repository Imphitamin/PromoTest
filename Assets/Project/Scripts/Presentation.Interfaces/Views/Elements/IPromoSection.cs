using PromoTest.Project.BusinessLogic.Interfaces.Factories;
using PromoTest.Project.BusinessLogic.Interfaces.Models;
using PromoTest.Project.Common.Extenders;
using PromoTest.Project.Project.Scripts.Common.Interfaces;
using UnityEngine;

namespace PromoTest.Project.Presentation.Interfaces.Views
{
    public interface IPromoSection : IGameObjectHolder, IFactoryObject<IPromoSectionModel>
    {
        void SetParent(Transform parent);
        void SetParentScrollRect(ScrollRectExtended parentScrollRect);
    }
}