using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Debug)]
    [ActionDescription("Print variable value to the Unity Console.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Debug.Log.html")]
    public class DebugLogVariable : BaseDebugLogAction
    {
        [Tooltip("Message Type.")]
        [SerializeField]
        private Type _logType;
        
        [SerializeReference]
        [BaseType(typeof(object))]
        [Tooltip("The Variable to log.")]
        private AnyVariableRef _variable;

        [Tooltip("Only log when the value changes. Useful if debugging EveryFrame.")]
        [SerializeField]
        private bool _onlyWhenValueChanges;

        [Tooltip("Add a prefix to the log message.")]
        [SerializeField, DefaultValue(true)]
        private bool _prefixVariableName;

        private string _previousOutput;

        public override bool CanExecute() => !_variable.IsNone;

        public override void Execute()
        {
            var output = DebugUtility.GetDebugString(_variable.Value);
            if (_onlyWhenValueChanges && output == _previousOutput) return;
            _previousOutput = output;
            
            if (_prefixVariableName)
            {
                output = $"{_variable.Variable?.Name}: {output}";
            }
            
            Log(_logType, output);
            FsmLog(_logType, output);
        }

        public override string GetSummary() => GetLogSummary(_logType, "{_variable}");
    }
}