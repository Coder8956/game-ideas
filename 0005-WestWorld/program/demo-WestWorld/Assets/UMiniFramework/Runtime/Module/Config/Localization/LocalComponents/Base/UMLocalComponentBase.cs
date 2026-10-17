using UnityEngine;

namespace UMiniFramework.Runtime
{
    public abstract class UMLocalComponentBase : MonoBehaviour
    {
        // ==================== 可序列化字段（Inspector 可编辑） ====================

        [SerializeField] protected string m_localID;

        // ==================== 属性 ====================

        public string LocalID
        {
            get { return m_localID; }
            set
            {
                if (m_localID != value)
                {
                    m_localID = value;
                    OnUpdateLocal();
                }
            }
        }

        // ==================== 生命周期 ====================

        private void Awake()
        {
            OnAwake();
        }

        protected virtual void OnEnable()
        {
            UMLocalCfg.RegisterComponent(this);

            if (!string.IsNullOrEmpty(m_localID))
            {
                OnUpdateLocal();
            }
        }

        protected virtual void OnDisable()
        {
            UMLocalCfg.UnregisterComponent(this);
        }

        // ── 子类回调 ──────────────────────────────────────────

        protected abstract void OnAwake();

        internal abstract void OnUpdateLocal();

        // ==================== 逻辑 ====================

        protected string LocalValue()
        {
            return UMLocalCfg.GetValue(m_localID);
        }
    }
}
