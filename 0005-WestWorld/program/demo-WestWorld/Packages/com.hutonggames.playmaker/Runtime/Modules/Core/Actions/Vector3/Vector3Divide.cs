
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ConvertibleGroup("Vector3Operator")]
	[ActionDescription("Divides a Vector3 by a float value.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-operator_divide.html")]
	public sealed class Vector3Divide : BaseAction
	{
		
		[Tooltip("The Vector3 to divide.")]
		[SerializeField, WriteOnly, FormerlySerializedAs("_a")]
		private Vector3Ref _vector3;
		
		[ConvertibleName("operand")]
		[Tooltip("Divide by this float.")]
		[SerializeField, FormerlySerializedAs("_b")]
		private FloatVar _divide;
		
		public override bool CanExecute() => CheckParameters(_vector3, _divide);

		public override void Execute() => _vector3.Value /= _divide.Value;

		public override string GetSummary() => "Divide {_vector3} by {_divide}";
	}
}
