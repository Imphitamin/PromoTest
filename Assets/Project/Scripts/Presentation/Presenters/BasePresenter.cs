using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using PromoTest.Project.BusinessLogic.Interfaces.Models;
using PromoTest.Project.Common.Constants;
using PromoTest.Project.Common.Extensions;
using PromoTest.Project.Presentation.Views;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PromoTest.Project.Presentation.Presenters
{
    public abstract class BasePresenter<TView>
        where TView : BaseView
    {
        protected Canvas Canvas;
        protected TView View;

        private readonly Transform _mainCanvasTransform;
        
        protected BasePresenter(Func<Transform> mainCanvasTransformGetter)
        {
            _mainCanvasTransform = mainCanvasTransformGetter.Invoke();
        }

        public virtual void Show()
        {
            CreateView();
            View.Show();
            Canvas.enabled = true;
        }

        public virtual void Close()
        {
            Canvas.enabled = false;
            View.Close();
            
            Object.Destroy(Canvas.gameObject);
            Canvas = null;
            View = null;
        }

        protected void CreateView()
        {
            Canvas = GetInstanceOf<Canvas>(_mainCanvasTransform);
            Canvas.name = "Canvas";
            View = GetInstanceOf<TView>(Canvas.transform);
            View.name = typeof(TView).Name;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T GetInstanceOf<T>([CanBeNull] Transform parent = null)
            where T : Component
        {
            var path = $"{ProjectConstants.PathToPrefabs}/{typeof(T).Name}";
            var prefab = Resources.Load<T>(path);
#if UNITY_EDITOR || DEBUG
            prefab.VerifyNotNull();
#endif
            return Object.Instantiate(prefab, parent);
        }
    }

    public abstract class BasePresenter<TModel, TView> : BasePresenter<TView>
        where TView : BaseView<TModel>
        where TModel : class, IBaseModel
    {
        protected TModel Model;
        
        protected BasePresenter(Func<Transform> mainCanvasTransformGetter)
            : base(mainCanvasTransformGetter)
        { }

        public override void Show()
        {
            CreateView();
            Initialize();
            View.Show(Model);
            Canvas.enabled = true;
        }

        protected abstract TModel ConstructViewModel();

        private void Initialize()
        {
            Model = ConstructViewModel();
#if UNITY_EDITOR || DEBUG
            Model.VerifyNotNull();
#endif
        }
    }
}