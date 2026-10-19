using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.PerSecond)]
    [ActionDescription("Multiply a float by Time.deltaTime to get a float per second.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Time-deltaTime.html")]
    public class GetFloatPerSecond : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        
        [Tooltip("The float to multiply")]
		[SerializeField]
        private FloatVar _float;

        [WriteOnly]
        [Tooltip("Store the result of the multiplication.")]
        [SerializeField] 
        private FloatRef _result;

        public override bool CanExecute() => CheckParameters(_float, _result);

        public override void Execute() => _result.Value = _float.Value * Time.deltaTime;

        public override string GetSummary() => "Get {_float} per second -> {_result}";
    }
}
