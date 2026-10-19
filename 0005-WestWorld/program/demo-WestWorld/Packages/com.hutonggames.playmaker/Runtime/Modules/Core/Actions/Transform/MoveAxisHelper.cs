using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    public static class MoveAxisHelper
    {
        public static Vector3 Apply(MoveAxis axis, Vector3 from, Vector3 to)
        {
            switch (axis)
            {
                case MoveAxis.XY:
                    to.z = from.z; // lock Z
                    break;

                case MoveAxis.XZ:
                    to.y = from.y; // lock Y
                    break;

                case MoveAxis.YZ:
                    to.x = from.x; // lock X
                    break;

                case MoveAxis.X:
                    to.Set(to.x, from.y, from.z);
                    break;

                case MoveAxis.Y:
                    to.Set(from.x, to.y, from.z);
                    break;

                case MoveAxis.Z:
                    to.Set(from.x, from.y, to.z);
                    break;

                case MoveAxis.XYZ:
                default:
                    // No constraints
                    break;
            }

            return to;
        }
        
        public static Vector3 ProjectToAxis(MoveAxis axis, Vector3 v)
        {
            switch (axis)
            {
                case MoveAxis.XYZ: return v;
                case MoveAxis.XY:  return new Vector3(v.x, v.y, 0f);
                case MoveAxis.XZ:  return new Vector3(v.x, 0f, v.z);
                case MoveAxis.YZ:  return new Vector3(0f, v.y, v.z);
                case MoveAxis.X:   return new Vector3(v.x, 0f, 0f);
                case MoveAxis.Y:   return new Vector3(0f, v.y, 0f);
                case MoveAxis.Z:   return new Vector3(0f, 0f, v.z);
                default:           return v;
            }
        }
        
        public static Vector3 GetWorldUpForAxis(MoveAxis axis)
        {
            switch (axis)
            {
                case MoveAxis.XY:  return Vector3.forward; // keep rotation around Z for 2D
                case MoveAxis.XZ:  return Vector3.up;      // Y-up for ground plane
                case MoveAxis.YZ:  return Vector3.right;   // X-up for side-on plane
                case MoveAxis.X:   return Vector3.up;
                case MoveAxis.Y:   return Vector3.right;
                case MoveAxis.Z:   return Vector3.up;
                default:           return Vector3.up;
            }
        }
        
        public static Vector3 ZeroUnusedAxes(MoveAxis axis, Vector3 p)
        {
            switch (axis)
            {
                case MoveAxis.XYZ: return p;
                case MoveAxis.XY:  return new Vector3(p.x, p.y, 0f);
                case MoveAxis.XZ:  return new Vector3(p.x, 0f, p.z);
                case MoveAxis.YZ:  return new Vector3(0f, p.y, p.z);
                case MoveAxis.X:   return new Vector3(p.x, 0f, 0f);
                case MoveAxis.Y:   return new Vector3(0f, p.y, 0f);
                case MoveAxis.Z:   return new Vector3(0f, 0f, p.z);
                default:           return p;
            }
        }
        
        public static float GetDistance(MoveAxis axis, Vector3 from, Vector3 to)
        {
            to = Apply(axis, from, to);
            return Vector3.Distance(from, to);
        }
        
        public static float GetDistanceSquared(MoveAxis axis, Vector3 from, Vector3 to)
        {
            to = Apply(axis, from, to);
            return (from - to).sqrMagnitude;
        }
    }
}