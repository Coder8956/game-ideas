using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.PerSecond)]
    [ActionDescription("Multiply a Vector2 by Time.deltaTime to get a Vector2 per second.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Time-deltaTime.html")]
    public class GetVector2PerSecond : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        
        [Tooltip("The Vector2 to multiply")]
		[SerializeField]
        private Vector2Ref _vector2;

        [WriteOnly]
        [Tooltip("Store the result of the multiplication.")]
        [SerializeField] 
        private Vector2Ref _result;

        public override bool CanExecute() => CheckParameters(_vector2, _result);

        public override void Execute() => _result.Value = _vector2.Value * Time.deltaTime;
        
    public override string GetSummary() => "Get {_vector2} per second -> {_result}";
    }
}
