
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ConvertibleGroup("Vector4Operator")]
	[ActionDescription("Divides a Vector4 by a float value.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4-operator_divide.html")]
	public sealed class Vector4Divide : BaseAction
	{
		
		[Tooltip("A.")]
		[SerializeField, WriteOnly]
		private Vector4Ref _a;
		
		[Tooltip("B.")]
		[SerializeField]
		private FloatVar _b;
		
		public override bool CanExecute() => CheckParameters(_a, _b);

		public override void Execute() => _a.Value /= _b.Value;

		public override string GetSummary() => "Divide {_a} by {_b}";
	}
}
