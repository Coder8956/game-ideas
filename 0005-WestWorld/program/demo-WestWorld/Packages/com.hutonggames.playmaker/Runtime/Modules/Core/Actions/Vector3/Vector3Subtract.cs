
using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ConvertibleGroup("Vector3Operator")]
	[ActionDescription("Subtracts one vector from another.\n\nSubtracts each component of b from a.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-operator_subtract.html")]
	public sealed class Vector3Subtract : BaseAction
	{
		
		[Tooltip("The Vector3 to subtract from.")]
		[SerializeField, WriteOnly, FormerlySerializedAs("_a")]
		private Vector3Ref _vector3;
		
		[ConvertibleName("operand")]
		[Tooltip("The Vector3 to subtract." + Strings.PerSecondNote)]
		[SerializeField, FormerlySerializedAs("_b")]
		private Vector3Var _subtract;
		
		public override bool CanUsePerSecond => true;
		
		public override bool CanExecute() => CheckParameters(_vector3, _subtract);

		public override void Execute() => _vector3.Value -= _subtract.Value * PerSecond;

		public override string GetSummary() => "Subtracts {_subtract} from {_vector3} {PerSecond}";
	}
}
