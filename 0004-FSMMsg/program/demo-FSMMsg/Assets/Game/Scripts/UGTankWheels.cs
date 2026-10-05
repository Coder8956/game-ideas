using System.Collections.Generic;
using UnityEngine;

namespace UGU.Runtime
{
    /// <summary>
    /// 坦克四轮滚动组件（玩家/敌人等任意坦克可复用）。
    /// 由外部控制器每帧调用 <see cref="Drive"/> 驱动：
    /// <para>· 前进/后退：四个轮子同向滚动；</para>
    /// <para>· 原地转向：左右两侧轮子反向滚动（左轮随转向方向、右轮反向）；</para>
    /// <para>· 运动中转向：不产生转向动画，仅保留前进/后退滚动。</para>
    /// </summary>
    public class UGTankWheels : MonoBehaviour
    {
        [Header("车轮")]
        [Tooltip("四个车轮的 Transform 引用；留空时按名字（f/b + left/right）自动匹配")]
        [SerializeField]
        private Transform frontLeft;

        [Tooltip("前右轮")]
        [SerializeField]
        private Transform frontRight;

        [Tooltip("后左轮")]
        [SerializeField]
        private Transform backLeft;

        [Tooltip("后右轮")]
        [SerializeField]
        private Transform backRight;

        [Tooltip("车轮半径（米），用于把位移换算成滚动角度；0 表示按各车轮网格包围盒自动估算")]
        [SerializeField]
        private float m_wheelRadius = 0f;

        [Tooltip("轮距半宽（米），原地转向时把转向角速度换算成轮子滚动速度；0 表示按各轮相对坦克中心的横向距离自动估算")]
        [SerializeField]
        private float m_trackHalfWidth = 0f;

        /// <summary>车轮滚动角度的指数平滑系数（越大越跟手，越小越有惯性感）</summary>
        private const float SpinSmoothing = 25f;

        /// <summary>单帧滚动角度上限（度），防止异常输入或数值突变导致车轮狂转</summary>
        private const float MaxAnglePerFrame = 90f;

        /// <summary>汇总后的车轮列表（仅包含非空槽位）</summary>
        private Transform[] m_allWheels;

        /// <summary>各车轮的实际滚动半径（可为每个轮子独立估算）</summary>
        private float[] m_wheelRadii;

        /// <summary>各车轮平滑后的单帧滚动角度</summary>
        private float[] m_smoothAngles;

        /// <summary>按车轮相对坦克中心横向距离自动估算的轮距半宽</summary>
        private float m_estimatedTrackHalfWidth;

        private void Start()
        {
            // 有槽位为空时，按名字自动匹配四个轮子
            AutoAssignWheels();

            // 汇总非空轮子并初始化滚动状态
            BuildWheelList();

            if (m_allWheels.Length == 0)
                Debug.LogWarning($"{name}: 未找到任何车轮，车轮将不会滚动。请在 Inspector 中指定 frontLeft / frontRight / backLeft / backRight。", this);
        }

        /// <summary>
        /// 每帧驱动轮子滚动（由玩家/敌人控制器调用）。
        /// </summary>
        /// <param name="forwardSpeed">沿自身前方向的移动速度（米/秒），正=前进、负=后退</param>
        /// <param name="turnSpeed">绕自身 Y 轴的角速度（度/秒），正=右转、负=左转；仅在无前后移动时生效</param>
        public void Drive(float forwardSpeed, float turnSpeed)
        {
            if (m_allWheels.Length == 0) return;

            var dt = Time.deltaTime;
            var smoothFactor = 1f - Mathf.Exp(-SpinSmoothing * dt);
            var trackHalfWidth = m_trackHalfWidth > 0f ? m_trackHalfWidth : m_estimatedTrackHalfWidth;
            var hasForward = !Mathf.Approximately(forwardSpeed, 0f);

            for (var i = 0; i < m_allWheels.Length; i++)
            {
                var wheel = m_allWheels[i];
                if (wheel == null) continue;

                var radius = m_wheelRadii[i];
                if (radius <= 0f) continue;

                // 前进/后退滚动角度（度）：位移=速度×时间，角度=位移÷半径
                var moveAngle = forwardSpeed * dt / radius * Mathf.Rad2Deg;

                // 原地转向滚动角度（度）：左轮随转向方向滚动，右轮反向滚动
                var turnAngle = 0f;
                if (!hasForward && !Mathf.Approximately(turnSpeed, 0f))
                {
                    var pivotAngle = turnSpeed * dt * trackHalfWidth / radius;
                    turnAngle = (wheel == frontLeft || wheel == backLeft) ? pivotAngle : -pivotAngle;
                }

                var angle = Mathf.Clamp(moveAngle + turnAngle, -MaxAnglePerFrame, MaxAnglePerFrame);
                m_smoothAngles[i] = Mathf.Lerp(m_smoothAngles[i], angle, smoothFactor);
                wheel.Rotate(m_smoothAngles[i], 0f, 0f, Space.Self);
            }
        }

