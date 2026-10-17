using UnityEngine;
using UnityEngine.UI;

namespace UMiniFramework.Runtime
{
    public abstract class UMUIPanelBase : MonoBehaviour
    {
        // ==================== 可序列化字段（Inspector 可编辑） ====================

        [SerializeField] private bool m_useCommonMask = true;
        [SerializeField] private RectTransform[] m_layoutRebuilderOnOpen;
        [SerializeField] private Button m_btnClose;

        // ==================== 私有字段（运行时状态） ====================

        protected Image m_imgMask;

        private int m_layer;

        // ==================== 属性 ====================

        /// <summary>
        /// 是否使用通用遮罩
        /// </summary>
        public bool UseCommonMask
        {
            get { return m_useCommonMask; }
        }

        // ==================== 逻辑 ====================

        internal void Initialize()
        {
            m_imgMask = GetComponent<Image>();
            if (m_btnClose != null)
            {
                m_btnClose.onClick.AddListener(Close);
            }

            OnInitialize();
        }

        /// <summary>
        /// 子类初始化回调
        /// </summary>
        protected abstract void OnInitialize();

        // ==================== 公开接口 ====================

        /// <summary>
        /// 打开面板：挂到对应层级 → 拉伸 → 激活 → 回调。
        /// </summary>
        public virtual void Open(int layer = 0)
        {
            m_layer = layer;
            transform.SetParent(UMOUI.GetLayer(m_layer), false);
            UMUIUtils.StretchFull(GetComponent<RectTransform>());

            if (UseCommonMask && m_imgMask != null)
            {
                m_imgMask.color = UMOUI.PanelMaskColor;
            }

            gameObject.SetActive(true);

            if (m_layoutRebuilderOnOpen != null)
            {
                for (var i = 0; i < m_layoutRebuilderOnOpen.Length; i++)
                {
                    RectTransform rebuildRect = m_layoutRebuilderOnOpen[i];
                    LayoutRebuilder.ForceRebuildLayoutImmediate(rebuildRect);
                }
            }
        }

        /// <summary>
        /// 关闭面板：回调 → 失活 → 移入缓存。
        /// </summary>
        public virtual void Close()
        {
            if (this == null) return;
            gameObject.SetActive(false);
            transform.SetParent(UMOUI.UICache, false);
        }

        /// <summary>
        /// 释放面板：回调 → 移除缓存 → 销毁。
        /// </summary>
        public virtual void Release()
        {
            if (gameObject.activeSelf)
            {
                Close();
            }

            UMOUI.RemoveFromCache(this);
            Destroy(gameObject);
        }
    }
}
