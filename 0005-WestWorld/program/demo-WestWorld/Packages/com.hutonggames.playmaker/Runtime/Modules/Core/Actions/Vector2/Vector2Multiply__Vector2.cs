
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ConvertibleGroup("Vector2Operator")]
	[ActionDescription("Multiplies a Vector2 by another Vector2 value.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2-operator_multiply.html")]
	public sealed class Vector2Multiply__Vector2 : BaseAction
	{
		
		[Tooltip("A.")]
		[SerializeField, WriteOnly]
		private Vector2Ref _a;
		
		[Tooltip("B.")]
		[SerializeField]
		private Vector2Var _b;
		
		public override bool CanExecute() => CheckParameters(_a, _b);

		public override void Execute() => _a.Value *= _b.Value;

		public override string GetSummary() => "Multiply {_a} by {_b}";
	}
}
