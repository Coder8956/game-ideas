using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UMiniFramework.Runtime
{
    public class UMAudioSFX : UMAudioFuncBase
    {
        // ==================== 私有字段（运行时状态） ====================

        private const int DefaultASCount = 3;

        private Dictionary<string, UMACInfo> m_effectClipDic;
        private Queue<AudioSource> m_asQue;
        private List<AudioSource> m_asPlayingList;
        private int m_keepASCount = DefaultASCount;
        private int m_createdASCount = 0;
        private bool m_mute = false;
        private float m_volume = 1;

        // ==================== 属性 ====================

        public int KeepAsCount
        {
            get { return m_keepASCount; }
            set
            {
                value = Mathf.Clamp(value, DefaultASCount, int.MaxValue);
                m_keepASCount = value;
            }
        }

        /// <summary>
        /// 静音属性
        /// </summary>
        public bool Mute
        {
            get { return m_mute; }
            set
            {
                m_mute = value;
                if (m_asPlayingList == null) return;
                for (var i = 0; i < m_asPlayingList.Count; i++)
                {
                    m_asPlayingList[i].mute = m_mute;
                }
            }
        }

        /// <summary>
        /// 音量属性
        /// </summary>
        public float Volume
        {
            get { return m_volume; }
            set
            {
                m_volume = value;
                if (m_asPlayingList == null) return;
                for (var i = 0; i < m_asPlayingList.Count; i++)
                {
                    m_asPlayingList[i].volume = m_volume;
                }
            }
        }

        // ==================== 逻辑 ====================

        /// <summary>
        /// 初始化 AudioSource 队列
        /// </summary>
        private void InitASQue()
        {
            m_asQue = new Queue<AudioSource>();
            m_asPlayingList = new List<AudioSource>();

            for (int i = 0; i < KeepAsCount; i++)
            {
                BackAS(CreateAS());
            }
        }

        /// <summary>
        /// 从 AudioSource 队列中获取一个对象
        /// </summary>
        private AudioSource GetAS()
        {
            AudioSource getAS = m_asQue.Count > 0 ? m_asQue.Dequeue() : CreateAS();
            getAS.enabled = true;
            return getAS;
        }

        /// <summary>
        /// 将 AudioSource 对象放回队列
        /// </summary>
        private void BackAS(AudioSource backAS)
        {
            backAS.clip = null;
            backAS.enabled = false;

            if (m_asQue.Count >= KeepAsCount)
            {
                Destroy(backAS);
            }
            else
            {
                m_asQue.Enqueue(backAS);
            }
        }

        /// <summary>
        /// 创建一个 AudioSource 对象
        /// </summary>
        private AudioSource CreateAS()
        {
            AudioSource newAS = gameObject.AddComponent<AudioSource>();
            newAS.playOnAwake = false;
            newAS.enabled = false;
            m_createdASCount++;
            return newAS;
        }

        /// <summary>
        /// 等待音频播放完成
        /// </summary>
        private IEnumerator WaitEffectPlayOver(AudioSource audioSource)
        {
            yield return new WaitWhile(() => audioSource.isPlaying);
            m_asPlayingList.Remove(audioSource);
            BackAS(audioSource);
        }

        internal void Init()
        {
            m_effectClipDic = new Dictionary<string, UMACInfo>();
            InitASQue();
        }

        // ==================== 公开接口 ====================

        /// <summary>
        /// 播放音效
        /// </summary>
        public void Play(string id)
        {
            if (!m_effectClipDic.TryGetValue(id, out UMACInfo aci))
            {
                Debug.LogWarning($"[UMAudioEffect] 未注册的音效 ID: {id}");
                return;
            }

            if (aci.Clip == null)
            {
                LoadClipInACI(aci);
            }

            AudioSource curtAS = GetAS();
            m_asPlayingList.Add(curtAS);

            curtAS.clip = aci.Clip;
            curtAS.volume = m_volume;
            curtAS.mute = m_mute;
            curtAS.Play();

            StartCoroutine(WaitEffectPlayOver(curtAS));
        }

        public void AddClip(string id, string path, bool isPreLoad = false)
        {
            AddClip(new UMACInfo(id, path, isPreLoad));
        }

        public void AddClip(UMACInfo aci)
        {
            m_effectClipDic.Add(aci.ID, aci);
            if (aci.IsPreLoad)
            {
                LoadClipInACI(aci);
            }
        }

        /// <summary>
        /// 输出 AudioSource 相关信息
        /// </summary>
        public void PrintASInfo()
        {
            Debug.Log(
                $"=== Print AS Info ===\n" +
                $"Created AS Count: {m_createdASCount}\n" +
                $"AS Queue Count: {m_asQue.Count}\n" +
                $"AS Playing List Count: {m_asPlayingList.Count}\n" +
                $"=====================");
        }
    }
}
