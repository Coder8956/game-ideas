using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    public abstract class BaseDebugLogAction : BaseAction
    {
        public enum Type
        {
            Info,
            Warning,
            Error
        }

        protected static void Log(Type logType, string message)
        {
            switch (logType)
            {
                case Type.Info:
                    Debug.Log(message);
                    break;
                case Type.Warning:
                    Debug.LogWarning(message);
                    break;
                case Type.Error:
                    Debug.LogError(message);
                    break;
            }
        }
        
        protected static string GetLogSummary(Type logType, string summary) => $"{GetLogPrefix(logType)} {summary}";

        private static string GetLogPrefix(Type logType) =>
            logType switch
            {
                Type.Info => "Log",
                Type.Warning => "Log Warning",
                Type.Error => "Log Error",
                _ => "Unknown"
            };

        [Conditional("UNITY_EDITOR")]
        protected void FsmLog(Type logType, string message)
        {
            #if UNITY_EDITOR
            switch (logType)
            {
                case Type.Info:
                    LogInfo(message);
                    break;
                case Type.Warning:
                    LogWarning(message);
                    break;
                case Type.Error:
                    LogError(message);
                    break;
            }
            #endif
        }
    }
}
