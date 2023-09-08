using Grace.DependencyInjection;
using PromoTest.Project.BusinessLogic.Factories;
using PromoTest.Project.BusinessLogic.Interfaces.Factories;
using PromoTest.Project.BusinessLogic.Interfaces.Services;
using PromoTest.Project.BusinessLogic.Services;
using PromoTest.Project.Common.Constants;
using PromoTest.Project.Common.Extensions;
using PromoTest.Project.Presentation.Presenters;
using UnityEngine;

namespace PromoTest.Project.DI.Initializers
{
    public sealed class Initializer : MonoBehaviour
    {
        private readonly DependencyInjectionContainer _container = new();
        
        private void Awake()
        {
            _container.Configure(block =>
            {
                // Main Canvas export (single instance)
                block
                    .ExportFactory<Transform>(CreateMainCanvas)
                    .AsKeyed<Transform>("MainCanvasTransform")
                    .Lifestyle.Singleton();

                // Services export
                block.Export<UserService>().As<IUserService>().Lifestyle.Singleton();
                block.Export<PromoService>().As<IPromoService>().Lifestyle.Singleton();
                block.Export<PurchaseManager>().As<IPurchaseManager>().Lifestyle.Singleton();
                
                // Presenters export
                block.Export<LobbyPresenter>().Lifestyle.Singleton();
                block.Export<PromoPresenter>().Lifestyle.Singleton();

                // Factories export
                block.Export<PromoSectionFactory>().As<IPromoSectionFactory>().Lifestyle.Singleton();
                block.Export<PromoSectionItemFactory>().As<IPromoSectionItemFactory>().Lifestyle.Singleton();
                block.Export<PromoResourcesFactory>().As<IPromoResourcesFactory>().Lifestyle.Singleton();

                // Sprites loader export
                block.Export<SpriteAssetLoader>().As<ISpriteAssetLoader>().Lifestyle.Singleton();
            });

            // Services
            _container.Locate<IUserService>();
            _container.Locate<IPromoService>();
            
            // Presenters
            _container.Locate<LobbyPresenter>().Show();

            // Sprites loader
            _container.Locate<ISpriteAssetLoader>();
        }

        private static Transform CreateMainCanvas()
        {
            var path = $"{ProjectConstants.PathToPrefabs}/MainCanvas";
            var prefab = Resources.Load<Canvas>(path);
#if UNITY_EDITOR || DEBUG
            prefab.VerifyNotNull();
#endif

            var mainCanvas = Instantiate(prefab);
            mainCanvas.name = "MainCanvas";
                    
            return mainCanvas.transform;
        }
    }
}