using UnityEngine;
using UnityEngine.InputSystem;

namespace UGU.Runtime
{
    /// <summary>
    /// 输入工具
    /// </summary>
    public static class UGUInputUtils
    {
        /// <summary>
        /// 判断鼠标是否在屏幕内
        /// </summary>
        /// <returns>是否在屏幕内</returns>
        public static bool IsMouseInScreen()
        {
            if (Mouse.current == null) return false;

            Vector2 mousePosition = Mouse.current.position.ReadValue();

            bool isXInScreen = mousePosition.x >= 0 && mousePosition.x <= Screen.width;
            bool isYInScreen = mousePosition.y >= 0 && mousePosition.y <= Screen.height;

            return isXInScreen && isYInScreen;
        }

        /// <summary>
        /// 获取鼠标点的世界位置
        /// </summary>
        /// <param name="referenceCamera">参考相机</param>
        /// <param name="mouseZVal">鼠标点的深度，具体值根据你的场景而定</param>
        /// <returns></returns>
        public static Vector3 MousePointScreenToWorld(Camera referenceCamera, float mouseZVal)
        {
            if (Mouse.current == null) return Vector3.zero;

            Vector3 mousePosition = Mouse.current.position.ReadValue();
            mousePosition.z = mouseZVal;
            Vector3 worldPosition = referenceCamera.ScreenToWorldPoint(mousePosition);
            return worldPosition;
        }
    }
}
