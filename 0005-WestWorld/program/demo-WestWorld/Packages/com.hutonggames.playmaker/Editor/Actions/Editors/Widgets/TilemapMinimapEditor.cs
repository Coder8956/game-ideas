using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.UI.Editor
{
    [CustomEditor(typeof(TilemapMinimap))]
    public sealed class TilemapMinimapEditor : BaseTargetManagerEditor<TilemapMinimap>
    {
        private SerializedProperty _tilemapsProp;
        private SerializedProperty _mapImageProp;
        private SerializedProperty _contentRootProp;
        private SerializedProperty _originProp;
        private SerializedProperty _rotateWithOriginProp;
        private SerializedProperty _hideOutsideMapProp;
        private SerializedProperty _followTargetProp;
        private SerializedProperty _mapScaleProp;
        private SerializedProperty _useCellColorsProp;
        private SerializedProperty _emptyColorProp;
        private SerializedProperty _defaultTileColorProp;
        private SerializedProperty _maxTextureSizeProp;
        private SerializedProperty _tileColorsProp;

        protected override void OnEnable()
        {
            base.OnEnable();

            _tilemapsProp = serializedObject.FindProperty("_tilemaps");
            _mapImageProp = serializedObject.FindProperty("_mapImage");
            _contentRootProp = serializedObject.FindProperty("_contentRoot");
            _originProp = serializedObject.FindProperty("_origin");
            _rotateWithOriginProp = serializedObject.FindProperty("_rotateWithOrigin");
            _hideOutsideMapProp = serializedObject.FindProperty("_hideOutsideMap");
            _followTargetProp = serializedObject.FindProperty("_followTarget");
            _mapScaleProp = serializedObject.FindProperty("_mapScale");
            _useCellColorsProp = serializedObject.FindProperty("_useCellColors");
            _emptyColorProp = serializedObject.FindProperty("_emptyColor");
            _defaultTileColorProp = serializedObject.FindProperty("_defaultTileColor");
            _maxTextureSizeProp = serializedObject.FindProperty("_maxTextureSize");
            _tileColorsProp = serializedObject.FindProperty("_tileColors");
        }

        protected override string DebugHeaderText => "Minimap blips";

        protected override void BuildInspectorGUI(VisualElement root)
        {
            root.Add(Header("Map"));
            root.Add(new PropertyField(_indicatorPanelProp, "Indicator Panel"));
            root.Add(new PropertyField(_contentRootProp, "Content Root"));
            root.Add(new PropertyField(_mapImageProp, "Map Image"));
            root.Add(new PropertyField(_tilemapsProp, "Tilemaps"));
            root.Add(new PropertyField(_maxTextureSizeProp, "Max Texture Size"));

            root.Add(Header("Rendering"));
            root.Add(new PropertyField(_useCellColorsProp, "Use Cell Colors"));
            root.Add(new PropertyField(_emptyColorProp, "Empty Color"));
            root.Add(new PropertyField(_defaultTileColorProp, "Default Tile Color"));
            root.Add(new PropertyField(_tileColorsProp, "Tile Colors"));

            root.Add(Header("Blips"));
            root.Add(new PropertyField(_defaultPrefabProp, "Default Prefab"));
            root.Add(new PropertyField(_hideOutsideMapProp, "Hide Outside Map"));
            root.Add(new PropertyField(_followTargetProp, "Follow Target"));
            root.Add(new PropertyField(_mapScaleProp, "Map Scale"));

            root.Add(Header("Orientation"));
            root.Add(new PropertyField(_originProp, "Origin"));
            root.Add(new PropertyField(_rotateWithOriginProp, "Rotate With Origin"));
        }
    }
}
