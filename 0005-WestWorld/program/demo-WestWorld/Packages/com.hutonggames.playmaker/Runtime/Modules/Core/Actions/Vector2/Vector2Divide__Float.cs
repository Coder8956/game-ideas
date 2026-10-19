
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ConvertibleGroup("Vector2Operator")]
	[ActionDescription("Divides a Vector2 by a float value.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2-operator_divide.html")]
	public sealed class Vector2Divide__Float : BaseAction
	{
		
		[Tooltip("A.")]
		[SerializeField, WriteOnly]
		private Vector2Ref _a;
		
		[Tooltip("B.")]
		[SerializeField]
		private FloatVar _b;
		
		public override bool CanExecute() => CheckParameters(_a, _b);

		public override void Execute() => _a.Value /= _b.Value;

		public override string GetSummary() => "Divide {_a} by {_b}";
	}
}