        /// <summary>
        /// 汇总四个命名槽位中非空的轮子，并为每个轮子初始化独立半径、平滑状态与轮距半宽。
        /// </summary>
        private void BuildWheelList()
        {
            var list = new List<Transform>();
            if (frontLeft != null) list.Add(frontLeft);
            if (frontRight != null) list.Add(frontRight);
            if (backLeft != null) list.Add(backLeft);
            if (backRight != null) list.Add(backRight);

            m_allWheels = list.ToArray();
            m_wheelRadii = new float[m_allWheels.Length];
            m_smoothAngles = new float[m_allWheels.Length];

            // 轮距半宽：各轮相对坦克中心（本物体 Y 轴）横向距离的平均值
            var widthSum = 0f;
            foreach (var wheel in m_allWheels)
                widthSum += Mathf.Abs(transform.InverseTransformPoint(wheel.position).x);
            m_estimatedTrackHalfWidth = m_allWheels.Length > 0 ? widthSum / m_allWheels.Length : 0f;

            for (var i = 0; i < m_allWheels.Length; i++)
                m_wheelRadii[i] = EstimateRadius(m_allWheels[i]);
        }

        /// <summary>
        /// 计算单个轮子的滚动半径：优先使用 Inspector 手动设置的 m_wheelRadius，
        /// 否则按该轮自身网格包围盒的竖直直径取半（前后轮尺寸不同也能各自准确滚动）。
        /// </summary>
        private float EstimateRadius(Transform wheel)
        {
            if (m_wheelRadius > 0f) return m_wheelRadius;

            var rend = wheel.GetComponent<Renderer>();
            return rend != null ? rend.bounds.size.y * 0.5f : 0f;
        }

        /// <summary>
        /// 为仍为空的槽位自动匹配轮子：按名字中的方位词（f/b、front/back、left/right）对应到
        /// frontLeft / frontRight / backLeft / backRight 四个槽位。
        /// </summary>
        private void AutoAssignWheels()
        {
            if (frontLeft != null && frontRight != null && backLeft != null && backRight != null) return;

            var wheels = new List<Transform>();
            FindWheels(transform, wheels);

            foreach (var wheel in wheels)
            {
                var n = wheel.name.ToLowerInvariant();
                var isFront = n.Contains("_f_") || n.Contains("front");
                var isBack = n.Contains("_b_") || n.Contains("back");
                var isLeft = n.Contains("left");
                var isRight = n.Contains("right");

                if (frontLeft == null && isFront && isLeft)
                    frontLeft = wheel;
                else if (frontRight == null && isFront && isRight)
                    frontRight = wheel;
                else if (backLeft == null && isBack && isLeft)
                    backLeft = wheel;
                else if (backRight == null && isBack && isRight)
                    backRight = wheel;
            }
        }

        /// <summary>
        /// 递归查找名字含 "Wheel"（不区分大小写）的子物体。
        /// </summary>
        private static void FindWheels(Transform root, List<Transform> results)
        {
            for (var i = 0; i < root.childCount; i++)
            {
                var child = root.GetChild(i);
                if (child.name.IndexOf("Wheel", System.StringComparison.OrdinalIgnoreCase) >= 0)
                    results.Add(child);
                FindWheels(child, results);
            }
        }
    }
}
