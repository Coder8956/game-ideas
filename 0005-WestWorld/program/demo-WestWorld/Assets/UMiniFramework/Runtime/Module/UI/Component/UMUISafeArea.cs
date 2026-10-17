using UnityEngine;

namespace UMiniFramework.Runtime
{
    /// <summary>
    /// 将挂载的RectTransform限制在屏幕安全区域内，避开刘海屏、圆角等无效像素区域。
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public class UMUISafeArea : MonoBehaviour
    {
        // ==================== 私有字段（运行时状态） ====================

        private RectTransform m_rectTransform;

        // ==================== 生命周期 ====================

        private void Awake()
        {
            m_rectTransform = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            ApplySafeArea();
        }

        /// <summary>
        /// 屏幕尺寸或方向变化时由Unity自动回调，实时刷新安全区域。
        /// </summary>
        private void OnRectTransformDimensionsChange()
        {
            ApplySafeArea();
        }

        // ==================== 逻辑 ====================

        /// <summary>
        /// 根据Screen.safeArea将像素坐标转换为归一化锚点，应用到RectTransform。
        /// </summary>
        private void ApplySafeArea()
        {
            if (m_rectTransform == null)
                return;

            Rect safeArea = Screen.safeArea;

            float screenWidth = Screen.width;
            float screenHeight = Screen.height;

            Vector2 anchorMin = safeArea.position;
            anchorMin.x /= screenWidth;
            anchorMin.y /= screenHeight;

            Vector2 anchorMax = safeArea.position + safeArea.size;
            anchorMax.x /= screenWidth;
            anchorMax.y /= screenHeight;

            m_rectTransform.anchorMin = anchorMin;
            m_rectTransform.anchorMax = anchorMax;

            m_rectTransform.offsetMin = Vector2.zero;
            m_rectTransform.offsetMax = Vector2.zero;
        }
    }
}
