
using HutongGames.Editor;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Editor
{
    [PublicAPI]
    [SceneGUI(typeof(RandomGetPointInRectRing))]
    public class RandomGetPointInRectRingSceneGUI : SceneGUIDrawer
    {
        private RandomGetPointInRectRing _action;

        public RandomGetPointInRectRingSceneGUI(RandomGetPointInRectRing target) : base(target)
        {
            _action = target;
        }
        
        public override bool IsValid => _action.IsEnabled;
        
        public override void OnSceneGUI(SceneView sceneView)
        {
            if (!IsValid) return;

            EditorGUI.BeginChangeCheck();

            // Handle center position
            Vector3 center3D = new Vector3(_action.Offset.Value.x, _action.Offset.Value.y, 0f);
            Vector3 newCenter3D = Handles.PositionHandle(center3D, Quaternion.identity);
            
            // Get rect info
            Rect innerRect = _action.InnerRect.Value;
            Rect outerRect = _action.OuterRect.Value;
            
            // Handle outer rectangle
            Vector3 outerRectCenter3D = center3D + new Vector3(outerRect.center.x, outerRect.center.y, 0f);
            Vector3 outerHalfWidth = Vector3.right * outerRect.width * 0.5f;
            Vector3 outerHalfHeight = Vector3.up * outerRect.height * 0.5f;
            
            // Outer rect corner handles (yellow)
            using (new Handles.DrawingScope(Color.yellow))
            {
                Vector3 outerBottomRight = outerRectCenter3D + outerHalfWidth - outerHalfHeight;
                Vector3 outerTopLeft = outerRectCenter3D - outerHalfWidth + outerHalfHeight;
                
                Vector3 newOuterBottomRight = Handles.Slider2D(
                    outerBottomRight,
                    Vector3.forward,
                    Vector3.right,
                    Vector3.up,
                    HandleUtility.GetHandleSize(outerBottomRight) * 0.1f,
                    Handles.RectangleHandleCap,
                    0f
                );
                
                Vector3 newOuterTopLeft = Handles.Slider2D(
                    outerTopLeft,
                    Vector3.forward,
                    Vector3.right,
                    Vector3.up,
                    HandleUtility.GetHandleSize(outerTopLeft) * 0.1f,
                    Handles.RectangleHandleCap,
                    0f
                );
                
                // Calculate new outer rect if handles moved
                if (newOuterBottomRight != outerBottomRight || newOuterTopLeft != outerTopLeft)
                {
                    Vector2 centerDelta = new Vector2(newCenter3D.x - center3D.x, newCenter3D.y - center3D.y);
                    Vector2 adjustedOuterBR = new Vector2(newOuterBottomRight.x, newOuterBottomRight.y) - centerDelta;
                    Vector2 adjustedOuterTL = new Vector2(newOuterTopLeft.x, newOuterTopLeft.y) - centerDelta;
                    
                    float newOuterWidth = Mathf.Abs(adjustedOuterBR.x - adjustedOuterTL.x);
                    float newOuterHeight = Mathf.Abs(adjustedOuterBR.y - adjustedOuterTL.y);
                    Vector2 newOuterCenter = (adjustedOuterBR + adjustedOuterTL) * 0.5f - new Vector2(newCenter3D.x, newCenter3D.y);
                    
                    outerRect = new Rect(
                        newOuterCenter.x - newOuterWidth * 0.5f,
                        newOuterCenter.y - newOuterHeight * 0.5f,
                        newOuterWidth,
                        newOuterHeight
                    );
                }
            }
            
            // Handle inner rectangle
            Vector3 innerRectCenter3D = center3D + new Vector3(innerRect.center.x, innerRect.center.y, 0f);
            Vector3 innerHalfWidth = Vector3.right * innerRect.width * 0.5f;
            Vector3 innerHalfHeight = Vector3.up * innerRect.height * 0.5f;
            
            // Inner rect corner handles (red)
            using (new Handles.DrawingScope(Color.red))
            {
                Vector3 innerBottomRight = innerRectCenter3D + innerHalfWidth - innerHalfHeight;
                Vector3 innerTopLeft = innerRectCenter3D - innerHalfWidth + innerHalfHeight;
                
                Vector3 newInnerBottomRight = Handles.Slider2D(
                    innerBottomRight,
                    Vector3.forward,
                    Vector3.right,
                    Vector3.up,
                    HandleUtility.GetHandleSize(innerBottomRight) * 0.08f,
                    Handles.RectangleHandleCap,
                    0f
                );
                
                Vector3 newInnerTopLeft = Handles.Slider2D(
                    innerTopLeft,
                    Vector3.forward,
                    Vector3.right,
                    Vector3.up,
                    HandleUtility.GetHandleSize(innerTopLeft) * 0.08f,
                    Handles.RectangleHandleCap,
                    0f
                );
                
                // Calculate new inner rect if handles moved
                if (newInnerBottomRight != innerBottomRight || newInnerTopLeft != innerTopLeft)
                {
                    Vector2 centerDelta = new Vector2(newCenter3D.x - center3D.x, newCenter3D.y - center3D.y);
                    Vector2 adjustedInnerBR = new Vector2(newInnerBottomRight.x, newInnerBottomRight.y) - centerDelta;
                    Vector2 adjustedInnerTL = new Vector2(newInnerTopLeft.x, newInnerTopLeft.y) - centerDelta;
                    
                    float newInnerWidth = Mathf.Abs(adjustedInnerBR.x - adjustedInnerTL.x);
                    float newInnerHeight = Mathf.Abs(adjustedInnerBR.y - adjustedInnerTL.y);
                    Vector2 newInnerCenter = (adjustedInnerBR + adjustedInnerTL) * 0.5f - new Vector2(newCenter3D.x, newCenter3D.y);
                    
                    // Ensure inner rect stays within outer rect bounds
                    newInnerWidth = Mathf.Min(newInnerWidth, outerRect.width - 0.1f);
                    newInnerHeight = Mathf.Min(newInnerHeight, outerRect.height - 0.1f);
                    
                    innerRect = new Rect(
                        newInnerCenter.x - newInnerWidth * 0.5f,
                        newInnerCenter.y - newInnerHeight * 0.5f,
                        newInnerWidth,
                        newInnerHeight
                    );
                }
            }
            
            if (EditorGUI.EndChangeCheck())
            {
                UndoHelper.RecordObject(_action.Owner, "Modify Rect Ring Parameters");
                
                // Update center
                _action.Offset.Value = new Vector2(newCenter3D.x, newCenter3D.y);
                
                // Update rectangles
                _action.OuterRect.Value = outerRect;
                _action.InnerRect.Value = innerRect;
                
                UndoHelper.RecordPrefabChanges(_action.Owner);
            }
        }
        
        public override void OnDrawGizmos()
        {
            if (!IsValid) return;
            
            Vector3 center3D = new Vector3(_action.Offset.Value.x, _action.Offset.Value.y, 0f);
            Rect innerRect = _action.InnerRect.Value;
            Rect outerRect = _action.OuterRect.Value;
            
            // Draw outer rectangle (yellow)
            DrawRectangle(center3D, outerRect, Color.yellow, 0.03f);
            
            // Draw inner rectangle (red)
            DrawRectangle(center3D, innerRect, Color.red, 0.025f);
            
            // Draw center point (white)
            using (new Handles.DrawingScope(Color.white))
            {
                float centerSize = HandleUtility.GetHandleSize(center3D) * 0.05f;
                Handles.DrawSolidDisc(center3D, Vector3.forward, centerSize);
            }
        }
        
        private void DrawRectangle(Vector3 center3D, Rect rect, Color color, float dotSizeMultiplier)
        {
            Vector3 rectCenter3D = center3D + new Vector3(rect.center.x, rect.center.y, 0f);
            
            using (new Handles.DrawingScope(color))
            {
                Vector3 halfWidth = Vector3.right * rect.width * 0.5f;
                Vector3 halfHeight = Vector3.up * rect.height * 0.5f;
                
                Vector3[] corners = new Vector3[4]
                {
                    rectCenter3D - halfWidth - halfHeight, // Bottom-left
                    rectCenter3D + halfWidth - halfHeight, // Bottom-right
                    rectCenter3D + halfWidth + halfHeight, // Top-right
                    rectCenter3D - halfWidth + halfHeight  // Top-left
                };
                
                // Draw rectangle lines
                Handles.DrawLine(corners[0], corners[1]);
                Handles.DrawLine(corners[1], corners[2]);
                Handles.DrawLine(corners[2], corners[3]);
                Handles.DrawLine(corners[3], corners[0]);
                
                // Draw corner dots for visual feedback
                float dotSize = HandleUtility.GetHandleSize(rectCenter3D) * dotSizeMultiplier;
                foreach (var corner in corners)
                {
                    Handles.DrawSolidDisc(corner, Vector3.forward, dotSize);
                }
            }
        }
    }
}
