
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Negates a vector.\n\nEach component in the result is negated.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2-operator_subtract.html")]
	public sealed class Vector2Negate : BaseAction
	{
		
		[Tooltip("The Vector2.")]
		[SerializeField]
		private Vector2Ref _vector2;
		
		public override bool CanExecute() => CheckParameters(_vector2);

		public override void Execute() => _vector2.Value = -_vector2.Value;

		public override string GetSummary() => "Negate {_vector2} ";
	}
}
