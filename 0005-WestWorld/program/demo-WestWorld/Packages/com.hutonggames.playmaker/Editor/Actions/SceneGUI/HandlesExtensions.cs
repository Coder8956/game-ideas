using HutongGames.PlayMaker;
using UnityEditor;
using UnityEngine;

namespace HutongGames.Editor.Extensions
{
    public static class HandlesExtensions
    {
        // temp buffer for DrawFrame
        private static readonly Vector3[] FramePoints = new Vector3[5];
        
        public static void DrawAxis(this Transform transform, AxisDirection axisDirection, float length = 5)
        {
            var originalColor = Handles.color;
            Handles.color = HandlesUtil.GetAxisColor(axisDirection);
            var axis = axisDirection.GetDirection(transform);
            var axisEnd = transform.position + axis * length;
            Handles.DrawLine(transform.position, axisEnd);
            HandlesUtil.DrawArrowCap(axisEnd, Quaternion.LookRotation(axis), 0.5f);
            Handles.color = originalColor;
        }
        
        /// <summary>
        /// Draw a colored frame, useful for debugging gui areas
        /// </summary>
        public static void DrawFrame(this Rect rect, Color color)
        {
            FramePoints[0] = new Vector3(rect.x, rect.y);
            FramePoints[1] = new Vector3(rect.xMax, rect.y);
            FramePoints[2] = new Vector3(rect.xMax, rect.yMax);
            FramePoints[3] = new Vector3(rect.x, rect.yMax);
            FramePoints[4] = new Vector3(rect.x, rect.y);

            var originalColor = Handles.color;
            Handles.color = color;
            Handles.DrawPolyLine(FramePoints);
            Handles.color = originalColor;
        }

        /// <summary>
        /// Draw a colored frame, useful for debugging gui areas
        /// </summary>
        public static void DrawFrameWithLabel(this Rect rect, Color color, string label)
        {
            FramePoints[0] = new Vector3(rect.x, rect.y);
            FramePoints[1] = new Vector3(rect.xMax, rect.y);
            FramePoints[2] = new Vector3(rect.xMax, rect.yMax);
            FramePoints[3] = new Vector3(rect.x, rect.yMax);
            FramePoints[4] = new Vector3(rect.x, rect.y);

            var originalColor = Handles.color;
            Handles.color = color;
            Handles.DrawPolyLine(FramePoints);
            Handles.Label(FramePoints[0], label);
            Handles.color = originalColor;
        }
    }
}