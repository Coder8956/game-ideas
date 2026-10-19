using HutongGames.Editor;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Editor
{
    [PublicAPI]
    [SceneGUI(typeof(RandomGetPointOnRect))]
    public class RandomGetPointOnRectSceneGUI : SceneGUIDrawer
    {
        private RandomGetPointOnRect _action;

        public RandomGetPointOnRectSceneGUI(RandomGetPointOnRect target) : base(target)
        {
            _action = target;
        }

        public override bool IsValid => _action.IsEnabled;

        public override void OnSceneGUI(SceneView sceneView)
        {
            if (!IsValid) return;

            EditorGUI.BeginChangeCheck();

            // Handle center position
            var center3D = new Vector3(_action.Offset.Value.x, _action.Offset.Value.y, 0f);
            var newCenter3D = Handles.PositionHandle(center3D, Quaternion.identity);

            // Get rect info
            var rect = _action.Rect.Value;
            var rectCenter3D = center3D + new Vector3(rect.center.x, rect.center.y, 0f);

            // Create corner handles using Slider2D
            var halfWidth = Vector3.right * rect.width * 0.5f;
            var halfHeight = Vector3.up * rect.height * 0.5f;

            // Bottom-right corner handle (most intuitive for resizing)
            var bottomRightCorner = rectCenter3D + halfWidth - halfHeight;
            var newBottomRightCorner = Handles.Slider2D(
                bottomRightCorner,
                Vector3.forward,
                Vector3.right,
                Vector3.up,
                HandleUtility.GetHandleSize(bottomRightCorner) * 0.1f,
                Handles.RectangleHandleCap,
                0f
            );

            // Top-left corner handle
            var topLeftCorner = rectCenter3D - halfWidth + halfHeight;
            var newTopLeftCorner = Handles.Slider2D(
                topLeftCorner,
                Vector3.forward,
                Vector3.right,
                Vector3.up,
                HandleUtility.GetHandleSize(topLeftCorner) * 0.1f,
                Handles.RectangleHandleCap,
                0f
            );

            if (EditorGUI.EndChangeCheck())
            {
                UndoHelper.RecordObject(_action.Owner, "Modify Rect Parameters");

                // Update center
                _action.Offset.Value = new Vector2(newCenter3D.x, newCenter3D.y);

                // Calculate new rect from corner positions
                var centerDelta = new Vector2(newCenter3D.x - center3D.x, newCenter3D.y - center3D.y);

                // Adjust corner positions for center movement
                var adjustedBottomRight = new Vector2(newBottomRightCorner.x, newBottomRightCorner.y) - centerDelta;
                var adjustedTopLeft = new Vector2(newTopLeftCorner.x, newTopLeftCorner.y) - centerDelta;

                // Calculate new rect dimensions
                var newWidth = Mathf.Abs(adjustedBottomRight.x - adjustedTopLeft.x);
                var newHeight = Mathf.Abs(adjustedBottomRight.y - adjustedTopLeft.y);

                // Calculate new rect center relative to action center
                var newRectCenter = (adjustedBottomRight + adjustedTopLeft) * 0.5f -
                                    new Vector2(newCenter3D.x, newCenter3D.y);

                // Update rect
                _action.Rect.Value = new Rect(
                    newRectCenter.x - newWidth * 0.5f,
                    newRectCenter.y - newHeight * 0.5f,
                    newWidth,
                    newHeight
                );

                UndoHelper.RecordPrefabChanges(_action.Owner);
            }
        }

        public override void OnDrawGizmos()
        {
            if (!IsValid) return;

            var center3D = new Vector3(_action.Offset.Value.x, _action.Offset.Value.y, 0f);
            var rect = _action.Rect.Value;

            // Calculate actual rectangle position in world space
            var rectCenter3D = center3D + new Vector3(rect.center.x, rect.center.y, 0f);

            // Draw rectangle outline
            using (new Handles.DrawingScope(Color.yellow))
            {
                var halfWidth = Vector3.right * rect.width * 0.5f;
                var halfHeight = Vector3.up * rect.height * 0.5f;

                var corners = new Vector3[4]
                {
                    rectCenter3D - halfWidth - halfHeight, // Bottom-left
                    rectCenter3D + halfWidth - halfHeight, // Bottom-right
                    rectCenter3D + halfWidth + halfHeight, // Top-right
                    rectCenter3D - halfWidth + halfHeight // Top-left
                };

                // Draw rectangle lines
                Handles.DrawLine(corners[0], corners[1]);
                Handles.DrawLine(corners[1], corners[2]);
                Handles.DrawLine(corners[2], corners[3]);
                Handles.DrawLine(corners[3], corners[0]);

                // Draw corner dots for visual feedback
                var dotSize = HandleUtility.GetHandleSize(rectCenter3D) * 0.03f;
                foreach (var corner in corners)
                {
                    Handles.DrawSolidDisc(corner, Vector3.forward, dotSize);
                }
            }

            // Draw center point
            using (new Handles.DrawingScope(Color.red))
            {
                var centerSize = HandleUtility.GetHandleSize(center3D) * 0.05f;
                Handles.DrawSolidDisc(center3D, Vector3.forward, centerSize);
            }
        }
    }
}