
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ConvertibleGroup("Vector2Operator")]
	[ActionDescription("Subtracts one vector from another.\n\nSubtracts each component of b from a.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2-operator_subtract.html")]
	public sealed class Vector2Subtract : BaseAction
	{
		
		[Tooltip("The Vector2 to subtract from.")]
		[SerializeField, WriteOnly, FormerlySerializedAs("_a")]
		private Vector2Ref _vector2;
		
		[Tooltip("The Vector2 to subtract." + Strings.PerSecondNote)]
		[SerializeField, FormerlySerializedAs("_b")]
		private Vector2Var _subtract;
		
		public override bool CanUsePerSecond => true;
		
		public override bool CanExecute() => CheckParameters(_vector2, _subtract);

		public override void Execute() => _vector2.Value -= _subtract.Value * PerSecond;

		public override string GetSummary() => "Subtracts {_subtract} from {_vector2} {PerSecond}";
	}
}
