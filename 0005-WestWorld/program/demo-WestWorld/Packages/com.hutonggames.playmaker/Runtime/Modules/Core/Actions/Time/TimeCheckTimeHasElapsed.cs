using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.TimeUnity)]
    [ActionDescription("Checks if a certain amount of time has passed since a recorded time.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Time-time.html")]
    public class TimeCheckTimeHasElapsed : BaseTrueFalseAction
    {

        [Tooltip("Time previously recorded using Get Time.")]
        [SerializeField]
        private FloatRef _recordedTime;

        [Tooltip("Time to check against the recorded time.")]
        [SerializeField, DefaultValue(1f)]
        private FloatVar _hasElapsed;

        protected override bool Test() => Time.time - _recordedTime.Value >= _hasElapsed.Value;

        protected override string TrueSummary => "{_hasElapsed:seconds} since {_recordedTime}";
        protected override string FalseSummary => "less than {_hasElapsed:seconds} since {_recordedTime}";
    }
}