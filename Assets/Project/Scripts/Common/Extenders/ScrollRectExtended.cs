using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PromoTest.Project.Common.Extenders
{
    [AddComponentMenu("UI/Scroll Rect Extended", 38)]
    public class ScrollRectExtended : ScrollRect
    {
        [CanBeNull]
        [SerializeField]
        private ScrollRectExtended _parentScrollRect;

        private bool _isParentScrollRectValid, _needToCallParent;

        protected override void Awake()
        {
            ValidateParentScrollRect();
        }

        public void SetParentScrollRect(ScrollRectExtended scrollRectExtended)
        {
            _parentScrollRect = scrollRectExtended;
            ValidateParentScrollRect();
        }
        
        public override void OnBeginDrag(PointerEventData eventData)
        {
            if (!_isParentScrollRectValid)
            {
                base.OnBeginDrag(eventData);
                return;
            }

            var delta = eventData.delta;

            // We're re-routing events to parent ScrollRect in two cases below:
            // 1. If current ScrollRect is only 'horizontal' but player tries to scroll vertically
            if (horizontal &&
                Mathf.Abs(delta.y) > Mathf.Abs(delta.x))
            {
                _needToCallParent = true;
            }
            // 2. If current ScrollRect is only 'horizontal' but player tries to scroll vertically
            else if (vertical &&
                     Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
            {
                _needToCallParent = true;
            }
            // ...else, we have no need to call the parent ScrollRect's event handlers
            else
            {
                _needToCallParent = false;
            }

            if (_needToCallParent)
            {
                _parentScrollRect!.OnBeginDrag(eventData);
            }
            else
            {
                base.OnBeginDrag(eventData);
            }
        }

        public override void OnDrag(PointerEventData eventData)
        {
            if (!_isParentScrollRectValid ||
                !_needToCallParent)
            {
                base.OnDrag(eventData);
                return;
            }
            
            _parentScrollRect!.OnDrag(eventData);
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            if (!_isParentScrollRectValid ||
                !_needToCallParent)
            {
                base.OnEndDrag(eventData);
                return;
            }
            
            _parentScrollRect!.OnEndDrag(eventData);
        }

        private void ValidateParentScrollRect()
        {
            // This flag here is for one reason only - to not check for 'null' everytime some drag event happens
            _isParentScrollRectValid = _parentScrollRect != null;
        }
    }
}