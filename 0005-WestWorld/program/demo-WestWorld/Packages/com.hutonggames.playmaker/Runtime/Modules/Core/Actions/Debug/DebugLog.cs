using UnityEngine;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Debug)]
    [ActionDescription("Print a message to the Unity Console and FSM Log.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Debug.Log.html")]
    public class DebugLog : BaseDebugLogAction
    {
        [Tooltip("Message Type.")] 
        public Type LogType;
        
        [Delayed, HideLabel, OptionalField, Multiline(5), HasVariableNames]
        [DefaultValue("")]
        [Tooltip("Text to log to the Unity Console." +
                 "\n<b>Tip</b>: Use {VariableName} to insert variable values.")] 
        public StringVar Text;

        public override void Execute()
        {
            var output = GetOutput();

            Log(LogType, output);
            FsmLog(LogType, output);
        }

        // We want to use GetDebugString for variables instead of ToString,
        // which is often not very useful for debugging (e.g., RaycastHit)
        private string GetOutput() => Text.IsVariable 
            ? DebugUtility.GetDebugString(Text.Variable) 
            : DebugLogTextFormatter.Format(Text.Value, Fsm?.Variables);

        public override string GetSummary() => GetLogSummary(LogType, "{Text}");
    }
}
