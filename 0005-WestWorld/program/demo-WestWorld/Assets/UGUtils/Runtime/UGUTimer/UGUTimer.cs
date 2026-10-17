using System;
using UnityEngine;

namespace UGU.Runtime
{
    public class UGUTimer : MonoBehaviour
    {
        private float m_duration;
        private float m_currentTime;
        private bool m_isRunning = false;
        private bool m_isLoop;
        private bool m_isDestroyOnComplete;
        private Action m_onComplete;
        private Action<float> m_onUpdate;

        public bool IsRunning => m_isRunning;

        /// <summary>
        /// 设置计时器
        /// </summary>
        /// <param name="duration">计时时长</param>
        /// <param name="isLoop">循环</param>
        /// <param name="isDestroyOnComplete">计时完成后销毁计时器</param>
        public void Set(float duration, bool isLoop = false, bool isDestroyOnComplete = false)
        {
            m_duration = duration;
            m_isLoop = isLoop;
            m_isDestroyOnComplete = isDestroyOnComplete;
            m_currentTime = 0f;
        }

        /// <summary>
        /// 运行计时器
        /// </summary>
        public void RunTimer() => m_isRunning = true;

        /// <summary>
        /// 暂停计时器
        /// </summary>
        public void PauseTimer() => m_isRunning = false;

        /// <summary>
        /// 重置计时器
        /// </summary>
        public void ResetTimer()
        {
            m_isRunning = false;
            m_currentTime = 0f;
        }

        /// <summary>
        /// 销毁计时器
        /// </summary>
        public void DestroyTimer()
        {
            m_onUpdate = null;
            m_onComplete = null;
            Destroy(gameObject);
        }

        public void UpdateAddListener(Action<float> callback)
        {
            m_onUpdate += callback;
        }

        public void UpdateRemoveListener(Action<float> callback)
        {
            m_onUpdate -= callback;
        }

        public void CompleteAddListener(Action callback)
        {
            m_onComplete += callback;
        }

        public void CompleteRemoveListener(Action callback)
        {
            m_onComplete -= callback;
        }

        private void Update()
        {
            if (!m_isRunning) return;

            m_currentTime += Time.deltaTime;

            m_onUpdate?.Invoke(m_currentTime / m_duration);

            if (m_currentTime >= m_duration)
            {
                m_onComplete?.Invoke();

                if (m_isLoop)
                {
                    m_currentTime = 0f;
                }
                else
                {
                    m_isRunning = false;
                    if (m_isDestroyOnComplete)
                    {
                        DestroyTimer();
                    }
                }
            }
        }

        /// <summary>
        /// 创建计时器
        /// </summary>
        /// <param name="user">使用者</param>
        /// <returns></returns>
        public static UGUTimer Create(GameObject user)
        {
            GameObject go = new GameObject($"[UGUTimer]{user.name}");
            UGUTimer newTimer = go.AddComponent<UGUTimer>();
            newTimer.transform.SetParent(user.transform);
            newTimer.transform.localPosition = Vector3.zero;
            return newTimer;
        }
    }
}