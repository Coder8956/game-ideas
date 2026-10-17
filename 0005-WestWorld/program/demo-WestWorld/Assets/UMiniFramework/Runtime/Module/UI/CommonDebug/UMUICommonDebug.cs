using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UMiniFramework.Runtime
{
    [UMUIPanelCfg("UI/Debug/UMUICommonDebug")]
    public class UMUICommonDebug : UMUIPanelBase
    {
        [SerializeField] private Button m_btnDebug;
        [SerializeField] private GameObject m_panel;
        private List<UMDebugItemBase> m_debugItems;

        protected override void OnInitialize()
        {
            m_panel.SetActive(false);
            m_btnDebug.onClick.AddListener(SwitchPanel);
            UMDebugItemBase[] items = GetComponentsInChildren<UMDebugItemBase>(true);
            m_debugItems = new List<UMDebugItemBase>(items);
            for (var i = 0; i < m_debugItems.Count; i++)
            {
                m_debugItems[i].Init();
            }
        }

        private void SwitchPanel()
        {
            m_panel.SetActive(!m_panel.activeSelf);
        }
    }
}