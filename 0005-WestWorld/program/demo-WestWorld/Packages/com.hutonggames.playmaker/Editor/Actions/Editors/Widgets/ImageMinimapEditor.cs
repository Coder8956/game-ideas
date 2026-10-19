using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.UI.Editor
{
    [CustomEditor(typeof(ImageMinimap))]
    public sealed class ImageMinimapEditor : BaseTargetManagerEditor<ImageMinimap>
    {
        private SerializedProperty _mapImageProp;
        private SerializedProperty _contentRootProp;
        private SerializedProperty _originProp;
        private SerializedProperty _rotateWithOriginProp;
        private SerializedProperty _hideOutsideMapProp;
        private SerializedProperty _followTargetProp;
        private SerializedProperty _mapScaleProp;
        private SerializedProperty _worldMinProp;
        private SerializedProperty _worldMaxProp;
        private SerializedProperty _planeProp;

        protected override void OnEnable()
        {
            base.OnEnable();

            _mapImageProp = serializedObject.FindProperty("_mapImage");
            _contentRootProp = serializedObject.FindProperty("_contentRoot");
            _originProp = serializedObject.FindProperty("_origin");
            _rotateWithOriginProp = serializedObject.FindProperty("_rotateWithOrigin");
            _hideOutsideMapProp = serializedObject.FindProperty("_hideOutsideMap");
            _followTargetProp = serializedObject.FindProperty("_followTarget");
            _mapScaleProp = serializedObject.FindProperty("_mapScale");
            _worldMinProp = serializedObject.FindProperty("_worldMin");
            _worldMaxProp = serializedObject.FindProperty("_worldMax");
            _planeProp = serializedObject.FindProperty("_plane");
        }

        protected override string DebugHeaderText => "Image minimap blips";

        protected override void BuildInspectorGUI(VisualElement root)
        {
            root.Add(Header("Map"));
            root.Add(new PropertyField(_indicatorPanelProp, "Indicator Panel"));
            root.Add(new PropertyField(_contentRootProp, "Content Root"));
            root.Add(new PropertyField(_mapImageProp, "Map Image"));

            root.Add(Header("World Bounds"));
            root.Add(new PropertyField(_planeProp, "Plane"));
            root.Add(new PropertyField(_worldMinProp, "World Min"));
            root.Add(new PropertyField(_worldMaxProp, "World Max"));

            root.Add(Header("Blips"));
            root.Add(new PropertyField(_defaultPrefabProp, "Default Prefab"));
            root.Add(new PropertyField(_hideOutsideMapProp, "Hide Outside Map"));
            root.Add(new PropertyField(_followTargetProp, "Follow Target"));
            root.Add(new PropertyField(_mapScaleProp, "Map Scale"));

            root.Add(Header("Orientation"));
            root.Add(new PropertyField(_originProp, "Origin"));
            root.Add(new PropertyField(_rotateWithOriginProp, "Rotate With Origin"));
        }

        private void OnSceneGUI()
        {
            var minimap = (ImageMinimap)target;
            if (minimap == null)
                return;

            serializedObject.Update();

            var worldMin = _worldMinProp.vector2Value;
            var worldMax = _worldMaxProp.vector2Value;

            var bottomLeft = minimap.GetWorldPoint(worldMin);
            var topLeft = minimap.GetWorldPoint(new Vector2(worldMin.x, worldMax.y));
            var topRight = minimap.GetWorldPoint(worldMax);
            var bottomRight = minimap.GetWorldPoint(new Vector2(worldMax.x, worldMin.y));

            using (new Handles.DrawingScope(new Color(0.15f, 0.85f, 1f, 1f)))
            {
                Handles.DrawLine(bottomLeft, topLeft);
                Handles.DrawLine(topLeft, topRight);
                Handles.DrawLine(topRight, bottomRight);
                Handles.DrawLine(bottomRight, bottomLeft);
            }

            var labelStyle = new GUIStyle(EditorStyles.boldLabel)
            {
                normal = { textColor = new Color(0.15f, 0.85f, 1f, 1f) }
            };

            Handles.Label(bottomLeft, "World Min", labelStyle);
            Handles.Label(topRight, "World Max", labelStyle);

            EditorGUI.BeginChangeCheck();
            var newBottomLeft = Handles.PositionHandle(bottomLeft, Quaternion.identity);
            var newTopRight = Handles.PositionHandle(topRight, Quaternion.identity);

            if (!EditorGUI.EndChangeCheck())
                return;

            Undo.RecordObject(minimap, "Edit ImageMinimap Bounds");

            var newBottomLeftPlane = minimap.GetPlanePoint(newBottomLeft);
            var newTopRightPlane = minimap.GetPlanePoint(newTopRight);

            var min = new Vector2(
                Mathf.Min(newBottomLeftPlane.x, newTopRightPlane.x),
                Mathf.Min(newBottomLeftPlane.y, newTopRightPlane.y));
            var max = new Vector2(
                Mathf.Max(newBottomLeftPlane.x, newTopRightPlane.x),
                Mathf.Max(newBottomLeftPlane.y, newTopRightPlane.y));

            _worldMinProp.vector2Value = min;
            _worldMaxProp.vector2Value = max;
            serializedObject.ApplyModifiedProperties();
        }
    }
}
