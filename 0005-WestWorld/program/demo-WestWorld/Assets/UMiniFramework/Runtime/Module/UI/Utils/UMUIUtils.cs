using UnityEngine;

namespace UMiniFramework.Runtime
{
    /// <summary>
    /// UI工具
    /// </summary>
    public class UMUIUtils
    {
        public static void StretchFull(RectTransform rectTransform)
        {
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.pivot = new Vector2(0.5f, 0.5f);
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;
        }
    }
}