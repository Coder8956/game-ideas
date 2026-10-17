using System.Collections.Generic;
using UnityEngine;

namespace UMiniFramework.Runtime
{
    public class UMAudioBGM : UMAudioFuncBase
    {
        // ==================== 私有字段（运行时状态） ====================

        private const string INVALID_BGM_ID = "UM_INVALID_BGM_ID";

        private AudioSource m_audioSource = null;
        private Dictionary<string, UMACInfo> m_BGMClipDic;

        // ==================== 属性 ====================

        /// <summary>
        /// 静音属性
        /// </summary>
        public bool Mute
        {
            get { return m_audioSource != null && m_audioSource.mute; }
            set { if (m_audioSource != null) m_audioSource.mute = value; }
        }

        /// <summary>
        /// 音量属性
        /// </summary>
        public float Volume
        {
            get { return m_audioSource != null ? m_audioSource.volume : 0f; }
            set { if (m_audioSource != null) m_audioSource.volume = value; }
        }

        public string CurtBGMID { get; private set; }

        // ==================== 逻辑 ====================

        internal void Init()
        {
            CurtBGMID = INVALID_BGM_ID;
            m_BGMClipDic = new Dictionary<string, UMACInfo>();
            m_audioSource = gameObject.AddComponent<AudioSource>();
            m_audioSource.playOnAwake = false;
            m_audioSource.loop = true;
        }

        // ==================== 公开接口 ====================

        public void AddClip(string id, string path, bool isPreLoad = false)
        {
            AddClip(new UMACInfo(id, path, isPreLoad));
        }

        public void AddClip(UMACInfo aci)
        {
            m_BGMClipDic.Add(aci.ID, aci);
            if (aci.IsPreLoad)
            {
                LoadClipInACI(aci);
            }
        }

        public void Play(string id, bool loop = true)
        {
            if (!m_BGMClipDic.TryGetValue(id, out UMACInfo aci))
            {
                Debug.LogWarning($"[UMAudioBGM] 未注册的 BGM ID: {id}");
                return;
            }

            CurtBGMID = id;

            if (aci.Clip == null)
            {
                LoadClipInACI(aci);
            }

            m_audioSource.clip = aci.Clip;
            m_audioSource.loop = loop;
            m_audioSource.Play();
        }

        public void Stop()
        {
            if (m_audioSource == null) return;
            m_audioSource.Stop();
        }
    }
}
