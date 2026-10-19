using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.UI.Editor
{
    [CustomEditor(typeof(TargetIndicator))]
    public sealed class TargetIndicatorEditor : BaseTargetManagerEditor<TargetIndicator>
    {
        private SerializedProperty _hideWhenOffscreenProp;
        private SerializedProperty _worldOffsetProp;
        private SerializedProperty _clampToPanelProp;
        private SerializedProperty _sortByDistanceProp;

        protected override void OnEnable()
        {
            base.OnEnable();

            _hideWhenOffscreenProp = serializedObject.FindProperty("_hideWhenOffscreen");
            _worldOffsetProp       = serializedObject.FindProperty("_worldOffset");
            _clampToPanelProp      = serializedObject.FindProperty("_clampToPanel");
            _sortByDistanceProp    = serializedObject.FindProperty("_sortByDistance");
        }

        protected override string DebugHeaderText => "Target indicators";

        protected override void BuildInspectorGUI(VisualElement root)
        {
            // --- Bounds group ---
            root.Add(Header("Bounds"));
            root.Add(new PropertyField(_cameraProp, "Camera"));
            root.Add(new PropertyField(_indicatorPanelProp, "Indicator Panel"));
            root.Add(new PropertyField(_hideWhenOffscreenProp, "Hide When Offscreen"));
            root.Add(new PropertyField(_clampToPanelProp, "Clamp To Panel"));

            // --- Indicators group ---
            root.Add(Header("Indicators"));
            root.Add(new PropertyField(_defaultPrefabProp, "Default Prefab"));
            root.Add(new PropertyField(_worldOffsetProp, "World Offset"));
            root.Add(new PropertyField(_sortByDistanceProp, "Sort By Distance"));
        }
    }
}