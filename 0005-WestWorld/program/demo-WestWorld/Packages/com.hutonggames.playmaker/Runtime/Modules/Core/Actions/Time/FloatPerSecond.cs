using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.PerSecond)]
    [ActionDescription("Multiply a float by Time.deltaTime to get a float per second.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Time-deltaTime.html")]
    public class FloatPerSecond : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        
        [Tooltip("The float to multiply")]
		[SerializeField, WriteOnly]
        private FloatRef _float;

        public override bool CanExecute() => CheckParameters(_float);

        public override void Execute() => _float.Value *= Time.deltaTime;

        public override string GetSummary() => "Multiply {_float} per second";
    }
}
