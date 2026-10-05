using UnityEngine;
using UnityEngine.InputSystem;

namespace UGU.Runtime
{
    /// <summary>
    /// 玩家坦克 WASD 控制脚本（挂载在 Player 根节点上）。
    /// <para>W：前进　S：后退　A：左转　D：右转</para>
    /// 移动沿物体自身前方向（XZ 平面，Y 保持不变），转向绕自身 Y 轴旋转；
    /// 轮子滚动委托给同物体上的 <see cref="UGTankWheels"/> 组件驱动。
    /// </summary>
    public class UGPlayerController : MonoBehaviour
    {
        [Header("移动")]
        [Tooltip("前进/后退速度（米/秒）")]
        [SerializeField]
        private float m_moveSpeed = 5f;

        [Header("转向")]
        [Tooltip("旋转速度（度/秒）")]
        [SerializeField]
        private float m_rotateSpeed = 90f;

        [Header("车轮")]
        [Tooltip("坦克轮子滚动组件；留空自动获取本物体上的 UGTankWheels")]
        [SerializeField]
        private UGTankWheels m_wheels;

        private void Start()
        {
            if (m_wheels == null)
                m_wheels = GetComponent<UGTankWheels>();
        }

        private void Update()
        {
            var keyboard = Keyboard.current;
            if (keyboard == null) return;

            // W/S：前进/后退输入，同按相互抵消
            var moveInput = 0f;
            if (keyboard.wKey.isPressed) moveInput += 1f;
            if (keyboard.sKey.isPressed) moveInput -= 1f;

            // A/D：左转/右转输入，同按相互抵消
            var turnInput = 0f;
            if (keyboard.dKey.isPressed) turnInput += 1f;
            if (keyboard.aKey.isPressed) turnInput -= 1f;

            // 沿自身 Z 轴平移（默认 Space.Self，Y 保持不变）
            if (moveInput != 0f)
                transform.Translate(new Vector3(0f, 0f, moveInput * m_moveSpeed * Time.deltaTime));

            // 绕自身 Y 轴旋转
            if (turnInput != 0f)
                transform.Rotate(0f, turnInput * m_rotateSpeed * Time.deltaTime, 0f);

            // 驱动轮子滚动（UGTankWheels 内部处理原地转向反向滚动、运动中转向不产生转向动画）
            if (m_wheels != null)
                m_wheels.Drive(moveInput * m_moveSpeed, turnInput * m_rotateSpeed);
        }
    }
}
