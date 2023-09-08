using UnityEngine;

namespace PromoTest.Project.Presentation.Views
{
    public abstract class BaseView : MonoBehaviour
    {
        public virtual void Show() { }

        public virtual void Close() { }
    }
    
    public abstract class BaseView<TModel> : BaseView
    {
        public abstract void Show(TModel model);
    }
}