using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UMiniFramework.Runtime
{
    public class UMOScene : UMMonoSingletonBase<UMOScene>
    {
        // ==================== 属性 ====================

        /// <summary>
        /// 场景开始切换
        /// </summary>
        public static event Action<string> OnSceneLoadBegin;

        /// <summary>
        /// 场景切换完成
        /// </summary>
        public static event Action<string> OnSceneLoadCompleted;

        /// <summary>
        /// 当前场景名称
        /// </summary>
        public static string ActiveSceneName =>
            SceneManager.GetActiveScene().name;

        /// <summary>
        /// 当前场景索引
        /// </summary>
        public static int ActiveSceneIndex =>
            SceneManager.GetActiveScene().buildIndex;

        // ==================== 生命周期 ====================

        protected override void OnInit()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            OnSceneLoadCompleted?.Invoke(scene.name);
        }

        // ==================== 公开接口 ====================

        /// <summary>
        /// 同步切换场景
        /// </summary>
        public static void Load(string sceneName)
        {
            OnSceneLoadBegin?.Invoke(sceneName);
            SceneManager.LoadScene(sceneName);
        }

        /// <summary>
        /// 同步切换场景
        /// </summary>
        public static void Load(int buildIndex)
        {
            OnSceneLoadBegin?.Invoke(buildIndex.ToString());
            SceneManager.LoadScene(buildIndex);
        }

        /// <summary>
        /// 异步切换场景
        /// </summary>
        public static AsyncOperation LoadAsync(string sceneName)
        {
            OnSceneLoadBegin?.Invoke(sceneName);
            return SceneManager.LoadSceneAsync(sceneName);
        }

        /// <summary>
        /// 异步切换场景
        /// </summary>
        public static AsyncOperation LoadAsync(int buildIndex)
        {
            OnSceneLoadBegin?.Invoke(buildIndex.ToString());
            return SceneManager.LoadSceneAsync(buildIndex);
        }

        /// <summary>
        /// 加载附加场景(Additive)
        /// </summary>
        public static AsyncOperation LoadAdditive(string sceneName)
        {
            OnSceneLoadBegin?.Invoke(sceneName);
            return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }

        /// <summary>
        /// 卸载场景
        /// </summary>
        public static AsyncOperation Unload(string sceneName)
        {
            return SceneManager.UnloadSceneAsync(sceneName);
        }

        /// <summary>
        /// 设置活动场景
        /// </summary>
        public static bool SetActive(string sceneName)
        {
            Scene scene = SceneManager.GetSceneByName(sceneName);

            if (!scene.IsValid())
                return false;

            return SceneManager.SetActiveScene(scene);
        }

        /// <summary>
        /// 重新加载当前场景
        /// </summary>
        public static void Reload()
        {
            Load(ActiveSceneIndex);
        }
    }
}