using HutongGames.PlayMaker.UI;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.UI.Editor
{
    [CustomEditor(typeof(OffscreenIndicator))]
    public sealed class OffscreenIndicatorEditor : BaseTargetManagerEditor<OffscreenIndicator>
    {
        private SerializedProperty _borderShapeProp;
        private SerializedProperty _hideWhenInsideBoundsProp;
        private SerializedProperty _rotateIndicatorsProp;

        protected override void OnEnable()
        {
            base.OnEnable();

            _borderShapeProp         = serializedObject.FindProperty("_borderShape");
            _hideWhenInsideBoundsProp= serializedObject.FindProperty("_hideWhenInsideBounds");
            _rotateIndicatorsProp    = serializedObject.FindProperty("_rotateIndicators");
        }

        protected override string DebugHeaderText => "Offscreen targets";

        protected override void BuildInspectorGUI(VisualElement root)
        {
            // --- Bounds group ---
            root.Add(Header("Bounds"));
            root.Add(new PropertyField(_cameraProp, "Camera"));
            root.Add(new PropertyField(_indicatorPanelProp, "Indicator Panel"));
            root.Add(new PropertyField(_borderShapeProp, "Border Shape"));
            root.Add(new PropertyField(_hideWhenInsideBoundsProp, "Hide Inside Panel"));

            // --- Indicators group ---
            root.Add(Header("Indicators"));
            root.Add(new PropertyField(_defaultPrefabProp, "Default Prefab"));
            root.Add(new PropertyField(_rotateIndicatorsProp, "Rotate Indicators"));
        }
    }
}