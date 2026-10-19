using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.PerSecond)]
    [ActionDescription("Multiply a Vector3 by Time.deltaTime to get a Vector3 per second.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Time-deltaTime.html")]
    public class Vector3PerSecond : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        
        [Tooltip("The Vector3 to multiply")]
		[SerializeField, WriteOnly]
        private Vector3Ref _vector3;

        public override bool CanExecute() => CheckParameters(_vector3);

        public override void Execute() => _vector3.Value *= Time.deltaTime;
        
    public override string GetSummary() => "Multiply {_vector3} per second";
    }
}
