using UnityEngine.UI;

namespace UMiniFramework.Runtime
{
    public abstract class UMDebugBtnBase : UMDebugItemBase
    {
        private Button m_btn;

        public override void Init()
        {
            m_btn = GetComponent<Button>();
            if (m_btn != null)
            {
                m_btn.onClick.AddListener(OnClick);
            }
        }

        protected abstract void OnClick();
    }
}