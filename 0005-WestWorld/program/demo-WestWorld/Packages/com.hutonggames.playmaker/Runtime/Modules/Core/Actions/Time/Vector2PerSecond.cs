using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.PerSecond)]
    [ActionDescription("Multiply a Vector2 by Time.deltaTime to get a Vector2 per second.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Time-deltaTime.html")]
    public class Vector2PerSecond : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        
        [Tooltip("The Vector2 to multiply")]
		[SerializeField, WriteOnly]
        private Vector2Ref _vector2;

        public override bool CanExecute() => CheckParameters(_vector2);

        public override void Execute() => _vector2.Value *= Time.deltaTime;
        
    public override string GetSummary() => "Multiply {_vector2} per second";
    }
}
