using HutongGames.PlayMaker;
using UnityEditor;
using UnityEngine;

namespace HutongGames.Editor.Extensions
{
    public static class HandlesUtil
    {
        
        public static void DrawRotation(Vector3 center, Vector3 vector1, Vector3 vector2, float radius)
        {
            DrawWireArc(center, vector1, vector2, radius);
            
            var endPosition = center + vector2.normalized * radius;
            var upVector = Vector3.Cross(vector1, vector2).normalized;
            var endDirection = Vector3.Cross(upVector, vector2).normalized;
            DrawArrowHead(endPosition, endDirection, vector2.normalized);
        }
        
        public static void DrawArrowHead(Vector3 pos, Vector3 direction, Vector3 normal, float arrowHeadLength = .25f, float arrowHeadWidth = .15f)
        {
            var arrowStart = pos - direction * arrowHeadLength;
            Handles.DrawLine(pos, arrowStart - normal * arrowHeadWidth);
            Handles.DrawLine(pos, arrowStart + normal * arrowHeadWidth);
        }

        public static void DrawWireArc(Vector3 center, Vector3 vector1, Vector3 vector2, float radius)
        {
            var upVector = Vector3.Cross(vector1, vector2).normalized;
            var angle = Vector3.Angle(vector1, vector2);
            Handles.DrawWireArc(center, upVector, vector1, angle, radius);
        }
        
        public static void DrawDottedLineThroughPoint(Vector3 from, Vector3 point, float length, float screenSpaceSize = 5)
        {
            var lengthToPoint = (point - from).magnitude;
            var end = from + (point - from).normalized * Mathf.Max(lengthToPoint, length);
            Handles.DrawDottedLine(from, end, screenSpaceSize);
        }

        public static void DrawArrowCap(Vector3 position, Quaternion rotation, float size)
        {
            if (Event.current.type == UnityEngine.EventType.Repaint)
            {
                Handles.ConeHandleCap(0, position, rotation, size, UnityEngine.EventType.Repaint);
            }
        }
        
        public static Color GetAxisColor(AxisDirection axisDirection)
        {
            return axisDirection switch
            {
                AxisDirection.X or AxisDirection.NegativeX => Color.red,
                AxisDirection.Y or AxisDirection.NegativeY => Color.green,
                AxisDirection.Z or AxisDirection.NegativeZ => Color.blue,
                _ => Color.white
            };
        }
    }
}