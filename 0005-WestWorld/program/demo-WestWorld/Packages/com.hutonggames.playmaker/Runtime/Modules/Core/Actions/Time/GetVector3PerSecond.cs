using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.PerSecond)]
    [ActionDescription("Multiply a Vector3 by Time.deltaTime to get a Vector3 per second.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Time-deltaTime.html")]
    public class GetVector3PerSecond : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        
        [Tooltip("The Vector3 to multiply")]
		[SerializeField]
        private Vector3Ref _vector3;

        [WriteOnly]
        [Tooltip("Store the result of the multiplication.")]
        [SerializeField] 
        private Vector3Ref _result;

        public override bool CanExecute() => CheckParameters(_vector3, _result);

        public override void Execute() => _result.Value = _vector3.Value * Time.deltaTime;
        
    public override string GetSummary() => "Get {_vector3} per second -> {_result}";
    }
}
