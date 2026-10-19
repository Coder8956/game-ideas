using HutongGames.PlayMaker.UI;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.UI.Editor
{
    [CustomEditor(typeof(Radar))]
    public sealed class RadarEditor : BaseTargetManagerEditor<Radar>
    {
        SerializedProperty _originProp;
        SerializedProperty _planeProp;
        SerializedProperty _mappingProp;
        SerializedProperty _maxRangeProp;
        SerializedProperty _hideBeyondRangeProp;
        SerializedProperty _rotateWithOriginProp;

        protected override void OnEnable()
        {
            base.OnEnable();

            _originProp          = serializedObject.FindProperty("_origin");
            _planeProp           = serializedObject.FindProperty("_plane");
            _mappingProp         = serializedObject.FindProperty("_mapping");
            _maxRangeProp        = serializedObject.FindProperty("_maxRange");
            _hideBeyondRangeProp = serializedObject.FindProperty("_hideBeyondRange");
            _rotateWithOriginProp= serializedObject.FindProperty("_rotateWithOrigin");
        }

        protected override string DebugHeaderText => "Radar targets";

        protected override void BuildInspectorGUI(VisualElement root)
        {
            // --- Radar Space group ---
            root.Add(Header("Radar Space"));

            // Radar doesn’t actually use Camera in layout, but we can still expose it
            // in case you want to use it for something (e.g., fallback origin).
            root.Add(new PropertyField(_indicatorPanelProp, "Indicator Panel"));
            root.Add(new PropertyField(_originProp,          "Origin"));
            root.Add(new PropertyField(_planeProp,           "Plane"));
            root.Add(new PropertyField(_mappingProp,         "Mapping"));
            root.Add(new PropertyField(_maxRangeProp,        "Max Range"));
            root.Add(new PropertyField(_hideBeyondRangeProp, "Hide Beyond Range"));
            root.Add(new PropertyField(_rotateWithOriginProp,"Rotate With Origin"));

            // --- Indicators group ---
            root.Add(Header("Indicators"));
            root.Add(new PropertyField(_defaultPrefabProp, "Default Prefab"));
        }
    }
}
