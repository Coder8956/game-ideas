using UnityEngine;

namespace UGU.Runtime
{
    /// <summary>
    /// 数学/几何工具
    /// </summary>
    public static class UGUMathUtils
    {
        // ── 角度计算 ──────────────────────────────────────────────

        /// <summary>
        /// 计算两个向量之间的角度 (0 到 360 度)
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static float CalculateAngle360(Vector3 from, Vector3 to)
        {
            float dot = Vector3.Dot(from.normalized, to.normalized);
            Vector3 cross = Vector3.Cross(from, to);
            float angleDeg = Mathf.Acos(dot) * Mathf.Rad2Deg;

            if (cross.z < 0)
            {
                angleDeg = 360f - angleDeg;
            }

            return angleDeg;
        }

        /// <summary>
        /// 计算两个向量之间的角度 (0 到 180 度)
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static float CalculateAngle180(Vector3 from, Vector3 to)
        {
            float dot = Vector3.Dot(from.normalized, to.normalized);
            float angleDeg = Mathf.Acos(dot) * Mathf.Rad2Deg;
            return angleDeg;
        }

        /// <summary>
        /// 计算两个向量之间的角度 (-180 到 180 度)
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static float CalculateSignedAngle180(Vector3 from, Vector3 to)
        {
            float dot = Vector3.Dot(from.normalized, to.normalized);
            float angleDeg = Mathf.Acos(dot) * Mathf.Rad2Deg;
            Vector3 cross = Vector3.Cross(from, to);

            if (cross.z < 0)
            {
                angleDeg = -angleDeg;
            }

            return angleDeg;
        }

        /// <summary>
        /// 根据给定的角度和旋转轴计算目标向量
        /// </summary>
        /// <param name="from"></param>
        /// <param name="angle"></param>
        /// <param name="axis"></param>
        /// <returns></returns>
        public static Vector3 CalculateTargetVectorByAngle(Vector3 from, float angle, Vector3 axis)
        {
            Quaternion rotation = Quaternion.AngleAxis(angle, axis);
            return rotation * from;
        }

        // ── 几何计算 ──────────────────────────────────────────────

        /// <summary>
        /// 计算射线与平面的交点
        /// </summary>
        /// <param name="rayOrigin">射线起点</param>
        /// <param name="rayDirection">射线方向（单位向量）</param>
        /// <param name="planePoint">平面上的一个点</param>
        /// <param name="planeNormal">平面的法向量（单位向量）</param>
        /// <returns>交点坐标。如果没有交点，返回 Vector3.positiveInfinity</returns>
        public static Vector3 GetRayPlaneIntersection(Vector3 rayOrigin, Vector3 rayDirection, Vector3 planePoint,
            Vector3 planeNormal)
        {
            float denominator = Vector3.Dot(planeNormal, rayDirection);

            if (Mathf.Abs(denominator) < 0.0001f)
            {
                return Vector3.positiveInfinity;
            }

            float t = Vector3.Dot(planeNormal, planePoint - rayOrigin) / denominator;

            if (t < 0)
            {
                return Vector3.positiveInfinity;
            }

            return rayOrigin + t * rayDirection;
        }

        // ── 概率与值约束 ──────────────────────────────────────────

        /// <summary>
        /// 根据概率随机判断是否可以执行某事件
        /// </summary>
        /// <param name="probability">概率 [0, 1]，如 0.7 表示 70%</param>
        /// <returns>是否可以执行</returns>
        public static bool IsProbabilityMet(float probability)
        {
            return UnityEngine.Random.value <= probability;
        }

        /// <summary>
        /// int 值约束为大于等于 0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int IntValueGreaterOrEqualZero(int value)
        {
            return Mathf.Clamp(value, 0, int.MaxValue);
        }
    }
}
