#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.UI;

namespace PromoTest.Project.Common.Extenders.Editor
{
    [CustomEditor(typeof(ScrollRectExtended), false)]
    [CanEditMultipleObjects]
    public sealed class ScrollRectExtendedEditor : ScrollRectEditor
    {
        private SerializedProperty _parentScrollRect;
        
        protected override void OnEnable()
        {
            _parentScrollRect = serializedObject.FindProperty("_parentScrollRect");
            
            base.OnEnable();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            EditorGUILayout.PropertyField(_parentScrollRect);
            EditorGUILayout.Space();
            
            serializedObject.ApplyModifiedProperties();
            
            base.OnInspectorGUI();
        }
    }
}
#endif