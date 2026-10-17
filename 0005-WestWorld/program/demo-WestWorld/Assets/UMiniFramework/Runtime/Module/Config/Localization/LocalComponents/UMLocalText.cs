using System;
using UnityEngine;
using UnityEngine.UI;

namespace UMiniFramework.Runtime
{
    [RequireComponent(typeof(Text))]
    public class UMLocalText : UMLocalComponentBase
    {
        private Text m_text;
        private Func<string, string> m_localTextHandler;

        public string Text => m_text != null ? m_text.text : string.Empty;

        protected override void OnAwake()
        {
            m_text = GetComponent<Text>();
            if (m_text == null)
            {
                Debug.LogWarning($"[UMLocalText] m_text is null. localID:{m_localID}");
            }
        }

        internal override void OnUpdateLocal()
        {
            if (m_text == null) return;

            m_text.text = m_localTextHandler != null
                ? m_localTextHandler.Invoke(LocalValue())
                : LocalValue();
        }

        public void SetLocalTextHandler(Func<string, string> handler, bool immeUpdate = true)
        {
            m_localTextHandler = handler;
            if (immeUpdate)
            {
                OnUpdateLocal();
            }
        }

        public void ClearLocalTextHandle()
        {
            m_localTextHandler = null;
        }
    }
}
