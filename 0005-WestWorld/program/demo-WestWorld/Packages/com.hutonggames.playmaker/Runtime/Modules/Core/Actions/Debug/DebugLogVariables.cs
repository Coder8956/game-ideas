using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Debug)]
    [ActionDescription("Print variable values to the Unity Console.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Debug.Log.html")]
    public class DebugLogVariables : BaseDebugLogAction
    {
        [Tooltip("Message Type.")]
        [SerializeField]
        private Type _logType;
        
        [SerializeReference]
        [BaseType(typeof(object))]
        [Tooltip("The Variables to log.")]
        private AnyVariableRef[] _variables;

        public override void Execute()
        {
            var sb = StringBuilderPool.Get();
            
            foreach (var variableRef in _variables)
            {
                sb.Append(variableRef.Variable?.Name);
                sb.Append(": ");
                sb.Append(DebugUtility.GetDebugString(variableRef.Variable));
                sb.AppendLine();
            }

            var output = sb.ToString();
            Log(_logType, output);
            FsmLog(_logType, output);
            
            StringBuilderPool.Release(sb);
        }
        
        public override string GetSummary() => GetLogSummary(_logType, $"{_variables?.Length ?? 0} Variables");
    }
}